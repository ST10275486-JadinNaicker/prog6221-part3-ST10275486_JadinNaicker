using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class IngredientsWindow : Window
    {
        private RecipeMethod recipeManager;
        private string recipeName;
        private int numberOfIngredients;
        private int currentIngredientIndex = 0;
        private Recipes recipe;

        public IngredientsWindow(Recipes recipe, int numberOfIngredients, RecipeMethod recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
            this.recipeName = recipe.RecipeName;
            this.numberOfIngredients = numberOfIngredients;
            this.recipe = recipe;

            // Populate FoodGroupComboBox with items
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
            {
                string unit = UnitTextBox.Text;
                string foodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

                if (foodGroup != null)
                {
                    RecipeProperties ingredient = new RecipeProperties(ingredientName, quantity, unit, calories, foodGroup);
                    recipe.Ingredients.Add(ingredient);

                    currentIngredientIndex++;
                    if (currentIngredientIndex >= numberOfIngredients)
                    {
                        MessageBox.Show("All ingredients added. Please click Finish.");
                    }
                    else
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
                foreach (TextBox stepTextBox in StepsPanel.Children)
                {
                    recipe.Steps.Add(stepTextBox.Text);
                }

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
