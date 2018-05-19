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
    public class DivideOperatorTests
    {
        [TestMethod()]
        public void DivideOperatorTest()
        {
            // Division
            // 15 , 3

            string filePath = "divideTest.txt";
            File.WriteAllText(filePath, "15\n3");
            DivideOperator divideOp = new DivideOperator(File.OpenText(filePath));
            Assert.AreEqual(divideOp.ToString(), "(15/3)");
            Assert.AreEqual(divideOp.Evaluate(), 5);


        }
    }
}