using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DoctorController : Controller
    {
        AdministratorContext db;

        public DoctorController(AdministratorContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
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

        [HttpPost]
        public IActionResult DeleteDoctor(int? id)
        {
            Doctor doctor = db.doctors.FirstOrDefault(m => m.Id == id);
            db.doctors.Remove(doctor);
            db.SaveChanges();

            return View("ShowDoctors");

        }

        [HttpGet]
        public IActionResult ShowDoctors()
        {

            return View(db.doctors);
        }


    }
}
