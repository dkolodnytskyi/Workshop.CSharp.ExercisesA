using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> RegisterToDoctor(VisitViewModel visitView)
        {
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
        public IActionResult Filter(string doctorName, string doctorSurName,string patientName, string patientSurName)
        {
            var result = visitService.Filter(doctorName, doctorSurName, patientName, patientSurName);

            return View(nameof(ShowSchedule), result);

        }

    }
}
