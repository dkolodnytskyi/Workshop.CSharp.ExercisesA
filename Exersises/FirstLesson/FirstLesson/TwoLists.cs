using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    internal class TwoLists
    {
        public IEnumerable<int> MergeTwoLists(List<int> list1, List<int> list2)
        {
            List<int> result = new List<int>();

            /*for (int i = 0; i < list1.Count; i++)
            {
                for (int j = 0; j < list2.Count; j++)
                {
                    if (list1[i] >= list2[j])
                    {
                        result.Add(list2[j]);


                    }
                    else
                    {
                        result.Add(list1[i]);
                    }

                    
                }

            }*/

            

            return result;

        }

        public static void Test()
        {
            var ex = new TwoLists();

            List<int> list1 = new () { 1, 1 , 2, 3, 4 };
            List<int> list2 = new () { 3, 5, 6, 7, 8, };

            var result = ex.MergeTwoLists(list1 , list2);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            

        }

    }
}
