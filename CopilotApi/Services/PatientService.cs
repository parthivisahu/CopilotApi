using CopilotApi.Interfaces;
using CopilotApi.Models;
using MongoDB.Driver;
using System.Linq;
using CopilotApi.Settings;

namespace CopilotApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMongoCollection<Patient> _patients;

        public PatientService(IPatientSettings settings, IMongoClient mongoClient)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _patients = database.GetCollection<Patient>(settings.PatientsCollectionName);
        }

        public List<Patient> GetAllPatients() =>
            _patients.Find(patient => true).ToList();

        public Patient GetPatient(string id) =>
            _patients.Find(patient => patient.Id == id).FirstOrDefault();

        public Patient CreatePatient(Patient patient)
        {
            _patients.InsertOne(patient);
            return patient;
        }

        public void UpdatePatient(string id, Patient patientIn) =>
            _patients.ReplaceOne(patient => patient.Id == id, patientIn);

        public void DeletePatient(string id) =>
            _patients.DeleteOne(patient => patient.Id == id);
    }
}
