using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.Interfaces
{
    public interface IBreedDAO
    {
        Breed GetBreed(int breedId);
        IEnumerable<Breed> GetAllBreeds();
    }
}
