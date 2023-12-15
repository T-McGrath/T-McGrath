using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLecture.Auctioneering
{
    /// <summary>
    /// A buyout auction sets a buyout price that the bidder can use allowing
    /// the auction to end.
    /// </summary>
    public class BuyoutAuction : Auction
    {

        public BuyoutAuction(int buyoutPrice, string title) : base(title)
        {
            
            BuyoutPrice = buyoutPrice;
        }
        public int BuyoutPrice { get; private set; }

        public override bool PlaceBid(Bid hedgehog)
        {
            if (hedgehog.BidAmount >= BuyoutPrice)
            {
                base.PlaceBid(hedgehog);
                Console.WriteLine("Buyout met by: " + hedgehog.Bidder + " for " + hedgehog.BidAmount);
                base.EndAuction();
                return true;
            }
            else
            {
               return base.PlaceBid(hedgehog);
            }

        }

    }
}
