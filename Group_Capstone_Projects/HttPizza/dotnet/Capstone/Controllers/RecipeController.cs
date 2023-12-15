using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeDao recipeDao;

        public RecipeController(IRecipeDao recipeDao)
        {
            this.recipeDao = recipeDao;
        }

        [HttpGet()]
        public IList<Recipe> GetAllRecipes()
        {
            return recipeDao.GetAllRecipes();
        }

        [HttpGet("{recipeId}")]
        public ActionResult<Recipe> GetRecipeByRecipeId(int recipeId)
        {
            Recipe recipe = recipeDao.GetRecipeByRecipeId(recipeId);
            
            if(recipe != null)
            {
                return recipe;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{recipeId}")]
        public ActionResult<Recipe> UpdateRecipeAvailability(int recipeId, Recipe recipe)
        {
            Recipe updatedRecipe = recipeDao.UpdateRecipeAvailability(recipeId, recipe);
            if (updatedRecipe == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(updatedRecipe);
            }
        }

        //[HttpPost()]
        //public ActionResult LinkRecipeIngredient(Recipe recipe, Ingredient ingredient)
        //{
        //    string success = "Check status code";
        //    recipeDao.LinkIngredientAndRecipe(recipe, ingredient);
        //    return Created($"/recipes/hedgehog", success);
        //}
        [HttpPost()]
        public ActionResult<Recipe> CreateRecipe(Recipe recipe)
        {
            Recipe newRecipe = recipeDao.CreateRecipe(recipe);
            return Created($"/recipes/{recipe.RecipeId}", newRecipe);
        }
    }
}
