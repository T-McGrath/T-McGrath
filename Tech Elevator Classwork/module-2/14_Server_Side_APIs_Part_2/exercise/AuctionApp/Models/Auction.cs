using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace AuctionApp.Models
{
    public class Auction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'Title' must not be blank.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field 'Description' must not be blank.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field 'User' must not be blank.")]
        public string User { get; set; }

        [Range(0.01, int.MaxValue, ErrorMessage = "The field 'CurrentBid' must be greater than 0.")]
        public double CurrentBid { get; set; }
    }
}
