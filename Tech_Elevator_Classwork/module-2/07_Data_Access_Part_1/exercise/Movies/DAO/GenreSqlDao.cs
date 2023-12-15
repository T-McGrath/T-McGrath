using Movies.Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Movies.DAO
{
    public class GenreSqlDao : IGenreDao
    {
        private readonly string connectionString;

        public GenreSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Genre GetGenreById(int id)
        {
            Genre genre = null;
            string sqlString = "SELECT genre_id, genre_name FROM genre WHERE genre_id = @genre_id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@genre_id", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    genre = MapRowToGenre(reader);
                }
            }
            return genre;
        }

        public List<Genre> GetGenres()
        {
            List<Genre> genreList = new List<Genre>();
            string sqlString = "SELECT * FROM genre ORDER BY genre_name ASC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlString, conn);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    genreList.Add(MapRowToGenre(reader));
                }
            }
            return genreList;
        }

        public List<Genre> GetGenresByName(string name, bool useWildCard)
        {
            List<Genre> genreList = new List<Genre>();
            string sqlString = "SELECT * FROM genre WHERE genre_name LIKE @name;";
            if(useWildCard)
            {
                name = $"%{name}%";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmnd = new SqlCommand(sqlString, conn);
                cmnd.Parameters.AddWithValue("@name", name);

                SqlDataReader reader = cmnd.ExecuteReader();
                while (reader.Read())
                {
                    genreList.Add(MapRowToGenre(reader));
                }
            }
            return genreList;
        }

        public Genre MapRowToGenre(SqlDataReader reader)
        {
            Genre genre = new Genre();
            genre.Id = Convert.ToInt32(reader["genre_id"]);
            genre.Name = Convert.ToString(reader["genre_name"]);
            return genre;
        }
    }
}
