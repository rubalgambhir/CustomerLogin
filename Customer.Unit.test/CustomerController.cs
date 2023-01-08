using System.Security.Cryptography.X509Certificates;
using CustomerLogin.Controllers;
using Microsoft.AspNetCore.Mvc;
using CustomerLogin.Models;
using CustomerLogin.Services;

namespace Customer.Unit.test
{
    public class CustomerControllerTest
    {
       // private readonly ICustomerService _customerService;
       private CustomersController controller;
      // controller = new CustomersController {Serviceprovider =new CustomerService()};
       private CustomerService _sutl;

       public CustomerControllerTest()
       {
           _sutl=new CustomerService();
       }

       [Fact]
       public void GetCustomer_returnCustomer_whenexits()
       {  //Arrange


           var result = _sutl.GetAllCustomerData() as CustomerLogin.Models.Customer;
           //Assert
           Assert.NotNull(result);
           //Assert.Equal(10, result.);

       }
       [Fact]
       public void GetCustomer_returnCustomer_whenEmail()
       {  //Arrange


           var result = _sutl.GetCustomerByEmail("James.miller@gmail.com");
           //Assert
           Assert.NotNull(result);
           Assert.Equal("James", result.Name);

       }

       

    }
}
