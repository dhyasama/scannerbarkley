using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ScannerDarkly.Models
{
    public class TwitterListRepository : ITwitterListRepository
    {
        MongoServer _server;
        MongoDatabase _database;
        MongoCollection<TwitterList> _twitterLists;

        public TwitterListRepository()
            : this("")
        {
        }

        public TwitterListRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = "mongodb://dhyasama:dad3339@dharma.mongohq.com:10077/scannerbarkley";
            }

            _server = MongoServer.Create(connection);
            _database = _server.GetDatabase("scannerbarkley", SafeMode.True);
            _twitterLists = _database.GetCollection<TwitterList>("TwitterLists");
        }

        public IEnumerable<TwitterList> GetAllLists()
        {
            return _twitterLists.FindAll();
        }

        public TwitterList GetList(string slug)
        {
            IMongoQuery query = Query.EQ("slug", slug);
            return _twitterLists.Find(query).FirstOrDefault();
        }
    }
}
