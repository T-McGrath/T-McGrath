using HotelReservations.DAO;
using HotelReservations.Models;
using System.Collections.Generic;

namespace HotelReservationsServer.DAO
{
    public class HotelSqlDao : IHotelDao
    {
        public Hotel GetHotelById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Hotel> GetHotels()
        {
            throw new System.NotImplementedException();
        }

        public List<Hotel> GetHotelsByStateAndCity(string state, string city)
        {
            throw new System.NotImplementedException();
        }
    }
}
