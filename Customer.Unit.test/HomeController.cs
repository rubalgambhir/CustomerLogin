using Xunit;
using CustomerLogin.Controllers;
//using Microsoft.AS
using Microsoft.AspNetCore.Mvc;


namespace Customer.Unit.Test
{
    public class HomeControllerTest
    {
        [Fact]
        public void Test_to_check_if_home_controller_works()
        {

            //int count = 5;
            //var fakeCustomers = A.CollectionOfDummy<WebApiDemo.Models.Customer>(count).AsEnumerable();
            //var dataStore = A.Fake<WebApiDemo.Data>();
            //    A.CallTo(() => dataStore.GetAllCustomers()).Return(Task.FromResult(fakeCustomers));
            //var controller = new CustomersController(datastore);

            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.Equal("Index", result?.ViewName);
        }
    }
}