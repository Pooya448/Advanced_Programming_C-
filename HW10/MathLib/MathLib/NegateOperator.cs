using System;
using System.IO;

namespace OOCalculator
{
    public class NegateOperator : UnaryOperator
    {
        /// <summary>
        /// constructor of Negate operator which calls the base constructor with the TextReader: reader
        /// </summary>
        /// <param name="reader"></param>
        public NegateOperator(TextReader reader): base (reader)
        {
           
        }
        
        /// <summary>
        /// overriding the operator symbol of base class (UnaryOperator) for Negate operator class for causing polymorphism
        /// </summary>
        public override string OperatorSymbol => "-";
        /// <summary>
        /// method that calculates the numeral output of the Negate operator
        /// </summary>
        /// <returns>result of calculation</returns>
        public override double Evaluate() => Operand.Evaluate() * -1;
    }
}