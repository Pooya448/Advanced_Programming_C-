using System;

namespace SimpleCalculator
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }
        /// <summary>
        /// when in this state, if an equal is entered, the process operator method is called with computestate return
        /// </summary>
        /// <returns></returns>
        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));
        /// <summary>
        /// when in this state if a zero is entered then the Display variable must become 0
        /// </summary>
        /// <returns></returns>
        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }
        /// <summary>
        /// when in this state if a non zero digit is entered the Display variable must become equal to the digit entered
        /// </summary>
        /// <param name="c"> the digit entered </param>
        /// <returns></returns>
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }
        /// <summary>
        /// when in this state, if an operator is entered, the process operator method is called with startstate return
        /// because there are no operands to process
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c) => 
            ProcessOperator(new StartState(this.Calc), c);
        /// <summary>
        /// when in this state, if a dot is entered the display var must become 0. and the calculator must go into point state
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}