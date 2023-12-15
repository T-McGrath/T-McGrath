using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Movies.DAO
{
    public class PersonSqlDao : IPersonDao
    {
        private readonly string connectionString;

        public PersonSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Person GetPersonById(int id)
        {
            Person person = null;
            string sqlString = "SELECT * FROM person WHERE person_id = @person_id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.Parameters.AddWithValue("@person_id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    person = MapRowToPerson(reader);
                }    
            }
            return person;
        }

        public List<Person> GetPersons()
        {
            List<Person> personList = new List<Person>();
            string sqlString = "SELECT * FROM person;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    personList.Add(MapRowToPerson(reader));
                }
            }
            return personList;
        }

        public List<Person> GetPersonsByCollectionName(string collectionName, bool useWildCard)
        {
            List<Person> personList = new List<Person>();
            //string sqlString = "SELECT * FROM person WHERE person_id IN " +
            //                    "(SELECT actor_id FROM movie_actor WHERE movie_id IN " +
            //                    "(SELECT movie_id FROM movie WHERE collection_id IN " +
            //                    "(SELECT collection_id FROM [collection] WHERE collection_name LIKE @collection_name)));";
            string sqlString = "SELECT * FROM person AS p " +
                                "INNER JOIN movie_actor AS ma ON p.person_id = actor_id " +
                                "INNER JOIN movie As m ON ma.movie_id = m.movie_id " +
                                "INNER JOIN[collection] AS c ON m.collection_id = c.collection_id " +
                                "WHERE collection_name LIKE @collection_name;";
            if (useWildCard)
            {
                collectionName = $"%{collectionName}%";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.Parameters.AddWithValue("@collection_name", collectionName);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    personList.Add(MapRowToPerson(reader));
                }
            }
            return personList;
        }

        public List<Person> GetPersonsByName(string name, bool useWildCard)
        {
            List<Person> personList = new List<Person>();
            string sqlString = "SELECT * FROM person WHERE person_name LIKE @person_name;";
            if (useWildCard)
            {
                name = $"%{name}%";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.Parameters.AddWithValue("@person_name", name);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    personList.Add(MapRowToPerson(reader));
                }
            }
            return personList;
        }

        public Person MapRowToPerson(SqlDataReader reader)
        {
            Person human = new Person();
            human.Id = Convert.ToInt32(reader["person_id"]);
            human.Name = SqlUtil.NullableString(reader["person_name"]);
            human.Birthday = SqlUtil.NullableDateTime(reader["birthday"]);
            human.DeathDate = SqlUtil.NullableDateTime(reader["deathday"]);
            human.Biography = SqlUtil.NullableString(reader["biography"]);
            human.ProfilePath = SqlUtil.NullableString(reader["profile_path"]);
            human.HomePage = SqlUtil.NullableString(reader["home_page"]);
            return human;
        }
    }
}
