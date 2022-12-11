using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    internal class LongestCommonPrefix
    {
        public  string LongestPrefix(string[] arr_strings)
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


        public static void Test()
        {
            var Ex = new LongestCommonPrefix();

            string[] arr_strings1 = { "flower", "flow", "flight" };
            Console.WriteLine("Original number: " + $"{string.Join(", ", arr_strings1)}");
            Console.WriteLine("Longest common prefix from the said array of strings: " + Ex.LongestPrefix(arr_strings1));
        }
    }
}
