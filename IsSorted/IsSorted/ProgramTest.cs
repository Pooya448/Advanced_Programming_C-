using System;
using Hello_World;
using Microsoft.TestTools.UnitTesting;
//using Xunit;
namespace IsSorted
{
    public class ProgramTest
    {
        public ProgramTest()
        {
            int[] grades_acs = new int[] { 1, 3, 5, 6, 9, 11 };
            int[] grades_desc = new int[] { 12,9,8,5,3,2,1 };
            int[] grades_neg = new int[] {1,5,3,9,6,12,98,4};

            Assert.IsTrue(Program.IsSorted(grades_acs, true));
            Assert.IsTrue(Program.IsSorted(grades_desc, false));
            Assert.IsTrue(Program.IsSorted(grades_neg, false));
        }
    }
}
