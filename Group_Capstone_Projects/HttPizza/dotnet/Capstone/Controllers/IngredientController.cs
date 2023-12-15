using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientDao ingredientDao;

        public IngredientController(IIngredientDao ingredientDao)
        {
            this.ingredientDao = ingredientDao;
        }

        [HttpGet()]
        public IList<Ingredient> GetAllIngredients()
        {
            return ingredientDao.GetAllIngredients();
        }

        [HttpGet("{ingredientId}")]
        public ActionResult<Ingredient> GetIngredientByIngredientId(int ingredientId)
        {
            Ingredient ingredient = ingredientDao.GetIngredientByIngredientId(ingredientId);

            if (ingredient != null)
            {
                return ingredient;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("recipe/{recipeId}")]
        public ActionResult<IList<Ingredient>> GetIngredientsByRecipeId(int recipeId)
        {
            IList<Ingredient> ingredients = ingredientDao.GetIngredientsByRecipeId(recipeId);
            if (ingredients.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(ingredients);
            }
        }

        [HttpPut("{ingredientId}")]
        public ActionResult<Ingredient> UpdateIngredientAvailability(int ingredientId, Ingredient ingredient)
        {
            Ingredient updatedIngredient = ingredientDao.UpdateIngredientAvailability(ingredientId, ingredient);
            if (updatedIngredient == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(updatedIngredient);
            }
        }

        [HttpPost()]
        public ActionResult<Ingredient> CreateIngredient(Ingredient ingredient)
        {
            Ingredient newIngredient = ingredientDao.CreateIngredient(ingredient);
            return Created($"/ingredients/{newIngredient.IngredientId}", newIngredient);
        }
    }
}
