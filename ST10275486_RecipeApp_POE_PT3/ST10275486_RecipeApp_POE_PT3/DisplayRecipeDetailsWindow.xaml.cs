using System.Collections.Generic;
using System.Windows;

namespace RecipeApp
{
    public partial class DisplayRecipeDetailsWindow : Window
    {
        private RecipeMethod recipeManager;

        public DisplayRecipeDetailsWindow(RecipeMethod recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
        }

        private void Display_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            var recipe = recipeManager.GetRecipeByName(recipeName);
            if (recipe != null)
            {
                IngredientsListBox.ItemsSource = recipe.Ingredients;
                //Formats steps
                List<string> formattedSteps = new List<string>(); //Author: (Troelsen and Japikse, 2022)
                                                                  //Availability: Pro C# 10 with .NET6 Apress
                                                                  //Date Accessed: 10 June 2024

                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    formattedSteps.Add($"Step {i + 1}: {recipe.Steps[i]}");
                }
                StepsListBox.ItemsSource = formattedSteps;
            }
            else
            {
                MessageBox.Show("Recipe not found.");
                IngredientsListBox.ItemsSource = null; // Clear items if recipe not found
                StepsListBox.ItemsSource = null; 
            }
        }
    }
}
