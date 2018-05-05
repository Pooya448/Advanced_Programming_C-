﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Assignment5.Tests
{
    [TestClass()]
    public class RecipeTests
    {
        [TestMethod()]
        public void RecipeAddRemoveTest()
        {

            string TestTitle = "Test";
            string TestInstructions = "Test";
            string TestCuisine = "Test";
            string[] TestKeywords = new string[] { "Test1", "Test2" };
            int TestServingCount = 2;
            int TestInCount = 5;

            Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
            string InName = "Name";
            string InDiscription = "Discription";
            double InQuantity = 0.350;
            string InUnit = "Unit";
            Ingredient TestIn = new Ingredient(InName, InDiscription, InQuantity, InUnit);

            Assert.IsTrue(TestRecipe.AddIngredient(TestIn));
            Assert.IsFalse(TestRecipe.RemoveIngredient("Jibber-Jabber"));
            Assert.IsTrue(TestRecipe.RemoveIngredient(TestIn.Name));
            

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
            string[] TestKeywords = new string[] { "Test1", "Test2" };
            int TestServingCount = 0;
            int TestInCount = 0;
            Recipe Test = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
            string TestRes = $" Title : {TestTitle}\n Instructions : {TestInstructions}\n Cuisine : {TestCuisine}\n Serving Count : {TestServingCount} \n Ingredients Count : {TestInCount}\n";
            string Actual = Test.ToString();
            Assert.AreEqual(TestRes, Actual);
        }
        [TestMethod()]
        public void UpdateServingCountTest ()
        {
            string TestTitle = "Test";
            string TestInstructions = "Test";
            string TestCuisine = "Test";
            string[] TestKeywords = new string[] { "Test1", "Test2" };
            int TestServingCount = 2;
            int InitialQuantity = 1;
            int Multiplier = 5;
            Ingredient Test = new Ingredient("Name", "Description", InitialQuantity, "Unit");
            List<Ingredient> TestArr = new List<Ingredient>
            {
                Test
            };
            Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestArr, TestServingCount, TestCuisine, TestKeywords);
            TestRecipe.UpdateServingCount(Multiplier);
            foreach (Ingredient item in TestRecipe.IngredientsList)
            {
                Assert.AreEqual(item.Quantity,Multiplier / TestServingCount * InitialQuantity);
            }
        }




        [TestMethod()]
        public void RecipeSerializeTests()
        {
            Ingredient Test = new Ingredient("Name", "Description", 1, "Unit");
            List<Ingredient> TestArr = new List<Ingredient>
            {
                Test
            };
            string[] TestKeywords = new string[] { "Test1", "Test2" };
            Recipe TestRecipe = new Recipe("Title", "Instructions", TestArr, 1, "Cuisine", TestKeywords);
            using (StreamWriter Writer = new StreamWriter(@"RecipeTest.txt"))
            {
                TestRecipe.Serialize(Writer);
            }
            Recipe TestSub;
            using (StreamReader Reader = new StreamReader(@"RecipeTest.txt"))
            {
                TestSub = Recipe.Deserialize(Reader);
            }
            Assert.AreEqual(TestRecipe.Title,TestSub.Title);
            Assert.AreEqual(TestRecipe.Instructions, TestSub.Instructions);
            Assert.AreEqual(TestRecipe.ServingCount, TestSub.ServingCount);
            Assert.AreEqual(TestRecipe.Cuisine, TestSub.Cuisine);
            CollectionAssert.AreEqual(TestRecipe.KeyWords, TestSub.KeyWords);
            for (int i = 0; i < TestRecipe.IngredientsList.Count; i++)
            {
                Assert.AreEqual(TestRecipe.IngredientsList[i].Description, TestSub.IngredientsList[i].Description);
                Assert.AreEqual(TestRecipe.IngredientsList[i].Name,TestSub.IngredientsList[i].Name);
                Assert.AreEqual(TestRecipe.IngredientsList[i].Quantity, TestSub.IngredientsList[i].Quantity);
                Assert.AreEqual(TestRecipe.IngredientsList[i].Unit, TestSub.IngredientsList[i].Unit);
            }
        }
        
    }
}