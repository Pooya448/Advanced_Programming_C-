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
    public class ExpressionTests
    {
        [TestMethod()]
        public void BuildExpressionTreeTest()
        {
            string filePath = "expressionTest";
            string testExpression = "Multiply\n" +
                "Negate\n" +
                "5\n" +
                "Add\n" +
                "3\n" +
                "Divide\n" +
                "2\n" +
                "Sqrt\n" +
                "Substract\n" +
                "5\n" +
                "Square\n" +
                "2";
            File.WriteAllText(filePath, testExpression);
            string toStringResult = "(-(5)*(3+(2/Sqrt((5-Square(2))))))";
            Assert.AreEqual(Expression.BuildExpressionTree(File.OpenText(filePath)).Evaluate(), -25);
            Assert.AreEqual(Expression.BuildExpressionTree(File.OpenText(filePath)).ToString(), toStringResult);
            
        }
    }
}