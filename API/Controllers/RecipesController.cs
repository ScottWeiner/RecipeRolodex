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
    public async Task<ActionResult<List<RecipeHeaderDto>>> GetAllRecipes([FromQuery] string searchString)
    {

        List<Recipe> recipes;
        Console.WriteLine(string.IsNullOrEmpty(searchString));

        if (string.IsNullOrEmpty(searchString))
        {
            recipes = await _context.Recipe.OrderBy(x => x.Id).ToListAsync();

        }
        else
        {
            var lowerCaseSearchString = searchString.Trim().ToLower();
            Console.WriteLine(lowerCaseSearchString);
            recipes = await _context.Recipe.Where(x => x.Title.Contains(lowerCaseSearchString)).ToListAsync(); ;


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
        var recipeToUpdate = await _context.Recipe.Include(d => d.Details).Include(s => s.Steps).FirstOrDefaultAsync(x => x.Id == id);

        if (recipeToUpdate == null || recipeToUpdate.Id != id)
        {
            return NotFound("Recipe not found!");
        }

        recipeToUpdate.Title = recipeDto.Title;
        recipeToUpdate.Servings = recipeDto.Servings;


        //TODO: Refactor the logic to update Details & Steps into a single function since they do basically the same thing....

        // Go through each Detail provided in the DTO & update or add it.
        foreach (var detail in recipeDto.Details)
        {
            var existingDetail = recipeToUpdate.Details.FirstOrDefault(x => x.Id == detail.Id);
            if (existingDetail != null)
            {
                //Update the existing detail
                _mapper.Map(detail, existingDetail);
            }
            else
            {
                //Add new detail
                var newDetail = _mapper.Map<RecipeDetail>(detail);
                recipeToUpdate.Details.Add(newDetail);
            }

        }

        //Go through Details in the Data that are not in the DTO, and remove (absense in the DTO implies deletion by user)
        foreach (var existingDetail in recipeToUpdate.Details.ToList())
        {
            if (!recipeDto.Details.Any(d => d.Id == existingDetail.Id))
            {
                _context.RecipeDetails.Remove(existingDetail);
            }
        }


        //Do the same for Steps
        foreach (var step in recipeDto.Steps)
        {
            var existingStep = recipeToUpdate.Steps.FirstOrDefault(x => x.Id == step.Id);
            if (existingStep != null)
            {
                //Update the existing detail
                _mapper.Map(step, existingStep);
            }
            else
            {
                //Add new detail
                var newStep = _mapper.Map<RecipeSteps>(step);
                recipeToUpdate.Steps.Add(newStep);
            }

        }

        //Go through Details in the Data that are not in the DTO, and remove (absense in the DTO implies deletion by user)
        foreach (var existingStep in recipeToUpdate.Steps.ToList())
        {
            if (!recipeDto.Steps.Any(d => d.Id == existingStep.Id))
            {
                _context.RecipeSteps.Remove(existingStep);
            }
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
