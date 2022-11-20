using System;
using System.Collections.Generic;
using System.ComponentModel;
using Workshop.Common;

namespace Workshop.CSharp.CSharp2.ExercisesB
{
[TestClass]
    public class DelegatesExercises
    {
        /// <summary>
        /// Posortowac liste napisow po ich dlugosci wykorzystujac metode listy 'Sort(Comparison<T> comparison)'
        /// 
        ///
        /// Zaimplementowac nastepujace metody:
        /// - 'List<T> Where<T>(List<T> items, Func<T,bool> predicate)' dzialajaca analogicznie do metody listy FindAll
        /// - 'T First<T>(List<T> items, Func<T, bool> predicate)' dzialajaca analogicznie do metody listy Find
        /// 
        /// Podpowiedzi: 
        /// - w dowolnym miejscu w kodzie metody mozemy wywolac "return wartosc;" przerywajac jej dzialanie i zwracajac wynik
        /// - wyrazenie 'default(nazwa_typu)' zwraca domyslna wartosc dla przekazanego typu
        ///
        /// Napisac kod testujacy dzialanie metod.
        /// </summary>
        [TestMethod]
        public void Delegates()  
        {
            var list = new List<string> { "one", "two", "three", "four", "five", "six" };
            list.Sort((a, b) => a.Length > b.Length ? 1 : (a.Length < b.Length ? -1 : 0));
            /*if (a.Length > b.Length)
                return 1;
            else if (a.Length < b.Length)
                return -1;

            return 0;*/
            var list2 = new List<int> { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(string.Join(",",list));
            var result = Where(list2, item => item > 2);
 
            

        }

        List<T> Where<T>(List<T> items, Predicate<T> predicate)
        {
            var result = new List<T>();
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }
            return result;

        }

        T First<T>(List<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default;
        }






        /// <summary>
        /// Zdefiniowac klase Customer{Name:string,Address:string} posiadajca zdarzenie 
        /// 'event PropertyChangedEventHandler PropertyChanged' informujace o zmienia wartosci kazdej 
        /// z wlasciwoci.
        /// 
        /// delegat PropertyChangedEventHandler znajduje sie w w przestrzeni nazw 'System.ComponentModel' 
        /// 
        /// Napisac kod testujacy dzialanie zdarzenia.
        /// </summary>
        [TestMethod]
        public void Events()  
        {
            var customer = new Customer();
            customer.PropertyChanged += (sender, e) => 
            {
                Console.WriteLine("Zmiemila sie wlasciwosc {0}", e.PropertyName);
            };

            customer.Name = "Daniel";
            customer.Name += "!";
            customer.Address = "Krakow";
        }

        class Customer
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public string _name;
            public string _address;
            public string Name
            {
                get => _name;
                set
                {
                    _name = value;
                    OnPropertyChande(new PropertyChangedEventArgs("Name"));
                }
            }
            public string Address
            {
                get => _address;
                set
                {
                    _address = value;
                    OnPropertyChande(new PropertyChangedEventArgs("Address"));
                }
            }

            private void OnPropertyChande(PropertyChangedEventArgs args)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, args);
                }
            }
            

        }       
    }
}
