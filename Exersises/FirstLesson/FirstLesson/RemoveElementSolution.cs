using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    internal  class RemoveElementSolution
    {
        public static int RemoveElement(int[] nums, int val)
        {
            int result = 0;
            List<int> list = nums.ToList();
            var arr = list.Where(x=>x!=val);

            result = arr.Count();

            return result;
        }

        public static void Test()
        {
            int[] nums = new[] { 3, 2, 2, 3 };
            int val = 3;

            int result = RemoveElement(nums, val);

            Console.WriteLine(result);
        }

    }

    

    
}
