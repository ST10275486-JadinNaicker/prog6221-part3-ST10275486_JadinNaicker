using System.Windows;

namespace RecipeApp
{
    public partial class EnterRecipeWindow : Window
    {
        private RecipeMethod recipeManager;

        public EnterRecipeWindow(RecipeMethod recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            if (int.TryParse(NumberOfIngredientsTextBox.Text, out int numberOfIngredients))
            {
                Recipes newRecipe = new Recipes(recipeName); // Create a new recipe instance
                IngredientsWindow ingredientsWindow = new IngredientsWindow(newRecipe, numberOfIngredients, recipeManager);
                ingredientsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid number of ingredients.");
            }
        }
    }
}
