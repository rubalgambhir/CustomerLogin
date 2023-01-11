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
          private readonly ICustomerService _serviceprovider;


        public CustomersController(ICustomerService service)
        {
            _serviceprovider = service;
        }
        //public ICustomerService Serviceprovider

        //{
        //    protected get { return serviceprovider; }
        //    set { serviceprovider = value; }
        //}
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


        [HttpGet]
        [ActionName("GetCustomerByEmail")]
        public Customer GetCustomersById(string email)
        {
            //return listEmp.First(e => e.ID == id);
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from CustomerLogin where Email="+"'"+email+"'"+"";// "Select * from Customer where age=" + Age + "";
            //sqlCmd.Parameters.Add("@Email", email);

            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Customer cust = null;
            while (reader.Read())
            {
                cust = new Customer();
               
                cust.Name = reader.GetValue(1).ToString();
                cust.Email = reader.GetValue(2).ToString();
                cust.Password = reader.GetValue(3).ToString();
                // emp.ManagerId = Convert.ToInt32(reader.GetValue(2));
            }
            return cust;
            myConnection.Close();

        }



    }


}
