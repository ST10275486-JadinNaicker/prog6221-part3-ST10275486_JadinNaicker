using System.Windows;

namespace RecipeApp
{
    public partial class RevertRecipeWindow : Window
    {
        private RecipeMethod recipeManager;

        public RevertRecipeWindow(RecipeMethod recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
        }

        private void Revert_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text; // Get the recipe name from the text box.
            recipeManager.RevertRecipe(recipeName); // Call the RecipeMethod to revert the specified recipe.
            MessageBox.Show("Recipe reverted successfully!");
            this.Close();
        }
    }
}