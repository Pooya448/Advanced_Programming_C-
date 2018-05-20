using System;
using System.IO;

namespace OOCalculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        /// <summary>
        /// an expression that stores the value of the number expression or other expression
        /// used in unary operators
        /// </summary>
        protected Expression Operand;
        /// <summary>
        /// constructor for unary base class
        /// </summary>
        /// <param name="reader">the text reader used for reading expressions</param>
        public UnaryOperator(TextReader reader)
        {
            // assigns the next expression in the file to Operand local expression
            Operand = GetNextExpression(reader);
        }
        /// <summary>
        /// method that is general for every derived class and is dynamically called with derived class
        /// propereties , example of dynamic polymorphism
        /// </summary>
        /// <returns>string of expression</returns>
        public sealed override string ToString() =>  $"{OperatorSymbol}({Operand})";
        /// <summary>
        /// operator symbol which is abstract and should be overriden in each derived class so the To String method can cause dynamic 
        /// polymorphism to happen at the time of To String method call
        /// </summary>
        public abstract string OperatorSymbol { get; }
    }
}