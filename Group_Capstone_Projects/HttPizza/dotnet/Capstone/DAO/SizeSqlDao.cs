using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Exceptions;
using Capstone.Models;

namespace Capstone.DAO
{
    public class SizeSqlDao :ISizeDao
    {
        private readonly string connectionString;
        public SizeSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public IList<Size> GetAllSizes()
        {
            IList<Size> sizes = new List<Size>();
            string sql = "SELECT * FROM sizes;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Size size = MapRowToSize(reader);
                        sizes.Add(size);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw new DaoException("SQL Exception Occured!", ex);
            }
            return sizes;
        }
        public Size GetSizeById(int sizeId)
        {
            Size size = null;
            string sql = "SELECT * FROM sizes WHERE size_id = @size_id;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@size_id", sizeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        size = MapRowToSize(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception Occured!", ex);
            }
            return size;
        }
        public Size UpdateSizeAvailability(int sizeId, Size size)
        {
            Size updatedSize = null;
            string sql = "UPDATE sizes SET size_name = @size_name, is_available = @is_available WHERE size_id = @size_id;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@size_name", size.SizeName);
                    cmd.Parameters.AddWithValue("@is_available", size.IsAvailable);
                    cmd.Parameters.AddWithValue("@size_id", sizeId);
                    cmd.ExecuteNonQuery();
                }
                updatedSize = GetSizeById(sizeId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception Occured!", ex);
            }
            return updatedSize;
        }
        public Size CreateSize(Size size)
        {
            Size newSize = null;
            string sql = "INSERT INTO sizes (size_name, is_available) " +
                            "OUTPUT INSERTED.size_id " +
                            "VALUES (@size_name, @is_available);";
            try
            {
                int newSizeId;
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@size_name", size.SizeName);
                    cmd.Parameters.AddWithValue("@is_available", size.IsAvailable);
                    newSizeId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                newSize = GetSizeById(newSizeId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception Occured!", ex);
            }
            return newSize;
        }
        public Size MapRowToSize(SqlDataReader reader)
        {
            Size size = new Size();
            size.SizeId = Convert.ToInt32(reader["size_id"]);
            size.SizeName = Convert.ToString(reader["size_name"]);
            size.IsAvailable = Convert.ToBoolean(reader["is_available"]);
            return size;
        }
    }
}
