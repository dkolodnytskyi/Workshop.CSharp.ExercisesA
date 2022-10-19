using Workshop.Common;

namespace Workshop.CSharp.Introduction.ExercisesB
{
    /*[TestClass]*/
    public class IntroductionExercises
    {
        /// <summary>
        /// Zaimplementowac ponizsza metode w nastepujacy sposob:
        /// "
        ///  Podaj liczbe a: ...
        ///  Podaj liczbe b: ...
        ///  Wynik a + b =  ...
        /// "
        /// Uwaga: skorzystac z metody int.Parse do zamiany string na int.
        /// </summary>
        [TestMethod]
        public void ConsoleDialog() {

            Console.WriteLine("podaj 1 liczbe");
            string a = Console.ReadLine();
            Console.WriteLine("podaj 2 liczbe");
            string b = Console.ReadLine();
            int resultA = int.Parse(a);
            int resultB = int.Parse(b);
            
            Console.WriteLine(resultA + resultB);

        }

        /// <summary>
        /// Zaimplementowac ponizsza metode tak ze wywoluje w petli metode 'ConsoleDialog' poprzedzajac kazda 
        /// iteracje pytaniem "Czy liczyc dalej? : ". Jesli uzytkownik odpowie "nie" to petla jest przerywana.
        /// </summary>
        [TestMethod]
        public void ConsoleDialogInLoop() {

            bool end = false;
            while (!end)
            {
                Console.WriteLine("Czy liczyc dalej?");
                string answer = Console.ReadLine();  
                if (!end)
                {
                    ConsoleDialog();
                }
            }
       
        }

        /// <summary>
        /// Napisac metode 'SumPositiveNumbers' liczaca sume liczb dodatnich znajdujacej sie przekazanej tablicy.
        /// 
        /// Napisac kod testujacy metode.
        /// </summary>   
        [TestMethod]
        public void SumPositiveNumbersRunner() {
            int[] array = { 2, -1, 3, -6, -10, -21, 21, 13 };
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    result += array[i];
                }
                
            }

            Console.WriteLine(result);
        
        }
    }
}
