namespace WebApplication2.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string SurName { get; private set; }
        public string ReasonOfVisit { get; private set; }



        public Patient(int id, string name, string surName, string reasonOfVisit)
        {
            Id = id;
            Name = name;
            SurName = surName;
            ReasonOfVisit = reasonOfVisit;
            
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
