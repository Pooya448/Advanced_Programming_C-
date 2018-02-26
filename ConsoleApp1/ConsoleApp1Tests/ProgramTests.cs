using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void IsSortedTest()
        {
            int[] gradesAsc = { 1, 2, 3, 6, 9 };
            int[] gradesDesc = { 11, 8, 5, 3, 1 };
            int[] gradesNeg = { 8, 5, 7, 6, 1 };

            Assert.IsTrue(Program.IsSorted(gradesAsc, true));
            Assert.IsTrue(Program.IsSorted(gradesDesc, false));
            Assert.IsFalse(Program.IsSorted(gradesNeg, false));
        }
    }
}