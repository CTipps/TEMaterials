using System;
using System.Collections.Generic;
using System.Text;
using PopulateDatabaseFromRescueGroupAPI.Models;

namespace PopulateDatabaseFromRescueGroupAPI.DAO.Interfaces
{
    interface IBreedDAO
    {
        bool AddBreeds(IEnumerable<Breed> breeds);
    }
}
