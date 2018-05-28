using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AccumulateStateTest() => RunTest<AccumulateState>(keys: "123430q", expectedDisplay: "123430");

        [TestMethod()]
        public void PointStateTest() => RunTest<PointState>(keys: ".......q", expectedDisplay: "0.");

        [TestMethod()]
        public void StartStateTest() => RunTest<StartState>(keys: "12+q", expectedDisplay: "12");

        [TestMethod()]
        public void ErrorStateTest() => RunTest<ErrorState>(keys: "12+5==q", expectedDisplay: "17");

        [TestMethod()]
        public void SumTest() => RunTest<ComputeState>(keys: "10+10=q", expectedDisplay: "20");

        [TestMethod()]
        public void PowerTest() => RunTest<ComputeState>(keys: "2^3=q", expectedDisplay: "8");

        [TestMethod()]
        public void SubtractTest() => RunTest<ComputeState>(keys: "95-10=q", expectedDisplay: "85");

        [TestMethod()]
        public void ZeroTest() => RunTest<StartState>(keys: "000000q", expectedDisplay: "0");

        [TestMethod()]
        public void ExtraPointTest() => RunTest<PointState>(keys: "55.234.2q", expectedDisplay: "55.2342");

        [TestMethod()]
        public void MultiplyTest() => RunTest<ComputeState>(keys: "10*10=q", expectedDisplay: "100");

        [TestMethod()]
        public void MultipleSumTest() => RunTest<ComputeState>(keys: "10+10+10.3=q", expectedDisplay: "30.3");

        [TestMethod()]
        public void DivideTest() => RunTest<ComputeState>(keys: "10/2=q", expectedDisplay: "5");

        [TestMethod()]
        public void AccumulationTest() => RunTest<AccumulateState>(keys: "10000000q", expectedDisplay: "10000000");

        [TestMethod()]
        public void StartingPointTest() => RunTest<ComputeState>(keys: ".5*2=q", expectedDisplay: "1");

        [TestMethod()]
        public void ErrorCasesTests()
        {
            // after '==' the calculator must be in error state, so we can test this state methods
            RunTest<StartState>(keys: "==/q", expectedDisplay: "0");
            RunTest<StartState>(keys: "==9q", expectedDisplay: "0");
            RunTest<StartState>(keys: "===q", expectedDisplay: "0");
            RunTest<StartState>(keys: "==.q", expectedDisplay: "0");
            RunTest<StartState>(keys: "==0q", expectedDisplay: "0");
        }

        [TestMethod()]
        public void ComputeNonZeroTest() => RunTest<AccumulateState>(keys: "2+3=9q", expectedDisplay: "9");

        [TestMethod()]
        public void ComputeZeroTest() => RunTest<StartState>(keys: "2+3=0q", expectedDisplay: "0");

        [TestMethod()]
        public void ComputeOpTest() => RunTest<ErrorState>(keys: "2+3=+q", expectedDisplay: "5");

        [TestMethod()]
        public void ComputePointTest() => RunTest<PointState>(keys: "2+3=.q", expectedDisplay: "0.");

        [TestMethod()]
        public void StartOpTest() => RunTest<StartState>(keys: "+q", expectedDisplay: "0");

        [TestMethod()]
        public void StartEqualTest() => RunTest<ComputeState>(keys: "=q", expectedDisplay: "0");

        [TestMethod()]
        public void CalcStateTests()
        {
            Calculator CalcTest = new Calculator();
            CalculatorState CalcStateTest = new CalculatorState(CalcTest);
            Assert.IsTrue(CalcStateTest.EnterEqual() is CalculatorState);
            Assert.IsTrue(CalcStateTest.EnterNonZeroDigit('T') is CalculatorState);
            Assert.IsTrue(CalcStateTest.EnterOperator('+') is CalculatorState);
            Assert.IsTrue(CalcStateTest.EnterPoint() is CalculatorState);
            Assert.IsTrue(CalcStateTest.EnterZeroDigit() is CalculatorState);

            Assert.IsTrue(CalcStateTest.ProcessOperator(new StartState(CalcTest), null, true) is ErrorState);

        }

        private void RunTest<ExpectedState>(string keys, string expectedDisplay)
        {
            int i = 0;
            Calculator c = Program.RunCalculator(() => keys[i++],() => { });
            Assert.AreEqual(c.Display, expectedDisplay);
            Assert.IsTrue(c.State is ExpectedState);
        }

    }
}