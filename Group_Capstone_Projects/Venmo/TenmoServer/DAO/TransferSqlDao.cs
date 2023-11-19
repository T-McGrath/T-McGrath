using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TenmoServer.Exceptions;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class TransferSqlDao : ITransferDao
    {
        private readonly string connectionString;
        IAccountDao accountDao;
        IUserDao userDao;

        public TransferSqlDao(string dbConnectionString, IAccountDao accountDao, IUserDao userDao)
        {
            connectionString = dbConnectionString;
            this.accountDao = accountDao;
            this.userDao = userDao;
        }


        public Transfer GetTransferById(int id)
        {
            Transfer transfer = null;
            string sqlSelect = "SELECT * FROM transfer WHERE transfer_id = @transfer_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlSelect, conn);
                    command.Parameters.AddWithValue("@transfer_id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        transfer = MapRowToTransferObject(reader); 
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Database error.", ex);
            }
            return transfer;
        }

        public Transfer CreateTransfer(Transfer transfer)
        {
            Transfer newTransfer = null;
            int newTransferId;
            string sqlInsert = "INSERT INTO transfer (transfer_type_id, transfer_status_id, account_from, account_to, amount) " +
                                "OUTPUT INSERTED.transfer_id " +
                                "VALUES (@transfer_type_id, @transfer_status_id, @account_from, @account_to, @amount);";
            //string sqlGetAccount = "SELECT account_id AS id FROM account WHERE user_id = @user_id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //int accountTo = 0;
                    //int accountFrom = 0;
                    conn.Open();
                    //SqlCommand command = new SqlCommand(sqlGetAccount, conn);
                    //command.Parameters.AddWithValue("@user_id", transfer.AccountTo);
                    //SqlDataReader reader = command.ExecuteReader();
                    //if (reader.Read())
                    //{
                    //    accountTo = Convert.ToInt32(reader["id"]);
                    //}
                    //reader.Close();
                    //command = new SqlCommand(sqlGetAccount, conn);
                    //command.Parameters.AddWithValue("@user_id", transfer.AccountFrom);
                    //SqlDataReader reader2 = command.ExecuteReader();
                    //if (reader2.Read())
                    //{
                    //    accountFrom = Convert.ToInt32(reader2["id"]);
                    //}
                    //reader2.Close();

                    SqlCommand command = new SqlCommand(sqlInsert, conn);
                    command.Parameters.AddWithValue("@transfer_type_id", transfer.TransferTypeId);
                    command.Parameters.AddWithValue("@transfer_status_id", transfer.TransferStatusId);
                    command.Parameters.AddWithValue("@account_from", transfer.AccountFrom);
                    command.Parameters.AddWithValue("@account_to", transfer.AccountTo);
                    command.Parameters.AddWithValue("@amount", transfer.Amount);

                    newTransferId = Convert.ToInt32(command.ExecuteScalar());

                    if (transfer.TransferTypeId == 2)
                    {
                        Account fromAccount = accountDao.GetAccountByAccountId(transfer.AccountFrom);
                        Account toAccount = accountDao.GetAccountByAccountId(transfer.AccountTo);
                        UpdateAccountBalances(fromAccount, toAccount, transfer.Amount);
                    }
                }
                newTransfer = GetTransferById(newTransferId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error contacting database.", ex);
            }
            return newTransfer;
        }

        public List<Transfer> GetTransfersByUserId(int userId)
        {
            List<Transfer> transferList = new List<Transfer>();
            string sqlSelect = "SELECT t.transfer_id, t.transfer_type_id, t.transfer_status_id, t.account_from, t.account_to, t.amount FROM transfer AS t " +
                                "JOIN account AS a1 ON t.account_from = a1.account_id " +
                                "JOIN account AS a2 ON t.account_to = a2.account_id " +
                                "WHERE a1.user_id = @user_id OR a2.user_id = @user_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlSelect, conn);
                    command.Parameters.AddWithValue("@user_id", userId);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        transferList.Add(MapRowToTransferObject(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error contacting database.", ex);
            }
            return transferList;
        }

        public List<Transfer> GetTransfersByStatusAndUserId(int userId, int statusId) // Get all pending transfers for the current user.
        {
            List<Transfer> transferList = new List<Transfer>();
            string sqlSelect = "SELECT t.transfer_id, t.transfer_type_id, t.transfer_status_id, t.account_from, t.account_to, t.amount FROM transfer as t " +
                                "JOIN account AS a1 ON t.account_from = a1.account_id " +
                                //"JOIN account AS a2 ON t.account_to = a2.account_id " +
                                "WHERE t.transfer_status_id = @transfer_status_id AND t.account_from = @account_id;";  //t.account_to = @user_id OR

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlSelect, conn);
                    command.Parameters.AddWithValue("@transfer_status_id", statusId);
                    command.Parameters.AddWithValue("@account_id", accountDao.GetAccountByUserId(userId).AccountId);
                    //using (SqlConnection conn = new SqlConnection(connectionString))
                    //{
                    //    conn.Open();

                    //    SqlCommand cmd = new SqlCommand(sql, conn);
                    //    SqlDataReader reader = cmd.ExecuteReader();

                    //    if (reader.Read())
                    //    {
                    //        count = Convert.ToInt32(reader["count"]);
                    //    }
                    //}
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        transferList.Add(MapRowToTransferObject(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error contacting database.", ex);
            }
            return transferList;
        }

        public Transfer UpdateTransferById(Transfer transfer)
        {        
            Transfer updatedTransfer = null;
            string sqlUpdate = "UPDATE transfer SET transfer_type_id = @transfer_type_id, transfer_status_id = @transfer_status_id, account_from = @account_from, account_to = @account_to, amount = @amount " +
                               "WHERE transfer_id = @transfer_id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlUpdate, conn);
                    command.Parameters.AddWithValue("@transfer_type_id", transfer.TransferTypeId);
                    command.Parameters.AddWithValue("@transfer_status_id", transfer.TransferStatusId);
                    command.Parameters.AddWithValue("@account_from", transfer.AccountFrom);
                    command.Parameters.AddWithValue("@account_to", transfer.AccountTo);
                    command.Parameters.AddWithValue("@amount", transfer.Amount);
                    command.Parameters.AddWithValue("@transfer_id", transfer.TransferId);

                    int numRowsAffected = command.ExecuteNonQuery();
                    if (numRowsAffected == 0)
                    {
                        throw new DaoException("No transfers were updated.");
                    }

                    if (transfer.TransferTypeId == 1 && transfer.TransferStatusId == 2)
                    {
                        Account fromAccount = accountDao.GetAccountByUserId(userDao.GetUserByAccountId(transfer.AccountFrom).UserId);
                        Account toAccount = accountDao.GetAccountByUserId(userDao.GetUserByAccountId(transfer.AccountTo).UserId);
                        UpdateAccountBalances(fromAccount, toAccount, transfer.Amount);
                    }
                }
                updatedTransfer = GetTransferById(transfer.TransferId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error contacting database.", ex);
            }
            return updatedTransfer;
        }

        public void UpdateAccountBalances(Account fromAccount, Account toAccount, decimal transferAmount)
        {
            decimal newFromBalance = fromAccount.Balance - transferAmount;
            decimal newToBalance = toAccount.Balance + transferAmount;
            fromAccount.Balance = newFromBalance;
            toAccount.Balance = newToBalance;
            accountDao.UpdateAccount(fromAccount);
            accountDao.UpdateAccount(toAccount);
        }

        public Transfer MapRowToTransferObject(SqlDataReader reader)
        {
            Transfer transfer = new Transfer();
            transfer.TransferId = Convert.ToInt32(reader["transfer_id"]);
            transfer.TransferStatusId = Convert.ToInt32(reader["transfer_status_id"]);
            transfer.TransferTypeId = Convert.ToInt32(reader["transfer_type_id"]);
            transfer.AccountFrom = Convert.ToInt32(reader["account_from"]);
            transfer.AccountTo = Convert.ToInt32(reader["account_to"]);
            transfer.Amount = Convert.ToDecimal(reader["amount"]);
            return transfer;
        }
    }
}
