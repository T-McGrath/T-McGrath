using RestSharp;
using StarWarsCharacters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacters.Services
{
    public class SwapiService
    {
        private static RestClient client = null;
        public SwapiService(string url)
        {
            if (client == null)
            {
                client = new RestClient(url);
            }
        }
        //todo: get characters from swapi
        public List<Character> GetAllCharacters()
        {
            HttpStatusCode currentCode = HttpStatusCode.OK;
            List<Character> allCharacters = new List<Character>();
            int pageNum = 1;
            while (currentCode == HttpStatusCode.OK)
            {
                RestRequest request = new RestRequest($"people?page={pageNum}");
                IRestResponse<SWApiResponse> response = client.Get<SWApiResponse>(request);
                if (response.IsSuccessful)
                {
                    SWApiResponse returnedObject = response.Data;
                    allCharacters.AddRange(returnedObject.Results);
                    pageNum++;
                }
                else
                {
                    currentCode = response.StatusCode;
                }
            }

            return allCharacters;

            
        }
    }
}
