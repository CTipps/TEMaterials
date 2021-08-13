using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Breed
    {
        public int BreedId { get; set; }
        public int SpeciesId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"BreedId: {BreedId}, SpeciesId: {SpeciesId}, Name: {Name}";
        }
    }
}
