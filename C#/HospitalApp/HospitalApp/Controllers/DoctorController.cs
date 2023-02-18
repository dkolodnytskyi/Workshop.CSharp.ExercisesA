using Microsoft.AspNetCore.Mvc;
using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Services.Interfaces;
using HospitalApp.ViewModels;

namespace HospitalApp.Controllers
{
    public class DoctorController : Controller
    {
        public IDoctorService doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatingDoctor(DoctorViewModel doctor)
        {
            
            await doctorService.CreateAsync(doctor);

            ViewData["doctors"] = doctorService.GetDoctors();

            return View();

        }

        
        public IActionResult GetDoctorImage(int id)
        {
            var doctor = doctorService.GetDoctorById(id);

            return File(doctor.image,"image/jpeg");
        }

        [HttpGet]
        public IActionResult CreatingDoctor()
        {
            ViewData["doctors"] = doctorService.GetDoctors();

            return View();

        }

        [HttpPost]
        public IActionResult EditDoctor(int? id)
        {
            if (!ModelState.IsValid)
            {
                return View("EditDoctor");
            }
            Doctor doctor = doctorService.Update(id);

            return View(doctor);

        }

        [HttpPost]
        public async Task<IActionResult> SaveDoctorChanges(Doctor doctor)
        {
            await doctorService.SaveChangesAsync(doctor);

            return RedirectToAction("ShowDoctors");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDoctor(int? id)
        {
            await doctorService.DeleteAsync(id);

            return RedirectToAction(nameof(ShowDoctors));

        }

        [HttpGet]
        public IActionResult ShowDoctors()
        {

            return View(doctorService.GetDoctors());
        }

        [HttpPost]
        public IActionResult ShowAllDoctors()
        {

            return RedirectToAction("ShowDoctors");
        }

        [HttpPost]
        public IActionResult Filter(string name, string surName,string speciality,int? duration)
        {
            var result = doctorService.Filter(name, surName, speciality,duration);

            return View(nameof(ShowDoctors), result);

        }

        


    }
}
