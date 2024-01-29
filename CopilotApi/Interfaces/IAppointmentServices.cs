using CopilotApi.Models;

namespace CopilotApi.Interfaces
{
   public interface IAppointmentServices
    {
      List<Appointment> GetAllAppointments();
      Appointment GetAppointment(string id);
      Appointment CreateAppointment(Appointment appointment);
      void UpdateAppointment(string id, Appointment appointment);
      void DeleteAppointment(string id);
   }
}
