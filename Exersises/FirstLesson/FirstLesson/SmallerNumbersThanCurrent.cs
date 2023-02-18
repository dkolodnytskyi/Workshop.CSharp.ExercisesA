using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    internal class SmallerNumbersThanCurrent
    {
        public static List<int> SmallerThanCurrent(int[] nums)
        {
            List<int> Arr = new List<int>();
            int biggernumber = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] < nums[i] && i != j)
                    {

                        biggernumber++;
                    }

                }

                Arr.Add(biggernumber);
                biggernumber = 0;

            }

            /*int[] arr = Arr.ToArray();
            return arr;*/

            return Arr;
        }


        public static void Test()
        {
            int[] nums = new[] { 8, 1, 2, 2, 3 };
            List<int> result = SmallerThanCurrent(nums); 
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            
        }
}
    }
