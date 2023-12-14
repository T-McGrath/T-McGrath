using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao)
        {
            dao = auctionDao;
        }

        [HttpGet]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return dao.GetAuctionsByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return dao.GetAuctionsByMaxBid(currentBid_lte);
            }

            return dao.GetAuctions();
        }

        [HttpGet("{id}")]
        public ActionResult<Auction> Get(int id)
        {
            Auction auction = dao.GetAuctionById(id);
            if (auction != null)
            {
                return Ok(auction);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Auction> Create(Auction auction)
        {
            Auction newAuction = dao.CreateAuction(auction);
            string uri = $"/auctions/{newAuction.Id}";
            return Created(uri, newAuction);
        }

        [HttpPut("{id}")]
        public ActionResult<Auction> UpdateAuction(Auction auction, int id)
        {
            auction.Id = id;
            try
            {
                Auction updatedAuction = dao.UpdateAuction(auction);
                return Ok(updatedAuction);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAuction(int id)
        {
            int result = dao.DeleteAuctionById(id);
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
