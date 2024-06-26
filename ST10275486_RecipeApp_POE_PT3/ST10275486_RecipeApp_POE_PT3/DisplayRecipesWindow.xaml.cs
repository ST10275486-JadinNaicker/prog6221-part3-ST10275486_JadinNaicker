using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class DisplayRecipesWindow : Window
    {
        private RecipeMethod recipeManager;

        public DisplayRecipesWindow(RecipeMethod recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
            DisplayRecipes();
        }

        private void DisplayRecipes()
        {
            // Set the ItemsSource to the list of recipes
            RecipesListBox.ItemsSource = recipeManager.GetRecipes();
        }
    }
}
