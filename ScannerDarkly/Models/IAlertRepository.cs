using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace ScannerDarkly.Models
{
    public interface IAlertRepository
    {
        IEnumerable<Alert> GetAllAlerts();

        Alert GetAlert(string id);

        Alert AddAlert(Alert alert);
    }
}