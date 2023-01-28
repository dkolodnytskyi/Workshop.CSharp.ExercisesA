using System.ComponentModel.DataAnnotations;

namespace HospitalApp.ViewModels
{
    public class VisitViewModel
    {        
        public int DoctorId { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "U cant use numbers in your name")]
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "length must be between 3 to 15")]
        public string PatientName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "U cant use numbers in your surname")]
        [Required(ErrorMessage = "Please enter your SurName")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "length must be between 3 to 20")]
        public string PatientSurName { get; set; }
        public DateTime DayOfVisit { get; set; }
        public DateTime TimeOfVisit { get; set; }
        public DateTime DateOfBirth { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "U cant use numbers")]
        [Required(ErrorMessage = "Please enter the reason of visit")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "length must be between 3 to 20")]
        public string ReasonOfVisit { get; set; }
    }
}
