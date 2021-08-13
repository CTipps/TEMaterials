using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using PopulateDatabaseFromRescueGroupAPI.Models;
using PopulateDatabaseFromRescueGroupAPI.DAO;
using PopulateDatabaseFromRescueGroupAPI.DAO.Interfaces;

namespace PopulateDatabaseFromRescueGroupAPI.DAO
{
    class SpeciesSqlDAO : ISpeciesDAO
    {
        private readonly string connectionString;

        private readonly string sqlAddSpecies =
            "INSERT INTO species(species_id, name, plural, young_singular, young_plural) " +
            "VALUES (@SpeciesId, @Name, @Plural, @YoungSingular, @YoungPlural);";

        public SpeciesSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddAllSpecies(IEnumerable<Species> allSpecies)
        {
            bool result = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (Species species in allSpecies)
                    {
                        if (!AddSpecies(species, conn))
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

        private bool AddSpecies(Species species, SqlConnection conn)
        {
            bool result = false;

            SqlCommand cmd = new SqlCommand(sqlAddSpecies, conn);
            cmd.Parameters.AddWithValue("@SpeciesId", species.SpeciesId);
            cmd.Parameters.AddWithValue("@Name", species.Name);
            cmd.Parameters.AddWithValue("@Plural", species.Plural);
            cmd.Parameters.AddWithValue("@YoungSingular", species.YoungSingular);
            cmd.Parameters.AddWithValue("@YoungPlural", species.YoungPlural);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                result = true;

            return result;
        }
    }
}
