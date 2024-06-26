using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class FilterRecipesWindow : Window
    {
        private RecipeMethod recipeManager;

        public FilterRecipesWindow(RecipeMethod recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedFilter = (FilterTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var filterValue = FilterValueTextBox.Text;
            var filteredRecipes = recipeManager.GetRecipes();

            if (string.IsNullOrWhiteSpace(selectedFilter) || string.IsNullOrWhiteSpace(filterValue))
            {
                MessageBox.Show("Please select a filter type and enter a value.");
                return;
            }

            switch (selectedFilter)
            {
                case "Ingredient":
                    filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Any(i => i.RecipeName.Equals(filterValue, StringComparison.OrdinalIgnoreCase))).ToList();
                    break;

                case "Food Group":
                    filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Any(i => i.FoodGroup.Equals(filterValue, StringComparison.OrdinalIgnoreCase))).ToList();
                    break;

                case "Maximum Calories":
                    if (double.TryParse(filterValue, out double maxCalories))
                    {
                        filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Sum(i => i.Calories) <= maxCalories).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number for maximum calories.");
                        return;
                    }
                    break;
            }

            FilteredRecipesList.ItemsSource = filteredRecipes.Select(r => r.RecipeName).ToList();
        }
    }
}
