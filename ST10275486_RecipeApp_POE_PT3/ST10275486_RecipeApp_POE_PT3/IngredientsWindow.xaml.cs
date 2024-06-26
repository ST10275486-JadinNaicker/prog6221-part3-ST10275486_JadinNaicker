using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class IngredientsWindow : Window
    {
        private RecipeMethod recipeManager; 
        private string recipeName;//Name of the recipe
        private int numberOfIngredients; //Number of ingredients
        private int currentIngredientIndex = 0; //Tracks the amount of ingredients being added
        private Recipes recipe;

        public IngredientsWindow(Recipes recipe, int numberOfIngredients, RecipeMethod recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
            this.recipeName = recipe.RecipeName;
            this.numberOfIngredients = numberOfIngredients;
            this.recipe = recipe;

            // Populates FoodGroupComboBox
            FoodGroupComboBox.Items.Add(new ComboBoxItem() { Content = "Grains" });
            FoodGroupComboBox.Items.Add(new ComboBoxItem() { Content = "Vegetables" });
            FoodGroupComboBox.Items.Add(new ComboBoxItem() { Content = "Fruits" });
            FoodGroupComboBox.Items.Add(new ComboBoxItem() { Content = "Dairy" });
            FoodGroupComboBox.Items.Add(new ComboBoxItem() { Content = "Protein" });
            FoodGroupComboBox.Items.Add(new ComboBoxItem() { Content = "Fats & Oils" });

            // Optionally, set a default selection
            FoodGroupComboBox.SelectedIndex = 0;
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientNameTextBox.Text;
            if (double.TryParse(QuantityTextBox.Text, out double quantity) &&
                double.TryParse(CaloriesTextBox.Text, out double calories))
            { // Get ingredient details from the text boxes.
                string unit = UnitTextBox.Text;
                string foodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

                if (foodGroup != null)  // If a food group is selected, add the ingredient to the recipe.
                {
                    RecipeProperties ingredient = new RecipeProperties(ingredientName, quantity, unit, calories, foodGroup);
                    recipe.Ingredients.Add(ingredient);
                    // Increment the current ingredient index.
                    currentIngredientIndex++;
                    if (currentIngredientIndex >= numberOfIngredients)
                    {
                        MessageBox.Show("All ingredients added. Please click Finish.");
                    }
                    else // Clear the text boxes for the next ingredient.
                    {
                        IngredientNameTextBox.Clear();
                        QuantityTextBox.Clear();
                        UnitTextBox.Clear();
                        CaloriesTextBox.Clear();
                        FoodGroupComboBox.SelectedIndex = 0; // Reset selection if needed
                    }
                }
                else
                {
                    MessageBox.Show("Please select a food group.");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values for quantity and calories.");
            }
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var stepTextBox = new TextBox
            {
                Text = "Enter Step",
                Margin = new Thickness(0, 5, 0, 5)
            };
            StepsPanel.Children.Add(stepTextBox);
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            if (currentIngredientIndex == numberOfIngredients)
            {
                foreach (TextBox stepTextBox in StepsPanel.Children) // Add all steps from the text boxes to the recipe.
                {
                    recipe.Steps.Add(stepTextBox.Text);
                }
                // Add the recipe to the recipe manager and show a success message.
                recipeManager.AddRecipe(recipe);
                MessageBox.Show("Recipe added successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please add all ingredients before finishing.");
            }
        }
    }
}
