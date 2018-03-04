using Microsoft.VisualStudio.TestTools.UnitTesting;
using Probability_in_Array;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            Assert.AreEqual(0.25, Program.calculate_prob(test1, 3));
            Assert.AreEqual(0.125, Program.calculate_prob(test2, 2));
            Assert.AreEqual(0.375, Program.calculate_prob(test3, 3));
        }
        [TestMethod()]
        public void input_selectedTest()
        {
            // 3 const int values for unit testing
            const int test_int1 = 8;
            const int test_int2 = 5;
            const int test_int3 = 2;
            // creating a StringReader and assigning a string value to it
            using (StringReader test_reader = new StringReader(test_int1.ToString()))
            {
                // comparing the function return value and expected value
                Assert.AreEqual(Program.input_selected(test_reader), 8);
            }
            using (StringReader test_reader = new StringReader(test_int2.ToString()))
            {
                Assert.AreEqual(Program.input_selected(test_reader), 5);
            }
            using (StringReader test_reader = new StringReader(test_int3.ToString()))
            {
                Assert.AreEqual(Program.input_selected(test_reader), 2);
            }
        }   
        [TestMethod()]
        public void output_resultTest()
        {
            // test double value for testing
            const double test = 0.264;
            // creating a StringWriter 
            using (StringWriter test_writer = new StringWriter())
            {
                Program.output_result(test, test_writer);
                /* getting the written value by output_result function from the test_writer 
                   StringWriter and comparing it to the expected string value */
                string output_test = test_writer.GetStringBuilder().ToString();
                output_test = output_test.Remove(output_test.Length - 2);
                Assert.AreEqual(output_test, test.ToString());
                
            }
        }
    }
}