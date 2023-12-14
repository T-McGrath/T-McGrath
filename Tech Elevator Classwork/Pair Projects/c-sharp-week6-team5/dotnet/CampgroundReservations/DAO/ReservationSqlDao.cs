using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampgroundReservations.Exceptions;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class ReservationSqlDao : IReservationDao
    {
        private readonly string connectionString;

        public ReservationSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Reservation GetReservationById(int id)
        {
            Reservation res = null;
            string sqlSelect = "SELECT * FROM reservation WHERE reservation_id = @reservation_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlSelect, conn);
                    command.Parameters.AddWithValue("@reservation_id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        res = MapRowToReservation(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("YOU FOUND AN ERROR. CONGRATULATION.", ex);
            }
            return res;
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            Reservation newRes = null;
            string sqlInsert = "INSERT INTO reservation (site_id, name, from_date, to_date, create_date) " +
                                "OUTPUT INSERTED.reservation_id " +
                                "VALUES (@site_id, @name, @from_date, @to_date, @create_date);";
            int newId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sqlInsert, conn);
                    command.Parameters.AddWithValue("@site_id", reservation.SiteId);
                    command.Parameters.AddWithValue("@name", reservation.Name);
                    command.Parameters.AddWithValue("@from_date", reservation.FromDate);
                    command.Parameters.AddWithValue("@to_date", reservation.ToDate);
                    command.Parameters.AddWithValue("@create_date", reservation.CreateDate);

                    newId = Convert.ToInt32(command.ExecuteScalar());
                }
                newRes = GetReservationById(newId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("We has error, uh-oh!", ex);
            }
            return newRes;
        }

        private Reservation MapRowToReservation(SqlDataReader reader)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationId = Convert.ToInt32(reader["reservation_id"]);
            reservation.SiteId = Convert.ToInt32(reader["site_id"]);
            reservation.Name = Convert.ToString(reader["name"]);
            reservation.FromDate = Convert.ToDateTime(reader["from_date"]);
            reservation.ToDate = Convert.ToDateTime(reader["to_date"]);
            reservation.CreateDate = Convert.ToDateTime(reader["create_date"]);

            return reservation;
        }
    }
}
