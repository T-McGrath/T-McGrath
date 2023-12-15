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

        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
            {
                dao = new AuctionMemoryDao();
            }
            else
            {
                dao = auctionDao;
            }
        }

        [HttpGet()]
        // Apparently this can be done with just two if statements. See the next day's HW. Whoopsie.
        public List<Auction> GetAllAuctions(string title_like = "", double currentBid_lte = 0) //Giving this a default value of an emptry string makes so this value does not have to be filled in. In that case, this method will just get ALL auctions.
        {
            if (title_like != "" && currentBid_lte != 0)
            {
                return dao.GetAuctionsByTitleAndMaxBid(title_like, currentBid_lte);
            }
            else if (title_like != "" && currentBid_lte == 0)
            {
                return dao.GetAuctionByTitle(title_like);
            }
            else if (title_like == "" && currentBid_lte != 0)
            {
                return dao.GetAuctionsByMaxBid(currentBid_lte);
            }
            return dao.GetAuctions();
        }

        [HttpGet("{id}")]
        public ActionResult<Auction> GetAuctionById(int id)
        {
            Auction auction = dao.GetAuctionById(id);
            if (auction == null)
            {
                return NoContent(); //Returns a 204 code 'No content'
            }
            return auction;
        }

        [HttpPost()]
        public Auction CreateAuction(Auction auction)
        {
            return dao.CreateAuction(auction);
        }
    }
}
