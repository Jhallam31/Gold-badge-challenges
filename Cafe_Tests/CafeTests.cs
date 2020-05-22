using System;
using System.Collections.Generic;
using System.Threading;
using Komodo_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class CafeTests

    {
        
        public Menu_Repository _repo = new Menu_Repository();
        public List<Meal> _menu = new List<Meal>();
        List<string> _ingredients = new List<string>();
        
        public void SeedMealList()
        {
            List<string> coffeeIngredients = new List<string>() { "coffee" };
            Meal coffee = new Meal(2, "Coffee", "Black coffee from freshly ground beans", coffeeIngredients, 1.99);
            List<string> hamIngredients = new List<string>() { "ham", "bread", "mayonnaise", "lettuce", "tomato" };
            Meal hamSandwich = new Meal(1, "Ham and Swiss", "A simple ham sandwich on rye bread with condiemtns of your choice", hamIngredients, 5.99);
            List<string> grilledChickenIngredients = new List<string>() { "chicken", "bread", "house sauce", "meunster cheese" };
            Meal grilledChicken = new Meal(3, "Grilled Chicken Sandwich", "Lightly seasoned chicken with a housemade sauce on a brioche bun", grilledChickenIngredients, 6.50);

            _repo.AddItemToMenu(coffee);
            _repo.AddItemToMenu(hamSandwich);
            _repo.AddItemToMenu(grilledChicken);
        }
       
        

        [TestMethod]
        public void AddItemTest()
        //TEST PASSED
        {
            //Arrange

            List<string> ingredients = new List<string>()
            { "milk", "coffee","sugar", "caramel syrup"};

            Meal latte = new Meal(4, "Cafe Latte", "A simple classic with pure sugar cane and locally sourced milk", ingredients, 3.99);

            List<string> ingredients2 = new List<string>() { "ham", "turkey", "swiss cheese", "mayonnaise", "lettuce", "tomato" };
            Meal clubSandwich = new Meal(12, "Komodo Club", "Smoked turkey breast and black-forest ham on sourdough bread with a homemade spread", ingredients2, 3.99);

            //Act
            _repo.AddItemToMenu(latte);
            _repo.AddItemToMenu(clubSandwich);

            //Assert
            int expected = 5;
            int actual = _repo.GetFullMenu().Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        //TEST PASSED
        public void GetMealByNumberTest()
        {
            // Arrange
            List<string> pbjIngredients = new List<string>()
            { "peanut butter", "wheat bread","jelly"};
            Meal peanutbutter = new Meal(5, "Peanut Butter and Jelly Sandwich", "Childhood classic with elevated ingredients", pbjIngredients, 2.56);
            _repo.AddItemToMenu(peanutbutter);

            // Act
            Meal testContent = _repo.GetMealByNumber(5);

            // Assert
            Assert.AreEqual(peanutbutter, testContent);
        }
        [TestMethod]
        public void UpdateMealTest()
        //TEST PASSED
        {
            SeedMealList();

            List<string> coffeeIngredients = new List<string>() { "coffee", "hazelnut" };
            Meal newMeal = new Meal(2, "Coffee", "Black coffee from freshly ground beans", coffeeIngredients, 2.15);
            _repo.UpdateMealByNumber(2, newMeal);

            // SeedRepo(); <-- Don't need this if it's a [TestInitialize] method
            List<string> expected = coffeeIngredients;
            List<string> actual = _repo.GetMealByNumber(2).Ingredients;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveMealTest()
        //TEST PASSED
        {
            //Arrange
            SeedMealList();
            //Act
            _repo.RemoveMealByNumber(1);
            //Assert
            int expected = 2;
            int actual = _repo.GetFullMenu().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddToListTest()
        //TEST PASSED
        {

            string input = "milk";
            //Arrange
            bool wasAdded = _repo.AddIngredientToList(input);

            Assert.IsTrue(wasAdded);
        }
        
        
    }
        
}
