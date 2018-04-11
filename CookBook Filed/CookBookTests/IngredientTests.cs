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
        public void SerializeTests()
        {
            Ingredient Test = new Ingredient("Name", "Description", 1, "Unit");

            using (StreamWriter Writer = new StreamWriter(@"IngTest.txt"))
            {
                Test.Serilize(Writer);
            }
            Ingredient TestIng;
            using (StreamReader Reader = new StreamReader(@"IngTest.txt"))
            {
                TestIng = Ingredient.Deserialize(Reader);
            }
            Assert.AreEqual(Test.Name,TestIng.Name);
            Assert.AreEqual(Test.Unit, TestIng.Unit);
            Assert.AreEqual(Test.Description, TestIng.Description);
            Assert.AreEqual(Test.Quantity, TestIng.Quantity);

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