using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "U cant use numbers in your name")]
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name length must be between 3 to 15")]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "U cant use numbers in your surname")]
        [Required(ErrorMessage = "Please enter your SurName")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "surname length must be between 3 to 20")]
        public string SurName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "U cant use numbers in your specialty")]
        [Required(ErrorMessage = "Please enter your specialty")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "specialty length must be between 3 to 20")]
        public string Specialty { get; set; }
        [Range(0,60)]
        public int VisitDuration { get; set; }
        public byte[] image { get; set; }


        /*public Doctor(string name, string surName, string specialty)
        {
            Name = name;
            SurName = surName;
            Specialty = specialty;
            SurDate = new List<DateTime> { };
        }*/
    }
}
