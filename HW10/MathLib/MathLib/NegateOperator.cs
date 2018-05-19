using System;
using System.IO;

namespace OOCalculator
{
    public class NegateOperator : UnaryOperator
    {
       public NegateOperator(TextReader reader): base (reader)
        {
           
        }

        public override string OperatorSymbol => "-";

        public override double Evaluate() => Operand.Evaluate() * -1; 
    }
}