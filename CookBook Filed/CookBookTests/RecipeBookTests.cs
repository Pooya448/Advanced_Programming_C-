using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Tests
{
    [TestClass()]
    public class RecipeBookTests
    {
        [TestMethod()]
        public void RecipeBookconstTest()
        {
            RecipeBook TestBook1 = new RecipeBook("Test1", 30);
            RecipeBook TestBook2 = new RecipeBook("Test1", 30);
            Assert.AreEqual(TestBook1.BookTitle, TestBook2.BookTitle);
            Assert.AreEqual(TestBook1.Capacity, TestBook2.Capacity);
            Assert.IsNotNull(TestBook1.BookTitle);
            Assert.IsNotNull(TestBook2.BookTitle);
            Assert.IsNotNull(TestBook1.Capacity);
            Assert.IsNotNull(TestBook2.Capacity);
        }

        [TestMethod()]
        public void RecipeBookAddRemoveTest()
        {
            RecipeBook Test = new RecipeBook("Test", 10);
            string TestTitle = "Test";
            string TestInstructions = "Test";
            string TestCuisine = "Test";
            string[] TestKeywords = new string[] { "Test1", "Test2" };
            int TestServingCount = 5;
            int TestInCount = 0;
            Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
            Assert.IsTrue(Test.Add(TestRecipe));
            Assert.IsFalse(Test.Remove("Nonsense"));
            Assert.IsTrue(Test.Remove(TestRecipe.Title));
            Assert.IsFalse(Test.ListOfRecipes.Contains(TestRecipe));

        }
        [TestMethod()]
        public void RecipeBookLookUpTest()
        {
            RecipeBook Test = new RecipeBook("Test", 10);


            string TestKeyword = "Test1";

            string TestTitle = "Test";
            string TestInstructions = "Test";
            string TestCuisine = "Test";
            string[] TestKeywords = new string[] { "Test1", "Test2" };
            int TestServingCount = 0;
            int TestInCount = 0;
            Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);

            string TestKeyword2 = "Test3";

            string TestTitle2 = "Test1";
            string TestInstructions2 = "Test1";
            string TestCuisine2 = "Test1";
            string[] TestKeywords2 = new string[] { "Test3", "Test4" };
            int TestServingCount2 = 2;
            int TestInCount2 = 2;
            Recipe TestRecipe2 = new Recipe(TestTitle2, TestInstructions2, TestInCount2, TestServingCount2, TestCuisine2, TestKeywords2);



            Test.Add(TestRecipe);
            Test.Add(TestRecipe);
            Test.Add(TestRecipe);
            Assert.IsNull(Test.LookupByCuisine(TestRecipe2.Cuisine));
            Assert.IsNull(Test.LookupByTitle(TestRecipe2.Title));
            Assert.IsNull(Test.LookupByKeyword(TestKeyword2));
            Assert.IsNotNull(Test.LookupByCuisine(TestCuisine));
            Assert.IsNotNull(Test.LookupByTitle(TestTitle));
            Assert.IsNotNull(Test.LookupByKeyword(TestKeyword));
        }
        [TestMethod()]
        public void SaveTests()
        {
            string Path = @"SaveLoadTest.txt";
            RecipeBook Test = new RecipeBook("Test", 10);
            

            string TestTitle = "Test";
            string TestInstructions = "Test";
            string TestCuisine = "Test";
            string[] TestKeywords = new string[] { "Test1", "Test2" };
            int TestServingCount = 0;
            int TestInCount = 0;
            Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
            Test.Add(TestRecipe);
            Test.Save(Path);
            Assert.IsTrue(File.Exists(Path));
            
        }
        [TestMethod()]
        public void LoadTests()
        {
            string Path = @"SaveLoadTest.txt";
            RecipeBook Test = new RecipeBook("Test", 10);
            Assert.IsTrue(Test.Load(Path));
            string wrongPath = @"Fake.txt";

            Assert.IsFalse(Test.Load(wrongPath));
        }
        [TestMethod()]
        public void ListTest()
        {
            RecipeBook Test = new RecipeBook("Test", 10);
            string TestTitle = "Test";
            string TestInstructions = "Test";
            string TestCuisine = "Test";
            string[] TestKeywords = new string[] { "Test1", "Test2" };
            int TestServingCount = 0;
            int TestInCount = 0;
            Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
            Test.Add(TestRecipe);
            Assert.IsTrue(Test.ListRecipes(Test.ListOfRecipes));
        }
        [TestMethod()]
        public void ShowRecipeTest ()
        {
            RecipeBook Test = new RecipeBook("Test", 10);
            string TestTitle = "Test";
            string TestInstructions = "Test";
            string TestCuisine = "Test";
            string[] TestKeywords = new string[] { "Test1", "Test2" };
            int TestServingCount = 0;
            int TestInCount = 0;
            Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
            Assert.IsFalse(Test.ShowRecipe(TestRecipe));
            List<Ingredient> Ings = new List<Ingredient>();
            Ingredient ingTest = new Ingredient("name", "desc", 2.5, "kg");
            Ings.Add(ingTest);
            TestRecipe.IngredientsList = Ings;
            Assert.IsTrue(Test.ShowRecipe(TestRecipe));
        }
    }
}