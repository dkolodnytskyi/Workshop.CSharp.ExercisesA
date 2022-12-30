using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services.Interfaces

{
    public interface IDoctorService
    {
 
        Task CreateAsync(Doctor doctor);
        
        Doctor Update(int? id);

        Task SaveChangesAsync(Doctor doctor);

        Task DeleteAsync(int? id);

        IEnumerable<Doctor> GetDoctors();
        

        
    }
}
