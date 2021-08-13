using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;



namespace Capstone.DAO
{
    public class AgencySqlDAO : IAgencyDAO
    {
        private Random rand = new Random();
        private readonly string connectionString;

        private readonly string sqlGetAgency = "SELECT * FROM agencies WHERE agency_id = @agencyId;";
        private readonly string sqlGetAllAgencies = "UPDATE  agencies SET agencies.url = REPLACE(agencies.url, 'http://', ''); UPDATE  agencies SET agencies.url = REPLACE(agencies.url, 'https://', ''); SELECT * FROM agencies ORDER BY state DESC;";
        private readonly string sqlAddAgency =
            "INSERT INTO agencies(agency_id, name, street, city, state, postal_code, email, phone, lat, lon, about, url) " +
            "VALUES (@AgencyId, @Name, @Street, @City, @State, @PostalCode, @Email, @Phone, @Lat, @Lon, @About, @Url);";
        private readonly string sqlUpdateAgency =
            "UPDATE agencies SET agency_id = @AgencyId, name = @Name, street = @Street, city = @City, state = @State, " +
            "postal_code = @PostalCode, email = @Email, phone = @Phone, lat = @Lat, lon = @Lon, about = @About, url = @Url WHERE agency_id = @AgencyId ;";
        private readonly string sqlDeleteAgency = "DELETE FROM pets WHERE agency_id = @agencyId; " +
                                                  "DELETE FROM agencies WHERE agency_id = @agencyId;";

        public AgencySqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddAgency(Agency agency)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddAgency, conn);
                    AddAgencyParameters(agency, cmd);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public IEnumerable<Agency> GetAllAgencies()
        {
            List<Agency> result = new List<Agency>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllAgencies, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        result.Add(ReadAgency(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return result;
        }

        public Agency GetAgency(int agencyId)
        {
            Agency result = new Agency();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAgency, conn);
                    cmd.Parameters.AddWithValue("@agencyId", agencyId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        result = ReadAgency(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool UpdateAgency(Agency agency)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUpdateAgency, conn);
                    AddAgencyParameters(agency, cmd);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool DeleteAgency(int agencyId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlDeleteAgency, conn);
                    cmd.Parameters.AddWithValue("@agencyId", agencyId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        // Helper Methods
        private void AddAgencyParameters(Agency agency, SqlCommand cmd)
        {
            int randomId = rand.Next(9999);
            if (agency.AgencyId < 1)
            {
                cmd.Parameters.AddWithValue("@AgencyId", randomId);
            }
            else
            {
                cmd.Parameters.AddWithValue("@AgencyId", agency.AgencyId);
            }
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
        }

        private Agency ReadAgency(SqlDataReader reader)
        {
            Agency agency = new Agency();

            agency.AgencyId = Convert.ToInt32(reader["agency_id"]);
            agency.Name = Convert.ToString(reader["name"]);
            agency.Street = Convert.ToString(reader["street"]);
            agency.City = Convert.ToString(reader["city"]);
            agency.State = Convert.ToString(reader["state"]);
            agency.PostalCode = Convert.ToString(reader["postal_code"]);
            agency.Email = Convert.ToString(reader["email"]);
            agency.Phone = Convert.ToString(reader["phone"]);
            agency.Lat = Convert.ToDouble(reader["lat"]);
            agency.Lon = Convert.ToDouble(reader["lon"]);
            agency.About = Convert.ToString(reader["about"]);
            agency.Url = Convert.ToString(reader["url"]);

            return agency;
        }
    }
}
