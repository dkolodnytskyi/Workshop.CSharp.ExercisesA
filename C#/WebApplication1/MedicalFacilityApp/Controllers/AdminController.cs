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
        /*[HttpPost]
        public IActionResult CreatingDoctor(Doctor doctor)
        {
            db.doctors.Add(doctor);
            ViewData["doctors"] = db.doctors;
            db.SaveChanges();

            return View();

        }*/
        [HttpGet]
        public IActionResult CreatingDoctor()
        {
            ViewData["doctors"] = db.doctors;

            return View();

        }
        /*[HttpGet]
        public IActionResult ShowDoctors()
        {

            return View(db.doctors);
        }*/
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

        

        [HttpGet]
        public IActionResult CreateVisit()
        {
            

            return View(db.doctors);
        }
        
        [HttpPost]
        public IActionResult EditPatient(int? id)
        {
            Patient patient = db.patients.FirstOrDefault(v => v.Id == id);

            return View(patient);
        }

        /*[HttpPost]
        public IActionResult EditDoctor(int? id)
        {
            Doctor doctor = db.doctors.FirstOrDefault(v => v.Id == id);

            return View(doctor);

        }*/

        [HttpPost]
        public IActionResult EditVisitInSchedule(int? id)
        {
            Schedule schedule = db.schedule.Include(x => x.Doctor).Include(x => x.Patient).FirstOrDefault(x => x.Id == id);

 
            return View(schedule);

        }

        /*[HttpPost]
        public IActionResult SaveDoctorChanges(Doctor doctor)
        {
            db.Update(doctor);
            db.SaveChanges();
            return RedirectToAction("ShowDoctors");
        }*/

        [HttpPost]
        public IActionResult SavePatientChanges(Patient patient)
        {
            db.Update(patient);
            db.SaveChanges();
            return RedirectToAction("ShowPatients");
        }

        [HttpPost]
        public IActionResult SaveVisitChanges(Schedule schedule)
        {
            Schedule EditedSchedule = db.schedule.FirstOrDefault(m=>m.Id== schedule.Id);
            EditedSchedule.DateOfVisit = schedule.DateOfVisit;
            EditedSchedule.ReasonOfVisit = schedule.ReasonOfVisit;
            db.Update(EditedSchedule);
            db.SaveChanges();
            return RedirectToAction("ShowSchedule");
        }

        

        

        [HttpPost]
        public IActionResult RegisterToVisit(int id)
        {
            Doctor doctor = db.doctors.FirstOrDefault(m => m.Id == id);
            ViewBag.doctor = doctor;
            return View();
        }

        [HttpGet]
        public IActionResult RegisterToVisit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterToDoctor(VisitViewModel visitView)
        {
            Schedule NewSchedule = null;
            DateTime TimeOfVisit = new DateTime(visitView.DayOfVisit.Year, visitView.DayOfVisit.Month, visitView.DayOfVisit.Day, visitView.TimeOfVisit.Hour, visitView.TimeOfVisit.Minute, visitView.TimeOfVisit.Second);
            Patient patient = db.patients.FirstOrDefault(m => m.Name == visitView.PatientName &&
                                                            m.SurName == visitView.PatientSurName &&
                                                            m.DateOfBirth == visitView.DateOfBirth);

            Doctor doctor = db.doctors.FirstOrDefault(m => m.Id == visitView.DoctorId);
                                                        
            if(patient != null && doctor != null)
            {
                NewSchedule = new Schedule()
                {
                    Patient = patient,
                    Doctor = doctor,
                    DateOfVisit = TimeOfVisit,
                    ReasonOfVisit = visitView.ReasonOfVisit,
                   

                };
                
            }
            else if(patient == null)
            {
                Patient newPatient = new Patient()
                {
                    Name = visitView.PatientName,
                    SurName = visitView.PatientSurName,
                    DateOfBirth = visitView.DateOfBirth

                };

                db.patients.Add(newPatient);

                NewSchedule = new Schedule()
                {
                    Patient = newPatient,
                    Doctor = doctor,
                    DateOfVisit = TimeOfVisit,
                    ReasonOfVisit = visitView.ReasonOfVisit

                };

            }

            db.schedule.Add(NewSchedule);
            db.SaveChanges();
            

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
            var schedule = db.schedule.Include(x => x.Doctor).Include(x => x.Patient);
            
            return View(schedule);
        }

        /*[HttpPost]
        public IActionResult DeleteDoctor(int? id)
        {
            Doctor doctor = db.doctors.FirstOrDefault(m => m.Id == id);
            db.doctors.Remove(doctor);
            db.SaveChanges();

            return View("ShowDoctors");

        } */
        


      

    }
}
