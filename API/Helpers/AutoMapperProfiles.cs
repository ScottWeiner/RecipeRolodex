using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Recipe, RecipeHeaderDto>();
            CreateMap<RecipeDetail, RecipeDetailDto>();
            CreateMap<RecipeSteps, RecipeStepsDto>();
            CreateMap<RecipeDetail, RecipeFullDto>();
            CreateMap<RecipeSteps, RecipeFullDto>();
            CreateMap<Recipe, RecipeFullDto>();
            CreateMap<CreateRecipeFullDto, Recipe>();
            CreateMap<RecipeDetailDto, RecipeDetail>();
            CreateMap<RecipeStepsDto, RecipeSteps>();
        }
    }
}