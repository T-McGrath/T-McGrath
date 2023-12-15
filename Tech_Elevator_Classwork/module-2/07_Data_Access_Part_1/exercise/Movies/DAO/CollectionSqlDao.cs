using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Movies.DAO
{
    public class CollectionSqlDao : ICollectionDao
    {
        private readonly string connectionString;

        public CollectionSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Collection GetCollectionById(int id)
        {
            Collection collection = null;
            string sqlString = "SELECT * FROM collection WHERE collection_id = @collection_id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.Parameters.AddWithValue("@collection_id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    collection = MapRowToCollection(reader);
                }
            }
            return collection;
        }

        public List<Collection> GetCollections()
        {
            List<Collection> collectionList = new List<Collection>();
            string sqlString = "SELECT * FROM collection ORDER BY collection_name ASC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Collection collection = MapRowToCollection(reader);
                    collectionList.Add(collection);
                }
            }
            return collectionList;
        }

        public List<Collection> GetCollectionsByName(string name, bool useWildCard)
        {
            List<Collection> collectionList = new List<Collection>();
            string sqlString = "SELECT collection_id, collection_name FROM collection WHERE collection_name LIKE @collection_name;";
            if (useWildCard)
            {
                name = $"%{name}%";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);                
                cmd.Parameters.AddWithValue("@collection_name", name);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    collectionList.Add(MapRowToCollection(reader));
                }
            }
            return collectionList;
        }

        public Collection MapRowToCollection(SqlDataReader reader)
        {
            Collection collection = new Collection();
            collection.Id = Convert.ToInt32(reader["collection_id"]);
            collection.Name = Convert.ToString(reader["collection_name"]);
            return collection;
        }
    }
}
