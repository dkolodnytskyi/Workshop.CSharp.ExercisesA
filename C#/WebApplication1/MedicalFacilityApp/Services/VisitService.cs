using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Services
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

        public IEnumerable<Visit> Filter(string doctorName, string doctorSurName, string patientName, string patientSurName)
        {
            if (doctorName == null && doctorSurName == null && patientName == null && patientSurName == null)
            {
                return GetVisits();
            }

            var filterByPatient = FilterByPatient(patientName, patientSurName);
            var filterByDoctor = FilterByDoctor(doctorName, doctorSurName);

            return filterByPatient.Intersect(filterByDoctor);

        }

        public IEnumerable<Visit> FilterByDoctor(string doctorName, string doctorSurName)
        {
            if (doctorName == null && doctorSurName == null)
            {
                return GetVisits();
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

            return GetVisits().Where(m => m.Patient.Name
            .Contains(patientName)).Where(m => m.Patient.SurName
            .Contains(patientSurName)).OrderBy(m => m.Doctor.SurName);
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

        public async Task RegisterToDoctorAsync(VisitViewModel visitView)
        {
            Visit NewSchedule = null;
            DateTime TimeOfVisit = new DateTime(visitView.DayOfVisit.Year, visitView.DayOfVisit.Month, visitView.DayOfVisit.Day, visitView.TimeOfVisit.Hour, visitView.TimeOfVisit.Minute, visitView.TimeOfVisit.Second);
            Patient patient = db.patients.FirstOrDefault(m => m.Name == visitView.PatientName &&
                                                            m.SurName == visitView.PatientSurName &&
                                                            m.DateOfBirth == visitView.DateOfBirth);

            Doctor doctor = db.doctors.FirstOrDefault(m => m.Id == visitView.DoctorId);

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
