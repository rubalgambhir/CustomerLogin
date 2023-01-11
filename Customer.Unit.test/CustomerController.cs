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
           controller = new CustomersController(_sutl);
        }

       [Fact]
       public void GetCustomer_returnCustomer_whenexists()
       {  //Arrange


           var result = _sutl.GetAllCustomerData();// as CustomerLogin.Models.Customer;
           //Assert
           Assert.NotNull(result);
           //Assert.Equal(10, result.);

       }
       [Fact]
       public void GetCustomer_returnCustomer_whenEmail()
       {  //Arrange


           var result = _sutl.GetCustomerByEmail("Jen.Ken@gmail.com");
           //Assert
           Assert.NotNull(result);
           Assert.Equal("Jen Ken", result.Name);

       }

       [Fact]
       public void Add_InvalidObjectPassed_ReturnsBadRequest()
       {
           // Arrange
           var nameMissingItem = new CustomerLogin.Models.Customer()
           {   Email = "xyz@gmaill.com",
               Password = "XYZ123"

           };
           //name field missing
          controller.ModelState.AddModelError("Name", "Required");
          //ModelState.AddModelError(string.Empty, "The item cannot be removed");
            // Act
            var badResponse = _sutl.AddCustomer(nameMissingItem);
            // Assert
            //  Assert.IsType<BadRequestObjectResult>(badResponse);
            Assert.Null(badResponse.Name);
          //  Assert.IsType<BadRequestObjectResult>(badResponse);
       
    }
       //[Fact]
       //public void Add_ValidObjectPassed_ReturnsCreatedResponse()
       //{
       //    // Arrange
       //    CustomerLogin.Models.Customer testItem = new CustomerLogin.Models.Customer()
       //    {
       //        Name = "Guinness Original 6 Pack", //name field added
       //        Email = "xyz@gmaill.com",
       //        Password = "XYZ123"
       //    };
       //    // Act
       //    var createdResponse = _sutl.AddCustomer(testItem);
       //    // Assert
       //    Assert.IsType<CreatedAtActionResult>(createdResponse);
       //}


    }
}
