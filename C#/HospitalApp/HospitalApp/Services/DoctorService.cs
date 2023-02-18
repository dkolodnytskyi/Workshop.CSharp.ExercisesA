using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Services.Interfaces;
using HospitalApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Services
{
    public class DoctorService : IDoctorService
    {
        public AdministratorContext db;

        public DoctorService(AdministratorContext db)
        {
            this.db = db;
        }


        public async Task CreateAsync(DoctorViewModel doctor)
        {
            Doctor newDoctor = new Doctor()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                SurName = doctor.SurName,
                VisitDuration= doctor.VisitDuration,
                Specialty= doctor.Specialty,

            };
            
            using (var memoryStream = new MemoryStream())
            {
                await doctor.image.CopyToAsync(memoryStream);
                var imageData = memoryStream.ToArray();
                newDoctor.image = imageData;
                
            }

            await db.doctors.AddAsync(newDoctor);

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

        public IEnumerable<Doctor> FilterByDuration(int? duration)
        {
            if(duration == null)
            {
                return GetDoctors();
            }

            return db.doctors.Where(n => n.VisitDuration == duration);
        }



        public IEnumerable<Doctor> Filter(string name, string surName, string speciality, int? duration)
        {
            if (name == null && surName == null && speciality == null && duration == null)
            {
                return GetDoctors();
            }

            var filterbyname = FilterByName(name);
            var filterbysurname = FilterBySurName(surName);
            var filterbyspeciality = FilterBySpeciality(speciality);
            var filterbyduration = FilterByDuration(duration);

            

           return filterbyname.Intersect(filterbysurname).Intersect(filterbyspeciality).Intersect(filterbyduration);

        }

        public Doctor GetDoctorById(int id)
        {
            return db.doctors.FirstOrDefault(x => x.Id == id);
        }

        
    }
}
