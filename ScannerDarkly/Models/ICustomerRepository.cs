using System.Collections.Generic;
using MongoDB.Bson;

namespace ScannerDarkly.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();

        Customer GetCustomer(string id);

        Customer GetCustomerByEmail(string email);

        Customer AddCustomer(Customer item);

        bool RemoveCustomer(string id);

        bool UpsertCustomer(Customer item);
    }
}
