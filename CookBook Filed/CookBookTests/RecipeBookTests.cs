using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
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
            Assert.IsTrue(Test.Remove(TestRecipe.Title));

        }
        [TestMethod()]
        public void RecipeBookLookUpTest()
        {
            RecipeBook Test = new RecipeBook("Test", 10);
            
            
            string TestKeyword = "TestKeyword1";

            string TestTitle = "Test";
            string TestInstructions = "Test";
            string TestCuisine = "Test";
            string[] TestKeywords = new string[] { "Test1", "Test2" };
            int TestServingCount = 0;
            int TestInCount = 0;
            Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);




            Test.Add(TestRecipe);
            Test.Add(TestRecipe);
            Test.Add(TestRecipe);
            Assert.IsNotNull(Test.LookupByCuisine(TestCuisine));
            Assert.IsNotNull(Test.LookupByTitle(TestTitle));
            Assert.IsNotNull(Test.LookupByKeyword(TestKeyword));
        }
        public void RecipeBookSelectRecipeTest()
        {
            RecipeBook Test = new RecipeBook("Test", 10);
            Recipe[] TestList = new Recipe[] {new Recipe(null, null, null, 0, null, null),new Recipe(null, null, null, 0, null, null)};
            const int TestIndex = 1;
            Assert.IsNotNull(Test.SelectRecipe(TestList, TestIndex));
        }
    }
}