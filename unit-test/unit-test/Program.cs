using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_test
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static bool IsSorted(int[] grades, bool asc)
        {
            int LastGrade = grades[0];
            foreach (int grade in grades)
            {
                if (asc)
                {
                    if (grade < LastGrade)
                    {
                        return false;
                    }
                    else
                    {
                        LastGrade = grade;
                    }
                }

                else
                {
                    if (grade > LastGrade)
                    {
                        return false;
                    }
                    else
                    {
                        LastGrade = grade;
                    }
                }
            }
            return true;

        }

    }
}
