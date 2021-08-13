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
    
    [Route("[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetDAO petDAO;
        private IPictureDAO pictureDAO;

        public PetsController(IPetDAO petDAO, IPictureDAO pictureDAO)
        {
            this.petDAO = petDAO;
            this.pictureDAO = pictureDAO;
        }
        [HttpGet]
        public ActionResult<List<Pet>> GetAllPets()
        {
            return Ok(petDAO.GetAllPets());
        }

        

        [HttpGet("{petId}")]
        public ActionResult<Pet> GetPet(int petId)
        {
            return Ok(petDAO.GetPet(petId));
        }
       
        [HttpGet("{petId}/pictures")]
        public ActionResult<IEnumerable<Picture>> GetPetPictures(int petId)
        {
            return Ok(pictureDAO.GetPetPictures(petId));
        }

        //todo Add Authorization
        [HttpPost]
        public ActionResult<Pet> AddPet(Pet pet)
        {
            return Ok(petDAO.AddPet(pet));
        }

        [HttpPut]
        public ActionResult<bool> UpdatePet(Pet pet)
        {
            return Ok(petDAO.UpdatePet(pet));
        }

        [HttpDelete("{petId}")]
        public ActionResult<bool> DeletePet(int petId)
        {
            return Ok(petDAO.DeletePet(petId));
        }
    }
}
