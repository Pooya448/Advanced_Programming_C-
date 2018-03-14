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
            Assert.AreEqual<RecipeBook>(TestBook1, TestBook2);
        }

        [TestMethod()]
        public void RecipeBookAddRemoveTest()
        {
            RecipeBook Test = new RecipeBook("Test", 10);
            Recipe Test1 = new Recipe(null, null, null, 0, null, null);
            Assert.IsTrue(Test.Add(Test1));
            Assert.IsTrue(Test.Remove(Test1.Title));

        }
        [TestMethod()]
        public void RecipeBookLookUpTest()
        {
            RecipeBook Test = new RecipeBook("Test", 10);
            string[] TestKeywords = new string[] {"TestKeyword1","Testkeyword2" };
            string TestCuisine = "TestCuisine";
            string TestTitle = "TestTitle";
            string TestKeyword = "TestKeyword1";
            Test.Add(new Recipe(null,null,null,0,TestCuisine,null));
            Test.Add(new Recipe(null, null, null, 0, null, TestKeywords));
            Test.Add(new Recipe(TestTitle, null, null, 0, null, null));
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