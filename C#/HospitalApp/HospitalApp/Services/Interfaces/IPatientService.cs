using HospitalApp.Models;

namespace HospitalApp.Services.Interfaces
{
    public interface IPatientService
    {
        Task CreateAsync(Patient patient);

        Patient Update(int? id);

        Task SaveChangesAsync(Patient patient);

        void Delete(int? id);

        IEnumerable<Patient> GetPatients();

        IEnumerable<Patient> FilterByName(string name);

        IEnumerable<Patient> FilterBySurName(string surName);

        IEnumerable<Patient> Filter(string name, string surName);
    }
}
