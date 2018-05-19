using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace OOCalculator.Tests
{
    [TestClass()]
    public class NegateOperatorTests
    {
        [TestMethod()]
        public void NegateOperatorTest()
        {
            // Negate
            // 8
            string filePath = @"negateTest.txt";
            File.WriteAllText(filePath, "8");
            NegateOperator negateOp = new NegateOperator(File.OpenText(filePath));
            Assert.AreEqual(negateOp.Evaluate(), -5);
            Assert.AreEqual(negateOp.ToString(), "-(5)");
        }
    }
}