using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe
{
    public enum IngredientType
    { milk=1, eggs, butter,sugar, bread, wheat_bread, sourdough, ham, chicken, turkey, meunster, cheddar, lettuce, tomato, onion, pickle}
    

    public class Meal
    {
        //Meal number
        //Meal name
        //description
        //list of ingredients
        //price
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }

        



        public Meal(int mealNumber, 
            string mealName, 
            string description,
            List<string> ingredients, 
            double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;

            

        }
        
    }  
}
