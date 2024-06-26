using System.Windows;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private RecipeMethod recipeManager = new RecipeMethod(); //Author: (Troelsen and Japikse, 2022)
                                                                 //Avaiability: Pro C# 10 with .NET6 Apress
                                                                 //Date Accessed: 10 June 2024

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterRecipe_Click(object sender, RoutedEventArgs e)
        {
            EnterRecipeWindow enterRecipeWindow = new EnterRecipeWindow(recipeManager);
            enterRecipeWindow.Show();
        }

        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            DisplayRecipesWindow displayRecipesWindow = new DisplayRecipesWindow(recipeManager);
            displayRecipesWindow.Show();
        }

        private void DisplayRecipeDetails_Click(object sender, RoutedEventArgs e)
        {
            DisplayRecipeDetailsWindow displayRecipeDetailsWindow = new DisplayRecipeDetailsWindow(recipeManager);
            displayRecipeDetailsWindow.Show();
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipeWindow scaleRecipeWindow = new ScaleRecipeWindow(recipeManager);
            scaleRecipeWindow.Show();
        }

        private void RevertRecipe_Click(object sender, RoutedEventArgs e)
        {
            RevertRecipeWindow revertRecipeWindow = new RevertRecipeWindow(recipeManager);
            revertRecipeWindow.Show();
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            FilterRecipesWindow filterRecipesWindow = new FilterRecipesWindow(recipeManager);
            filterRecipesWindow.Show();
        }

        private void ClearRecipes_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear all recipes?", "Clear Recipes", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                recipeManager.ClearRecipes();
                MessageBox.Show("Recipes cleared.");
            }
        }


        private void ExitApplication_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
