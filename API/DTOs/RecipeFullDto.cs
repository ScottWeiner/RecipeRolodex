using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs
{
    public class RecipeFullDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Servings { get; set; }

        // The Details will need to be a ICollectin of Recipie Detail DTOs
        public List<RecipeDetailDto> Details { get; set; }
        public List<RecipeStepsDto> Steps { get; set; }
    }
}