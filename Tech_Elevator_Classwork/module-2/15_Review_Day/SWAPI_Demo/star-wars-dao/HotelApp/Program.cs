using Microsoft.Extensions.Configuration;
using StarWarsCharacters.DAO;
using StarWarsCharacters.Utility;
using System;

namespace StarWarsCharacters
{
    class Program
    {
        private const string ApiUrl = "https://swapi.dev/api/";
        static void Main()
        {
            try
            {
                IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

                string connectionString = config.GetConnectionString("StarWarsCharactersConnection");
                ICharacterDao characterDao = new CharacterSqlDao(connectionString);
                ApiConsumer app = new ApiConsumer(ApiUrl, characterDao);

                app.Run();
            }
            catch(Exception ex)
            {
                BasicLogger.Log(ex.Message);         
            }
        }
    }
}
