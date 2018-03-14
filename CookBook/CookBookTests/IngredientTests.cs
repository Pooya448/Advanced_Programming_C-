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
    public class IngredientTests
    {
        [TestMethod()]
        public void IngredientconstTest()
        {
            Ingredient Test1 = new Ingredient(null, null, 0, null);
            Ingredient Test2 = new Ingredient(null, null, 0, null);
            Assert.AreEqual<Ingredient>(Test1, Test2);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string TestName = "Test";
            string TestDiscription = "Test";
            string TestUnit = "Test";
            double TestQuantity = 0.234;
            Ingredient Test = new Ingredient(TestName,TestDiscription,TestQuantity,TestUnit);
            Assert.AreEqual(Test.ToString(), $"{TestName}:\t{TestQuantity} {TestUnit} - {TestDiscription}\n");
        }
    }
}