using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public class RecipeMethod
    {
        private List<Recipes> recipes = new List<Recipes>(); //Stores all recipes //Author: (Troelsen and Japikse, 2022)
                                                                                  //Avaiability: Pro C# 10 with .NET6 Apress
                                                                                  //Date Accessed: 10 June 2024

        public void AddRecipe(Recipes recipe) //This method allows users to add recipes to the list
        {
            recipes.Add(recipe);
        }

        public List<Recipes> GetRecipes()
        {
            return recipes;
        }

        public Recipes GetRecipeByName(string name) // Method to get a recipe by its name
        {
            return recipes.FirstOrDefault(r => r.RecipeName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void ScaleRecipe(string recipeName, double factor) //Method to scale ingredients
        {
            var recipe = GetRecipeByName(recipeName);
            if (recipe != null)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity *= factor; //Scales quantity
                    ingredient.Calories *= factor; // Scale calories
                }
            }
        }

        public void RevertRecipe(string recipeName) //Reverts ingredients to its orginal quantity
        {
            var recipe = GetRecipeByName(recipeName);
            if (recipe != null)
            {
                recipe.Revert(); // Revert the ingredients list to original

               
                var index = recipes.FindIndex(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));  // Find the index of the recipe in the list and update it.
                if (index != -1)
                {
                    recipes[index] = recipe; 
                }
            }
            else
            {
                MessageBox.Show("Recipe not found.");
            }
        }

        public void ClearRecipes() //Method to clear all recipes from list
        {
            recipes.Clear();
        }

        public List<Recipes> GetAllRecipes()
        {
            return recipes;
        }

        public List<RecipeProperties> FilterRecipes(string ingredient = null, string foodGroup = null, double? maxCalories = null) // Method to filter recipes based on ingredient, food group, and maximum calories.
        {
            return recipes
                .SelectMany(r => r.Ingredients)
                .Where(ingredientFilter(ingredient))
                .Where(foodGroupFilter(foodGroup))
                .Where(caloriesFilter(maxCalories))
                .ToList();
        }

        private Func<RecipeProperties, bool> ingredientFilter(string ingredient)
        {
            if (string.IsNullOrWhiteSpace(ingredient))
                return _ => true;
            return r => r.RecipeName.Equals(ingredient, StringComparison.OrdinalIgnoreCase);
        }

        private Func<RecipeProperties, bool> foodGroupFilter(string foodGroup)
        {
            if (string.IsNullOrWhiteSpace(foodGroup))
                return _ => true;
            return r => r.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase);
        }

        private Func<RecipeProperties, bool> caloriesFilter(double? maxCalories)
        {
            if (!maxCalories.HasValue)
                return _ => true;
            return r => r.Calories <= maxCalories;
        }
    }
}
