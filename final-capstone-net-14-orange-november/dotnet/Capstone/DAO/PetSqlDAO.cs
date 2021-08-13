using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PetSqlDAO : IPetDAO
    {
        private Random rand = new Random();
        private readonly string connectionString;

        private readonly string sqlGetPet = "SELECT pets.*, species.name AS species_name, breeds.name AS breed_name FROM pets " +
            "JOIN species ON pets.species_id = species.species_id " +
            "JOIN breeds ON pets.breed_id = breeds.breed_id WHERE pets.pet_id = @PetId";
        private readonly string sqlGetAllPets = "SELECT pets.*, species.name AS species_name, breeds.name AS breed_name FROM pets " +
            "JOIN species ON pets.species_id = species.species_id " +
            "JOIN breeds ON pets.breed_id = breeds.breed_id;";
        private readonly string sqlGetAgencyPets = "SELECT pets.*, species.name AS species_name, breeds.name AS breed_name FROM pets " +
    "JOIN species ON pets.species_id = species.species_id " +
    "JOIN breeds ON pets.breed_id = breeds.breed_id WHERE pets.agency_id = @AgencyId;";

        private readonly string sqlGetLikedPets = "SELECT pets.*, species.name AS species_name, breeds.name AS breed_name FROM pets " +
            "JOIN species ON pets.species_id = species.species_id " +
            "JOIN breeds ON pets.breed_id = breeds.breed_id " +
            "JOIN user_pet ON user_pet.pet_id = pets.pet_id " +
            "JOIN users ON users.user_id = user_pet.user_id " +
            "WHERE users.user_id = @userId;";
        private string sqlGetFilteredPetsPrefix = "SELECT pets.*, " +
            "species.name AS species_name, breeds.name AS breed_name " +
            "FROM pets JOIN species ON pets.species_id = species.species_id " +
            "JOIN breeds ON pets.breed_id = breeds.breed_id WHERE 1=1 ";
        private readonly string sqlGetFilteredPetsSuffix = "EXCEPT " +
            "SELECT pets.*, " +
            "species.name AS species_name, breeds.name AS breed_name " +
            "FROM pets JOIN species ON pets.species_id = species.species_id " +
            "JOIN breeds ON pets.breed_id = breeds.breed_id " +
            "JOIN user_pet ON user_pet.pet_id = pets.pet_id " +
            "JOIN users ON users.user_id = user_pet.user_id " +
            "WHERE user_pet.user_id = @UserId";
        private readonly string sqlAddPet = "INSERT INTO pets(pet_id, species_id, breed_id, agency_id, " +
            "primary_image_id, primary_image_url, thumbnail_url, name, description_text, sex, age_group, " +
            "age_string, activity_level, exercise_needs, owner_experience, size_group, vocal_level) " +
            "VALUES (@PetId, @SpeciesId, @BreedId, @AgencyId, @PrimaryImageId, @PrimaryImageUrl, " +
            "@ThumbnailUrl, @Name, @DescriptionText, @Sex, @AgeGroup, @AgeString, @ActivityLevel, " +
            "@ExerciseNeeds, @OwnerExperience, @SizeGroup, @VocalLevel);";
        private readonly string sqlUpdatePet = "UPDATE pets SET species_id = @SpeciesId, " +
            "breed_id = @BreedId, agency_id = @AgencyId, primary_image_id = @PrimaryImageId, " +
            "primary_image_url = @PrimaryImageUrl, thumbnail_url = @ThumbnailUrl, name = @Name, " +
            "description_text = @DescriptionText, sex = @Sex, age_group = @AgeGroup, age_string = @AgeString, " +
            "activity_level = @ActivityLevel, exercise_needs = @ExerciseNeeds, owner_experience = @OwnerExperience," +
            "size_group = @SizeGroup, vocal_level = @VocalLevel WHERE pet_id = @PetId";
        private readonly string sqlDeletePet = "DELETE FROM pets WHERE pet_id = @petId";
        private readonly string sqlLikePet = "INSERT INTO user_pet (user_id, pet_id) " +
            "VALUES (@userId, @petId);";
        private readonly string sqlUnlikePet = "DELETE FROM user_pet WHERE user_id = @userId AND pet_id = @petId;";

        public PetSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddPet(Pet pet)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddPet, conn);
                    AddPetParameters(pet, cmd);

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


        public Pet GetPet(int petId)
        {
            Pet result = new Pet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetPet, conn);
                    cmd.Parameters.AddWithValue("@PetId", petId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        result = ReadPet(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            List<Pet> result = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllPets, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        result.Add(ReadPet(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
        public IEnumerable<Pet> GetAgencyPets(int agencyId)
        {
            List<Pet> result = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAgencyPets, conn);
                    cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        result.Add(ReadPet(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public IEnumerable<Pet> GetLikedPets(int userId)
        {
            List<Pet> result = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetLikedPets, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        result.Add(ReadPet(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public IEnumerable<Pet> GetFilteredPets(SearchCriteria search)
        {
            List<Pet> result = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = BuildFilterSqlString(conn, search);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        result.Add(ReadPet(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool UpdatePet(Pet pet)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUpdatePet, conn);
                    AddPetParameters(pet, cmd);

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

        public bool DeletePet(int petId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlDeletePet, conn);
                    cmd.Parameters.AddWithValue("@petId", petId);

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

        public bool LikePets(int userId, IEnumerable<Pet> likedPets)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (Pet likedPet in likedPets)
                    {
                        LikePet(userId, likedPet, conn);
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public bool UnlikePet(int userId, Pet unlikedPet)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUnlikePet, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@petId", unlikedPet.PetId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        // Helper methods
        private bool LikePet(int userId, Pet likedPet, SqlConnection conn)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand(sqlLikePet, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@petId", likedPet.PetId);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    result = true;
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        private void AddPetParameters(Pet pet, SqlCommand cmd)
        {
            if (pet.PetId < 1)
            {
                pet.PetId = rand.Next(1, 9999);
            }
            cmd.Parameters.AddWithValue("@PetId", pet.PetId);
            cmd.Parameters.AddWithValue("@SpeciesId", pet.SpeciesId);
            cmd.Parameters.AddWithValue("@BreedId", pet.BreedId);
            cmd.Parameters.AddWithValue("@AgencyId", pet.AgencyId);
            if (pet.PrimaryImageId < 1)
            {
                pet.PrimaryImageId = rand.Next(9999, 1000000); ;
            }
                cmd.Parameters.AddWithValue("@PrimaryImageId", pet.PrimaryImageId);
            cmd.Parameters.AddWithValue("@PrimaryImageUrl", pet.PrimaryImageUrl);
            if (pet.ThumbnailUrl == null)
            {
                cmd.Parameters.AddWithValue("@ThumbnailUrl", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("@ThumbnailUrl", pet.ThumbnailUrl);
            }
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
        }

        private Pet ReadPet(SqlDataReader reader)
        {
            Pet pet = new Pet();

            pet.PetId = Convert.ToInt32(reader["pet_id"]);
            pet.SpeciesId = Convert.ToInt32(reader["species_id"]);
            pet.Species = Convert.ToString(reader["species_name"]);
            pet.BreedId = Convert.ToInt32(reader["breed_id"]);
            pet.Breed = Convert.ToString(reader["breed_name"]);
            pet.AgencyId = Convert.ToInt32(reader["agency_id"]);
            pet.PrimaryImageId = Convert.ToInt32(reader["primary_image_id"]);
            pet.PrimaryImageUrl = Convert.ToString(reader["primary_image_url"]);
            pet.ThumbnailUrl = Convert.ToString(reader["thumbnail_url"]);
            pet.Name = Convert.ToString(reader["name"]);
            pet.DescriptionText = Convert.ToString(reader["description_text"]);
            pet.Sex = Convert.ToString(reader["sex"]);
            pet.AgeGroup = Convert.ToString(reader["age_group"]);
            pet.AgeString = Convert.ToString(reader["age_string"]);
            pet.ActivityLevel = Convert.ToString(reader["activity_level"]);
            pet.ExerciseNeeds = Convert.ToString(reader["exercise_needs"]);
            pet.OwnerExperience = Convert.ToString(reader["owner_experience"]);
            pet.SizeGroup = Convert.ToString(reader["size_group"]);
            pet.VocalLevel = Convert.ToString(reader["vocal_level"]);

            return pet;
        }

        private SqlCommand BuildFilterSqlString(SqlConnection conn, SearchCriteria search)
        {
            SqlCommand cmd = new SqlCommand(sqlGetFilteredPetsPrefix, conn);
            cmd.Parameters.AddWithValue("@UserId", search.UserId);

            if (search.SpeciesId != 0)
            {
                cmd.CommandText += " AND pets.species_id = @SpeciesId ";
                cmd.Parameters.AddWithValue("@SpeciesId", search.SpeciesId);
            }
            if (search.BreedIds.Count > 0)
            {
                cmd.CommandText += " AND ( 1=0";
                for (int i = 0; i < search.BreedIds.Count; i++)
                {
                    cmd.CommandText += $" OR pets.breed_id = @breedId{i}";
                    cmd.Parameters.AddWithValue($"@breedId{i}", search.BreedIds[i]);
                }
                cmd.CommandText += ") ";
            }
            if (search.AgencyIds.Count > 0)
            {
                cmd.CommandText += " AND ( 1=0";
                for (int i = 0; i < search.AgencyIds.Count; i++)
                {
                    cmd.CommandText += $" OR agency_id = @agencyId{i}";
                    cmd.Parameters.AddWithValue($"@agencyId{i}", search.AgencyIds[i]);
                }
                cmd.CommandText += ") ";
            }
            if (search.Sex != "")
            {
                cmd.CommandText += $" AND sex = @sex ";
                cmd.Parameters.AddWithValue("@sex", search.Sex);
            }
            if (search.AgeGroups.Count > 0)
            {
                cmd.CommandText += " AND ( 1=0";
                for (int i = 0; i < search.AgeGroups.Count; i++)
                {
                    cmd.CommandText += $" OR age_group = @ageGroup{i}";
                    cmd.Parameters.AddWithValue($"@ageGroup{i}", search.AgeGroups[i]);
                }
                cmd.CommandText += ") ";
            }
            if (search.ActivityLevels.Count > 0)
            {
                cmd.CommandText += " AND ( 1=0";
                for (int i = 0; i < search.ActivityLevels.Count; i++)
                {
                    cmd.CommandText += $" OR activity_level = @activityLevel{i}";
                    cmd.Parameters.AddWithValue($"@activityLevel{i}", search.ActivityLevels[i]);
                }
                cmd.CommandText += ") ";
            }
            if (search.AllExerciseNeeds.Count > 0)
            {
                cmd.CommandText += " AND ( 1=0";
                for (int i = 0; i < search.AllExerciseNeeds.Count; i++)
                {
                    cmd.CommandText += $" OR exercise_needs = @exerciseNeeds{i}";
                    cmd.Parameters.AddWithValue($"@exerciseNeeds{i}", search.AllExerciseNeeds[i]);
                }
                cmd.CommandText += ") ";
            }
            if (search.OwnerExperiences.Count > 0)
            {
                cmd.CommandText += " AND ( 1=0";
                for (int i = 0; i < search.OwnerExperiences.Count; i++)
                {
                    cmd.CommandText += $" OR owner_experience = @ownerExperience{i}";
                    cmd.Parameters.AddWithValue($"@ownerExperience{i}", search.OwnerExperiences[i]);
                }
                cmd.CommandText += ") ";
            }
            if (search.SizeGroups.Count > 0)
            {
                cmd.CommandText += " AND ( 1=0";
                for (int i = 0; i < search.SizeGroups.Count; i++)
                {
                    cmd.CommandText += $" OR size_group = @sizeGroup{i}";
                    cmd.Parameters.AddWithValue($"@sizeGroup{i}", search.SizeGroups[i]);
                }
                cmd.CommandText += ") ";
            }
            if (search.VocalLevels.Count > 0)
            {
                cmd.CommandText += " AND ( 1=0";
                for (int i = 0; i < search.VocalLevels.Count; i++)
                {
                    cmd.CommandText += $" OR vocal_level = @vocalLevel{i}";
                    cmd.Parameters.AddWithValue($"@vocalLevel{i}", search.VocalLevels[i]);
                }
                cmd.CommandText += ") ";
            }

            cmd.CommandText += sqlGetFilteredPetsSuffix;

            return cmd;
        }
    }
}
