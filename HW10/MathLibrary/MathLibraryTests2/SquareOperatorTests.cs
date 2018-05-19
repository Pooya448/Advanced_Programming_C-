using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOCalculator.Tests
{
    [TestClass()]
    public class SquareOperatorTests
    {
        [TestMethod()]
        public void SquareOperatorTest()
        {
            // Square
            // 3
            string filePath = @"squareTest.txt";
            File.WriteAllText(filePath, "3");
            SquareOperator squareOp = new SquareOperator(File.OpenText(filePath));
            Assert.AreEqual(squareOp.Evaluate(), 9);
            Assert.AreEqual(squareOp.ToString(), "Square(3)");
        }
    }
}