using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public class RecipeMethod
    {
        private List<Recipes> recipes = new List<Recipes>();

        public void AddRecipe(Recipes recipe)
        {
            recipes.Add(recipe);
        }

        public List<Recipes> GetRecipes()
        {
            return recipes;
        }

        public Recipes GetRecipeByName(string name)
        {
            return recipes.FirstOrDefault(r => r.RecipeName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void ScaleRecipe(string recipeName, double factor)
        {
            var recipe = GetRecipeByName(recipeName);
            if (recipe != null)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity *= factor;
                    ingredient.Calories *= factor; // Scale calories along with quantity
                }
            }
        }

        public void RevertRecipe(string recipeName)
        {
            var recipe = GetRecipeByName(recipeName);
            if (recipe != null)
            {
                recipe.Revert(); // Revert the ingredients list to original

                // Update the internal state of the recipes list
                var index = recipes.FindIndex(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
                if (index != -1)
                {
                    recipes[index] = recipe; // Replace the old recipe with the reverted one
                }
            }
            else
            {
                MessageBox.Show("Recipe not found.");
            }
        }

        public void ClearRecipes()
        {
            recipes.Clear();
        }

        public List<Recipes> GetAllRecipes()
        {
            return recipes;
        }

        public List<RecipeProperties> FilterRecipes(string ingredient = null, string foodGroup = null, double? maxCalories = null)
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
