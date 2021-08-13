using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO.Interfaces;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class BreedSqlDAO : IBreedDAO
    {
        private readonly string connectionString;

        private readonly string sqlGetBreed = "SELECT * FROM breeds WHERE breed_id = @breedId;";
        private readonly string sqlGetAllBreeds = "SELECT * FROM breeds;";

        public BreedSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Breed GetBreed(int breedId)
        {
            Breed result = new Breed();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetBreed, conn);
                    cmd.Parameters.AddWithValue("@breedId", breedId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        result.BreedId = breedId;
                        result.SpeciesId = Convert.ToInt32(reader["species_id"]);
                        result.Name = Convert.ToString(reader["name"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public IEnumerable<Breed> GetAllBreeds()
        {
            List<Breed> result = new List<Breed>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllBreeds, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        Breed breed = new Breed();
                        breed.BreedId = Convert.ToInt32(reader["breed_id"]);
                        breed.SpeciesId = Convert.ToInt32(reader["species_id"]);
                        breed.Name = Convert.ToString(reader["name"]);

                        result.Add(breed);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
