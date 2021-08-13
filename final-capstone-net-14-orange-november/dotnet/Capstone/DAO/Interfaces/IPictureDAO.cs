using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.Interfaces
{
    public interface IPictureDAO
    {
        IEnumerable<Picture> GetPetPictures(int petId);
    }
}
