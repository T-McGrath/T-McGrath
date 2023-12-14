using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
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
            string sqlString = "SELECT COUNT(*) AS count FROM park";
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

            string sql = "SELECT MIN(date_established) as oldest FROM park";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
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

            string sql = "select avg(area) as average_area from park;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
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
            var parkList = new List<string>();
            string sql = "SELECT park_name FROM park ORDER BY park_name ASC;";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string parkName = Convert.ToString(reader["park_name"]);
                    parkList.Add(parkName);
                }
            }

                return parkList;
        }

        public Park GetRandomPark()
        {
            Park park = new Park();

            string sql = "SELECT TOP 1 * FROM park ORDER BY NEWID();";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    park = MapRowToPark(reader);
                }
            }
            return park;
        }

        public IList<Park> GetParksWithCamping()
        {
            List<Park> parks = new List<Park>();
            string sql = "select park_id, park_name, date_established, area, has_camping from park where has_camping = 1";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Park park = MapRowToPark(reader);
                    parks.Add(park);
                }
            }
            return parks;
        }

        public Park GetParkById(int parkId)
        {
            Park park = null;

            string sql = "SELECT TOP 1 * FROM park where park_id = @park_id;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@park_id", parkId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    park = MapRowToPark(reader);
                }
            }
            return park;
        }

        public IList<Park> GetParksByState(string stateAbbreviation)
        {
            IList<Park> parks = new List<Park>();

            string sql = "SELECT p.park_id, park_name, date_established, area, has_camping " +
                         "FROM park p JOIN park_state ps ON p.park_id = ps.park_id " +
                         "WHERE state_abbreviation = @state_abbreviation;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Park park = MapRowToPark(reader);
                    parks.Add(park);
                }
            }

            return parks;
        }

        public IList<Park> GetParksByName(string name, bool useWildCard)
        {

            IList<Park> parks = new List<Park>();

            string sql = "SELECT p.park_id, park_name, date_established, area, has_camping " +
                         "FROM park p " +
                         "WHERE p.park_name LIKE @name";

            if (useWildCard)
            {
                name = "%" + name + "%";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Park park = MapRowToPark(reader);
                    parks.Add(park);
                }
            }

            return parks;
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            var parkRow = new Park();
            parkRow.Area = Convert.ToDecimal(reader["area"]);
            parkRow.ParkId = Convert.ToInt32(reader["park_id"]);
            parkRow.DateEstablished = Convert.ToDateTime(reader["date_established"]);
            parkRow.HasCamping = Convert.ToBoolean(reader["has_camping"]);
            parkRow.ParkName = Convert.ToString(reader["park_name"]);

            return parkRow;
        }
    }
}
