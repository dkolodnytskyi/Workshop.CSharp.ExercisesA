using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Common;


namespace Workshop.CSharp.ExercisesA.Alg1
{
    [TestClass]
    internal class Ex1
    {

        public int NumberOfSteps(int num)
        {
            int steps = 0;
            do
            {
                if (num % 2 == 0)
                {
                    num %= 2;
                    steps++;
                }
                else if (num % 2 == 1)
                {
                    num -= 1;
                    steps++;

                }
            }
            while (num == 0);


            return steps;

        }

        public bool IsSebsuqence(string c, string t)
        {
            for (int i = 0; i < c.Length; i++)
            {
                for (int j = 0; j < t.Length; j++)
                {
                    if (c[i] == t[j])
                    {
                        i++;
                    }

                    else return false;

                }
            }
            return true;
        }

        public int FirstUniqChar(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                    {
                        result = s.IndexOf(s[i]);
                    }

                    else return -1;

                }

            }

            return result;
        }

        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            List<int> Arr = new List<int>();
            int biggernumber = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        biggernumber++;

                    }

                    Arr.Add(biggernumber);

                    


                }

            }

            int[] arr = Arr.ToArray();
            return arr;
        }

        /*public List<List<int>> Generate(int numRows)
        {

        }*/
        [TestMethod]
        public static void Test()
        {
            var ex1 = new Ex1();
            var result = ex1.NumberOfSteps(14);
            Console.WriteLine(result);
        }
    }
}
