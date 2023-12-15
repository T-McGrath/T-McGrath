using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLecture.Auctioneering
{
    public class BuyoutAuction : Auction
    {
        public int BuyOutPrice { get; private set; }

        public BuyoutAuction(int buyoutPrice, string auctionTitle) : base(auctionTitle)
        {
            
            BuyOutPrice = buyoutPrice;
        }

        public override bool PlaceBid(Bid currentBid)
        {
            if (currentBid.BidAmount >= BuyOutPrice)
            {
                base.PlaceBid(currentBid);
                base.EndAuction(); // or just EndAuction();
                return true;
            }
            else
            {
                return base.PlaceBid(currentBid);
            }
        }


        //public void IsBuyOutPriceMet(Bid currentBid)
        //{
        //    if (currentBid.BidAmount >= BuyOutPrice)
        //    {
        //        EndAuction();
        //    }
        //}
    }
}
