using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services
{
    public class PatientService : IPatientService
    {

        AdministratorContext db;

        public PatientService(AdministratorContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(Patient patient)
        {
           await db.patients.AddAsync(patient);
           await db.SaveChangesAsync();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatients()
        {
            return db.patients;
        }

        public async Task SaveChangesAsync(Patient patient)
        {
            db.Update(patient);
            await db.SaveChangesAsync();
        }
        

        public Patient Update(int? id)
        {
            return db.patients.FirstOrDefault(v => v.Id == id);
        }
    }
}
