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
    public class SubtractOperatorTests
    {
        [TestMethod()]
        public void SubtractOperatorTest()
        {
            // Substraction
            // 14 , 9
            string filePath = "substractTest.txt";
            File.WriteAllText(filePath, "14\n9");
            SubtractOperator substractOp = new SubtractOperator(File.OpenText(filePath));
            Assert.AreEqual(substractOp.ToString(), "(14-9)");
            Assert.AreEqual(substractOp.Evaluate(), 5);
        }
    }
}