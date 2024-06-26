using System.Collections.Generic;

namespace RecipeApp
{
    public class Recipes
    {
        public string RecipeName { get; set; } //Stores the name of the recipe.
        public List<RecipeProperties> Ingredients { get; set; }         // Generic collection to store ingredients  //Author: Geeks for Geeks
                                                                        //Availability: https://www.geeksforgeeks.org/collections-in-c-sharp/
                                                                        //Date Accessed: 25 May 2024
         private List<RecipeProperties> originalIngredients;             
        public List<string> Steps { get; set; } //Stores the recipe steps

        public Recipes(string recipeName) // Constructor that initializes the recipe with a name, and creates new lists for ingredients and steps.
        {
            RecipeName = recipeName;
            Ingredients = new List<RecipeProperties>();
            originalIngredients = new List<RecipeProperties>();
            Steps = new List<string>(); 
        }

        public void Revert() // Method to revert the ingredients to their original state.
        {
            Ingredients = new List<RecipeProperties>(originalIngredients);
        }
    }
}
