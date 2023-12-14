using CatCards.Models;
using RestSharp;
using System;
using System.Net.Http;

namespace CatCards.Services
{
    public class CatFactService : ICatFactService
    {
        private static readonly string API_URL = "https://cat-data.netlify.app/api/facts/random";
        private readonly RestClient client = new RestClient();

        public CatFact GetFact()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<CatFact> response = client.Get<CatFact>(request);
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
