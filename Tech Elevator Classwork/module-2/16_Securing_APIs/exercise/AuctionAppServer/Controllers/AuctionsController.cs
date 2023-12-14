using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;
using Microsoft.AspNetCore.Authorization;
using AuctionApp.Exceptions;
using System.Security.Claims;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize] // Means user must authenticate...even though the attribue is 'authorize'
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao auctionDao;

        public AuctionsController(IAuctionDao auctionDao)
        {
            this.auctionDao = auctionDao;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return auctionDao.GetAuctionsByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return auctionDao.GetAuctionsByMaxBid(currentBid_lte);
            }

            return auctionDao.GetAuctions();
        }

        [HttpGet("{id}")]
        public ActionResult<Auction> Get(int id)
        {
            Auction auction = auctionDao.GetAuctionById(id);
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
        [Authorize(Roles = "creator, admin")]
        public ActionResult<Auction> Create(Auction auction)
        {
            Auction returnAuction = auctionDao.CreateAuction(auction);
            return Created($"/auctions/{returnAuction.Id}", returnAuction);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "creator, admin")]
        public ActionResult<Auction> Update(int id, Auction auction)
        {
            // The id on the URL takes precedence over the one in the payload, if any
            auction.Id = id;

            try
            {
                Auction updatedAuction = auctionDao.UpdateAuction(auction);
                return Ok(updatedAuction);

            }
            catch (DaoException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            int numDeleted = auctionDao.DeleteAuctionById(id);
            if (numDeleted == 1)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("whoami")]
        public ActionResult WhoAmI()
        {
            return Ok($"{User.Identity.Name}"); // OR Ok($"{User.FindFirst("name")?.Value}"); 
                                            // Or could use...Ok($"{User.FindFirstValue("name")}");...but where to put the ?
        }
    }
}
