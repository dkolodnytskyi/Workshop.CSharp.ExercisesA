using System;
using System.Linq;
using NUnit.Framework.Constraints;
using Workshop.Common;

namespace Workshop.CSharp.ClassesObjects.ExercisesB
{
    //[TestClass]
    public class ClassesObjectsExercises
    {
        /// <summary>
        /// Zdefiniowac klase IntPair { Value1:int, Value2:int } posiadajaca:
        /// - 3 konstruktury:
        /// -- domyslny
        /// -- przyjmujacy dwa parametry value1 i value2 ustawiajace wlasciwosci Value1 i Value2
        /// -- przyjmujacy jeden parametr value ustawiajacy wlasciwosci Value1 i Value2
        /// - metode instancyjna 'Swap()' zamieniajaca wartosci Value1 i Value2 
        /// 
        /// Napisac metode statyczna 'IntPair FindMaxMin(int[])' znajdujaca maksymalna i minimalna wartosc
        /// przekazanej tabicy zwracajac obiekt 'IntPair(min,max)'
        /// 
        /// Napisac kod testujacy dzialanie klasy oraz metody.
        /// </summary>
        [TestMethod]
        public void IntPairs()
        {
            IntPair intPair = new IntPair(2, 4);
            var result = IntPair.FindMaxValue(new int[] { 2, 1, 4, -1, 0 });
            Console.WriteLine("max" + result.Value1 + "min" + result.Value2);

        }

        class IntPair
        {
            public int Value1 { get; set; }
            public int Value2 { get; set; }


            public IntPair()
            {

            }

            public IntPair(int value)
            {
                value = Value1 = Value2;

            }

            public IntPair(int value1, int value2)
            {
                Value1 = value1;
                Value2 = value2;
            }

            public void Swap()
            {
                Value1 = Value2;
            }

            public static IntPair FindMaxValue(int[] arr)
            {
                int min = 0;
                int max = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                    else if (arr[i] < min)
                    {
                        min = arr[i];
                    }


                }

                return new IntPair(max, min);

            }

        }



        /// <summary>
        /// Zdefiniowac klase Employee {Name:string, DateOfEmployment:DateTime, Salary:decimal} posiadajaca:
        /// - konstruktor ustawiajacy wlasciwosc DateOfEmployment, ktorej nie mozna zmienic po zainicjowaniu w konstruktorze
        /// - wlasciwosc Salary uniemozliwiajaca ustawienie pensji mniejszej jak 0 oraz mniejszej jak aktualna wartosc pesja 
        /// (mozna dac jedynie podwyzke :) )        
        /// - instancyjna metode GiveARise() dajaca powyzke o procent rowny ilosci przepracowanych lat.
        /// - statyczna metode 'decimal CalculateAverageSalary(Employee[])' liczaca srednia pensje dla przekazanej tablicy pracownikow.
        /// 
        /// Napisac kod testujacy dzialanie klasy.
        /// </summary>
        [TestMethod]
        public void Employees() 
        {
            var daniel = new Employee("Daniel", new DateTime(2012, 1, 1),100);
            var Marcin = new Employee("Marcin", new DateTime(2020, 1, 1), 200);

            Console.WriteLine("Pracownik " + daniel.Name + "zarabia" + daniel.Salary);
            daniel.GiveARise();
            
        }

        public class Employee
        {
            DateTime CurrentTime = DateTime.Now;
            

            public string Name { get; private set; }
            public DateTime DateOfEmployement { get; private set; }
            private decimal _salary;

            public decimal Salary
            {
                get
                {
                    return _salary;
                }
                set
                {
                    if (value > 0 && value > _salary)
                        _salary = value;
                }
            }
                    
            

            public Employee(string name,DateTime dateofemployement,decimal salary)
            {
                Name = name;
                DateOfEmployement = dateofemployement;
                salary = _salary; 



            }
            public void GiveARise()
            {
              

            }

            public static decimal CalculateAverageSalary(Employee[] arr)
            {
                if (arr.Length == 0)
                    return 0;

                decimal sum = 0;
                foreach (var employee in arr)
                {
                    sum += employee._salary;

                }
                return sum/arr.Length;

            }


        }
    }
}
