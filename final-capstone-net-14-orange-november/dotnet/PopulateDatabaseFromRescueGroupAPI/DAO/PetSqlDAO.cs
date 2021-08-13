using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using PopulateDatabaseFromRescueGroupAPI.Models;
using PopulateDatabaseFromRescueGroupAPI.DAO;
using PopulateDatabaseFromRescueGroupAPI.DAO.Interfaces;

namespace PopulateDatabaseFromRescueGroupAPI.DAO
{
    public class PetSqlDAO : IPetDAO
    {
        private readonly string connectionString;


        private readonly string sqlAddPet = "INSERT INTO pets(pet_id, species_id, breed_id, agency_id, " +
            "primary_image_id, primary_image_url, thumbnail_url, name, description_text, sex, age_group, " +
            "age_string, activity_level, exercise_needs, owner_experience, size_group, vocal_level) " +
            "VALUES (@PetId, @SpeciesId, @BreedId, @AgencyId, @PrimaryImageId, @PrimaryImageUrl, " +
            "@ThumbnailUrl, @Name, @DescriptionText, @Sex, @AgeGroup, @AgeString, @ActivityLevel, " +
            "@ExerciseNeeds, @OwnerExperience, @SizeGroup, @VocalLevel);";

        public PetSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddPets(IEnumerable<Pet> pets)
        {
            bool result = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (Pet pet in pets)
                    {
                        if (pet.PrimaryImageUrl != null && pet.PrimaryImageUrl != "")
                        {
                            if (!AddPet(pet, conn))
                            {
                                result = false;
                            }
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

        private bool AddPet(Pet pet, SqlConnection conn)
        {
            bool result = false;

            SqlCommand cmd = new SqlCommand(sqlAddPet, conn);
            cmd.Parameters.AddWithValue("@PetId", pet.PetId);
            cmd.Parameters.AddWithValue("@SpeciesId", pet.SpeciesId);
            cmd.Parameters.AddWithValue("@BreedId", pet.BreedId);
            cmd.Parameters.AddWithValue("@AgencyId", pet.AgencyId);
            cmd.Parameters.AddWithValue("@PrimaryImageId", pet.PrimaryImageId);
            cmd.Parameters.AddWithValue("@PrimaryImageUrl", pet.PrimaryImageUrl);
            cmd.Parameters.AddWithValue("@ThumbnailUrl", pet.ThumbnailUrl);
            cmd.Parameters.AddWithValue("@Name", pet.Name);
            cmd.Parameters.AddWithValue("@DescriptionText", pet.DescriptionText);
            cmd.Parameters.AddWithValue("@Sex", pet.Sex);
            cmd.Parameters.AddWithValue("@AgeGroup", pet.AgeGroup);
            cmd.Parameters.AddWithValue("@AgeString", pet.AgeString);
            cmd.Parameters.AddWithValue("@ActivityLevel", pet.ActivityLevel);
            cmd.Parameters.AddWithValue("@ExerciseNeeds", pet.ExerciseNeeds);
            cmd.Parameters.AddWithValue("@OwnerExperience", pet.OwnerExperience);
            cmd.Parameters.AddWithValue("@SizeGroup", pet.SizeGroup);
            cmd.Parameters.AddWithValue("@VocalLevel", pet.VocalLevel);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                result = true;

            return result;
        }
    }
}
