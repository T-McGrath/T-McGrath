using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IRecipeDao
    {
        IList<Recipe> GetAllRecipes();
        Recipe GetRecipeByRecipeId(int recipeId);
        Recipe UpdateRecipeAvailability(int recipeId, Recipe recipe);
        Recipe CreateRecipe(Recipe recipe);
        IList<RecipeIngredient> GetRI(int recipeId);
        void LinkIngredientAndRecipe(int recipeId, int ingredientId);
    }
}
