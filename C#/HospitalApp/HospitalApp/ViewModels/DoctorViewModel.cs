using System.ComponentModel.DataAnnotations;

namespace HospitalApp.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public string SurName { get; set; }
    
        public string Specialty { get; set; }
 
        public int VisitDuration { get; set; }

        public IFormFile image { get; set; }
    }
}
