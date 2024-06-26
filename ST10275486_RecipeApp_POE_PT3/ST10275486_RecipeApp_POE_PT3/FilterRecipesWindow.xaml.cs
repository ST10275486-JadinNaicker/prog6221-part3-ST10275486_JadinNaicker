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

            if (string.IsNullOrWhiteSpace(selectedFilter) || string.IsNullOrWhiteSpace(filterValue)) // Check if filter type or filter value is empty.
            {
                MessageBox.Show("Please select a filter type and enter a value.");
                return;
            }
            // Apply filtering based on the selected filter type.
            switch (selectedFilter) 
                                    //Author: W3Schools
                                    //Availability: https://www.w3schools.com/cs/cs_switch.php
                                    //Date Accessed: 5 April 2024
            {
                case "Ingredient":
                    filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Any(i => i.RecipeName.Equals(filterValue, StringComparison.OrdinalIgnoreCase))).ToList(); //Ingredient Name matches filter value
                    break;

                case "Food Group": //Foodgroup matches the filter
                    filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Any(i => i.FoodGroup.Equals(filterValue, StringComparison.OrdinalIgnoreCase))).ToList();
                    break;

                case "Maximum Calories": //Calories matches the filter
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
