using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;
using CustomerLogin.Models;
using CustomerLogin.Services;


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Mvc;



namespace CustomerLogin.Controllers
{

    //[ApiController]
    //[Microsoft.AspNetCore.Components.Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private ICustomerService serviceprovider;

        public ICustomerService Serviceprovider

        {
            protected get { return serviceprovider; }
            set { serviceprovider = value; }
        }
        //[Route("/")]
        // [Route("GetAllCustomers")]
        // [Route("Customers/GetAllCustomers")]
        [HttpGet(Name = "GetAllCustomers")]
        public List<CustomerLogin.Models.Customer> GetAllCustomers()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

            List<Models.Customer> AllCustomer = new List<Models.Customer>();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from CustomerLogin";

            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                AllCustomer.Add(new Models.Customer()
                {
                   
                    Name = reader.GetValue(1).ToString(),
                    Email = reader.GetValue(2).ToString(),
                    Password = reader.GetValue(3).ToString(),

                });
            }
            return AllCustomer;

        }


        

        [HttpPost]
        public void AddCustomer(Models.Customer customer)
        {
            // try
            // {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO CustomerLogin (Name,Email,Password) Values (@Name,@Email,@Password)";
            sqlCmd.Connection = myConnection;
            sqlCmd.Parameters.AddWithValue("@Name", customer.Name);
            sqlCmd.Parameters.AddWithValue("@Email", customer.Email);
            sqlCmd.Parameters.AddWithValue("@Password", customer.Password);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
           
        }





    }
}