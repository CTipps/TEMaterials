using System;
using PopulateDatabaseFromRescueGroupAPI.Models;
using PopulateDatabaseFromRescueGroupAPI.Services;
using PopulateDatabaseFromRescueGroupAPI.Services.Interfaces;
using PopulateDatabaseFromRescueGroupAPI.DAO;

namespace PopulateDatabaseFromRescueGroupAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;";
            string jsonFilePath = @"C:\Users\Student\final-capstone-net-14-orange-november\dotnet\PopulateDatabaseFromRescueGroupAPI\Services\Data\catsAndDogsAllWithPicsOrgsBreedsSpecies.json";

            AgencySqlDAO agencyDAO = new AgencySqlDAO(connectionString);
            SpeciesSqlDAO speciesDAO = new SpeciesSqlDAO(connectionString);
            BreedSqlDAO breedDAO = new BreedSqlDAO(connectionString);
            PetSqlDAO petDAO = new PetSqlDAO(connectionString);
            PictureSqlDAO pictureDAO = new PictureSqlDAO(connectionString);

            RescueGroupJsonFileDAO rescueGroup = new RescueGroupJsonFileDAO();

            speciesDAO.AddAllSpecies(rescueGroup.Species.Values);
            breedDAO.AddBreeds(rescueGroup.Breeds.Values);
            agencyDAO.AddAgencies(rescueGroup.Agencies.Values);
            pictureDAO.AddPictures(rescueGroup.Pictures.Values);
            petDAO.AddPets(rescueGroup.Pets.Values);
        }
    }
}
