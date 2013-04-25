using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ScannerDarkly.Models
{
    public class AlertRepository : IAlertRepository
    {
        MongoServer _server;
        MongoDatabase _database;
        MongoCollection<Alert> _alerts;

        public AlertRepository()
            : this("")
        {
        }

        public AlertRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = "mongodb://dhyasama:dad3339@dharma.mongohq.com:10077/scannerbarkley";
            }

            _server = MongoServer.Create(connection);
            _database = _server.GetDatabase("scannerbarkley", SafeMode.True);
            _alerts = _database.GetCollection<Alert>("Alerts");
        }

        public IEnumerable<Alert> GetAllAlerts()
        {
            return _alerts.FindAll();
        }

        public Alert GetAlert(string id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            return _alerts.Find(query).FirstOrDefault();
        }

        public Alert AddAlert(Alert alert)
        {
            alert.Id = ObjectId.GenerateNewId().ToString();
            _alerts.Insert(alert);
            return alert;
        }
    }
}
