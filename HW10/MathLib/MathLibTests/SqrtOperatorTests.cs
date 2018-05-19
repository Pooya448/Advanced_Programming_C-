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
    public class SqrtOperatorTests
    {
        [TestMethod()]
        public void SqrtOperatorTest()
        {
            // Square Root
            // 16
            string filePath = @"sqrtTest.txt";
            File.WriteAllText(filePath, "16");
            SqrtOperator sqrtOp = new SqrtOperator(File.OpenText(filePath));
            Assert.AreEqual(sqrtOp.Evaluate(), 4);
            Assert.AreEqual(sqrtOp.ToString(), "Sqrt(16)");
        }
    }
}