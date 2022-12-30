using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services
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
    }
}
