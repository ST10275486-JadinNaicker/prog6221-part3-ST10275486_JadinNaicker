using System.Windows;

namespace RecipeApp
{
    public partial class EnterRecipeWindow : Window
    {
        private RecipeMethod recipeManager;

        public EnterRecipeWindow(RecipeMethod recipeManager) // Constructor that initializes the window and sets the recipe manager.
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            if (int.TryParse(NumberOfIngredientsTextBox.Text, out int numberOfIngredients))
            {
                Recipes newRecipe = new Recipes(recipeName); 
                IngredientsWindow ingredientsWindow = new IngredientsWindow(newRecipe, numberOfIngredients, recipeManager); // Open the IngredientsWindow with the new recipe and number of ingredients.
                ingredientsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid number of ingredients."); // Show an error message if the number of ingredients is not a valid integer.
            }
        }
    }
}
