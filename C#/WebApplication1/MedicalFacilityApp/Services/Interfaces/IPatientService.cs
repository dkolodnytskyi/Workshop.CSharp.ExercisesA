using WebApplication2.Models;

namespace WebApplication2.Services.Interfaces
{
    public interface IPatientService
    {
        Task CreateAsync(Patient patient);

        Patient Update(int? id);

        Task SaveChangesAsync(Patient patient);

        void Delete(int? id);

        IEnumerable<Patient> GetPatients();
    }
}
