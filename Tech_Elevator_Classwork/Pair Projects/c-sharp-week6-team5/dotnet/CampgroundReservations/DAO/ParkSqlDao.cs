using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampgroundReservations.Exceptions;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class ParkSqlDao : IParkDao
    {
        private readonly string connectionString;

        public ParkSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Park> GetParks()
        {
            List<Park> parkList = new List<Park>();
            string sqlSelect = "SELECT * FROM park ORDER BY location ASC;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlSelect, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        parkList.Add(MapRowToPark(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error, error on the wall...", ex);
            }
            return parkList;
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            Park park = new Park();
            park.ParkId = Convert.ToInt32(reader["park_id"]);
            park.Name = Convert.ToString(reader["name"]);
            park.Location = Convert.ToString(reader["location"]);
            park.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
            park.Area = Convert.ToInt32(reader["area"]);
            park.Visitors = Convert.ToInt32(reader["visitors"]);
            park.Description = Convert.ToString(reader["description"]);

            return park;
        }
    }
}
