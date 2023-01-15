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

        IEnumerable<Doctor> FilterByName(string name);

        IEnumerable<Doctor> FilterBySurName(string surName);

        IEnumerable<Doctor> FilterBySpeciality(string speciality);

        IEnumerable<Doctor> Filter(string name, string surName, string speciality);


    }
}
