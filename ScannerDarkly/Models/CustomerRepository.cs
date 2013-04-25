using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ScannerDarkly.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        MongoServer _server;
        MongoDatabase _database;
        MongoCollection<Customer> _customers;

        public CustomerRepository()
            : this("")
        {
        }

        public CustomerRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = "mongodb://dhyasama:dad3339@dharma.mongohq.com:10077/scannerbarkley";
            }

            _server = MongoServer.Create(connection);
            _database = _server.GetDatabase("airheads", SafeMode.True);
            _customers = _database.GetCollection<Customer>("Customers");

        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers.FindAll();
        }

        public Customer GetCustomer(string id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            return _customers.Find(query).FirstOrDefault();
        }

        public Customer GetCustomerByEmail(string email)
        {
            IMongoQuery query = Query.EQ("Email", email);
            return _customers.Find(query).FirstOrDefault();
        }

        public Customer AddCustomer(Customer item)
        {
            item.Id = ObjectId.GenerateNewId().ToString();
            _customers.Insert(item);
            return item;
        }

        public bool RemoveCustomer(string id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            WriteConcernResult result = _customers.Remove(query);
            return result.DocumentsAffected == 1;
        }

        public bool UpsertCustomer(Customer item)
        {
            return _customers.Save(item).DocumentsAffected == 1;
        }
    }
}
