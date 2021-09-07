using System.Collections.Generic;
using System.Data.SqlClient;
using BeersLib;

namespace BeersApi.Handlers
{
    public class DbHandler
    {
        static string connectionString = "Server=beersdb.cxjl13cbth6s.us-east-1.rds.amazonaws.com;Database=BeersDB;User Id=admin;password=abcd1234";
        SqlConnection connection;

        public string Connect() {
            connection = new SqlConnection(connectionString);
            connection.Open();

            return "Ok";

        }

        public List<Beer> GetAllBeers() {
            
            List<Beer> beers = new List<Beer>();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
            
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Beer", connection);
                
                SqlDataReader result = command.ExecuteReader();
                
                // result of command.ExecuteReader is an object that can only be traversed one way
                while (result.Read())
                {
                    // convert the data from DB into the object neeeded
                    string name = result.GetString(0);
                    string brewery = result.GetString(1);
                    float abv = (float)result.GetDecimal(2);
                    uint ibu = (uint)result.GetInt32(3);
                    int amount = result.GetInt32(4);
                    float cost = (float)result.GetDecimal(5);

                    beers.Add(new Beer(name, brewery, abv, ibu, amount, cost));

                }
            }
            
            return beers;
        }

        public Beer GetBeerByName(string name) {
            string query = "SELECT * FROM Beer WHERE Name = @Name"; 
            
            Beer foundBeer = null;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);

                // SqlParameter is used to protect against SQL Injection
                SqlParameter nameParam = new SqlParameter();
                nameParam.ParameterName = "@Name";
                nameParam.Value = name;

                command.Parameters.Add(nameParam);

                connection.Open();
                SqlDataReader result = command.ExecuteReader();

                // result of command.ExecuteReader is an object that can only be traversed one way
                while (result.Read())
                {
                    // convert the data from DB into the object neeeded
                    string beerName = result.GetString(0);
                    string brewery = result.GetString(1);
                    float abv = (float)result.GetDecimal(2);
                    uint ibu = (uint)result.GetInt32(3);
                    int amount = result.GetInt32(4);
                    float cost = (float)result.GetDecimal(5);

                    foundBeer = new Beer(beerName, brewery, abv, ibu, amount, cost);
                }
            
            }

            return foundBeer;

        }
    }

}

