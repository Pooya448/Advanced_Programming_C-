using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probability_in_Array
{
    public class Program
    {
        /// <summary>
        /// calculating the probability of the selected integer by user using the probability 
        /// principals and math operator : division
        /// </summary>
        /// <param name="num_array"> the main array which hosts the selected integer</param>
        /// <param name="input"> the selected integer by the user for calculating it's probability
        /// of being chosen by a random selection </param>
        /// <returns> returns the probability result </returns>
        public static double calculate_prob (int[] num_array, int input)
        {
            /* declaration and initiation of counter as integer used for counting the quantity 
            of the selected integer in num_array */
            double counter = 0;
            foreach (int num in num_array)
            {
                if (num == input)
                {
                    counter++;
                }
            }
            // the final quantity of the probability calculation
            double prob = counter / 8;
            // returning the final result to the main function
            return prob;
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
            for (int i = 0; i<8; i++)
            {
                // getting the array elements from user as string and changing it into integer value
                array[i] = int.Parse(Console.ReadLine());
            }
            // holder of the selected integer by user
            int input;
            do
            {
                // getting integer from user as string value and changing it into int value
                input = int.Parse(Console.ReadLine());
                // printing the final result into the console
                Console.WriteLine(calculate_prob(array,input));

            } while (input != -1);
            

        }
    }
}


