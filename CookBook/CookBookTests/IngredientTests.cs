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
            Ingredient Test1 = new Ingredient("Test", "Test", 1, "Test");
            Ingredient Test2 = new Ingredient("Test", "Test", 1, "Test");
            Assert.AreEqual(Test1.Name, Test2.Name);
            Assert.AreEqual(Test1.Unit, Test2.Unit);
            Assert.AreEqual(Test1.Description, Test2.Description);
            Assert.AreEqual(Test1.Quantity, Test2.Quantity);
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