using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    internal class FirstUniqChar
    {
        public static int FirstUniq(string s)
        {
            int result = 0;
            bool findChar = true;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                    {
                        findChar = false;
                        break;
                    }
                   


                }
                if (findChar == true)
                {
                    return i;
                }

            }

            return -1;


        }

        public static void Test()
        {
            string s = "letmein";

            Console.WriteLine(FirstUniq(s));
        }
    }
}
