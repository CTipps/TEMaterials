using System;
using System.Collections.Generic;
using System.Text;
using PopulateDatabaseFromRescueGroupAPI.Models;

namespace PopulateDatabaseFromRescueGroupAPI.DAO.Interfaces
{
    interface IPetDAO
    {
        bool AddPets(IEnumerable<Pet> pets);
    }
}
