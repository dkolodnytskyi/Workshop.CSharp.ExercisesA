using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    internal class SolutionPlusOne
    {
        public static int[] PlusOne(params int[] digits)
        {

            int num;
            if (Int32.TryParse(string.Join("", digits), out num))
            {
                num += 1;
                return digitArr(num);
            }
            else
            {
                return new int[] { -1 };
                //failed - too many digits in the array
            }
        }

        public static int[] digitArr(int n)
        {
            if (n == 0) return new int[1] { 0 };

            var digits = new List<int>();

            for (; n != 0; n /= 10)
            {
                var aa = n % 10;
                digits.Add(n % 10);

            }


            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }

        public static string Test(string[] arr_strings)
        {
            if (arr_strings.Length == 0 || Array.IndexOf(arr_strings, "") != -1)
                return "";
            string result = arr_strings[0];
            int i = result.Length;
            foreach (string word in arr_strings)
            {
                int j = 0;
                foreach (char c in word)
                {
                    if (j >= i || result[j] != c)
                        break;
                    j += 1;
                }
                i = Math.Min(i, j);
            }
            return result.Substring(0, i);

        }
    }
}
