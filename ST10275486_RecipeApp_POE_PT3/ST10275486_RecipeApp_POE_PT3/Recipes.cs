using System.Collections.Generic;

namespace RecipeApp
{
    public class Recipes
    {
        public string RecipeName { get; set; }
        public List<RecipeProperties> Ingredients { get; set; }
        private List<RecipeProperties> originalIngredients;
        public List<string> Steps { get; set; } // Add this property

        public Recipes(string recipeName)
        {
            RecipeName = recipeName;
            Ingredients = new List<RecipeProperties>();
            originalIngredients = new List<RecipeProperties>();
            Steps = new List<string>(); // Initialize the Steps list
        }

        public void Revert()
        {
            Ingredients = new List<RecipeProperties>(originalIngredients);
        }
    }
}
