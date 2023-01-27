using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "U cant use numbers in your name")]
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(15,MinimumLength =3, ErrorMessage ="Name length must be between 3 to 15")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "U cant use numbers in your surname")]
        [Required(ErrorMessage = "Please enter your SurName")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name length must be between 3 to 20")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth")]
        public DateTime DateOfBirth { get; set; }


       
        

      

     
    }
}
