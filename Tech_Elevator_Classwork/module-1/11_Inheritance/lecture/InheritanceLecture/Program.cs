using InheritanceLecture.Auctioneering;
using System;

namespace InheritanceLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new general auction
            Console.WriteLine("Starting a general auction");
            Console.WriteLine("-----------------");

            Auction generalAuction = new Auction("A new general auction. Hooray!");

            Bid offeredBid = new Bid("Josh", 1);
            generalAuction.PlaceBid(offeredBid);
            generalAuction.PlaceBid(new Bid("Fonz", 23));
            generalAuction.PlaceBid(new Bid("Rick Astley", 13));

            //ReserveAuction reserveA = new ReserveAuction(10);
            

            Console.ReadLine();
            generalAuction.EndAuction();
        }
    }
}
