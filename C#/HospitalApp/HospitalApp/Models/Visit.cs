using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Models
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOfVisit { get; set; }

        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

        public string ReasonOfVisit { get; set; }

        

        
    }
}
