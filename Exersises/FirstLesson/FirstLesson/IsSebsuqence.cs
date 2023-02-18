using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    internal class IsSebsuqence
    {
        public static bool IsSebsuqencE(string s, string t)
        {
            string test = "";
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < t.Length; j++)
                {
                    if (s[i] == t[j])
                    {
                        test += t[j];

                    }

                }

            }

            return test == s;
        }


        public static void Test()
        {
            string s = "abc";
            string t = "ahbgdc";

            Console.WriteLine(IsSebsuqencE(s,t));
        }
    }
}
