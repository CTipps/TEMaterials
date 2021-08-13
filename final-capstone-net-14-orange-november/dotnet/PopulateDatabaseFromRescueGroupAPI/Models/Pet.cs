using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulateDatabaseFromRescueGroupAPI.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public int SpeciesId { get; set; }
        public int BreedId { get; set; }
        public int AgencyId { get; set; }
        public int PrimaryImageId { get; set; }
        public string PrimaryImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Name { get; set; }
        public string DescriptionText { get; set; }
        public string Sex { get; set; }
        public string AgeGroup { get; set; }
        public string AgeString { get; set; }
        public string ActivityLevel { get; set; }
        public string ExerciseNeeds { get; set; }
        public string OwnerExperience { get; set; }
        public string SizeGroup { get; set; }
        public string VocalLevel { get; set; }

        public Pet()
        {
            DescriptionText = "";
            Sex = "";
            AgeGroup = "";
            AgeString = "";
            ActivityLevel = "";
            ExerciseNeeds = "";
            OwnerExperience = "";
            SizeGroup = "";
            VocalLevel = "";
        }
        public override string ToString()
        {
            return $"PetId: {PetId}, BreedId: {BreedId}, AgencyId: {AgencyId} Name: {Name}";
        }
    }
}
