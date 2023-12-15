using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Exceptions;
using Capstone.Models;

namespace Capstone.DAO
{
    public class CustomerSqlDao : ICustomerDao
    {
        private readonly string connectionString;
        
        public CustomerSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        
        public IList<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            string sqlQuery = "SELECT * FROM customers;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = MapRowToCustomer(reader);
                        customerList.Add(customer);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occurred!", ex);
            }
            return customerList;
        }
        public Customer GetCustomerByCustomerId(int customerId)
        {
            Customer customer = null;
            string sqlQuery = "SELECT * FROM customers WHERE customer_id = @customer_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    command.Parameters.AddWithValue("@customer_id", customerId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        customer = MapRowToCustomer(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occurred!", ex);
            }
            return customer;
        }
        public Customer GetCustomerByUserId(int userId)
        {
            Customer customer = null;
            string sql = "SELECT * FROM customers WHERE user_id = @userId;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        customer = MapRowToCustomer(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occurred!", ex);
            }
            return customer;
        }
        public Customer UpdateCustomer(int customerId, Customer customer)
        {
            Customer updatedCustomer = null;
            string sqlQuery = "UPDATE customers SET user_id = @user_id, customer_name = @customer_name, address = @address, phone_num = @phone_num, payment_info = @payment_info WHERE customer_id = @customer_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    command.Parameters.AddWithValue("@user_id", customer.UserId);
                    command.Parameters.AddWithValue("@customer_name", customer.CustomerName);
                    command.Parameters.AddWithValue("@address", customer.Address);
                    command.Parameters.AddWithValue("@phone_num", customer.PhoneNum);
                    command.Parameters.AddWithValue("@payment_info", customer.PaymentInfo);
                    command.Parameters.AddWithValue("@customer_id", customerId);
                    command.ExecuteNonQuery();
                }
                updatedCustomer = GetCustomerByCustomerId(customerId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occurred!", ex);
            }

            return updatedCustomer;
        }
        public Customer CreateCustomer(Customer customer)
        {
            Customer newCustomer = null;
            string sqlQuery = "INSERT INTO customers (user_id, customer_name, address, phone_num, payment_info) " +
                                "OUTPUT INSERTED.customer_id " +
                                "VALUES (@user_id, @customer_name, @address, @phone_num, @payment_info);";
            try
            {
                int newCustomerId;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    command.Parameters.AddWithValue("@user_id", customer.UserId);
                    command.Parameters.AddWithValue("@customer_name", customer.CustomerName);
                    command.Parameters.AddWithValue("@address", customer.Address);
                    command.Parameters.AddWithValue("@phone_num", customer.PhoneNum);
                    command.Parameters.AddWithValue("@payment_info", customer.PaymentInfo);
                    newCustomerId = Convert.ToInt32(command.ExecuteScalar());
                }
                newCustomer = GetCustomerByCustomerId(newCustomerId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occurred!", ex);
            }
            return newCustomer;
        }

        public Customer MapRowToCustomer(SqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.CustomerId = Convert.ToInt32(reader["customer_id"]);
            customer.UserId = Convert.ToInt32(reader["user_id"]);
            customer.CustomerName = Convert.ToString(reader["customer_name"]);
            customer.Address = Convert.ToString(reader["address"]);
            customer.PhoneNum = Convert.ToString(reader["phone_num"]);
            customer.PaymentInfo = Convert.ToString(reader["payment_info"]);
            return customer;
        }
    }
}
