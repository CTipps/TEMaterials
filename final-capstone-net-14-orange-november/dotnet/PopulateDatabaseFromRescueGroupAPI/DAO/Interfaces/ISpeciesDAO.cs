using System;
using System.Collections.Generic;
using System.Text;
using PopulateDatabaseFromRescueGroupAPI.Models;

namespace PopulateDatabaseFromRescueGroupAPI.DAO.Interfaces
{
    interface ISpeciesDAO
    {
        bool AddAllSpecies(IEnumerable<Species> allSpecies);
    }
}
