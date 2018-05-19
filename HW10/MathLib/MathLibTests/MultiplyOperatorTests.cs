using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCalculator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCalculator.Tests
{
    [TestClass()]
    public class MultiplyOperatorTests
    {
        [TestMethod()]
        public void MultiplyOperatorTest()
        {
            // Multiply
            // 2, 6
            string filePath = @"multiplyTest.txt";
            File.WriteAllText(filePath, "2\n6");
            MultiplyOperator multiplyOp = new MultiplyOperator(File.OpenText(filePath));
            Assert.AreEqual(multiplyOp.Evaluate(), 12);
            Assert.AreEqual(multiplyOp.ToString(), "(2*6)");
        }
    }
}