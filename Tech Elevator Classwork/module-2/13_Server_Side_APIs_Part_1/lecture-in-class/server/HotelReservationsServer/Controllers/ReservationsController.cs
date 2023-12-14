using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservations.Controllers
{
    //[Route("reservations")]
    [Route("[controller]")]
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
        public List<Reservation> ListAllReservations()
        {
            return reservationDao.GetReservations();
        }

        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = reservationDao.GetReservationById(id);
            if(reservation != null)
            {
                return reservation;
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("/hotels/{hotelId}/reservations")]
        public ActionResult<List<Reservation>> ListReservationsByHotel(int hotelId)
        {
            Hotel hotel = hotelDao.GetHotelById(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }
            return reservationDao.GetReservationsByHotel(hotelId);
        }

        [HttpPost()]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            Reservation added = reservationDao.CreateReservation(reservation);
            string uri = $"reservations/{added.Id}";
            return Created(uri, added);
        }



    }
}
