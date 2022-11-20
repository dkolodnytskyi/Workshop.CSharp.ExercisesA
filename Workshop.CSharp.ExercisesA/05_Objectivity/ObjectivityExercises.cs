using System;
using System.Collections.Generic;
using System.ComponentModel;
using Workshop.Common;

namespace Workshop.CSharp.Objectivity.ExercisesB
{
    [TestClass]
    public class ObjectivityExercises
    {
        /// <summary>
        /// Napisac klase Class {Name:string, RoomNumber:int} reprezetnujaca przedmiot, a nastepnie:
        /// - przeciezyc metode ToString() zwracajaca informacje o przedmiocie
        /// - zaimplementowac interfejs ISaveable
        /// - zaimplementowac interfejs INotifyPropertyChanged (analogicznie do wczesniejszej klasy Customer)
        /// 
        /// Przetestowac dzialanie klasy z za pomoca SchoolManager.
        /// 
        /// Napisac klase 'ClassComparer : IComparer<Class>' porownujaca obiekty przedmiotow porownujac
        /// numery pokojow w ktorych sa prowadzone. Wykorzytac ClassComparer do posortowania tablicy przedmiotow
        /// za pomoca metody 'Array.Sort(tablica, comparer)'
        /// </summary>
        [TestMethod]
        public void ObjectsInterfaces()  
        {
            var magazine = new Magazine("Test",100);

            Console.WriteLine(magazine);
        }

       abstract class Periodical
        {
            public string Name { get; set; }

            public int NumOfPages { get; set; }

            public Periodical(string name, int numOfPages)
            {
                Name = name;
                NumOfPages = numOfPages;
            }

            public override string ToString()
            {
                return Name;
            }

            /*public virtual int GetNumberPages();*/
        }

        sealed class Magazine : Periodical
        {
            public Magazine(string name, int numOfPages) : base(name, numOfPages)
            {
            }
        }




        public class Class
        {
            public string Name { get; set;}

            public int RoomNumber { get; set;}


            public override string ToString()
            {
                return Name;
            }
        }

        public interface ISaveable
        {

        }

        /*public interface INotifyPropertyChanged*/




    }
}
