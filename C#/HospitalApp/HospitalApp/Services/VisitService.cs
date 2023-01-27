using Microsoft.EntityFrameworkCore;
using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Services.Interfaces;
using HospitalApp.ViewModels;

namespace HospitalApp.Services
{
    public class VisitService : IVisitService
    {
        public AdministratorContext db;

        public VisitService(AdministratorContext db)
        {
            this.db = db;
        }

        public Visit EditVisit(int? id)
        {
            return db.visits.Include(x => x.Doctor).Include(x => x.Patient).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Visit> Filter(string doctorName, string doctorSurName, string patientName, string patientSurName, DateTime day)
        {
            if (doctorName == null && doctorSurName == null && patientName == null && patientSurName == null && day == null)
            {
                return GetVisits();
            }

            var filterByPatient = FilterByPatient(patientName, patientSurName);
            var filterByDoctor = FilterByDoctor(doctorName, doctorSurName);
            var filterByDay = FilterByDay(day);

            return filterByPatient.Intersect(filterByDoctor).Intersect(filterByDay);

        }

        public IEnumerable<Visit> FilterByDay(DateTime day)
        {
            if (day == null)
            {
                return GetVisits();
            }

            var visit = db.visits.Where(m => m.DateOfVisit.Date == day.Date);

            return visit;

        }

        public IEnumerable<Visit> FilterByDoctor(string doctorName, string doctorSurName)
        {
            if (doctorName == null && doctorSurName == null)
            {
                return GetVisits();
            }

            if(doctorName == null && doctorSurName != null)
            {
                return GetVisits().Where(m=>m.Doctor.SurName
                .Contains(doctorSurName)).OrderBy(m=>m.Doctor.SurName);
            }

            if (doctorName != null && doctorSurName == null)
            {
                return GetVisits().Where(m => m.Doctor.Name
                .Contains(doctorName)).OrderBy(m => m.Doctor.Name);
            }



            return GetVisits().Where(m => m.Doctor.Name
            .Contains(doctorName)).Where(m => m.Doctor.SurName
            .Contains(doctorSurName)).OrderBy(m => m.Doctor.SurName);
        }

        public IEnumerable<Visit> FilterByPatient(string patientName, string patientSurName)
        {
            if (patientName == null && patientSurName == null)
            {
                return GetVisits();
            }

            if (patientName == null && patientSurName != null)
            {
                return GetVisits().Where(m => m.Patient.SurName
                .Contains(patientSurName)).OrderBy(m => m.Patient.SurName);
            }

            if (patientName != null && patientSurName == null)
            {
                return GetVisits().Where(m => m.Patient.Name
                .Contains(patientName)).OrderBy(m => m.Patient.Name);
            }



            return GetVisits().Where(m => m.Patient.Name
            .Contains(patientName)).Where(m => m.Patient.SurName
            .Contains(patientSurName)).OrderBy(m => m.Patient.SurName);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return db.doctors;

        }

        public IEnumerable<Visit> GetVisits()
        {
            var visit = db.visits.Include(x => x.Doctor).Include(x => x.Patient);
            return visit;
        }

        public bool VisitIsBooked(VisitViewModel visitView)
        {
            DateTime TimeOfVisit = new DateTime(visitView.DayOfVisit.Year, visitView.DayOfVisit.Month, visitView.DayOfVisit.Day, visitView.TimeOfVisit.Hour, visitView.TimeOfVisit.Minute, visitView.TimeOfVisit.Second);
            
            Doctor doctor = db.doctors.FirstOrDefault(m => m.Id == visitView.DoctorId);

            if (doctor != null)
            {
                var doctorVisits = GetVisits().Where(x => x.Doctor == doctor);
                var visit = doctorVisits.FirstOrDefault(x => x.DateOfVisit == TimeOfVisit);
                if (visit != null)
                {
                    return false;
                }

                return true;
            }

            return false;

        }

        public async Task RegisterToDoctorAsync(VisitViewModel visitView)
        {
            Visit NewSchedule = null;
            DateTime TimeOfVisit = new DateTime(visitView.DayOfVisit.Year, visitView.DayOfVisit.Month, visitView.DayOfVisit.Day, visitView.TimeOfVisit.Hour, visitView.TimeOfVisit.Minute, visitView.TimeOfVisit.Second);
            Patient patient = db.patients.FirstOrDefault(m => m.Name == visitView.PatientName &&
                                                            m.SurName == visitView.PatientSurName &&
                                                            m.DateOfBirth == visitView.DateOfBirth);

            Doctor doctor = db.doctors.FirstOrDefault(m => m.Id == visitView.DoctorId);

            if(doctor != null)
            {
                var doctorVisits = db.visits.Where(x => x.Doctor == doctor);
                var visit = doctorVisits.FirstOrDefault(x => x.DateOfVisit == TimeOfVisit);
                if(visit != null)
                {
                    
                }

                
            }


            if (patient != null && doctor != null)
            {
                NewSchedule = new Visit()
                {
                    Patient = patient,
                    Doctor = doctor,
                    DateOfVisit = TimeOfVisit,
                    ReasonOfVisit = visitView.ReasonOfVisit,


                };

            }
            else if (patient == null)
            {
                Patient newPatient = new Patient()
                {
                    Name = visitView.PatientName,
                    SurName = visitView.PatientSurName,
                    DateOfBirth = visitView.DateOfBirth

                };

                db.patients.Add(newPatient);

                NewSchedule = new Visit()
                {
                    Patient = newPatient,
                    Doctor = doctor,
                    DateOfVisit = TimeOfVisit,
                    ReasonOfVisit = visitView.ReasonOfVisit

                };

            }

            await db.visits.AddAsync(NewSchedule);
            await db.SaveChangesAsync();
        }

        public async Task SaveVisitChangesAsync(Visit visit)
        {
            Visit EditedSchedule = db.visits.FirstOrDefault(m => m.Id == visit.Id);
            EditedSchedule.DateOfVisit = visit.DateOfVisit;
            EditedSchedule.ReasonOfVisit = visit.ReasonOfVisit;
            db.Update(EditedSchedule);
            await db.SaveChangesAsync();

        }
    }
}
