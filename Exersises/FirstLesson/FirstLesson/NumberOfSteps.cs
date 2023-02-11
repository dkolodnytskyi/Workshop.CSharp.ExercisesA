using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    public class NumberOfSteps
    {
        public static int NumberOfStepsNum(int num)
        {
            int steps = 0;
            do
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                    steps++;
                }
                else if (num % 2 == 1)
                {
                    num -= 1;
                    steps++;

                }
            }
            while (num != 0);


            return steps;

        }


        public static void Test()
        {
            NumberOfSteps numberOfSteps = new NumberOfSteps();

            int num = 10;



        }
    }
}
