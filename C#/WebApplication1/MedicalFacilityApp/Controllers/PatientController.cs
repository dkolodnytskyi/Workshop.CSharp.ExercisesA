using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PatientController : Controller
    {
        AdministratorContext db;

        public PatientController(AdministratorContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
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
        public IActionResult EditPatient(int? id)
        {
            Patient patient = db.patients.FirstOrDefault(v => v.Id == id);

            return View(patient);
        }

        [HttpPost]
        public IActionResult SavePatientChanges(Patient patient)
        {
            db.Update(patient);
            db.SaveChanges();
            return RedirectToAction("ShowPatients");
        }
    }
}
