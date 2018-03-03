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
        /// calculating the probability of the selected integer by user using the probability 
        /// principals and math operator : division
        /// </summary>
        /// <param name="array"> the main array which hosts the selected integer</param>
        /// <param name="input"> the selected integer by the user for calculating it's probability
        /// of being chosen by a random selection </param>
        /// <returns> returns the probability result as double value </returns>
        public static double calculate_prob(int[] array, int input)
        {
            /* declaration and initiation of counter as integer used for counting the quantity 
            of the selected integer in array */
            double counter = 0;
            foreach (int num in array)
            {
                if (num == input)
                {
                    counter++;
                }
            }
            
            // returning the final result to the main function
            return counter / array.Length;
        }
        /// <summary>
        /// getting the selected integer from user ans returning the integer value
        /// </summary>
        /// <param name="selected_int"> a text stream which a console output or input stream
        /// can be passed to </param>
        /// <returns> returns ineteger value Parsed from a string value taken from the 
        /// text stream "selected_int" </returns>
        public static int input_selected(TextReader selected_int)
        {
            // getting integer from user as string value and changing it into int value
            
            return int.Parse(selected_int.ReadLine());
        }
        /// <summary>
        /// getting the main array from user (using console or a manual text stream) and calling 
        /// input_selected function fro every element in the array
        /// </summary>
        /// <param name="array"> the main array of integers' allocated space in the memory passed
        /// to the function by reference type of passing </param>
        /// <param name="reader"> manual text stream having the default value of null </param>
        /// <param name="starting_pos"> the starting position of for loop for unit testing 
        /// having the default value of 0 when called in the main function </param>
        public static int[] input_arr(int[] array, TextReader reader = null, int starting_pos = 0)
        {

            for (int i = starting_pos; i < array.Length; i++)
            {
                /* getting the array element of index i from user by calling input_selected function
                   and changing it to int value at the same time */
                array[i] = input_selected(reader);
            }
            return array;
        }




        /// <summary>
        /// writing the result output in a textwriter stream : System Console in the main program run calling and
        /// a manual textwriter stream when unit testing
        /// </summary>
        /// <param name="result"> double value of final result of calculation </param>
        /// <param name="writer"> a Textwriter stream of System.IO </param>
        public static void output_result(double result, TextWriter writer)
        {
            // printing the final result into TextWriter stream of choice (Console by program running)
            writer.WriteLine(result);
        }
        /// <summary>
        /// getting the main array of integers and the selected integer grom user and calculating
        /// the probability of be chosen by a random selection using the calculate_prob function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // the main integer array with 8 elements
            int[] array = new int[8];
            // getting the integer array from user by calling input_arr function
            input_arr(array, Console.In);
            // holder of the selected integer by user
            int input = 0;
            do
            {
                // getting the selected integer from the user by calling the input_selected function
                input = input_selected(Console.In);
                // breaking from the while loop if the user entered "-1" value.
                if (input == -1)
                    break;
                /* writing the result to console using output_result function call and passing the
                   calculate_prob function return value as the argument */
                output_result(calculate_prob(array, input), Console.Out);
            } while (input != -1);
        }
    }
}


