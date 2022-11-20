using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
       
        

      

     
    }
}
