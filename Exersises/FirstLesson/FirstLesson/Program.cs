namespace FirstLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Duplicates.Test();

            



        }


        



    }


        /*public static int SearchInsert(int[] nums, int target)
        {
            int index = Array.IndexOf(nums, target);
     
            if(index == -1)
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

        }*/




        /* public static int NumberOfSteps(int num)
         {
             int steps = 0;
             do
             {
                 if (num % 2 == 0)
                 {
                     num /= 2;
                     steps++;
                 }
                 else if (num % 2 == 1)
                 {
                     num -= 1;
                     steps++;

                 }
             }
             while (num != 0);


             return steps;

         }*/

        /* public static bool IsSebsuqence(string s, string t)
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
         }*/

        /* public static int FirstUniqChar(string s)
         {
             int result = 0;

             for (int i = 0; i < s.Length; i++)
             {
                 for (int j = i + 1; j < s.Length; j++)
                 {
                     if (s[i] != s[j])
                     {
                         j++;
                     }
                     else if (s[i] == s[j])
                     {
                         i++;

                     }

                     else if (s[i] == s[j] && s[i] == s.Length)
                     {
                         return -1;
                     }


                 }

             }


         }*/

        /*public static int[] SmallerNumbersThanCurrent(int[] nums)
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

            int[] arr = Arr.ToArray();
            return arr;
        }*/

        /*public List<List<int>> Generate(int numRows)
        {
            
        }*/

        /*public static int[] PlusOne(params int[] digits)
        {
            
            int num;
            if (Int32.TryParse(string.Join("", digits), out num))
            {
                num += 1;
                return digitArr(num);
            }
            else
            {
                return new int[] {-1};
                //failed - too many digits in the array
            }
        }*/

        /*public static int[] digitArr(int n)
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
        }*/

        /*public static string test(string[] arr_strings)
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

        }*/
    }
