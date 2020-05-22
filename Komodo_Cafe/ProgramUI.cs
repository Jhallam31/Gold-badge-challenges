using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Komodo_Cafe
{
    public class ProgramUI
    {
        public readonly Menu_Repository _repo = new Menu_Repository();
        public List<string> _menu = new List<string>();




        public void Run()
        {
            RunMenu();
        }




        private void RunMenu()
        {
            bool ContinueToRun = true;
            while (ContinueToRun)
            {

                Console.WriteLine(
                    "Please enter the number of your selection:\n" +
                    "1. Show all menu items:\n" +
                    "2. Add new meal\n" +
                    "3. Find meal by number:\n" +
                    "4. Remove meal/item:\n" +
                    "5. Exit:\n"
                        );

                string selection = Console.ReadLine();

                switch (selection)
                {
                    //Show all
                    case "1":
                        Console.Clear();
                        ShowAllMenuMeals();
                        Console.ReadKey();
                        break;
                    //Find by number

                    //Add new meal
                    case "2":


                        Console.Clear();
                        //Add meal name
                        Console.WriteLine("Please enter a meal name.\n" +
                            "Press Enter to submit.");

                        string mealName = Console.ReadLine();


                        //Add description to meal
                        Console.Clear();
                        Console.WriteLine("Please write a short description.\n" +
                            "Press Enter to submit.");

                        string description = Console.ReadLine();


                        //Add ingredients to meal ingredient list

                        Console.Clear();
                        List<string> ingredients = new List<string>();
                        //
                        Console.WriteLine("Please type the ingredients for this meal separated by commas.");

                        string ingredientInput = Console.ReadLine();
                        string[] ingredientArray = ingredientInput.Split(',');
                        foreach (var item in ingredientArray)
                        {
                            ingredients.Add(item);
                        }




                        //Enter a price
                        Console.Clear();
                        Console.WriteLine("Please enter a price (do not include a dollar sign). For Example: 12.99");
                        double price = Convert.ToDouble(Console.ReadLine());

                        //Enter a combo number
                        Console.Clear();
                        Console.WriteLine("Please enter the combo number for this meal");
                        int mealNumber = Convert.ToInt32(Console.ReadLine());


                        Meal newMeal = new Meal(mealNumber, mealName, description, ingredients, price);
                        _repo.AddItemToMenu(newMeal);

                        Console.Clear();
                        Console.WriteLine("New menu item successfully created!");
                        Console.ReadKey();


                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Please enter the combo number of the meal you would like to view");

                        mealNumber = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        Meal meal = _repo.GetMealByNumber(mealNumber);



                        _repo.DisplayMeal(meal);



                        Console.WriteLine($" \n" +
                            $" \n" +
                            $"Press Y to view ingredients for this meal, or press any other key to go back to the main menu");

                        //View ingredients list

                        ingredients = meal.Ingredients;
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            foreach (var ingredient in ingredients)
                            {
                                Console.Write($"\n" +
                                    $"{ingredient}");

                            }

                        }
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Remove by combo number
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Please enter the number of the meal you would like to remove from the menu:");
                        mealNumber = Convert.ToInt32(Console.ReadLine());
                        _repo.RemoveMealByNumber(mealNumber);
                        Console.WriteLine("Meal successfully removed!\n"+
                            "Press any key to return to the main menu");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to exit?\n" +
                            "Press Y to quit. Otherwise, press Enter to go back to the selection menu.");
                        switch (Console.ReadLine())
                        {
                            case "y":
                                ContinueToRun = false;
                                Console.WriteLine("GoodBye!");

                                Thread.Sleep(2000);
                                break;

                        }
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid option.");
                        Console.ReadKey();
                        break;


                }
            }
        }




        private void ShowAllMenuMeals()
        {
            Console.Clear();
            List<Meal> listOfMeals = _repo.GetFullMenu();

            foreach (Meal meal in listOfMeals)
            {
                _repo.DisplayMeal(meal);
            }
            
        }






        //Remove meal
        //Exit



    }
}
