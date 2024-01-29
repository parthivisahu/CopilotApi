using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CopilotApi.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("patientId")]
        public string PatientId { get; set; } = string.Empty;

        [BsonElement("doctorId")]
        public string DoctorId { get; set; } = string.Empty;

        [BsonElement("date")]
        public string Date { get; set; } = string.Empty;

        [BsonElement("time")]
        public string Time { get; set; } = string.Empty;

        [BsonElement("status")]
        public string Status { get; set; } = "Pending";

        [BsonElement("patientName")]
        public string PatientName { get; set; } = string.Empty;

        [BsonElement("doctorName")]
        public string DoctorName { get; set; } = string.Empty;

        [BsonElement("patientEmail")]
        public string PatientEmail { get; set; } = string.Empty;

        [BsonElement("doctorEmail")]
        public string DoctorEmail { get; set; } = string.Empty;

        [BsonElement("patientPhone")]
        public string PatientPhone { get; set; } = string.Empty;

        [BsonElement("patientAddress")]
        public string PatientAddress { get; set; } = string.Empty;

        [BsonElement("doctorAddress")]
        public string DoctorAddress { get; set; } = string.Empty;

        [BsonElement("patientGender")]
        public string PatientGender { get; set; } = string.Empty;

        [BsonElement("patientAge")]
        public string PatientAge { get; set; } = string.Empty;

        [BsonElement("patientBloodGroup")]
        public string PatientBloodGroup { get; set; } = string.Empty;

        [BsonElement("patientDepartment")]
        public string PatientDepartment { get; set; } = string.Empty;
    }
}
