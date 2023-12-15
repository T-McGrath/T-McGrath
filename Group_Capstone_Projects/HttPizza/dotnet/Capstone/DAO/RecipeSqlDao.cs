using System.Collections.Generic;
using Capstone.Exceptions;
using System.Data.SqlClient;
using Capstone.Models;
using System;

namespace Capstone.DAO
{
    public class RecipeSqlDao :IRecipeDao
    {
        private readonly string connectionString;
        public RecipeSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public IList<Recipe> GetAllRecipes()
        {
            IList<Recipe> recipes = new List<Recipe>();
            string sql = "SELECT * FROM recipes;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Recipe recipe = MapRowToRecipe(reader);
                        recipes.Add(recipe);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return recipes;
        }
        public Recipe GetRecipeByRecipeId(int recipeId)
        {
            Recipe recipe = null;
            string sql = "SELECT * FROM recipes WHERE recipe_id = @recipe_id;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        recipe = MapRowToRecipe(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return recipe;
        }
        public Recipe UpdateRecipeAvailability(int recipeId, Recipe recipe)
        {
            Recipe updatedRecipe = null;
            string sql = "UPDATE recipes SET recipe_name = @recipe_name, recipe_price = @recipe_price, is_available = @is_available " +
                            "WHERE recipe_id = @recipe_id;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@recipe_name", recipe.RecipeName);
                    cmd.Parameters.AddWithValue("@recipe_price", recipe.RecipePrice);
                    cmd.Parameters.AddWithValue("@is_available", recipe.IsAvailable);
                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);
                    cmd.ExecuteNonQuery();
                }
                updatedRecipe = GetRecipeByRecipeId(recipeId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return updatedRecipe;
        }
        public Recipe CreateRecipe(Recipe recipe)
        {
            Recipe newRecipe = null;
            string sql = "INSERT INTO recipes (recipe_name, recipe_price, is_available) " +
                            "OUTPUT INSERTED.recipe_id " +
                            "VALUES (@recipe_name, @recipe_price, @is_available);";

            try
            {
                int newRecipeId;
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@recipe_name", recipe.RecipeName);
                    cmd.Parameters.AddWithValue("@recipe_price", recipe.RecipePrice);
                    cmd.Parameters.AddWithValue("@is_available", recipe.IsAvailable);
                    newRecipeId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                newRecipe = GetRecipeByRecipeId(newRecipeId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return newRecipe;
        }
        public IList<RecipeIngredient> GetRI(int recipeId)
        {
            IList<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
            string sql = "SELECT * FROM recipe_ingredient WHERE recipe_id = @recipe_id;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        RecipeIngredient recipeIngredient = new RecipeIngredient();
                        recipeIngredient.RecipeId = Convert.ToInt32(reader["recipe_id"]);
                        recipeIngredient.IngredientId = Convert.ToInt32(reader["ingredient_id"]);
                        recipeIngredients.Add(recipeIngredient);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return recipeIngredients;
        }
        public void LinkIngredientAndRecipe(int recipeId, int ingredientId)
        {
            string sql = "INSERT INTO recipe_ingredient (recipe_id, ingredient_id) VALUES (@recipe_id, @ingredient_id);";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);
                    cmd.Parameters.AddWithValue("@ingredient_id", ingredientId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
        }
        public Recipe MapRowToRecipe(SqlDataReader reader)
        {
            Recipe recipe = new Recipe();
            recipe.RecipeId = Convert.ToInt32(reader["recipe_id"]);
            recipe.RecipeName = Convert.ToString(reader["recipe_name"]);
            recipe.RecipePrice = Convert.ToDecimal(reader["recipe_price"]);
            recipe.IsAvailable = Convert.ToBoolean(reader["is_available"]);
            return recipe;
        }
        
    }
}
