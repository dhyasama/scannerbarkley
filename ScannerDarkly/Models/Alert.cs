using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ScannerDarkly.Models
{
    public class Alert
    {
        [BsonId]
        public string Id { get; set; }

        public string customerId { get; set; }

        public DateTime discoveryTimestamp { get; set; }

        public List<string> keywords { get; set; }

        public bool sent { get; set; }

        public DateTime sentTimestamp { get; set; }

        public string sentTo { get; set; }

        public Tweet tweet { get; set; }
    }
}
