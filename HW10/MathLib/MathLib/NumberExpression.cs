using System;
using System.IO;

namespace OOCalculator
{
    public class NumberExpression : Expression
    {
        /// <summary>
        /// double variable for storig the integer value of the number expression
        /// </summary>
        protected double Number;
        /// <summary>
        /// constructor for number expression class which takes a line as string and parses it to double value
        /// </summary>
        /// <param name="line"></param>
        public NumberExpression(string line)
        {
            // assigns the parsed double value to Number local variable of class
            Number = double.Parse(line);
        }
        /// <summary>
        /// calculating the numeral value of this number expression which is the same as returning Number variable
        /// </summary>
        /// <returns></returns>
        public override double Evaluate() => Number;
        /// <summary>
        /// returns the Number variable value (originally double) as string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Number.ToString();
    }
}