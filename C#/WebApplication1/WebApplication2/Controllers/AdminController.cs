using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {

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
            Administrator.doctors.Add(doctor);

            return View();

        }
        [HttpGet]
        public IActionResult CreatingDoctor()
        {

          return View();

        }
        [HttpGet]
        public IActionResult ShowDoctors()
        {
            var doctors = new List<Doctor>();

            return View(Administrator.doctors.OrderBy(s=>s.SurName).ToList());
        }
        [HttpPost]
        public IActionResult CreatePatient(Patient patient)
        {
            Administrator.patients.Add(patient);

            return View();
        }

        [HttpGet]
        public IActionResult CreatePatient()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowPatients()
        {
            return View(Administrator.patients);
        }

        [HttpPost]
        public IActionResult CreateVisit(VisitViewModel newVisit)
        {
            Visit visit = null;
            Doctor FoundDoctor = Administrator.doctors.FirstOrDefault(m => m.Name == newVisit.DoctorName);
            Patient FoundPatient = Administrator.patients.FirstOrDefault(m => m.Name == newVisit.PatientName);
            if (FoundPatient != null)
            {
                visit = new Visit()
                {
                    patient = FoundPatient,
                    doctor = FoundDoctor,
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

                Administrator.patients.Add(NewPatient);
                visit = new Visit()
                {
                    doctor = FoundDoctor,
                    patient = NewPatient,
                    ReasonOfVisit = newVisit.ReasonOfVisit
                    
                };
            }
            
            Administrator.visits.Add(visit);


            return View();
        }

        [HttpGet]
        public IActionResult CreateVisit()
        {
            ViewBag.doctors = Administrator.doctors;
            return View();
        }

        [HttpGet]
        public IActionResult ShowVisits()
        {
            return View(Administrator.visits);
        }

        /*[HttpPut]
        public IActionResult EditPatient(int id)
        {
            foreach (var patient in Administrator.patients)
            {
                if (patient.Id == id)
                {

                }
            }

        }*/

    }
}
