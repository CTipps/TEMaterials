using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Species
    {
        public int SpeciesId { get; set; }
        public string Name { get; set; }
        public string Plural { get; set; }
        public string YoungSingular { get; set; }
        public string YoungPlural { get; set; }
        public override string ToString()
        {
            return $"SpeciesId: {SpeciesId}, Name: {Name}";
        }
    }
}
