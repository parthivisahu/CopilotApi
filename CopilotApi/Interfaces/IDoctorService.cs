using CopilotApi.Models;
namespace CopilotApi.Interfaces
{
    public interface IDoctorService
    {
        List<Doctor> GetAllDoctors();
        Doctor GetDoctor(string id);
        
        Doctor CreateDoctor(Doctor doctor);
        void UpdateDoctor(string id, Doctor doctor);
        void DeleteDoctor(string id);
    }
}
