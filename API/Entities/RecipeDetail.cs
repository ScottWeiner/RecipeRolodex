using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class RecipeDetail
    {
        public int Id { get; set; }

        public string Ingredient { get; set; }
        public float Quantity { get; set; }

        public string Measure { get; set; }
        //Nav Properties

        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }

    }
}