namespace WebApplication2.Models
{
    public class Visit
    {
        public Patient patient { get; set; }
        public Doctor doctor { get; set; }

        public string ReasonOfVisit { get; set; }
    }
}
