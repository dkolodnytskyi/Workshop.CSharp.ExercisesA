using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers
{
    public class PatientController : Controller
    {
        public IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(Patient patient)
        {
           await patientService.CreateAsync(patient);
            
            ViewData["patients"] = patientService.GetPatients();
      
            return RedirectToAction(nameof(ShowPatients));
        }
        [HttpGet]
        public IActionResult CreatePatient()
        {
            ViewData["patients"] = patientService.GetPatients();

            return View();
        }

        [HttpGet]
        public IActionResult ShowPatients()
        {
            return View(patientService.GetPatients());
        }

        [HttpPost]
        public IActionResult EditPatient(int? id)
        {
            Patient patient = patientService.Update(id);

            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> SavePatientChanges(Patient patient)
        {
            await patientService.SaveChangesAsync(patient);
            return RedirectToAction("ShowPatients");
        }


    }
}
