using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDao customerDao;

        public CustomerController(ICustomerDao customerDao)
        {
            this.customerDao = customerDao;
        }

        [HttpGet()]
        public IList<Customer> GetAllCustomers()
        {
            return customerDao.GetAllCustomers();
        }

        [HttpGet("{customerId}")]
        public ActionResult<Customer> GetCustomersByCustomerId(int customerId)
        {
            Customer customer = customerDao.GetCustomerByCustomerId(customerId);
            if (customer != null)
            {
                return customer;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("user/{userId}")]
        public ActionResult<Customer> GetCustomerByUserId(int userId)
        {
            Customer customer = customerDao.GetCustomerByUserId(userId);
            if (customer != null)
            {
                return customer;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{customerId}")]
        public ActionResult<Customer> UpdateCustomer(int customerId, Customer customer)
        {
            Customer updatedCustomer = customerDao.UpdateCustomer(customerId, customer);
            if (updatedCustomer == null)
            {
                return NotFound();
            }
            else
            {
                return updatedCustomer;
            }
        }

        [HttpPost()]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            Customer newCustomer = customerDao.CreateCustomer(customer);
            return Created($"/customers/{newCustomer.CustomerId}", newCustomer);
        }
    }
}
