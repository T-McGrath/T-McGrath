using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservations.Controllers
{
    [Route("reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private static IReservationDao reservationDao;
        private static IHotelDao hotelDao;
        public ReservationsController()
        {
            if (hotelDao == null)
            {
                hotelDao = new HotelMemoryDao();
            }
            if (reservationDao == null)
            {
                reservationDao = new ReservationMemoryDao();
            }
        }
        [HttpGet()]
        public List<Reservation> GetAllReservations()
        {
            return reservationDao.GetReservations();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id) //ActionResult will allow us to access other info that comes from the response, such as status code.
        {
            Reservation res = reservationDao.GetReservationById(id);
            if (res != null)
            {
                return res;
            }
            return NotFound();
        }

        [HttpGet("/hotel/{hotelId}/reservations")] // NEED the slash before 'hotel' so we don't start at 'reservation' as it states in the top attribute.
        public ActionResult<List<Reservation>> GetReservationByHotel(int hotelId)
        {
            Hotel hotel = hotelDao.GetHotelById(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }
            return reservationDao.GetReservationsByHotel(hotelId);
        }

        [HttpPost()]
        public ActionResult<Reservation> CreateNewReservation(Reservation res)
        {
            Reservation newRes = reservationDao.CreateReservation(res);
            string uri = $"/reservations/{newRes.Id}"; // URI is Uniform Resource Indicator (same idea as URL)
            return Created(uri, newRes);
        }


    }
}
