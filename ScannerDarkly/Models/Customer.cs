using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ScannerDarkly.Models
{
    public class Customer
    {
        [BsonId]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
