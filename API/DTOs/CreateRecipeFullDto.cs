using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CreateRecipeFullDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Servings { get; set; }

        // The Details will need to be a ICollectin of Recipie Detail DTOs
        [Required]
        public List<RecipeDetailDto> Details { get; set; }
        //For the sake of the exercise, we will not require there to be steps with a recipe
        public List<RecipeStepsDto> Steps { get; set; }
    }
}