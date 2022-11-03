namespace WebApplication2.Models
{
    public class Doctor
    {
        public string Name { get; private set; }
        public string SurName { get; private set; }
        public string Specialty { get; private set; }
        public List<DateTime> SurDate { get; set; }


        public Doctor(string name, string surName, string specialty)
        {
            Name = name;
            SurName = surName;
            Specialty = specialty;
            SurDate = new List<DateTime> { };
        }
    }
}
