using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Services.Interfaces;
using HospitalApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace HospitalApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IVisitService visitService;
    
      public AdminController(IVisitService visitService)
        {
            this.visitService = visitService;
        }

        [HttpGet]
        public IActionResult CreateVisit()
        {

            return View(visitService.GetDoctors());
        }

        [HttpPost]
        public IActionResult EditVisitInSchedule(int? id)
        {
            Visit visit = visitService.EditVisit(id);

            return View(visit);

        }

        [HttpPost]
        public async Task<IActionResult> SaveVisitChanges(Visit visit)
        {
            await visitService.SaveVisitChangesAsync(visit);

            return RedirectToAction("ShowSchedule");
        }


        [HttpPost]
        public IActionResult ChooseDoctor(int id)
        {
            Doctor doctor = visitService.GetDoctors().FirstOrDefault(m => m.Id == id);
            ViewBag.doctor = doctor;
            return View("RegisterToVisit");
        }

        [HttpGet]
        public IActionResult ChooseDoctor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterToDoctor()
        {
            return View("RegisterToVisit");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterToDoctor(VisitViewModel visitView)
        {
           
            var visit = visitService.VisitIsBooked(visitView);

            if (!visit)
            {
                return RedirectToAction(nameof(CreateVisit));
            }
                
            await visitService.RegisterToDoctorAsync(visitView);

            return RedirectToAction(nameof(ApproveToVisit));
        }

        [HttpGet]
        public IActionResult ApproveToVisit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowSchedule()
        {
            var visit = visitService.GetVisits();

            return View(visit);
        }

        [HttpPost]
        public IActionResult Filter(string doctorName, string doctorSurName,string patientName, string patientSurName, DateTime day)
        {
            var result = visitService.Filter(doctorName, doctorSurName, patientName, patientSurName, day);

            return View(nameof(ShowSchedule), result);

        }

    }
}
