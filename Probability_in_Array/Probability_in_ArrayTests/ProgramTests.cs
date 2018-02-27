using Microsoft.VisualStudio.TestTools.UnitTesting;
using Probability_in_Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probability_in_Array.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void calculate_probTest()
        {
            // 3 test arrays for unit test assessment
            int[] test1 = new int[] { 1, 3, 7, 3, 7, 9, 10, 5 };
            int[] test2 = new int[] { 2, 7, 3, 8, 3, 9, 5, 8 };
            int[] test3 = new int[] { 3, 8, 3, 6, 23, 3, 2, 7 };
            // testing the three reliable cases using Assert function and AreEqual attribute
            Assert.AreEqual(0.25, Program.calculate_prob(test1, 3), 0);
            Assert.AreEqual(0.125, Program.calculate_prob(test2, 2), 0);
            Assert.AreEqual(0.375, Program.calculate_prob(test3, 3), 0);
        }
    }
}