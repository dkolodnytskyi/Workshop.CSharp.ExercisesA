using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Workshop.CSharp.Data;
using Workshop.CSharp.Data.SampleData;
using Workshop.Common;

namespace Workshop.CSharp.CSharp3.ExercisesB
{
    [TestClass]
    public class LinqExercises
    {
        // Uwagi:
        // - do wypisywania danych na ekran wykorzystac metode rozszerzajaca 'Workshop.Common.Extensions.Print(this object o)'
        // - dane na ktorych wykonywane sa zapytania pobierac za pomoca 'DataProvider.Products/Categories


        /// <summary>
        /// Zapytanie zwracajace ProductName i UnitPrice produktow ktorych UnitPrice jest wieksza od 50.
        /// (where, select)
        /// </summary>
        [TestMethod]
        public void WhereSelect()  
        {
            /*var result = DataProvider.Products.Where(p => p.UnitPrice > 10);

            result.Print();*/

            var exercises = DataProvider.Products
                .Where(p => p.UnitPrice > 50 && p.UnitPrice < 100)
                .Select(p => new { p.UnitPrice, p.ProductName }).ToList();
            exercises.Print();
        }

        /// <summary>
        /// Zapytanie zwracajace nazwy i wartosci calkowite (=UnitPrice*UnitsInStock) produktow, posortowane 
        /// malejaco po wartosciach calkowitych.
        /// (let, orderby, select)
        /// </summary>
        [TestMethod]
        public void LetOrderBy() 
        {
            var result = DataProvider.Products
                .Select(p => new { p.ProductName, Total = p.UnitPrice * p.UnitsInStock })
                .OrderBy(m => m.Total);
            result.Print();
        }

        /// <summary>
        /// Zapytanie zwracajace nazwy ProductName oraz nazwy CategoryName, posortowane po CategoryName
        /// a nastepnie po ProductName.
        /// (join, orderby, select)
        /// </summary>
        [TestMethod]
        public void Join()  
        {
            
        }

        /// <summary>
        /// Zapytanie zwracajace druga piatke najdrozszych produktow.
        /// (orderby, skip, take)
        /// </summary>
        [TestMethod]
        public void TakeSkip()  
        {
            var result1 = DataProvider.Products.OrderByDescending(p => p.UnitPrice)
                .Skip(5)
                .Take(5);
        }


        /// <summary>
        /// Napisac kod na ktory podstawie pliku XML z produktami (sciezka 'Path.Combine(Environment.CurrentDirectory, "Data/SampleData/Products.xml")'
        /// tworzy nowy plik XML zawierajacy informacje o produktach (id,name,unitsInStock) spelniajacych
        /// warunek 'UnitsInStock>100', posortowanych malejaco po UnitsInStock. Przykladowy plik wynikowy:        
        /// <Raport><Product id="73" name="Rod Kaviar" unitsInStock="101" /> ... </Raport>
        /// </summary>
        [TestMethod]
        public void LinqToXml()  {  }



    }
}
