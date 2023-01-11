using CustomerLogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerLogin.Services
{
    public interface ICustomerService
    {
        // Customer GetAllCustomerData();
        IEnumerable<Customer> GetAllCustomerData();
        Customer AddCustomer(Customer newCustomer);
       // Customer GetByEmail(string email);
        //void Remove(string email);
    }
}
