using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservations.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'HotelId' is required")]
        public int HotelId { get; set; }
        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        public DateTime CheckinDate { get; set; }

        [Range(1, 14, ErrorMessage ="you can only reserve 1-14 nights")]
        public int Nights { get; set; }

        [Range(1, 5)]
        public int Guests { get; set; }

        public Reservation()
        {
            //must have parameterless constructor to deserialize
        }

        public Reservation(int id, int hotelId, string fullName, DateTime checkinDate, int nights, int guests)
        {
            Id = id;
            HotelId = hotelId;
            FullName = fullName;
            CheckinDate = checkinDate;
            Nights = nights;
            Guests = guests;
        }
    }
}
