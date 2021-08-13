using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using PopulateDatabaseFromRescueGroupAPI.Models;
using PopulateDatabaseFromRescueGroupAPI.DAO;
using PopulateDatabaseFromRescueGroupAPI.DAO.Interfaces;

namespace PopulateDatabaseFromRescueGroupAPI.DAO
{
    class BreedSqlDAO : IBreedDAO
    {
        private readonly string connectionString;

        private readonly string sqlAddBreed =
            "INSERT INTO breeds(breed_id, species_id, name) " +
            "VALUES (@BreedId, @SpeciesId, @Name);";

        public BreedSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddBreeds(IEnumerable<Breed> breeds)
        {
            bool result = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (Breed breed in breeds)
                    {
                        if (!AddBreed(breed, conn))
                        {
                            result = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        private bool AddBreed(Breed breed, SqlConnection conn)
        {
            bool result = false;

            SqlCommand cmd = new SqlCommand(sqlAddBreed, conn);
            cmd.Parameters.AddWithValue("@BreedId", breed.BreedId);
            cmd.Parameters.AddWithValue("@SpeciesId", breed.SpeciesId);
            cmd.Parameters.AddWithValue("@Name", breed.Name);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                result = true;

            return result;
        }
    }
}
