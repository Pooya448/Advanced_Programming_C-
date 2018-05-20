using System;
using System.IO;

namespace OOCalculator
{
    public class MultiplyOperator : BinaryOperator
    {
        /// <summary>
        /// constructor of multiply operator which calls the base constructor with the TextReader: reader
        /// </summary>
        /// <param name="reader"></param>
        public MultiplyOperator(TextReader reader) : base(reader)
        {
            
        }
        /// <summary>
        /// overriding the operator symbol of base class for multiply operator class for causing polymorphism
        /// </summary>
        public override string OperatorSymbol => "*";
        /// <summary>
        /// method that calculates the numeral output of the multiply operator
        /// </summary>
        /// <returns>result of calculation</returns>
        public override double Evaluate() => LHS.Evaluate() * RHS.Evaluate();
    }
}