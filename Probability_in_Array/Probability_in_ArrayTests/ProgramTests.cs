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
        public void CalculateProbTest()
        {
            // 3 DoubleTest arrays for unit DoubleTest assessment
            int [] ArrayTest1 = new int[] { 1, 3, 7, 3, 7, 9, 10, 5 };
            int [] ArrayTest2 = new int[] { 2, 7, 3, 8, 3, 9, 5, 8 };
            int [] ArrayTest3 = new int[] { 3, 8, 3, 6, 23, 3, 2, 7 };
            // 3 Sample elements
            const int SampleTest1 = 3;
            const int SampleTest2 = 2;
            const int SampleTest3 = 3;
            // 3 result of the aboce tests
            const double SampleResult1 =0.250;
            const double SampleResult2 =0.125;
            const double SampleResult3 =0.375;
            // Testing the three reliable cases using Assert function and AreEqual attribute
            Assert.AreEqual(SampleResult1, Program.CalculateProb(ArrayTest1, SampleTest1));
            Assert.AreEqual(SampleResult2, Program.CalculateProb(ArrayTest2, SampleTest2));
            Assert.AreEqual(SampleResult3, Program.CalculateProb(ArrayTest3, SampleTest3));
        }
        [TestMethod()]
        public void InputSelectedTest()
        {
            // 3 const int values for unit testing
            const int IntTest1 = 8;
            const int IntTest2 = 5;
            const int IntTest3 = 2;
            // Creating a StringReader and assigning a string value to it
            using (StringReader ReaderTest1 = new StringReader(IntTest1.ToString()))
            {
                // Comparing the function return value and expected value
                Assert.AreEqual(Program.InputSelected(ReaderTest1), IntTest1);
            }
            using (StringReader Readertest2 = new StringReader(IntTest2.ToString()))
            {
                Assert.AreEqual(Program.InputSelected(Readertest2), IntTest2);
            }
            using (StringReader ReaderTest3 = new StringReader(IntTest3.ToString()))
            {
                Assert.AreEqual(Program.InputSelected(ReaderTest3), IntTest3);
            }
        }
        [TestMethod()]
        public void InputArrTest()
        {
            const string StringTest = "1 3 7 3 8 5 9 3";
            int[] IntArrayTest = { 1, 3, 7, 3, 8, 5, 9, 3 };
            using(StringReader StringReaderTest = new StringReader(StringTest))
            {
                CollectionAssert.AreEqual(Program.InputArray(StringReaderTest), IntArrayTest);
            }
        }
        [TestMethod()]
        public void OutputTest()
        {
            // DoubleTest double value for testing
            const double DoubleTest = 0.264;
            // Creating a StringWriter 
            using (StringWriter WriterTest = new StringWriter())
            {
                Program.Output(DoubleTest, WriterTest);
                /* Getting the written value by output_result function from the WriterTest 
                   StringWriter and comparing it to the expected string value */
                string OutputTestString = WriterTest.GetStringBuilder().ToString();
                OutputTestString = OutputTestString.Remove(OutputTestString.Length - 2);
                Assert.AreEqual(OutputTestString, DoubleTest.ToString());  
            }
        }
    }
}