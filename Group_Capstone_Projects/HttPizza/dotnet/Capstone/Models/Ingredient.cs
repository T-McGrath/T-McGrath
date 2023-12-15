namespace Capstone.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string IngredientType { get; set; }
        public bool IsAvailable { get; set; }
    }
}
