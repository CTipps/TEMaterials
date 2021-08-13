using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO.Interfaces;

namespace Capstone.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDAO userDAO;
        private IPetDAO petDAO;

        public UserController(IPetDAO petDAO, IUserDAO userDAO)
        {
            this.petDAO = petDAO;
            this.userDAO = userDAO;
        }

        [HttpGet("pets/liked")]
        public ActionResult<List<Pet>> GetLikedPets()
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            return Ok(petDAO.GetLikedPets(userId));
        }

        [HttpPost("pets/filter")]
        public ActionResult<List<Pet>> GetFilteredPets(SearchCriteria search)
        {
            search.UserId = int.Parse(this.User.FindFirst("sub").Value);
            return Ok(petDAO.GetFilteredPets(search));
        }

        [HttpPost("pets/liked")]
        public ActionResult<bool> LikePets(List<Pet> likedPets)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            return Ok(petDAO.LikePets(userId, likedPets));
        }

        [HttpDelete("pets/liked")]
        public ActionResult<bool> UnlikePet(Pet unlikedPet)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            return Ok(petDAO.UnlikePet(userId, unlikedPet));
        }
    }
}
