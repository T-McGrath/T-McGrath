using StarWarsCharacters.DAO;
using StarWarsCharacters.Models;
using StarWarsCharacters.Services;
using System;
using System.Collections.Generic;

namespace StarWarsCharacters
{
    public class ApiConsumer
    {
        private readonly SwapiService swapi;
        private ICharacterDao characterDao;

        public ApiConsumer(string apiURL, ICharacterDao characterDao) 
        {
            this.characterDao = characterDao;
            this.swapi = new SwapiService(apiURL);
        }

        public void Run()
        {

            //call the service to get characters
            List<Character> list = swapi.GetAllCharacters();

            //loop through list of characters to insert them in the database via the DAO layer
            foreach (Character element in list)
            {
                characterDao.CreateCharacter(element);
            }
            Console.ReadLine();
            
        }

       
    }
}
