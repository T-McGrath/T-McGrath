using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsCharacters.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }
        public string Url { get; set; }
        public string Homeworld { get; set; }

        [JsonPropertyName("hair_color")]
        public string HairColor { get; set; }


       
    }
}
