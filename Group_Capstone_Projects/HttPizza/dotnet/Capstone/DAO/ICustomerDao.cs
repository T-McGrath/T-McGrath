using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface ICustomerDao
    {
        IList<Customer> GetAllCustomers();
        Customer GetCustomerByCustomerId(int customerId);
        Customer GetCustomerByUserId(int userId);
        Customer UpdateCustomer(int customerId, Customer customer);
        Customer CreateCustomer(Customer customer);
    }
}
