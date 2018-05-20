using System;
using System.IO;

namespace OOCalculator
{
    public abstract class Expression
    {
        /// <summary>
        /// abstract method Evaluate that it's function is to calculate numeral result of operator
        /// it is in abstract form so that every derived class of this class be required to override this method for itself
        /// in this way we can call the Evaluate method for every operator which is derived from this class
        /// no matter what the difference is
        /// we know that the implementation has to be done and the functionality is the same
        /// </summary>
        /// <returns></returns>
        public abstract double Evaluate();
        /// <summary>
        /// gets the next expression from a stream reader by calling GetNextExpression method
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Expression BuildExpressionTree(StreamReader reader)
        {
            return Expression.GetNextExpression(reader);
        }
        /// <summary>
        /// reads the nexts expression from the file and determines if it is a expression (Add,Subtract,Multiply,Divide,SquareRoot,Square or Negate) or 
        /// a number epression and performs the suitable action for Evaluating the excpression
        /// </summary>
        /// <param name="reader">the file used for reading expressions</param>
        /// <returns></returns>
        protected static Expression GetNextExpression(TextReader reader)
        {
            string line = reader.ReadLine();
            switch (line)
            {
                // Making an Add Operator if the Expression read from the file is "Add"
                case "Add":
                    return new AddOperator(reader);
                // Making an Substract Operator if the Expression read from the file is "Subtract"
                case "Subtract":
                    return new SubtractOperator(reader);
                // Making an Multiply Operator if the Expression read from the file is "Multiply"
                case "Multiply":
                    return new MultiplyOperator(reader);
                // Making an Divide Operator if the Expression read from the file is "Divide"
                case "Divide":
                    return new DivideOperator(reader);
                // Making an Negate Operator if the Expression read from the file is "Negate"
                case "Negate":
                    return new NegateOperator(reader);
                // Making an Square Operator if the Expression read from the file is "Square"
                case "Square":
                    return new SquareOperator(reader);
                // Making an Sqrt Operator if the Expression read from the file is "SquareRoot"
                case "SquareRoot":
                    return new SqrtOperator(reader);
                // Making an Number Expression if the Expression read from the file is none of above (a number)
                default:
                    return new NumberExpression(line);

            }
        }
    }
}