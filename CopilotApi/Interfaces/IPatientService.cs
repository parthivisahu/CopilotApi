using CopilotApi.Models;

namespace CopilotApi.Interfaces
{
    public interface IPatientService
    {
        List<Patient> GetAllPatients();
        Patient GetPatient(string id);
        
        Patient CreatePatient(Patient patient);
        void UpdatePatient(string id, Patient patient);
        void DeletePatient(string id);

    }
}
