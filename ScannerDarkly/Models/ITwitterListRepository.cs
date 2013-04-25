using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace ScannerDarkly.Models
{
    public interface ITwitterListRepository
    {
        IEnumerable<TwitterList> GetAllLists();

        TwitterList GetList(string slug);
    }
}