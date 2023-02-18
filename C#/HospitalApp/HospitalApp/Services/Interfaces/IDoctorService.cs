using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.ViewModels;

namespace HospitalApp.Services.Interfaces

{
    public interface IDoctorService
    {
 
        Task CreateAsync(DoctorViewModel doctor);
        
        Doctor Update(int? id);

        Task SaveChangesAsync(Doctor doctor);

        Task DeleteAsync(int? id);

        IEnumerable<Doctor> GetDoctors();

        Doctor GetDoctorById(int id);

        IEnumerable<Doctor> FilterByName(string name);

        IEnumerable<Doctor> FilterBySurName(string surName);

        IEnumerable<Doctor> FilterBySpeciality(string speciality);

        IEnumerable<Doctor> FilterByDuration(int? duration);
       
        IEnumerable<Doctor> Filter(string name, string surName, string speciality, int? duration);


    }
}
