using CustomerLogin.Models;
using Microsoft.AspNetCore.Mvc;

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
        public Customer GetAllCustomerData() //
        {
            return new Customer()
            {
             
                Name = "James Miller",
                Email = "James.miller@gmail.com",
               Password="JMiller123"
            };
        }

        public Customer GetCustomerByEmail(string email) //
        {
            if (email == "James.miller@gmai.com")
            {
                return new Customer
                {

                    Name = "James Miller",
                    Email = "James.miller@gmail.com",
                    Password = "JMiller123"

                };
            }

            return null;
        }


      
        //public Customer AddCustomer(Customer customer) //
        //{
        //    if (id == 1234)
        //    {
        //        return new Customer
        //        {
        //            CustomerAddress = "1111 W rd",

        //            CustomerId = 3333,
        //            CustomerName = "Rick",
        //            age = 20

        //        };
        //    }

        //    return null;
        //}
    }

}
