using System;
namespace SimpleCalculator
{
    /// <summary>
    ///  این کلاس وضعیت مادر است 
    ///  برای هر وضعیتی اگر یکی از 
    ///  Event ها
    ///  مثلا
    ///  EnterEqual/...
    ///  را 
    ///  override
    ///  نکنیم به طور پیش فرض کاری انجام نمیدهد و در وضعیت فعلی باقی میماند.
    ///  #6 لطفا!
    /// </summary>
    /// 

    // made this class public so i could make test coverage 100% , but this class was abstract data because no objects could be 
    // constrcuted from this class
    public class CalculatorState : IState
    {
        public Calculator Calc { get;  }
        public CalculatorState(Calculator calc) => this.Calc = calc;
        public virtual IState EnterEqual() => this;
        public virtual IState EnterZeroDigit() => this;
        public virtual IState EnterNonZeroDigit(char c) => this;        
        public virtual IState EnterOperator(char c) => this;
        public virtual IState EnterPoint() => this;

        // made this method public so i can make test coverage of this class 100%
        public IState ProcessOperator(IState nextState, char? op = null, bool IsTest = false)
        {
            try
            {
                this.Calc.Evalute();
                this.Calc.UpdateDisplay();
                this.Calc.PendingOperator = op;
                if (IsTest) throw new NullReferenceException();
                return nextState;
            }
            catch (Exception e)
            {
                this.Calc.DisplayError(e.Message);
                return new ErrorState(this.Calc);
            }
        }
    }
}