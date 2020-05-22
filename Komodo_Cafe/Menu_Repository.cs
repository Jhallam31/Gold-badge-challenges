using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe
{
    

    public class Menu_Repository
    {
        
        public List<Meal> _menu = new List<Meal>();
        


        //CRUD
        //Create --> adding new content
        //Read-- getting content already there
        //Update ---> changing the content
        //Delete

        public void AddItemToMenu(Meal item)
        {
            int startingCount = _menu.Count;
            _menu.Add(item);
            
        }

        
        public List<Meal> GetFullMenu()
        {
            
            return _menu;
        }
        
        

        public Meal GetMealByNumber(int mealNumber)
        {
            foreach (Meal meal in _menu)
            {
                if (meal.MealNumber == mealNumber)
                {

                    return meal;
                }
                else 
                {
                    Console.WriteLine("Incorrect entry, please try again.");
                }   
            }
            return null;
        }
        public bool UpdateMealByNumber(int mealNumber, Meal newMeal)
        {
            Meal item = GetMealByNumber(mealNumber);

            if (item == null)
            {
                return false;
            }
            else
            {
                item.MealName = newMeal.MealName;
                item.Description = newMeal.Description;
                item.MealNumber = newMeal.MealNumber;
                item.Ingredients = newMeal.Ingredients;
                item.Price = newMeal.Price;
                return true;
            }
        }

        
        public bool RemoveMealByNumber(int mealNumber)
        {
            Meal meal = GetMealByNumber(mealNumber);

            if (meal == null)
            {
                Console.WriteLine("That is not a valid meal number.");
                return false;
            }
            else
            {
                _menu.Remove(meal);
                // int index = _contentDirectory.IndexOf(content);
                // _contentDirectory.RemoveAt(index);
                return true;
            }



        }

        

        public void DisplayMeal(Meal meal)
        {
            Console.WriteLine($"{meal.MealNumber}\t" +
                $"{meal.MealName}\t" +
                $"{meal.Description}\t" +
                $"{meal.Price}");
        }

        

    }
}


