namespace WebApplication2.ViewModels
{
    public class VisitViewModel
    {        
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurName { get; set; }
        public DateTime DayOfVisit { get; set; }
        public DateTime TimeOfVisit { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ReasonOfVisit { get; set; }
    }
}
