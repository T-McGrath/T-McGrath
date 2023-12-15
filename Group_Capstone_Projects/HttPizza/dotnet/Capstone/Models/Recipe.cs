namespace Capstone.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public decimal RecipePrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
