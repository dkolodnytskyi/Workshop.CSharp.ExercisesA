using System;
using System.Collections.Generic;
using System.IO.Ports;
using Workshop.Common;

namespace Workshop.CSharp.CSharp2.ExercisesB
{
    [TestClass]
    public class GenericExercises
    {
        /// <summary>
        /// Napisac klase Pair<T> analogiczna dla IntPair zastepujac typ 'int' typem 'T'.
        /// 
        /// Napisac kod testujacy dzialanie klasy.
        /// </summary>
        [TestMethod]
        public void GenericPairs() 
        {
            Pair<double> pair = new Pair<double>(1.0, 2.9);
            Console.WriteLine("v1={0} v2={1}", pair.Value1,pair.Value2);
            pair.Swap();
            Console.WriteLine("v1={0} v2={1}", pair.Value1, pair.Value2);
        }

        public class Pair<T>
        {
            public T Value1 { get; private set; }
            public T Value2 { get; private set; }


            public Pair()
            {

            }

            public Pair(T value)
            {
                Value1 = Value2 = value;

            }

            public Pair(T value1, T value2)
            {
                Value1 = value1;
                Value2 = value2;
            }

            public void Swap()
            {
                Value1 = Value2;
            }
        }
        
        /// <summary>
        /// Napisac metode 'Dictionary<int,int> Histogram(List<string> items)' ktora zlicza ilosc elementow 
        /// o takiej samej dlugosci. Przykladowo dla list { "a", "aa", "aa", "aaaa"} wynikiem jest 
        /// { {1,1} , {2,2} , {4,1} }
        /// 
        /// 
        /// Napisac metode 'Dictionary<int, List<string>> GroupByLength(List<string> items)' ktora grupuje
        /// elementy po ich dlugosci. Przykladowo dla list { "a", "aa", "aa", "aaaa"} wynikiem jest
        /// { {1, {"a"}} , {2,{"aa","aa"}} , {4,{"aaaa"}} }
        /// 
        /// 
        /// Zdefiniowac typ wyliczeniowy Condition {Greater,Lower,Equal}
        /// 
        /// Napisac metode 'List<int> Filter(List<int> items, int value, Condition condition)"
        /// zwracajaca liste skladajaca sie z elementow rownych/mniejszych/wiekszych od 
        /// przekazanego parametru 'value'        
        /// </summary>
        [TestMethod]
        public void GenericCollections()
        {
            /*var sampleList = new List<string>() { "a", "aa", "aa", "aaaa"};
            var result = GroupByLength(sampleList);

            foreach (var key in result.Keys)
            {
                foreach (var value in result[key])
                {
                    Console.WriteLine($"key:{key} value:{value} ");

                }
            }*/

            var test = new List<int>() { 1,2,3,4,5,7,2,21,-1,0};
            var result = Filter(test, 4, Condition.Lower);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        public Dictionary<int, int> Histogram(List<string> items)
        {
            Dictionary<int,int> result = new Dictionary<int,int>();
            foreach (var item in items)
            {
                var len = item.Length;
                if (result.ContainsKey(len))
                {
                    result[len] += 1;
                }
                else
                {
                    result.Add(len, 1);
                }
            }

            return result;

        }

        public Dictionary<int, List<string>> GroupByLength(List<string> items)
        {
            Dictionary<int, List<string>> result = new Dictionary<int, List<string>>();
            foreach (var item in items)
            {
                var len = item.Length;
                if (result.ContainsKey(len))
                {
                    result[len].Add(item);
                }
                else
                {
                    result.Add(len, new List<string>{item});

                }
                
                

            }
            return result;
        }

        public enum Condition
        {
            Greater,
            Lower,
            Equal

        }

        public List<int> Filter(List<int> items, int value, Condition condition)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < items.Count; i++)
            {
                if(condition == Condition.Greater)
                {
                    if (items[i] > value)
                        result.Add(items[i]);                                       
                }


                else if(condition == Condition.Equal)
                {
                    if (items[i] == value)
                        result.Add(items[i]);
                }

                else if(condition == Condition.Lower)
                {
                    if(items[i] < value)
                        result.Add(items[i]);
                }
            }

            return result;
                


        }

        


    }
}
