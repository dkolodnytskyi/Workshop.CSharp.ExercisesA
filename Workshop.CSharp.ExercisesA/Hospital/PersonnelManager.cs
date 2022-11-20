using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using Workshop.Common;

namespace Workshop.CSharp.ExercisesA.Hospital
{
    [TestClass]
    internal class PersonnelManager
    {
        [TestMethod]    
        public static void Test()
        {
            


            
        }

        public interface IBage
        {
         
            string GetBadge();
        }

        public abstract class Person
        {
            public string Name { get; set; }
            public string Surnname { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Identifier { get; set; }

        }



        public sealed class Patient : Person
        {
            public string MainDiagosis { get; set;}

            public Patient(string maindiagnosis)
            {
                this.MainDiagosis = maindiagnosis;
            }

        }


        public abstract class Practitioner : Person, IBage
        {
            public string License { get; set; }

            public DateTime DateOfEmplyement { get; set; }

            protected string Phone { get; set; }

            public string Prefix { get; set; }

            public abstract string GetPhone(Person person);

            public virtual string GetBadge()
            {
                return $"Practitioner {Prefix} {Name} {Surnname}";
            }
        }

        public class Doctor : Practitioner
        {
            

            public override string GetPhone(Person person)
            {
                Console.WriteLine("{0} {1}", person.Name, person.Surnname);
                Console.WriteLine($"{person.Name} {person.Surnname} odczytal numer pelegniarki {Name} {Surnname}");
                return Phone;
            }

            public override string GetBadge()
            {
                return $"Practitioner {Prefix} {Name} {Surnname}";
            }
        }

        public class Nurse : Practitioner
        {
            public bool CanWritePrescriptions { get; set; }

            public override string GetPhone(Person person)
            {
                return Phone;
            }

            public override string GetBadge()
            {
                return $"Pielegniarka {Prefix} {Name} {Surnname}";
            }
        }

        public static class HospitalUtils
        {
            static void Print(Person[] people)
            {
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.Name} {person.Surnname} {person.Identifier}");
                }

            }

            static void GenarateBadges(IBage[] badges)
            {
                foreach (var badge in badges)
                {
                    Console.WriteLine($"{badge.GetBadge()}");
                }
                
            }
        }
    }
}
