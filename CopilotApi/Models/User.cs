﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CopilotApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        [BsonElement("role")]
        public string Role { get; set; } = string.Empty;

        //passwordhash and passwordsalt are used for hashing and salting the password
        [BsonElement("passwordHash")]
        public byte[] PasswordHash { get; set; } = new byte[0];

        [BsonElement("passwordSalt")]
        public byte[] PasswordSalt { get; set; } = new byte[0];


    }
}
