using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    internal class Duplicates
    {
        public int RemoveDuplicates(int[] nums)
        {
            List<int> result = new List<int>();
            result.Add(nums[0]);

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] != result[j])
                    {
                        result.Add(result[j]);

                    }

                }
                
                


            }

            return result.Count;
        }



        public static void Test()
        {
            Duplicates duplicates = new Duplicates();

            int[] nums = new[] { 1, 1, 2, 2, 3, 3, 5, 6, };

            Console.WriteLine(duplicates.RemoveDuplicates(nums)); 
        }

    }
}
