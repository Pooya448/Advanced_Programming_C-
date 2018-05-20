using System;
using System.IO;

namespace OOCalculator
{
    public class SubtractOperator : BinaryOperator
    {
        /// <summary>
        /// constructor of substract operator which calls the base constructor with the TextReader: reader
        /// </summary>
        /// <param name="reader"></param>
        public SubtractOperator(TextReader reader) : base(reader)
        {
            
        }
        /// <summary>
        /// overriding the operator symbol of base class for substract operator class for causing polymorphism
        /// </summary>
        public override string OperatorSymbol => "-";
        /// <summary>
        /// method that calculates the numeral output of the Substract operator
        /// </summary>
        /// <returns>result of calculation</returns>
        public override double Evaluate() => LHS.Evaluate() - RHS.Evaluate();
    }
}