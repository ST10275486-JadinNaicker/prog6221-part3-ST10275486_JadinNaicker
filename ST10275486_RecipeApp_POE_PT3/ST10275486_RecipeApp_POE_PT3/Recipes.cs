using System.Collections.Generic;

namespace RecipeApp
{
    public class Recipes
    {
        public string RecipeName { get; set; }
        public List<RecipeProperties> Ingredients { get; set; }         // Generic collection to store ingredients  //Author: Geeks for Geeks
                                                                        //Availability: https://www.geeksforgeeks.org/collections-in-c-sharp/
                                                                        //Date Accessed: 25 May 2024
         private List<RecipeProperties> originalIngredients;             
        public List<string> Steps { get; set; } 

        public Recipes(string recipeName)
        {
            RecipeName = recipeName;
            Ingredients = new List<RecipeProperties>();
            originalIngredients = new List<RecipeProperties>();
            Steps = new List<string>(); 
        }

        public void Revert()
        {
            Ingredients = new List<RecipeProperties>(originalIngredients);
        }
    }
}
