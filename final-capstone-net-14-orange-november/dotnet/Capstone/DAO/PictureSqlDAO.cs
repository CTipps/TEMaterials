using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO.Interfaces;
using System.Data.SqlClient;

namespace Capstone.DAO 
{
    public class PictureSqlDAO : IPictureDAO
    {
        private readonly string connectionString;

        private readonly string sqlGetPetPictures = "SELECT * FROM pictures WHERE pet_id = @petId;";

        public PictureSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IEnumerable<Picture> GetPetPictures(int petId)
        {
            List<Picture> result = new List<Picture>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetPetPictures, conn);
                    cmd.Parameters.AddWithValue("@petId", petId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        Picture picture = new Picture();
                        picture.PictureId = Convert.ToInt32(reader["picture_id"]);
                        picture.PetId = Convert.ToInt32(reader["pet_id"]);
                        picture.Url = Convert.ToString(reader["url"]);

                        result.Add(picture);
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
