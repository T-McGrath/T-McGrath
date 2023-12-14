using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLecture.Auctioneering
{
    public class ReserveAuction : Auction
    {
        private int reservePrice;

        public override bool PlaceBid(Bid offeredBid)
        {
            bool isCurrentWinningBid = false;

            // Only consider if it meets the reserve price
            if (offeredBid.BidAmount >= reservePrice)
            {
                // Set it to current winning bid if the base
                // class behavior determines its higher than all other bids
                isCurrentWinningBid = base.PlaceBid(offeredBid);

                Console.WriteLine("Reserve has been met");
                Console.WriteLine();
            }

            return isCurrentWinningBid;
        }

        public ReserveAuction(int reservePrice) : base("This is a reserve auction")
        {
            this.reservePrice = reservePrice;
        }
    }
}
