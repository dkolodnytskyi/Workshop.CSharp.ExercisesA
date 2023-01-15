using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Services.Interfaces
{
    public interface IVisitService
    {
        Task RegisterToDoctorAsync(VisitViewModel visitView);

        IEnumerable<Doctor> GetDoctors();

        Visit EditVisit(int? id);

        Task SaveVisitChangesAsync(Visit visit);

        IEnumerable<Visit> GetVisits();

        IEnumerable<Visit> Filter(string doctorName, string doctorSurName, string patientName, string patientSurName);

        IEnumerable<Visit> FilterByDoctor(string doctorName, string doctorSurName);

        IEnumerable<Visit> FilterByPatient(string patientName, string patientSurName);






    }
}
