using System;
using System.IO;

namespace OOCalculator
{
    public class SquareOperator : UnaryOperator
    {
        /// <summary>
        /// constructor of Square operator which calls the base constructor with the TextReader: reader
        /// </summary>
        /// <param name="reader"></param>
        public SquareOperator(TextReader reader) : base(reader)
        {

        }
        /// <summary>
        /// overriding the operator symbol of base class (UnaryOperator) for Square operator class for causing polymorphism
        /// </summary>
        public override string OperatorSymbol => "Square";
        /// <summary>
        /// method that calculates the numeral output of the Square operator
        /// </summary>
        /// <returns>result of calculation</returns>
        public override double Evaluate() => Math.Pow(Operand.Evaluate(),2);

    }
}