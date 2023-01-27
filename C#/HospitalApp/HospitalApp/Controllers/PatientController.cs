using Microsoft.AspNetCore.Mvc;
using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Services.Interfaces;

namespace HospitalApp.Controllers
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
            if (!ModelState.IsValid)
            {
                return View("CreatePatient");
            }

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
            if (!ModelState.IsValid)
            {
                return View("EditPatient");
            }
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
