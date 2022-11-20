using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        AdministratorContext db;

        public AdminController(AdministratorContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatingDoctor(Doctor doctor)
        {
            db.doctors.Add(doctor);
            ViewData["doctors"] = db.doctors;
            db.SaveChanges();

            return View();

        }
        [HttpGet]
        public IActionResult CreatingDoctor()
        {
            ViewData["doctors"] = db.doctors;

            return View();

        }
        [HttpGet]
        public IActionResult ShowDoctors()
        {

            return View(db.doctors);
        }
        [HttpPost]
        public IActionResult CreatePatient(Patient patient)
        {
            db.patients.Add(patient);
            ViewData["patients"] = db.patients;
            db.SaveChanges();

            return View();
        }

        [HttpGet]
        public IActionResult CreatePatient()
        {
            ViewData["patients"] = db.patients;

            return View();
        }

        [HttpGet]
        public IActionResult ShowPatients()
        {
            return View(db.patients);
        }

        [HttpPost]
        public IActionResult CreateVisit(VisitViewModel newVisit)
        {
            Visit visit = null;
            Doctor FoundDoctor = db.doctors.FirstOrDefault(m => m.Name == newVisit.DoctorName);
            Patient FoundPatient = db.patients.FirstOrDefault(m => m.Name == newVisit.PatientName);
            if (FoundPatient != null)
            {
                visit = new Visit()
                {
                    Patient = FoundPatient,
                    Doctor = FoundDoctor,
                    ReasonOfVisit = newVisit.ReasonOfVisit,
                };
            }
            else
            {
                Patient NewPatient = new Patient()
                {
                    Name = newVisit.PatientName,
                    SurName = newVisit.PatientSurName,
                    DateOfBirth = newVisit.DateOfBirth
                };

                db.patients.Add(NewPatient);
                visit = new Visit()
                {
                    Doctor = FoundDoctor,
                    Patient = NewPatient,
                    ReasonOfVisit = newVisit.ReasonOfVisit
                    
                };
            }
            
            db.visits.Add(visit);

            db.SaveChanges();

            ViewBag.doctors = db.doctors;


            return View();
        }

        [HttpGet]
        public IActionResult CreateVisit()
        {
            ViewBag.doctors = db.doctors;

            return View();
        }

        [HttpGet]
        public IActionResult ShowVisits()
        {
            IEnumerable<Visit> visits = db.visits.Include(v=>v.Doctor).Include(a=>a.Patient);
            return View(visits);
        }

        [HttpPut]
        public IActionResult EditPatient(int id)
        {
            

            db.SaveChanges();
            return View();
        }

        [HttpPost]
        public IActionResult EditDoctor(int? id)
        {
            Doctor doctor = db.doctors.FirstOrDefault(v => v.Id == id);

            return View(doctor);

        }

        [HttpPost]
        public IActionResult SaveDoctorChanges(Doctor doctor)
        {
            db.Update(doctor);
            db.SaveChanges();
            return RedirectToAction("ShowDoctors");
        }

    }
}
