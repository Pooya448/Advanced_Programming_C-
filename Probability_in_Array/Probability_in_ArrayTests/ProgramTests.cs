using Microsoft.VisualStudio.TestTools.UnitTesting;
using Probability_in_Array;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void input_selectedTest()
        {
            // 3 const int values for unit testing
            const int test_int1 = 8;
            const int test_int2 = 5;
            const int test_int3 = 2;    
            // creating a StringReader and assigning a string value to it
            using (StringReader test_reader = new StringReader(test_int1.ToString()))
            {
                // setting the console input stream to the manual StringReader
                Console.SetIn(test_reader);
                // comparing the function return value and expected value
                Assert.AreEqual(Program.input_selected(test_reader), 8);
            }
            using (StringReader test_reader = new StringReader(test_int2.ToString()))
            {
                Console.SetIn(test_reader);
                Assert.AreEqual(Program.input_selected(test_reader), 5);
            }
            using (StringReader test_reader = new StringReader(test_int3.ToString()))
            {
                Console.SetIn(test_reader);
                Assert.AreEqual(Program.input_selected(test_reader), 2);
            }
        }
        public void input_arrTest()
        {
            // 2 arrays for testing
            int[] test1 = new int[8];
            int[] arr_test1 = new int[] { 1, 3, 7, 3, 7, 3, 5, 8 };
            for (int i = 0; i < test1.Length; i++)
            {
                // creating a StringReader and assigning a string value to it
                using (StringReader test_reader = new StringReader(arr_test1[i].ToString()))
                {
                    Program.input_arr(test1, test_reader,i);
                }
            }
            // counting the number of elements of 2 arrays which should be equal one by one
            // counter counts the number of equality between 2 test arrays' elements
            int counter = 0;
            for (int j = 0; j < test1.Length; j++)
                if (test1[j] == arr_test1[j])
                    counter++;
            // comparing counter and the number 8 : 
            Assert.AreEqual(counter, 8);
            
        }
        public void output_resultTest()
        {
            // test double value for testing
            const double test = 12.87;
            // creating a StringWriter 
            using (StringWriter test_writer = new StringWriter())
            {
                Program.output_result(test, test_writer);
                /* getting the written value by output_result function from the test_writer 
                   StringWriter and comparing it to the expected string value */
                string output_test = test_writer.GetStringBuilder().ToString();
                Assert.AreEqual(output_test, test.ToString());
            }
        }
    }
}