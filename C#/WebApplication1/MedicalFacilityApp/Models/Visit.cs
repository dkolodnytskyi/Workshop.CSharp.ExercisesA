using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public string ReasonOfVisit { get; set; }
    }
}
