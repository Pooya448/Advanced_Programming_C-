using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Probability_in_Array
{
    public class Program
    {
        /// <summary>
        /// Calculating the probability of the selected integer by user using the probability 
        /// principals and math operator : Division
        /// </summary>
        /// <param name="Array"> The main Array which hosts the selected integer</param>
        /// <param name="Input"> The selected integer by the user for calculating it's probability
        /// of being chosen by a random selection </param>
        /// <returns> Returns the probability Result as double value </returns>
        public static double CalculateProb(int[] Array, int Input)
        {
            /* Declaration and initiation of Counter as integer used for counting the quantity 
            of the selected integer in Array */
            double Counter = 0;
            foreach (int Num in Array)
            {
                if (Num == Input)
                {
                    Counter++;
                }
            }
            // Returning the final Result to the main function
            return Counter / Array.Length;
        }
        /// <summary>
        /// Getting the selected integer from user ans returning the integer value
        /// </summary>
        /// <param name="SelectedInt"> A text stream which a console output or Input stream
        /// can be passed to </param>
        /// <returns> Returns ineteger value Parsed from a string value taken from the 
        /// text stream "SelectedInt" </returns>
        public static int InputSelected (TextReader SelectedInt)
        {
            // getting integer from user as string value and changing it into int value
            return int.Parse(SelectedInt.ReadLine());
        }
        public static int[] InputArray (TextReader StringUnsplit)
        {
            string StringInput = StringUnsplit.ReadLine();
            string[] StringArr = StringInput.Split();
            int[] IntArr = new int[StringArr.Length];
            for(int i = 0; i < StringArr.Length; i++)
            {
                IntArr[i] = int.Parse(StringArr[i]);
            }
            return IntArr;
        }
        /// <summary>
        /// Writing the Result output in a textwriter stream : System Console in the main program run calling and
        /// a manual textwriter stream when unit testing
        /// </summary>
        /// <param name="Result"> Double value of final Result of calculation </param>
        /// <param name="Writer"> A Textwriter stream of System.IO </param>
        public static void Output(double Result, TextWriter Writer)
        {
            // Printing the final Result into TextWriter stream of choice (Console by program running)
            Writer.WriteLine(Result.ToString());
        }
        /// <summary>
        /// Getting the main Array of integers and the selected integer from user and Calculating
        /// the probability of be chosen by a random selection using the CalculateProb function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // The main array size value
            const int MainArraySize = 8;
            // The main integer Array with MainArraySize elements
            int[] Array = InputArray(Console.In);
            // Holder of the selected integer by user
            int InputNum = 0;
            do
            {
                // Getting the selected integer from the user by calling the InputSelected function
                InputNum = InputSelected(Console.In);
                // Breaking from the while loop if the user entered "-1" value.
                if (InputNum == -1)
                    break;
                /* Writing the Result to console using Output function call and passing the
                   CalculateProb function return value as the argument */
                Output(CalculateProb(Array, InputNum), Console.Out);
            } while (InputNum != -1);
        }
    }
}


