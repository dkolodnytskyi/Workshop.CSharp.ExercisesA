using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    public class SearchInsert
    {
        public static int SearchInsertNumbs(int[] nums, int target)
        {
            int index = Array.IndexOf(nums, target);

            if (index == -1)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (target > nums[i])
                    {
                        List<int> newlist = nums.ToList();
                        newlist.Insert(i + 1, target);
                        index = i + 1;

                    }
                }

            }
            return index;

        }


        public static void Test()
        {
            int[] nums = new[] { 1, 1, 2, 2, 3, 3, 5, 6, };

            int num = 10;
            Console.WriteLine(SearchInsertNumbs(nums,num));
        }
    }
}
