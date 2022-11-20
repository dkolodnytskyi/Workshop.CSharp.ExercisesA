namespace WebApplication2.Models
{
    public class Administrator
    {
        public Doctor Doctor { get; set; }
        public Visit Visit { get; set; }

        public static List<Doctor> doctors = new List<Doctor>();
        public static List<Patient> patients = new List<Patient>();
        public static List<Visit> visits = new List<Visit>(); 
        List<List<DateTime>> ListsOfTerms = new List<List<DateTime>>();
        
        
        

        public void SortedDoctorsList(Func<Doctor,string> SortedBy)
        {
           doctors = doctors.OrderBy(SortedBy).ToList();
            
        }

        /*public void AddDocotor(string DoctorName, string DoctorSurName, string DocotrSpecialty)
        {
            Doctor doctor = new Doctor(DoctorName, DoctorSurName, DocotrSpecialty);
            doctors.Add(doctor);
            

        }*/

        public void ShowDoctors()
        {
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{doctor.Name} {doctor.SurName} {doctor.Specialty}");
            }
        }

        public void RemoveDocByName(string name)
        {
           /* foreach(var doctor in doctors)
                if(doctor.Name == name)
                {
                    doctors.Remove(doctor);
                }*/

            doctors = doctors.SkipWhile(x => x.Name == name).ToList();
        }

        public void EditDoctor()
        {

        }

        

    }
}
