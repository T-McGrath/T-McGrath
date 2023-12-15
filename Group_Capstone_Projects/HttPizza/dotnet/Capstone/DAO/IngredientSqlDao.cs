using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Exceptions;
using System;

namespace Capstone.DAO
{
    public class IngredientSqlDao : IIngredientDao
    {
        private readonly string connectionString;

        public IngredientSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        
        public IList<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredientList = new List<Ingredient>();
            string sqlQuery = "SELECT ingredient_id, ingredient_name, ingredient_type, is_available FROM ingredients;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Ingredient ingredient = MapRowToIngredient(reader);
                        ingredientList.Add(ingredient);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Sql Exception error!", ex);
            }
            return ingredientList;
        }
        public Ingredient GetIngredientByIngredientId(int ingredientId)
        {
            Ingredient ingredient = null;
            string sql = "SELECT * FROM ingredients WHERE ingredient_id = @ingredient_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@ingredient_id", ingredientId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        ingredient = MapRowToIngredient(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Sql Exception error!", ex);
            }
            return ingredient;
        }

        public IList<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            IList<Ingredient> ingredients = new List<Ingredient>();
            string sql = "SELECT i.ingredient_id AS ingredient_id, i.ingredient_name AS ingredient_name, i.ingredient_type AS ingredient_type, i.is_available AS is_available FROM ingredients AS i " +
                            "JOIN recipe_ingredient AS ri ON i.ingredient_id = ri.ingredient_id " +
                            "JOIN recipes AS r ON ri.recipe_id = r.recipe_id " +
                            "WHERE r.recipe_id = @recipe_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@recipe_id", recipeId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Ingredient ingredient = MapRowToIngredient(reader);
                        ingredients.Add(ingredient);
                    }
                        
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Sql Exception error!", ex);
            }
            return ingredients;
        }
        public Ingredient UpdateIngredientAvailability(int ingredientId, Ingredient ingredient)
        {
            Ingredient updatedIngredient = null;
            string sql = "UPDATE ingredients SET ingredient_name = @ingredient_name, ingredient_type = @ingredient_type, is_available = @is_available " +
                           "WHERE ingredient_id = @ingredient_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@ingredient_name", ingredient.IngredientName);
                    command.Parameters.AddWithValue("@ingredient_type", ingredient.IngredientType);
                    command.Parameters.AddWithValue("@is_available", ingredient.IsAvailable);
                    command.Parameters.AddWithValue("@ingredient_id", ingredientId);
                    command.ExecuteNonQuery();
                }
                updatedIngredient = GetIngredientByIngredientId(ingredientId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("Sql Exception error!", ex);
            }
            return updatedIngredient;
        }
        public Ingredient CreateIngredient(Ingredient ingredient)
        {
            Ingredient newIngredient = null;
            string sql = "INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) " +
                            "OUTPUT INSERTED.ingredient_id " +
                            "VALUES (@ingredient_name, @ingredient_type, @is_available);";
            try
            {
                int newIngredientId;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@ingredient_name", ingredient.IngredientName);
                    command.Parameters.AddWithValue("@ingredient_type", ingredient.IngredientType);
                    command.Parameters.AddWithValue("@is_available", ingredient.IsAvailable);
                    newIngredientId = Convert.ToInt32(command.ExecuteScalar());
                }
                newIngredient = GetIngredientByIngredientId(newIngredientId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("Sql Exception error!", ex);
            }
            return newIngredient;
        }

        public Ingredient MapRowToIngredient(SqlDataReader reader)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.IngredientId = Convert.ToInt32(reader["ingredient_id"]);
            ingredient.IngredientName = Convert.ToString(reader["ingredient_name"]);
            ingredient.IngredientType = Convert.ToString(reader["ingredient_type"]);
            ingredient.IsAvailable = Convert.ToBoolean(reader["is_available"]);
            return ingredient;

        }
        
        public Ingredient MapRowToIngredientJoin(SqlDataReader reader)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.IngredientId = Convert.ToInt32(reader["i.ingredient_id"]);
            ingredient.IngredientName = Convert.ToString(reader["i.ingredient_name"]);
            ingredient.IngredientType = Convert.ToString(reader["i.ingredient_type"]);
            ingredient.IsAvailable = Convert.ToBoolean(reader["i.is_available"]);
            return ingredient;

        }
    }
}
