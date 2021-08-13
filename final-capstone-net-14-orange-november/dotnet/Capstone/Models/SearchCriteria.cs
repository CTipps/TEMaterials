using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class SearchCriteria
    {
        public int UserId { get; set; }
        public int SpeciesId { get; set; }
        public List<int> BreedIds { get; set; }
        public List<int> AgencyIds { get; set; }
        public string Sex { get; set; }
        public List<string> AgeGroups { get; set; }
        public List<string> ActivityLevels { get; set; }
        public List<string> AllExerciseNeeds { get; set; }
        public List<string> OwnerExperiences { get; set; }
        public List<string> SizeGroups { get; set; }
        public List<string> VocalLevels { get; set; }

        public override string ToString()
        {
            return $"UserId: {UserId}";
        }
    }
}
