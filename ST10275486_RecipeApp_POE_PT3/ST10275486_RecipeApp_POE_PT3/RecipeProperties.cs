namespace RecipeApp
{
    public class RecipeProperties
    {
        public string RecipeName { get; set; } 
        public double Quantity { get; set; }
        public double OriginalQuantity { get; } // Store original quantity
        public string Unit { get; set; }
        public double Calories { get; set; }
        public double OriginalCalories { get; } // Store original calories
        public string FoodGroup { get; set; }

        public RecipeProperties(string recipeName, double quantity, string unit, double calories, string foodGroup)
        {
            RecipeName = recipeName;
            Quantity = quantity;
            OriginalQuantity = quantity; // Initialize original quantity
            Unit = unit;
            Calories = calories;
            OriginalCalories = calories; // Initialize original calories
            FoodGroup = foodGroup;
        }

        public void Revert()
        {
            Quantity = OriginalQuantity;
            Calories = OriginalCalories;
        }
    }
}
