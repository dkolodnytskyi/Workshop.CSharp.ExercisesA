namespace WebApplication2.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Specialty { get; set; }


        /*public Doctor(string name, string surName, string specialty)
        {
            Name = name;
            SurName = surName;
            Specialty = specialty;
            SurDate = new List<DateTime> { };
        }*/
    }
}
