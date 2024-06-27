# prog6221-part3-ST10275486_JadinNaicker
 POE Part 3:

 Sanele Recipe Application
 --------------------------
The Sanele Recipe Application is a WPF-based tool created to help users with baking and cooking tasks. It enables users to create, scale, display, revert, filter, and clear recipes. This application was developed in C# using Visual Studio.

Installation
------------
1.	Ensure you have Visual Studio installed on your laptop/computer.
2.	Download or clone the repository containing the application code.
3.	Open the solution file ST10275486_RecipeApp_POE_PT3.sln in Visual Studio.
Instructions to Use the Application
1.	Run the application by clicking the green arrow in Visual Studio.
2.	You will be greeted with a welcome message and a menu with the following options:

Main Window Options
-------------------
•	Create New Recipe: Opens a window to input the details of your recipe.
•	View Recipe List: Displays a list of all recipes you have created.
•	Recipe Details: View the details of a specific recipe.
•	Scale Recipe: Scale the ingredients by a factor of 0.5, 2, or 3.
•	Revert Recipe: Reset the ingredient quantities to their original values.
•	Filter Recipes: Filter recipes based on specific criteria.
•	Clear Recipes: Clear all recipe data.
•	Exit Application: Exit the application.

Classes Used
-------------
Main Classes
•	RecipeMethod.cs: Provides functionalities for inputting, displaying, scaling, resetting, filtering, and clearing recipes, as well as managing events for calorie notifications. The following methods are included:
o	EnterRecipe(): Requests the user to input details of a recipe and saves them.
o	DisplayRecipes(): Shows a list of all recipe names.
o	DisplayRecipeDetails(): Presents the specifics of a chosen recipe, covering ingredients and steps.
o	ScaleRecipe(): Adjusts ingredient amounts based on a user-defined factor.
o	RevertRecipe(): Resets ingredient quantities to their original values.
o	ClearRecipes(): Removes all recipes from the list.

Additional Classes
•	RecipeProperties.cs: Contains variables associated with recipe attributes, including ingredient name, quantity, measurement unit, calorie count, and food category.
•	Recipes.cs: Manages a collection of ingredients and steps for each recipe and calculates the total calories.

WPF Windows
•	MainWindow.xaml.cs: The main window containing buttons for all primary actions (Create New Recipe, View Recipe List, etc.).
•	EnterRecipeWindow.xaml.cs: A window for entering the details of a new recipe.
•	DisplayRecipesWindow.xaml.cs: A window for displaying a list of recipes.
•	DisplayRecipeDetailsWindow.xaml.cs: A window for viewing the details of a specific recipe.
•	ScaleRecipeWindow.xaml.cs: A window for scaling recipe ingredients.
•	RevertRecipeWindow.xaml.cs: A window for reverting recipe ingredient quantities.
•	IngredientsWindow.xaml.cs: A window for entering ingredient details.

Error Handling
--------------
The application is equipped with basic error handling to address incorrect inputs. For instance, when a non-numeric value is inputted instead of a number, the user will be reminded to input a valid number. If an invalid choice from the menu is made, the user will receive a notification and be prompted to choose a valid option.

Update to Read me based on Pt 2 feedback
-----------------------------------------
I updated the README to improve its layout and structure for better readability on GitHub. Key improvements include the use of clear headings and subheadings to organise the content into distinct sections such as Installation, Instructions to Use the Application, Main Window Options, Classes Used, WPF Windows, and Error Handling. Blocks of text were replaced with bullet points and numbered lists for easier scanning and understanding of the information. Code formatting with backticks was applied to highlight file names and methods, making the technical details stand out. These changes make the README more understandable and accessible for users to view it on GitHub.

GitHub Link: https://github.com/ST10275486-JadinNaicker/prog6221-part3-ST10275486_JadinNaicker.git 
YouTube: https://youtu.be/WV6wnyNf0fg 

Bibliography
------------
Chand, M. (2018). XAML ComboBox. [online] www.c-sharpcorner.com. Available at: https://www.c-sharpcorner.com/UploadFile/mahesh/xaml-combobox/ [Accessed 20 Jun. 2024].
Chand, M. (2023). Display Image In WPF using XAML and C#. [online] www.c-sharpcorner.com. Available at: https://www.c-sharpcorner.com/UploadFile/mahesh/using-xaml-image-in-wpf/ [Accessed 23 Jun. 2024].
Microsoft (n.d.). TextBlock.FontStyle Property (System.Windows.Controls). [online] learn.microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.textblock.fontstyle?view=windowsdesktop-8.0 [Accessed 20 Jun. 2024].
Saini, A. (2018). Collections in C#. [online] GeeksforGeeks. Available at: https://www.geeksforgeeks.org/collections-in-c-sharp/ [Accessed 19 Jun. 2024].
Troelsen, A. and Japikse, P. (2022). Pro C# 10 with .NET 6. Apress.
w3schools (n.d.). C# Switch. [online] www.w3schools.com. Available at: https://www.w3schools.com/cs/cs_switch.php [Accessed 27 May 2024].



