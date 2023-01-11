using System.Text.Json.Serialization.Metadata;
using System.Web.Mvc;
//using System.Web.Mvc;
using CustomerLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace CustomerLogin.Services
{
    public class CustomerService : ICustomerService
    {
        //  private readonly ICustomerRepository _customerRepository;
        //private readonly ILoggingService _logger;

        //public CustomerService(ICustomerRepository customerRepository, ILoggingService logger)
        //{
        //    _customerRepository = customerRepository;
        //    _logger = logger;
        //}

        //public async Task<List<Customer>> GetAllAsync()
        //{

        //}
        private readonly List<Customer> _customerData;
        public CustomerService()
        {
            _customerData = new List<Customer>()
            {
                new Customer() { Name =  "Jen Ken", Email="Jen.Ken@gmail.com", Password = "Hello123"},
                new Customer() { Name =  "Tim Ray ", Email="Tim.Ray@gmail.com", Password = "tm1233"},
                new Customer() { Name =  "Ricky Sam", Email="Rick.sam@gmail.com", Password = "rs1233"}
            };
        }

        public IEnumerable<Customer> GetAllCustomerData()
        {
            return _customerData;
        }

        public Customer AddCustomer(Customer newItem)
        {
            //newItem.Email = "James.Miller@gmail.com";
            //newItem.Password = "Jm@gmail.com";
            //newItem.Name = "James Miller";
            //if (newItem.Name.Equals(null))
            //{
            //    return Exception;
            //}
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (ModelState["Birthday"].Errors.Count != 0)
            //{
            //    ModelState.AddModelError("test", "The format of DATETIME is not well ");
            //}

            _customerData.Add(newItem);
            return newItem;
        }


        public Customer GetCustomerByEmail(string email) //
        {
           //if (email == "James.miller@gmai.com")
           // {
            //    return new Customer
            //    {

            //        Name = "James Miller",
            //        Email = "James.miller@gmail.com",
            //        Password = "JMiller123"

            //    };
            //}

            //return null;
            return _customerData.Where(a => a.Email == email).FirstOrDefault();
        }

        //public void Remove(string email) //LATER
        //{
        //    var existing = _customerData.First(a => a.Email == email);
        //    _customerData.Remove(existing);
        //}


        //public Customer GetAllCustomerData() //
        //{
        //    return new Customer()
        //    {

        //        Name = "James Miller",
        //        Email = "James.miller@gmail.com",
        //       Password="JMiller123"
        //    };
        //}

    }

}
