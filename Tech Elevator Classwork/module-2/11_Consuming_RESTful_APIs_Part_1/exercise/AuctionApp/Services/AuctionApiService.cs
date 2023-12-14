using RestSharp;
using System.Collections.Generic;
using AuctionApp.Models;
using System.Net.Http;
using System.Collections.Specialized;

namespace AuctionApp.Services
{
    public class AuctionApiService
    {
        public IRestClient client;

        public AuctionApiService(string apiUrl)
        {
            client = new RestClient(apiUrl);
        }

        public void CheckForErrors(IRestResponse response)
        {
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Oh noooooo! There was an error accessing the server.");
            }
        }

        public List<Auction> GetAllAuctions()
        {
            RestRequest request = new RestRequest("auctions"); // Don't need the / before 'auctions' but it seems to work either way.
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            CheckForErrors(response);
            return response.Data;

        }

        public Auction GetDetailsForAuction(int auctionId)
        {
            RestRequest request = new RestRequest($"auctions/{auctionId}");
            IRestResponse<Auction> response = client.Get<Auction>(request);
            CheckForErrors(response);
            return response.Data;
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTerm)
        {
            RestRequest request = new RestRequest($"auctions?title_like={searchTerm}");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            CheckForErrors(response);
            return response.Data;
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            RestRequest request = new RestRequest($"auctions?currentBid_lte={searchPrice}");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            CheckForErrors(response);
            return response.Data;
        }
    }
}
