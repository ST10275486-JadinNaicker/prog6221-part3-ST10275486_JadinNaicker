using System.Windows;

namespace RecipeApp
{
    public partial class ScaleRecipeWindow : Window
    {
        private RecipeMethod recipeManager;

        public ScaleRecipeWindow(RecipeMethod recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            if (double.TryParse(ScalingFactorTextBox.Text, out double scalingFactor)) // Try to parse the scaling factor from the text box input.
            {
                recipeManager.ScaleRecipe(recipeName, scalingFactor); // Scale the recipe using the specified scaling factor.
                MessageBox.Show("Recipe scaled successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid scaling factor.");
            }
        }
    }
}
