using System.Reflection.Metadata.Ecma335;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public RecipesController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<RecipeHeaderDto>>> GetAllRecipes()
    {
        var recipes = await _context.Recipe.OrderBy(x => x.Id).ToListAsync();

        if (recipes == null)
        {
            return BadRequest("No recipes found!");
        }


        return _mapper.Map<List<RecipeHeaderDto>>(recipes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeFullDto>> GetRecipeById(int id)
    {
        var recipe = await _context.Recipe.Include(x => x.Details).Include(x => x.Steps).FirstOrDefaultAsync(x => x.Id == id);

        if (recipe == null)
        {
            return BadRequest("That Recipe doesn't exist!");
        }

        return _mapper.Map<RecipeFullDto>(recipe);
    }

    [HttpPost]
    public async Task<ActionResult<RecipeFullDto>> CreateRecipe(CreateRecipeFullDto createRecipeDto)
    {
        // 1) Map to a Full Recipe Entity object
        var newRecipe = _mapper.Map<Recipe>(createRecipeDto);

        // 2) Add to the context
        _context.Recipe.Add(newRecipe);

        // 3) Attempt to save & if successful send back a Full Recipe DTO of the info
        var result = await _context.SaveChangesAsync() > 0;

        // 4) If unsuccessful, send back an error
        if (!result)
        {
            return BadRequest("Could not save changes to the DB");
        }

        return CreatedAtAction(nameof(GetRecipeById), new { newRecipe.Id }, _mapper.Map<RecipeFullDto>(newRecipe));
    }
}
