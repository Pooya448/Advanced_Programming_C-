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
            Recipe Test = new Recipe(null,null,null,0,null,null);
            Ingredient TestIn = new Ingredient("Test",null,0,null);
            Assert.IsTrue(Test.AddIngredient(TestIn));
            Assert.IsTrue(Test.RemoveIngredient(TestIn.Name));

            const int TestCount = 5;
            Test.UpdateServingCount(TestCount);
            Assert.AreEqual(Test.ServingCount, TestCount);
        }
        [TestMethod()]
        public void RecipeToStringOverrideTest()
        {
            string TestTitle = "Test";
            string TestInstructions = "Test";
            string TestCuisine = "Test";
            int TestServingCount = 0;
            int TestInCount = 0;
            Recipe Test = new Recipe(TestTitle,TestInstructions,TestInCount,TestServingCount,TestCuisine,null);
            string TestRes = $" Title : {TestTitle}\n Instructions : {TestInstructions}\n Cuisine : {TestCuisine}\n Serving Count : {TestServingCount} \n Ingredients Count : {TestInCount}\n";
            Assert.AreEqual(TestRes,Test.ToString());
        }


    }
}