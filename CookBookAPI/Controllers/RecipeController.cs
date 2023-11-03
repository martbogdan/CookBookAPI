using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookAPI.Models;
using CookBookAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBookAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;
        private readonly IConfiguration _configuration;

        public RecipeController(RecipeService recipeService, IConfiguration configuration)
        {
            _recipeService = recipeService;
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public Recipe GetRecipe([FromRoute] int id)
        {
            return _recipeService.GetRecipeBy(id);
        }
        
        [HttpGet]
        public Recipe[] GetRecipes()
        {
            return _recipeService.GetAll();
        }

        [HttpPost]
        public Recipe Create([FromBody] Recipe recipe)
        {
            return _recipeService.AddRecipe(recipe);
        }

        [HttpGet("db")]
        public string DbVersion()
        {
            PostgresDbConnection connection = new PostgresDbConnection(_configuration);
            return connection.GetDbVersion();
        }
        
    }
}
