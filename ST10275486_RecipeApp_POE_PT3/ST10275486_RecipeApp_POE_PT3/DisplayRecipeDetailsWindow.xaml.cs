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

                // Format the steps
                List<string> formattedSteps = new List<string>();
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
