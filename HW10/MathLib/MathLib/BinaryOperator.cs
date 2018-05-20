using System;
using System.IO;

namespace OOCalculator
{
    public abstract class BinaryOperator: Expression, IOperator
    {
        /// <summary>
        /// expression that stores the number expression or expression on the left hand side of the operator
        /// </summary>
        protected Expression LHS;
        /// <summary>
        /// expression that stores the number expression or expression on the right hand side of the operator
        /// </summary>
        protected Expression RHS;
        /// <summary>
        /// constructor of binary operator base class which assigns the LHS and RHS with the right values
        /// </summary>
        /// <param name="reader"></param>
        public BinaryOperator(TextReader reader)
        {
            // assigning right values to LHS and RHS
            LHS = GetNextExpression(reader);
            RHS = GetNextExpression(reader);
        }
        /// <summary>
        /// operator symbol which is abstract and should be overriden in each derived class so the To String method can cause dynamic 
        /// polymorphism to happen at the time of To String method call
        /// </summary>
        public abstract string OperatorSymbol { get; }
        /// <summary>
        /// To String general method for making the expression an symbolic string
        /// </summary>
        /// <returns></returns>
        public sealed override string ToString() => $"({LHS}{OperatorSymbol}{RHS})";

    }
}