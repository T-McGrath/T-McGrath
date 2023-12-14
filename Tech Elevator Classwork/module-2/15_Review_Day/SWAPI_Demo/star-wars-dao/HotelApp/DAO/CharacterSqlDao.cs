using StarWarsCharacters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StarWarsCharacters.DAO
{
    public class CharacterSqlDao : ICharacterDao
    {
        private string connectionString;

        public CharacterSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Character CreateCharacter(Character character)
        {

            Character newCharacter = null;

            string sql = "insert into characters (name, url, birth_year, name_of_homeworld, hair_color) output inserted.id values(@name, @url, @birth_year, @name_of_homeworld, @hair_color);";

         
                int newCharacterId;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", character.Name);
                    cmd.Parameters.AddWithValue("@url", character.Url);
                    cmd.Parameters.AddWithValue("@birth_year", character.BirthYear);
                //IF this was null (as we thought it might be!) we would have to handle that by inserting "DBNull" there.
                //I did this with a ternery, which is one option. There is another option called "null-coalescing operator"
                //which makes this EVEN SHORTER but I don't want to confuse you further.
                    cmd.Parameters.AddWithValue("@name_of_homeworld", character.Homeworld == null ?  DBNull.Value : character.Homeworld );
                    cmd.Parameters.AddWithValue("@hair_color", character.HairColor);

                    newCharacterId = Convert.ToInt32(cmd.ExecuteScalar());
                }

            newCharacter = GetCharacterById(newCharacterId);
            return newCharacter;
            

        }
        public Character GetCharacterById(int id)
        {
            Character character = null;
            string sql = "SELECT * FROM characters WHERE id = @id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    character = new Character();
                    character.Id = Convert.ToInt32(reader["id"]);
                    character.Name = Convert.ToString(reader["name"]);
                    character.BirthYear = Convert.ToString(reader["birth_year"]);
                    character.Homeworld = Convert.ToString(reader["name_of_homeworld"]);
                    character.HairColor = Convert.ToString(reader["hair_color"]);

                }
            }
            return character;

        }
    }
}
