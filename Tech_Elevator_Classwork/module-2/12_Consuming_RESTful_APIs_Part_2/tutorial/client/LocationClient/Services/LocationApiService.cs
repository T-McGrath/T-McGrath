using LocationClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace LocationClient.Services
{
    public class LocationApiService
    {
        private RestClient client = null;
        public LocationApiService(string apiUrl)
        {
            client = new RestClient(apiUrl);
        }

        public List<Location> GetAllLocations()
        {
            RestRequest request = new RestRequest("locations");
            IRestResponse<List<Location>> response = client.Get<List<Location>>(request);
            return response.Data;
        }

        public Location GetDetailsForLocation(int locationId)
        {
            RestRequest requestOne = new RestRequest($"locations/{locationId}");
            IRestResponse<Location> response = client.Get<Location>(requestOne);
            CheckForErrors(response);
            return response.Data;
        }

        public Location AddLocation(Location newLocation)
        {
            RestRequest request = new RestRequest("locations");
            request.AddJsonBody(newLocation);
            IRestResponse<Location> response = client.Post<Location>(request);
            return response.Data;
        }

        public Location UpdateLocation(Location locationToUpdate)
        {
            RestRequest request = new RestRequest($"locations/{locationToUpdate.Id}");
            request.AddJsonBody(locationToUpdate);
            IRestResponse<Location> response = client.Put<Location>(request);
            return response.Data;
        }

        public bool DeleteLocation(int locationId)
        {
            RestRequest request = new RestRequest($"locations/{locationId}");
            IRestResponse response = client.Delete(request);
            if(response.IsSuccessful)
            {
                return true;
            }
            return false;
        }

        public void CheckForErrors(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error: unable to reach the server", response.ErrorException);
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception($"An error response was received from the server with status code " +
                                    $"{(int)response.StatusCode}.");
            }
            return; //Why is this necessary?
        }
    }
}