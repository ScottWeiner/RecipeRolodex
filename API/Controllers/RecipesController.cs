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

    [HttpPut("{id}")]
    public async Task<ActionResult<RecipeFullDto>> UpdateRecipe(int id, RecipeFullDto recipeDto)
    {
        var recipeToUpdate = await _context.Recipe.FirstOrDefaultAsync(x => x.Id == id);

        if (recipeToUpdate == null || recipeToUpdate.Id != id)
        {
            return NotFound("Recipe not found!");
        }

        recipeToUpdate.Title = recipeDto.Title;
        recipeToUpdate.Servings = recipeDto.Servings;


        _context.RecipeDetails.RemoveRange(_context.RecipeDetails.Where(x => x.RecipeId == id));
        await _context.SaveChangesAsync();

        foreach (var detail in recipeDto.Details)
        {
            var newDetail = _mapper.Map<RecipeDetail>(detail);
            newDetail.RecipeId = id;
            _context.RecipeDetails.Add(newDetail);
        }





        _context.RecipeSteps.RemoveRange(_context.RecipeSteps.Where(x => x.RecipeId == id));
        await _context.SaveChangesAsync();

        foreach (var step in recipeDto.Steps)
        {
            var newStep = _mapper.Map<RecipeSteps>(step);
            newStep.RecipeId = id;
            _context.RecipeSteps.AddRange(newStep);
        }

        var successful = await _context.SaveChangesAsync() > 0;

        if (successful)
        {
            return Ok();
        }

        return BadRequest("There was an error while trying to save updates");



    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRecipie(int id)
    {
        var recipeToDelete = await _context.Recipe.Include(x => x.Details).Include(x => x.Steps).FirstOrDefaultAsync(x => x.Id == id);
        if (recipeToDelete == null)
        {
            return NotFound();
        }

        _context.Recipe.Remove(recipeToDelete);

        var successful = await _context.SaveChangesAsync() > 0;

        if (successful)
        {
            return Ok();
        }

        return BadRequest("There was an issue saving your change");


    }
}
