using CopilotApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using CopilotApi.Settings;
using CopilotApi.Interfaces;


namespace CopilotApi.Services
{
    public class AppointmentService : IAppointmentServices
    {
        private readonly IMongoCollection<Appointment> _appointments;
    

        public AppointmentService(IAppointmentSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _appointments = database.GetCollection<Appointment>(settings.AppointmentsCollectionName);
           
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments.Find(appointment => true).ToList();
        }

        public Appointment GetAppointment(string id)
        {
            return _appointments.Find<Appointment>(appointment => appointment.Id == id).FirstOrDefault();
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            _appointments.InsertOne(appointment);
            return appointment;
        }

        public void UpdateAppointment(string id, Appointment appointment)
        {
            _appointments.ReplaceOne(appointment => appointment.Id == appointment.Id, appointment);
        }

        public void DeleteAppointment(string id)
        {
            _appointments.DeleteOne(appointment => appointment.Id == id);
        }
    }
}
