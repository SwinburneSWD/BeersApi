using System.Collections.Generic;
using System.Data.SqlClient;
using BeersLib;

namespace BeersApi.Handlers
{
    public class DbHandler
    {
        static string connectionString = "Server=beersdb.cxirr1vtrojf.us-east-1.rds.amazonaws.com;Database=BeersDB;User Id=admin;password=abcd1234";
        SqlConnection connection;

        public string Connect() {
            connection = new SqlConnection(connectionString);
            connection.Open();

            return "Ok";

        }

        public List<Beer> GetAllBeers() {
            this.Connect();

            SqlCommand command = new SqlCommand("SELECT * FROM Beer", connection);
            
            SqlDataReader reader = command.ExecuteReader();
            
            List<Beer> beers = new List<Beer>();

            // result of command.ExecuteReader is an object that can only be traversed one way
            while (reader.Read())
            {
                // convert the data from DB into the object neeeded
                string name = reader.GetString(0);
                string brewery = reader.GetString(1);
                float abv = (float)reader.GetDecimal(2);
                uint ibu = (uint)reader.GetInt32(3);
                int amount = reader.GetInt32(4);
                float cost = (float)reader.GetDecimal(5);

                beers.Add(new Beer(name, brewery, abv, ibu, amount, cost));

            }

            return beers;
        }
    }

}

