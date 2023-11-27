using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            SeedData(scope.ServiceProvider.GetService<DataContext>());
        }

        public static void SeedData(DataContext context)
        {
            context.Database.Migrate();

            if (context.Recipe.Any())
            {
                Console.WriteLine("Already have Data. Don't need to Seed more.");
                return;
            }

            var recipes = new List<Recipe>()
            {
                new() {

                    Title = "Turkey Sandwich",
                    Description = "A basic, yet delicious turkey sandwich",
                    Servings = 1,
                    Details = new List<RecipeDetail>()
                    {
                        new() {

                            Ingredient = "Slice of Bread",
                            Quantity = 2,
                            Measure = "Each"
                        },
                        new() {

                            Ingredient = "Slice of Cheese",
                            Quantity = 1,
                            Measure = "Each"
                        },
                        new() {

                            Ingredient = "Slice of Turkey Breast",
                            Quantity = 3,
                            Measure = "Each"
                        },
                        new() {

                            Ingredient = "Mustard",
                            Quantity = 1,
                            Measure = "Tbsp"
                        }
                    },
                    Steps = new List<RecipeSteps>()
                    {
                        new() {

                            Description = "Remove 2 slices of bread."
                        },
                        new() {

                            Description = "Spread Mustard on 1 side of 1 piece of bread"
                        },
                        new() {

                            Description = "Please slice of cheese on top of mustard."
                        },
                        new() {

                            Description = "Place meat on top of cheese"
                        },
                        new() {

                            Description = "place second slice of bread on top of meat and enjoy!!"
                        },
                    }
                }
            };

            context.AddRange(recipes);
            context.SaveChanges();

        }
    }
}