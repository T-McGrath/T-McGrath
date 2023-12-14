using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampgroundReservations.Exceptions;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class SiteSqlDao : ISiteDao
    {
        private readonly string connectionString;

        public SiteSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Site> GetSitesWithRVAccessByParkId(int parkId)
        {
            List<Site> siteList = new List<Site>();
            string sqlSelect = "SELECT * FROM site WHERE max_rv_length > 0 AND campground_id IN " +
                "(SELECT campground_id FROM campground WHERE park_id = @park_id);";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlSelect, conn);
                    command.Parameters.AddWithValue("@park_id", parkId);

                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        siteList.Add(MapRowToSite(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("OH NOOOOOOOOOOOOOOOOOO!", ex);
            }
            return siteList;
        }

        public IList<Site> GetSitesAvailableTodayByParkId(int parkId)
        {
            List<Site> siteList = new List<Site>();
            string sqlSelect = "SELECT * FROM site WHERE campground_id IN " +
                                "(SELECT campground_id FROM campground WHERE park_id = @park_id) " +
                                "AND site_id IN (SELECT site_id FROM reservation WHERE GETDATE() NOT BETWEEN " +
                                "from_date AND to_date);";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlSelect, conn);
                    command.Parameters.AddWithValue("@park_id", parkId);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        siteList.Add(MapRowToSite(reader));
                    }
                }
            }
            catch(SqlException ex)
            {
                throw new DaoException("Error?", ex);
            }
            return siteList;
        }

        private Site MapRowToSite(SqlDataReader reader)
        {
            Site site = new Site();
            site.SiteId = Convert.ToInt32(reader["site_id"]);
            site.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            site.SiteNumber = Convert.ToInt32(reader["site_number"]);
            site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
            site.Accessible = Convert.ToBoolean(reader["accessible"]);
            site.MaxRVLength = Convert.ToInt32(reader["max_rv_length"]);
            site.Utilities = Convert.ToBoolean(reader["utilities"]);

            return site;
        }
    }
}
