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
    public class RecipeTests
    {
        [TestMethod()]
        public void RecipeAddRemoveTest()
        {

            //string TestTitle = "Test";
            //string TestInstructions = "Test";
            //string TestCuisine = "Test";
            //string[] TestKeywords = new string[] { "Test1", "Test2" };
            //int TestServingCount = 2;
            //int TestInCount = 5;
            //Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
            //Ingredient TestIn = new Ingredient("Test","Test",1,"Test");
            //Assert.IsTrue(TestRecipe.AddIngredient(TestIn));
            //Assert.IsTrue(TestRecipe.RemoveIngredient(TestIn.Name));

            const int TestCount = 5;
            TestRecipe.UpdateServingCount(TestCount);
            Assert.AreEqual(TestRecipe.ServingCount, TestCount);
        }
        [TestMethod()]
        public void RecipeToStringOverrideTest()
        {
            string TestTitle = "Test";
            string TestInstructions = "Test";
            string TestCuisine = "Test";
            string[] TestKeywords = new string[] {"Test1","Test2" };
            int TestServingCount = 0;
            int TestInCount = 0;
            Recipe Test = new Recipe(TestTitle,TestInstructions,TestInCount,TestServingCount,TestCuisine,TestKeywords);
            string TestRes = $" Title : {TestTitle}\n Instructions : {TestInstructions}\n Cuisine : {TestCuisine}\n Serving Count : {TestServingCount} \n Ingredients Count : {TestInCount}\n";
            string Actual = Test.ToString();
            Assert.AreEqual(TestRes,Actual);
        }


    }
}