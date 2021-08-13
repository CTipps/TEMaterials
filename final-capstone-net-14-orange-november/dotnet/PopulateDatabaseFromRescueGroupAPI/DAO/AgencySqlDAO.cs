using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using PopulateDatabaseFromRescueGroupAPI.Models;
using PopulateDatabaseFromRescueGroupAPI.DAO;
using PopulateDatabaseFromRescueGroupAPI.DAO.Interfaces;

namespace PopulateDatabaseFromRescueGroupAPI.DAO
{
    class AgencySqlDAO : IAgencyDAO
    {
        private readonly string connectionString;

        private readonly string sqlAddAgency =
            "INSERT INTO agencies(agency_id, name, street, city, state, postal_code, " +
            "email, phone, lat, lon, about, url) " +
            "VALUES (@AgencyId, @Name, @Street, @City, @State, @PostalCode, @Email, " +
            "@Phone, @Lat, @Lon, @About, @Url);";

        public AgencySqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddAgencies(IEnumerable<Agency> agencies)
        {
            bool result = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (Agency agency in agencies)
                    {
                        if (!AddAgency(agency, conn))
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

        private bool AddAgency(Agency agency, SqlConnection conn)
        {
            bool result = false;

            SqlCommand cmd = new SqlCommand(sqlAddAgency, conn);
            cmd.Parameters.AddWithValue("@AgencyId", agency.AgencyId);
            cmd.Parameters.AddWithValue("@Name", agency.Name);
            cmd.Parameters.AddWithValue("@Street", agency.Street);
            cmd.Parameters.AddWithValue("@City", agency.City);
            cmd.Parameters.AddWithValue("@State", agency.State);
            cmd.Parameters.AddWithValue("@PostalCode", agency.PostalCode);
            cmd.Parameters.AddWithValue("@Email", agency.Email);
            cmd.Parameters.AddWithValue("@Phone", agency.Phone);
            cmd.Parameters.AddWithValue("@Lat", agency.Lat);
            cmd.Parameters.AddWithValue("@Lon", agency.Lon);
            cmd.Parameters.AddWithValue("@About", agency.About);
            cmd.Parameters.AddWithValue("@Url", agency.Url);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                result = true;

            return result;
        }
    }
}
