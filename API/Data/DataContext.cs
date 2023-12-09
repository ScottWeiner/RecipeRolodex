using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;


namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeDetail> RecipeDetails { get; set; }
        public DbSet<RecipeSteps> RecipeSteps { get; set; }


    }
}