using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RecipeDetailDto
    {
        public int Id { get; set; }

        public string Ingredient { get; set; }
        public float Quantity { get; set; }

        public string Measure { get; set; }
    }
}