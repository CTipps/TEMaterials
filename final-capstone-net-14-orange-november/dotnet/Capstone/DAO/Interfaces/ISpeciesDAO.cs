using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.Interfaces
{
    public interface ISpeciesDAO
    {
        Species GetSpecies(int speciesId);
        IEnumerable<Species> GetAllSpecies();
        IEnumerable<Breed> GetSpeciesBreeds(int speciesId);
    }
}
