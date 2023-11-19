using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Data.SqlClient;
using TenmoServer.Exceptions;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class AccountSqlDao : IAccountDao
    {
        private readonly string connectionString;

        public AccountSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Account GetAccountByUserId(int userId)
        {
            Account account = null;
            string sqlSelect = "SELECT account_id, user_id, balance FROM account WHERE user_id = @user_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sqlSelect, conn);
                    command.Parameters.AddWithValue("@user_id", userId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        account = MapRowToAccountObject(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error accessing database", ex);
            }
            return account;
        }
        public Account GetAccountByAccountId(int accountId)
        {
            Account account = null;
            string sqlSelect = "SELECT account_id, user_id, balance FROM account WHERE account_id = @account_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sqlSelect, conn);
                    command.Parameters.AddWithValue("@account_id", accountId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        account = MapRowToAccountObject(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error accessing database", ex);
            }
            return account;
        }


        public Account UpdateAccount(Account account)
        {
            Account updatedAccount = null;
            string sqlUpdate = "UPDATE account SET user_id = @user_id, balance = @balance WHERE account_id = @account_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlUpdate, conn);
                    command.Parameters.AddWithValue("@account_id", account.AccountId);
                    command.Parameters.AddWithValue("@user_id", account.UserId);
                    command.Parameters.AddWithValue("@balance", account.Balance);

                    int numRowsUpdated = command.ExecuteNonQuery();
                    if (numRowsUpdated == 0)
                    {
                        throw new DaoException("No rows were affected. Check user ID.");
                    }
                }
                updatedAccount = GetAccountByUserId(account.UserId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error contacting database.", ex);
            }
            return updatedAccount;
        }


        public Account MapRowToAccountObject(SqlDataReader reader)
        {
            Account account = new Account();
            account.AccountId = Convert.ToInt32(reader["account_id"]);
            account.UserId = Convert.ToInt32(reader["user_id"]);
            account.Balance = Convert.ToDecimal(reader["balance"]);
            return account;
        }
    }
}
