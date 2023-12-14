using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Movies.DAO
{
    public class MovieSqlDao : IMovieDao
    {
        private readonly string connectionString;

        public MovieSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Movie GetMovieById(int id)
        {
            Movie movie = null;
            string sqlString = "SELECT * FROM movie WHERE movie_id = @movie_id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.Parameters.AddWithValue("@movie_id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    movie = MapRowToMovie(reader);
                }
            }
            return movie;
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movieList = new List<Movie>();
            string sqlString = "SELECT * FROM movie;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlString, conn);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    movieList.Add(MapRowToMovie(reader));
                }
            }
            return movieList;
        }

        public List<Movie> GetMoviesByDirectorNameAndBetweenYears(string directorName, int startYear, int endYear, bool useWildCard)
        {
            List<Movie> movieList = new List<Movie>();
            string sqlString = "SELECT * FROM movie WHERE director_id IN " +
                                "(SELECT person_id FROM person WHERE person_name LIKE @director_name) " +
                                "AND release_date BETWEEN @start_year AND @end_year;";
            if (useWildCard)
            {
                directorName = $"%{directorName}%";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlString, conn);
                command.Parameters.AddWithValue("@director_name", directorName);
                command.Parameters.AddWithValue("@start_year", Convert.ToString(startYear)); 
                command.Parameters.AddWithValue("@end_year", Convert.ToString(endYear + 1)); //Add 1 because otherwise just includes movies to 1959-01-01...I think.

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    movieList.Add(MapRowToMovie(reader));
                }
            }
            return movieList;
        }

        public List<Movie> GetMoviesByTitle(string title, bool useWildCard)
        {
            List<Movie> movieList = new List<Movie>();
            string sqlString = "SELECT * FROM movie WHERE title Like @title;";
            if (useWildCard)
            {
                title = $"%{title}%";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlString, conn);
                command.Parameters.AddWithValue("@title", title);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    movieList.Add(MapRowToMovie(reader));
                }
            }
            return movieList;
        }

        public Movie MapRowToMovie(SqlDataReader reader)
        {
            Movie movie = new Movie();
            movie.Id = Convert.ToInt32(reader["movie_id"]);
            movie.Title = Convert.ToString(reader["title"]);
            movie.Overview = Convert.ToString(reader["overview"]);
            movie.Tagline = Convert.ToString(reader["tagline"]);
            movie.PosterPath = reader["poster_path"] is DBNull ? null : Convert.ToString(reader["poster_path"]);
            movie.HomePage = reader["home_page"] is DBNull ? null : Convert.ToString(reader["home_page"]);
            movie.ReleaseDate = reader["release_date"] is DBNull ? null : Convert.ToDateTime(reader["release_date"]);
            movie.LengthMinutes = reader["length_minutes"] is DBNull ? null : Convert.ToInt32(reader["length_minutes"]);
            movie.DirectorId = reader["director_id"] is DBNull ? null : Convert.ToInt32(reader["director_id"]);
            movie.CollectionId = reader["collection_id"] is DBNull ? null : Convert.ToInt32(reader["collection_id"]);
            return movie;
        }
    }
}
