using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers
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
        public async Task<IActionResult> CreatingDoctor(Doctor doctor)
        {
            await doctorService.CreateAsync(doctor);

            ViewData["doctors"] = doctorService.GetDoctors();

            return View();

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
        public IActionResult FilterDoctorsByFullName(string name, string surName)
        {
            var result = doctorService.FilterByFullName(name, surName);

            return View(nameof(ShowDoctors), result);

        }


    }
}
