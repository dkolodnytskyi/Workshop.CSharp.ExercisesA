using HospitalApp.Models;
using HospitalApp.ViewModels;

namespace HospitalApp.Services.Interfaces
{
    public interface IVisitService
    {
        Task RegisterToDoctorAsync(VisitViewModel visitView);

        IEnumerable<Doctor> GetDoctors();

        Visit EditVisit(int? id);

        Task SaveVisitChangesAsync(Visit visit);

        IEnumerable<Visit> GetVisits();

        IEnumerable<Visit> Filter(string doctorName, string doctorSurName, string patientName, string patientSurName, DateTime day);

        IEnumerable<Visit> FilterByDoctor(string doctorName, string doctorSurName);

        IEnumerable<Visit> FilterByPatient(string patientName, string patientSurName);

        IEnumerable<Visit> FilterByDay(DateTime day);

        bool VisitIsBooked(VisitViewModel visitView);






    }
}
