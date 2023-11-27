using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Servings { get; set; }
        public ICollection<RecipeDetail> Details { get; set; }
        public ICollection<RecipeSteps> Steps { get; set; }
    }
}