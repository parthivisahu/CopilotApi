using CopilotApi.Interfaces;
using CopilotApi.Models;
using CopilotApi.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CopilotApi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IMongoCollection<Doctor> _doctors;

        public DoctorService(IDoctorSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _doctors = database.GetCollection<Doctor>(settings.DoctorsCollectionName);
        }

        public List<Doctor> GetAllDoctors() =>
            _doctors.Find(doctor => true).ToList();

        public Doctor GetDoctor(string id) =>
            _doctors.Find<Doctor>(doctor => doctor.Id == id).FirstOrDefault();

        public Doctor CreateDoctor(Doctor doctor)
        {
            _doctors.InsertOne(doctor);
            return doctor;
        }

        public void UpdateDoctor(string id, Doctor doctorIn) =>
            _doctors.ReplaceOne(doctor => doctor.Id == id, doctorIn);

        public void DeleteDoctor(string id) =>
            _doctors.DeleteOne(doctor => doctor.Id == id);
    }
}
