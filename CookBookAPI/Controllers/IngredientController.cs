using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookAPI.Models;
using CookBookAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBookAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientRepository _repository;

        public IngredientController(IngredientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Ingredient[] GetAll()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public Ingredient? GetById([FromRoute] int id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public Ingredient AddIngredient([FromBody] Ingredient ingredient)
        {
            return _repository.Create(ingredient).Entity;
        }
    }
}
