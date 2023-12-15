using Capstone.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RIController : ControllerBase
    {
        private readonly IRecipeDao recipeDao;

        public RIController(IRecipeDao recipeDao)
        {
            this.recipeDao = recipeDao;
        }
        [HttpGet("{recipeId}")]
        public ActionResult<IList<RecipeIngredient>> GetIngredientsInRecipe(int recipeId)
        {
            IList<RecipeIngredient> recipeIngredients = recipeDao.GetRI(recipeId);
            if(recipeIngredients.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(recipeIngredients);
            }
        }

        [HttpPost()]
        public ActionResult<RecipeIngredient> LinkRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            recipeDao.LinkIngredientAndRecipe(recipeIngredient.RecipeId, recipeIngredient.IngredientId);
            return Created($"/recipes/hedgehog", recipeIngredient);
        }
    }
}
