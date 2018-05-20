using System;
using System.IO;

namespace OOCalculator
{
    public class AddOperator : BinaryOperator
    {
        /// <summary>
        /// constructor of add operator which calls the base constructor with the TextReader: reader
        /// </summary>
        /// <param name="reader"></param>
        public AddOperator(TextReader reader) : base (reader)
        {
        }
        /// <summary>
        /// overriding the operator symbol of base class for add operator class for causing polymorphism
        /// </summary>
        public override string OperatorSymbol => "+";
        /// <summary>
        /// method that calculates the numeral output of the add operator
        /// </summary>
        /// <returns>result of calculation</returns>
        public override double Evaluate() => LHS.Evaluate() + RHS.Evaluate();
    }
}