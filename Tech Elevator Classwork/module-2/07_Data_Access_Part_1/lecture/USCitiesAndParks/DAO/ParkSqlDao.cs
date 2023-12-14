using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class ParkSqlDao : IParkDao
    {
        private readonly string connectionString;

        public ParkSqlDao(string connString)
        {
            connectionString = connString;
        }

        public int GetParkCount()
        {
            int count = 0;
            string sqlString = "SELECT COUNT(*) AS count FROM park;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    count = Convert.ToInt32(reader["count"]);
                }
            }
            return count;
        }

        public DateTime GetOldestParkDate()
        {
            DateTime oldest = new DateTime();
            string sqlString = "SELECT MIN(date_established) AS oldest FROM park;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    oldest = Convert.ToDateTime(reader["oldest"]);
                }
            }
            return oldest;
        }

        public decimal GetAverageParkArea()
        {
            decimal averageArea = 0;
            string sqlString = "SELECT AVG(area) AS average_area FROM park";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    averageArea = Convert.ToDecimal(reader["average_area"]);
                }
            }
            return averageArea;
        }

        public IList<string> GetParkNames()
        {
            List<string> parkNameList = new List<string>();
            string sqlString = "SELECT park_name FROM park ORDER BY park_name ASC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string parkName = Convert.ToString(reader["park_name"]);
                    parkNameList.Add(parkName);
                }
            }
            return parkNameList;
        }

        public Park GetRandomPark()
        {
            Park randPark = null;
            string sqlString = "SELECT TOP 1 * FROM park ORDER BY NEWID();";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    randPark = MapRowToPark(reader);
                }
            }
            return randPark;
        }

        public IList<Park> GetParksWithCamping()
        {
            List<Park> parkList = new List<Park>();
            string sqlString = "SELECT park_id, park_name, date_established, area, has_camping FROM park WHERE has_camping = 1;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Park park = MapRowToPark(reader);
                    parkList.Add(park); // Or parkList.Add(MapRowToPark(reader));
                }
            }
            return parkList;
        }

        public Park GetParkById(int parkId)
        {
            Park selectedPark = null;
            string sqlString = "SELECT * FROM park WHERE park_id = @park_id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.Parameters.AddWithValue("@park_id", parkId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    selectedPark = MapRowToPark(reader);
                }
            }
            return selectedPark;
        }

        public IList<Park> GetParksByState(string stateAbbreviation)
        {
            return new List<Park>();
        }

        public IList<Park> GetParksByName(string name, bool useWildCard)
        {
            return new List<Park>();
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            Park park = new Park();
            park.ParkId = Convert.ToInt32(reader["park_id"]);
            park.ParkName = Convert.ToString(reader["park_name"]);
            park.DateEstablished = Convert.ToDateTime(reader["date_established"]);
            park.Area = Convert.ToDecimal(reader["area"]);
            park.HasCamping = Convert.ToBoolean(reader["has_camping"]);
            
            return park;
        }
    }
}
