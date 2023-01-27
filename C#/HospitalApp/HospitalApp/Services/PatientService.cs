using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Services.Interfaces;

namespace HospitalApp.Services
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

        public IEnumerable<Patient> Filter(string name, string surName)
        {
            if (name == null && surName == null)
            {
                return GetPatients();
            }

            var filterbyname = FilterByName(name);
            var filterbysurname = FilterBySurName(surName);



            return filterbyname.Intersect(filterbysurname);
        }

        public IEnumerable<Patient> FilterByName(string name)
        {
            if (name == null)
            {
                return GetPatients();
            }

            return db.patients.Where(n => n.Name.Contains(name))
                      .OrderBy(n => n.Name);
        }

        public IEnumerable<Patient> FilterBySurName(string surName)
        {
            if (surName == null)
            {
                return GetPatients();
            }

            return db.patients.Where(n => n.SurName.Contains(surName))
                      .OrderBy(n => n.SurName);
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
