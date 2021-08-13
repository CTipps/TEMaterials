using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using PopulateDatabaseFromRescueGroupAPI.Services.Interfaces;
using PopulateDatabaseFromRescueGroupAPI.Models;

namespace PopulateDatabaseFromRescueGroupAPI.Services
{
    public class RescueGroupJsonFileDAO
    {
        private string jsonFilePath = @"C:\Users\Student\final-capstone-net-14-orange-november\dotnet\PopulateDatabaseFromRescueGroupAPI\Services\Data\";
        public Dictionary<int, Pet> Pets { get; set; }
        public Dictionary<int, Picture> Pictures { get; set; }
        public Dictionary<int, Breed> Breeds { get; set; }
        public Dictionary<int, Species> Species { get; set; }
        public Dictionary<int, Agency> Agencies { get; set; }

        public RescueGroupJsonFileDAO()
        {
            Pets = new Dictionary<int, Pet>();
            Pictures = new Dictionary<int, Picture>();
            Breeds = new Dictionary<int, Breed>();
            Species = new Dictionary<int, Species>();
            Agencies = new Dictionary<int, Agency>();


            for (int i = 0; i <= 2 ; i++)
            {
                string jsonString = "";
                try
                {
                     jsonString = File.ReadAllText(jsonFilePath + $"page{i}.json");
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error reading the file");
                    Console.WriteLine(e.Message);
                }

                ParseJson(jsonString);
            }

        }

        private void ParseJson(string jsonString)
        {
            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement root = document.RootElement;

                JsonElement dataElement = root.GetProperty("data");
                foreach (JsonElement animalElement in dataElement.EnumerateArray())
                {
                    ParseAnimal(animalElement);
                }

                JsonElement includedArrayElement = root.GetProperty("included");
                foreach (JsonElement includedObject in includedArrayElement.EnumerateArray())
                {
                    string type = includedObject.GetProperty("type").GetString();
                    switch (type)
                    {
                        case "pictures":
                            ParsePictures(includedObject);
                            break;
                        case "orgs":
                            ParseOrgs(includedObject);
                            break;
                        case "breeds":
                            ParseBreeds(includedObject);
                            break;
                        case "species":
                            ParseSpecies(includedObject);
                            break;
                    }
                }
            }
        }

