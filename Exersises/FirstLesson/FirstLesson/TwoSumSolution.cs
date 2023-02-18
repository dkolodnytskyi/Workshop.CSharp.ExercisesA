using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    internal class TwoSumSolution
    {
        public static List<int> TwoSum(int[] nums, int target)
        {
            List<int> result = new List<int>();
            bool done = true;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        done = false;
                        result.Add(i);
                        result.Add(j);
                        break;
                    }


                }
            }

            return result;
        }


        public static void Test()
        {
            int[] nums = new[] { 3, 2, 4 };

            int target = 6;

            var result = TwoSum(nums, target);

            foreach (var item in result)
            {
                Console.WriteLine(item);

            }

        }
    }
}
