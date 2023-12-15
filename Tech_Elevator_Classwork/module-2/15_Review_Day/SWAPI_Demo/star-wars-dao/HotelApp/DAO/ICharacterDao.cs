using StarWarsCharacters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacters.DAO
{
    public interface ICharacterDao
    {
        Character CreateCharacter(Character character);
    }
}
