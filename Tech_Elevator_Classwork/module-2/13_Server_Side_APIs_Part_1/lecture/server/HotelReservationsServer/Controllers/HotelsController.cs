using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.DAO;

namespace HotelReservations.Controllers
{
    [Route("hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static IHotelDao hotelDao;

        public HotelsController()
        {
            if (hotelDao == null)
            {
                hotelDao = new HotelMemoryDao();
            }
        }

        [HttpGet()]
        public List<Hotel> ListHotels()
        {
            return hotelDao.GetHotels();
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> GetHotel(int id)
        {
            Hotel hotel = hotelDao.GetHotelById(id);

            if (hotel != null)
            {
                return hotel;
            }
            else
            {
                return NotFound();
            }
        }

        
        // THIS WILL NOT WORK because the HTTP attribute is the same as the GetList one. Need to make sure that method (or the corresponding one in HotelsMemoryDao)
        // 
        //[HttpGet()] // /hotels?state=oh&city=cleveland...........considered same path as /hotels, but has a query parameters of state=oh&city=cleveland
        //public List<Hotel> GetHotelByState(string state, string city)
        //{
        //    return hotelDao.GetHotelsByStateAndCity(state, city);
        //}
    }
}
