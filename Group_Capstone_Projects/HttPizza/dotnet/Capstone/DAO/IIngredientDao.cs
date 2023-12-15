using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IIngredientDao
    {
        IList<Ingredient> GetAllIngredients();
        Ingredient GetIngredientByIngredientId(int ingredientId);
        IList<Ingredient> GetIngredientsByRecipeId(int recipeId);
        Ingredient UpdateIngredientAvailability(int ingredientId, Ingredient ingredient);
        Ingredient CreateIngredient(Ingredient ingredient);
    }
}