        private void ParseAnimal(JsonElement animalElement)
        {
            JsonElement idElement = animalElement.GetProperty("id");
            int id = Int32.Parse(idElement.GetString());

            if (!Pets.ContainsKey(id))
            {
                JsonElement attributesElement = animalElement.GetProperty("attributes");
                Pet pet = ParseAnimalAttributes(attributesElement);
                pet.PetId = id;

                Pets.Add(pet.PetId, pet);

                if (animalElement.TryGetProperty("relationships", out JsonElement relationshipsElement))
                {
                    ParseRelationships(relationshipsElement, pet);
                }
            }
        }
        private Pet ParseAnimalAttributes(JsonElement attributesElement)
        {
            Pet pet = new Pet();

            if (attributesElement.TryGetProperty("breedPrimaryId", out JsonElement breedPrimaryIdElement))
            {
                pet.BreedId = breedPrimaryIdElement.GetInt32();
            }
            if (attributesElement.TryGetProperty("pictureThumbnailUrl", out JsonElement pictureThumbnailUrlElement))
            {
                pet.ThumbnailUrl = pictureThumbnailUrlElement.GetString();
            }
            if (attributesElement.TryGetProperty("name", out JsonElement nameElement))
            {
                pet.Name = nameElement.GetString();
            }
            if (attributesElement.TryGetProperty("descriptionText", out JsonElement descriptionTextElement))
            {
                pet.DescriptionText = descriptionTextElement.GetString();
            }
            if (attributesElement.TryGetProperty("sex", out JsonElement sexElement))
            {
                pet.Sex = sexElement.GetString();
            }
            if (attributesElement.TryGetProperty("ageGroup", out JsonElement ageGroupElement))
            {
                pet.AgeGroup = ageGroupElement.GetString();
            }
            if (attributesElement.TryGetProperty("ageString", out JsonElement ageStringElement))
            {
                pet.AgeString = ageStringElement.GetString();
            }
            if (attributesElement.TryGetProperty("activityLevel", out JsonElement activityLevelElement))
            {
                pet.ActivityLevel = activityLevelElement.GetString();
            }
            if (attributesElement.TryGetProperty("exerciseNeeds", out JsonElement exerciseNeedsElement))
            {
                pet.ExerciseNeeds = exerciseNeedsElement.GetString();
            }
            if (attributesElement.TryGetProperty("ownerExperience", out JsonElement ownerExperienceElement))
            {
                pet.OwnerExperience = ownerExperienceElement.GetString();
            }
            if (attributesElement.TryGetProperty("sizeGroup", out JsonElement sizeGroupElement))
            {
                pet.SizeGroup = sizeGroupElement.GetString();
            }
            if (attributesElement.TryGetProperty("vocalLevel", out JsonElement vocalLevelElement))
            {
                pet.VocalLevel = vocalLevelElement.GetString();
            }

            return pet;
        }
        private void ParseRelationships(JsonElement relationshipsElement, Pet pet)
        {
            if (relationshipsElement.TryGetProperty("pictures", out JsonElement picturesElement))
            {
                picturesElement = picturesElement.GetProperty("data");
                bool firstPicture = true;
                foreach (JsonElement pictureElement in picturesElement.EnumerateArray())
                {
                    Picture picture = new Picture();
                    picture.PictureId = Int32.Parse(pictureElement.GetProperty("id").GetString());
                    picture.PetId = pet.PetId;
                    if (firstPicture)
                    {
                        Pets[pet.PetId].PrimaryImageId = picture.PictureId;
                    }
                    firstPicture = false;
                    if (!Pictures.ContainsKey(picture.PictureId))
                    {
                        Pictures.Add(picture.PictureId, picture);
                    }
                }
            }
            if (relationshipsElement.TryGetProperty("orgs", out JsonElement orgsElement))
            {
                orgsElement = orgsElement.GetProperty("data");
                bool firstOrg = true;
                foreach (JsonElement orgElement in orgsElement.EnumerateArray())
                {
                    Agency agency = new Agency();
                    agency.AgencyId = Int32.Parse(orgElement.GetProperty("id").GetString());
                    if (firstOrg)
                    {
                        Pets[pet.PetId].AgencyId = agency.AgencyId;
                    }
                    firstOrg = false;
                    if (!Agencies.ContainsKey(agency.AgencyId))
                    {
                        Agencies.Add(agency.AgencyId, agency);
                    }
                }
            }
            if (relationshipsElement.TryGetProperty("species", out JsonElement allSpeciesElement))
            {
                allSpeciesElement = allSpeciesElement.GetProperty("data");
                foreach (JsonElement speciesElement in allSpeciesElement.EnumerateArray())
                {
                    Species species = new Species();
                    species.SpeciesId = Int32.Parse(speciesElement.GetProperty("id").GetString());
                    Pets[pet.PetId].SpeciesId = species.SpeciesId;
                    if (!Species.ContainsKey(species.SpeciesId))
                    {
                        Species.Add(species.SpeciesId, species);
                    }
                }
            }
            if (relationshipsElement.TryGetProperty("breeds", out JsonElement breedsElement))
            {
                breedsElement = breedsElement.GetProperty("data");
                foreach (JsonElement breedElement in breedsElement.EnumerateArray())
                {
                    Breed breed = new Breed();
                    breed.BreedId = Int32.Parse(breedElement.GetProperty("id").GetString());
                    if (!Breeds.ContainsKey(breed.BreedId))
                    {
                        Breeds.Add(breed.BreedId, breed);
                    }
                    Breeds[breed.BreedId].SpeciesId = pet.SpeciesId;
                }
            }
        }
        private void ParsePictures(JsonElement pictureElement)
        {
            int id = Int32.Parse(pictureElement.GetProperty("id").GetString());
            JsonElement attributesElement = pictureElement.GetProperty("attributes");
            if (Pictures.ContainsKey(id))
            {
                Pictures[id].Url = attributesElement.GetProperty("original").GetProperty("url").GetString();
            }
            foreach (Pet pet in Pets.Values)
            {
                if (pet.PrimaryImageId == id)
                {
                    pet.PrimaryImageUrl = Pictures[id].Url;
                }
            }
        }
        private void ParseOrgs(JsonElement orgElement)
        {
            int id = Int32.Parse(orgElement.GetProperty("id").GetString());
            JsonElement attributesElement = orgElement.GetProperty("attributes");
            if (Agencies.ContainsKey(id))
            {
                if (attributesElement.TryGetProperty("name", out JsonElement nameElement))
                {
                    Agencies[id].Name = nameElement.GetString();
                }
                if (attributesElement.TryGetProperty("street", out JsonElement streetElement))
                {
                    Agencies[id].Street = streetElement.GetString();
                }
                if (attributesElement.TryGetProperty("city", out JsonElement cityElement))
                {
                    Agencies[id].City = cityElement.GetString();
                }
                if (attributesElement.TryGetProperty("state", out JsonElement stateElement))
                {
                    Agencies[id].State = stateElement.GetString();
                }
                if (attributesElement.TryGetProperty("postalcode", out JsonElement postalcodeElement))
                {
                    Agencies[id].PostalCode = postalcodeElement.GetString();
                }
                if (attributesElement.TryGetProperty("email", out JsonElement emailElement))
                {
                    Agencies[id].Email = emailElement.GetString();
                }
                if (attributesElement.TryGetProperty("phone", out JsonElement phoneElement))
                {
                    Agencies[id].Phone = phoneElement.GetString();
                }
                if (attributesElement.TryGetProperty("lat", out JsonElement latElement))
                {
                    Agencies[id].Lat = latElement.GetDouble();
                }
                if (attributesElement.TryGetProperty("lon", out JsonElement lonElement))
                {
                    Agencies[id].Lon = lonElement.GetDouble();
                }
                if (attributesElement.TryGetProperty("about", out JsonElement aboutElement))
                {
                    Agencies[id].About = aboutElement.GetString();
                }
                if (attributesElement.TryGetProperty("url", out JsonElement urlElement))
                {
                    Agencies[id].Url = urlElement.GetString();
                }
            }
        }
        private void ParseBreeds(JsonElement breedElement)
        {
            int id = Int32.Parse(breedElement.GetProperty("id").GetString());
            JsonElement attributesElement = breedElement.GetProperty("attributes");
            if (Breeds.ContainsKey(id))
            {
                Breeds[id].Name = attributesElement.GetProperty("name").GetString();
            }
        }
        private void ParseSpecies(JsonElement speciesElement)
        {
            int id = Int32.Parse(speciesElement.GetProperty("id").GetString());
            JsonElement attributesElement = speciesElement.GetProperty("attributes");
            if (Species.ContainsKey(id))
            {
                Species[id].Name = attributesElement.GetProperty("singular").GetString();
                Species[id].Plural = attributesElement.GetProperty("plural").GetString();
                Species[id].YoungSingular = attributesElement.GetProperty("youngSingular").GetString();
                Species[id].YoungPlural = attributesElement.GetProperty("youngPlural").GetString();
            }
        }
    }
}
