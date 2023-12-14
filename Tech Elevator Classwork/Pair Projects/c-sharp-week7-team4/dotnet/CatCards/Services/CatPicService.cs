using CatCards.Models;
using RestSharp;
using System;
using System.Net.Http;

namespace CatCards.Services
{
    public class CatPicService : ICatPicService
    {
        private static readonly string API_URL = "https://cat-data.netlify.app/api/pictures/random";
        private readonly RestClient client = new RestClient();

        public CatPic GetPic()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<CatPic> response = client.Get<CatPic>(request);
            CheckForErrors(response);
            return response.Data;
        }

        private void CheckForErrors(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error: unable to reach server", response.ErrorException);
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("An error was received from the server with status code " + (int)response.StatusCode);
            }
            return;
        }
    }
}
