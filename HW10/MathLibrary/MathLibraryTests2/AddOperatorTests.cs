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
    public class AddOperatorTests
    {
        [TestMethod()]
        public void AddOperatorTest()
        {
            // Add
            // 6 , 13
            
            string filePath = @"addTest.txt";
            File.WriteAllText(filePath, "6\n13");
            AddOperator addOp = new AddOperator(File.OpenText(filePath));
            Assert.AreEqual(addOp.ToString(), "(6+13)");
            Assert.AreEqual(addOp.Evaluate(), 19);
        }
    }
}