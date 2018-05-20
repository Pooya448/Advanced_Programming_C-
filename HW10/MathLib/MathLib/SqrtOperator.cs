using System;
using System.IO;

namespace OOCalculator
{
    public class SqrtOperator : UnaryOperator
    {
        /// <summary>
        /// constructor of SquareRoot operator which calls the base constructor with the TextReader: reader
        /// </summary>
        /// <param name="reader"></param>
        public SqrtOperator(TextReader reader) : base (reader)
        {
        }
        /// <summary>
        /// overriding the operator symbol of base class (UnaryOperator) for SquareRoot operator class for causing polymorphism
        /// </summary>
        public override string OperatorSymbol => "Sqrt";
        /// <summary>
        /// method that calculates the numeral output of the SquareRoot operator
        /// </summary>
        /// <returns>result of calculation</returns>
        public override double Evaluate() => Math.Sqrt(Operand.Evaluate());
    }
}