using CustomerLogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerLogin.Services
{
    public interface ICustomerService
    {
        Customer GetAllCustomerData();
    }
}
