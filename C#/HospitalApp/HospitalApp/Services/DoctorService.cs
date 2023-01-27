using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Services.Interfaces;

namespace HospitalApp.Services
{
    public class DoctorService : IDoctorService
    {
        public AdministratorContext db;

        public DoctorService(AdministratorContext db)
        {
            this.db = db;
        }


        public async Task CreateAsync(Doctor doctor)
        {
            await db.doctors.AddAsync(doctor);

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            Doctor doctor = db.doctors.FirstOrDefault(m => m.Id == id);
            db.doctors.Remove(doctor);
            await db.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(Doctor doctor)
        {
            db.Remove(doctor);
            await db.SaveChangesAsync();
        }

        public Doctor Update(int? id)
        {
            return db.doctors.FirstOrDefault(v => v.Id == id);

        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return db.doctors;
        }

        public IEnumerable<Doctor> FilterByName(string name)
        {
            if (name == null)
            {
                return GetDoctors();
            }

            return db.doctors.Where(n => n.Name.Contains(name))
                      .OrderBy(n => n.Name);

        }

        public IEnumerable<Doctor> FilterBySurName(string surName)
        {
            if (surName == null)
            {
                return GetDoctors();
            }

            return db.doctors.Where(n => n.SurName.Contains(surName))
                      .OrderBy(n => n.SurName);

        }

        public IEnumerable<Doctor> FilterBySpeciality(string speciality)
        {
            if (speciality == null)
            {
                return GetDoctors();
            }

            return db.doctors.Where(n => n.Specialty == speciality);

        }
       

        public IEnumerable<Doctor> Filter(string name, string surName, string speciality)
        {
            if (name == null && surName == null && speciality == null)
            {
                return GetDoctors();
            }

            var filterbyname = FilterByName(name);
            var filterbysurname = FilterBySurName(surName);
            var filterbyspeciality = FilterBySpeciality(speciality);

            

           return filterbyname.Intersect(filterbysurname).Intersect(filterbyspeciality);

        }

        
    }
}
