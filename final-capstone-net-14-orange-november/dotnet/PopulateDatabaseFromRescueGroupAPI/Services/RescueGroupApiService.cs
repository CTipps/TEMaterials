using System;
using System.Collections.Generic;
using System.Text;
using PopulateDatabaseFromRescueGroupAPI.Services.Interfaces;
using PopulateDatabaseFromRescueGroupAPI.Models;

namespace PopulateDatabaseFromRescueGroupAPI.Services
{
    public class RescueGroupApiService : IRescueGroupService
    {
        public Dictionary<int, Pet> Pets { get; set; }
        public Dictionary<int, Picture> Pictures { get; set; }
        public Dictionary<int, Breed> Breeds { get; set; }
        public Dictionary<int, Species> Species { get; set; }
        public Dictionary<int, Agency> Agencies { get; set; }


    }
}
