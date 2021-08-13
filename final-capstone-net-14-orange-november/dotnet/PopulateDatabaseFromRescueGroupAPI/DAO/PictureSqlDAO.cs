using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using PopulateDatabaseFromRescueGroupAPI.Models;
using PopulateDatabaseFromRescueGroupAPI.DAO;
using PopulateDatabaseFromRescueGroupAPI.DAO.Interfaces;

namespace PopulateDatabaseFromRescueGroupAPI.DAO
{
    class PictureSqlDAO : IPictureDAO
    {
        private readonly string connectionString;

        private readonly string sqlAddPicture =
            "INSERT INTO pictures(picture_id, pet_id, url) " +
            "VALUES (@PictureId, @PetId, @Url);";

        public PictureSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddPictures(IEnumerable<Picture> pictures)
        {
            bool result = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (Picture picture in pictures)
                    {
                        if (!AddPicture(picture, conn))
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

        private bool AddPicture(Picture picture, SqlConnection conn)
        {
            bool result = false;

            SqlCommand cmd = new SqlCommand(sqlAddPicture, conn);
            cmd.Parameters.AddWithValue("@PictureId", picture.PictureId);
            cmd.Parameters.AddWithValue("@PetId", picture.PetId);
            cmd.Parameters.AddWithValue("@Url", picture.Url);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                result = true;

            return result;
        }
    }
}
