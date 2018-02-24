using System;
using Xunit;
using Hello_World;
namespace ProgramTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] grades_acs = new int[] { 1, 3, 5, 6, 9, 11 };
            int[] grades_desc = new int[] { 12, 9, 8, 5, 3, 2, 1 };
            int[] grades_neg = new int[] { 1, 5, 3, 9, 6, 12, 98, 4 };

            Assert.True(Program.IsSorted(grades_acs, true));
            Assert.True(Program.IsSorted(grades_desc, false));
            Assert.False(Program.IsSorted(grades_neg, false));
        }
        }
    }

