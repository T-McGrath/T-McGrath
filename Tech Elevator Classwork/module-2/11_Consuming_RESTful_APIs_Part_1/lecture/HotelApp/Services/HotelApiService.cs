using HotelApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HotelApp.Services
{
    public class HotelApiService
    {
        protected static RestClient client = null;

        public HotelApiService(string apiUrl)
        {
            if (client == null)
            {
                client = new RestClient(apiUrl);
            }
        }

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest("hotels"); // Add the last part of the URL (endpoint) for the API. This is a relative path.
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            CheckForError(response);
            return response.Data; //This contains just the hotel data, whereas the response variable holds the status code, headers, the hotel data, ect.
        }

        public List<Review> GetReviews()
        {
            RestRequest request = new RestRequest("reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            CheckForError(response);
            return response.Data;
        }

        public Hotel GetHotel(int hotelId)
        {
            RestRequest request = new RestRequest($"hotels/{hotelId}");
            IRestResponse<Hotel> response = client.Get<Hotel>(request);
            CheckForError(response);
            return response.Data;
        }

        public List<Review> GetHotelReviews(int hotelId)
        {
            RestRequest request = new RestRequest($"hotels/{hotelId}/reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            CheckForError(response);
            return response.Data;
        }

        public List<Hotel> GetHotelsWithRating(int starRating)
        {
            RestRequest request = new RestRequest($"hotels?stars = {starRating}");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            CheckForError(response);
            return response.Data;
        }

        public City GetPublicAPIQuery()
        {
            RestRequest request = new RestRequest("https://api.teleport.org/api/cities/geonameid:512581/"); //Absolute path.
            IRestResponse<City> response = client.Get<City>(request);
            CheckForError(response);
            return response.Data;
        }

        public void CheckForError(IRestResponse response)
        {
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("There was an error accessing data from the server. Yikes!");
            }
        }
    }
}
