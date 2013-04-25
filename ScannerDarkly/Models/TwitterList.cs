using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ScannerDarkly.Models
{
    public class TwitterList
    {
        [BsonId]
        public string Id { get; set; }

        public string listId { get; set; }

        public string slug { get; set; }

        public bool isBeingScanned { get; set; }
    }
}
