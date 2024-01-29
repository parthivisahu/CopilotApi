using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CopilotApi.Models
{
    public class Patient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("gender")]
        public string Gender { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        [BsonElement("bloodGroup")]
        public string BloodGroup { get; set; } = string.Empty;

        [BsonElement("age")]
        public string Age { get; set; } = string.Empty;

        [BsonElement("weight")]
        public string Weight { get; set; } = string.Empty;

        [BsonElement("height")]
        public string Height { get; set; } = string.Empty;

        [BsonElement("address")]
        public string Address { get; set; } = string.Empty;

        [BsonElement("injuryDepartment")]
        public string InjuryDepartment { get; set; } = string.Empty;
    }
}
