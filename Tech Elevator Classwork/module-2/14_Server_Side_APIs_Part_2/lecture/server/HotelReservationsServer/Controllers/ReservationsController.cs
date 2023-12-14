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
        private IReservationDao reservationDao;
        private IHotelDao hotelDao;
        public ReservationsController(IHotelDao hotelDao, IReservationDao reservationDao)
        {
            this.hotelDao = hotelDao;
            this.reservationDao = reservationDao;
        }

        [HttpGet()]
        public List<Reservation> ListReservations()
        {
            return reservationDao.GetReservations();
        }

        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = reservationDao.GetReservationById(id);

            if (reservation != null)
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
            return Created($"/reservations/{added.Id}", added);
        }

        [HttpPut("{id}")]
        public ActionResult<Reservation> UpdateReservation(int id, Reservation res)
        {
            res.Id = id; // Make sure the reservation object's ID is the one within the parameter, regardless of what was set originally in the object. This is the CONVENTIONAL way of doing things.
            try
            {
                Reservation updatedRes = reservationDao.UpdateReservation(res);
                return Ok(updatedRes);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            int result = reservationDao.DeleteReservationById(id); // The DeleteReservationById method returns a 1 if successful and 0 if not.
            if (result == 1)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
