using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO.Interfaces;
using System.Data.SqlClient;

namespace Capstone.DAO 
{
    public class SpeciesSqlDAO : ISpeciesDAO
    {
        private readonly string connectionString;

        private readonly string sqlGetSpecies = "SELECT * FROM species WHERE species_id = @speciesId;";
        private readonly string sqlGetAllSpecies = "SELECT * FROM species;";
        private readonly string sqlGetSpeciesBreeds = "SELECT * FROM breeds WHERE species_id = @speciesId;";

        public SpeciesSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Species GetSpecies(int speciesId)
        {
            Species result = new Species();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetSpecies, conn);
                    cmd.Parameters.AddWithValue("@speciesId", speciesId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        result.SpeciesId = speciesId;
                        result.Name = Convert.ToString(reader["name"]);
                        result.Plural = Convert.ToString(reader["plural"]);
                        result.YoungSingular = Convert.ToString(reader["young_singular"]);
                        result.YoungPlural = Convert.ToString(reader["young_plural"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public IEnumerable<Species> GetAllSpecies()
        {
            List<Species> result = new List<Species>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllSpecies, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        Species species = new Species();
                        species.SpeciesId = Convert.ToInt32(reader["species_id"]);
                        species.Name = Convert.ToString(reader["name"]);
                        species.Plural = Convert.ToString(reader["plural"]);
                        species.YoungSingular = Convert.ToString(reader["young_singular"]);
                        species.YoungPlural = Convert.ToString(reader["young_plural"]);

                        result.Add(species);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public IEnumerable<Breed> GetSpeciesBreeds(int speciesId)
        {
            List<Breed> result = new List<Breed>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetSpeciesBreeds, conn);
                    cmd.Parameters.AddWithValue("@speciesId", speciesId);
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
