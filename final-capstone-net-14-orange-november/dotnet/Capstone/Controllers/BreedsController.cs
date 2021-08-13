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
    public class BreedsController : ControllerBase
    {
        private IBreedDAO breedDAO;

        public BreedsController(IBreedDAO breedDAO)
        {
            this.breedDAO = breedDAO;
        }
        [HttpGet]
        public ActionResult<List<Breed>> GetAllBreeds()
        {
            return Ok(breedDAO.GetAllBreeds());
        }

        [HttpGet("{breedId}")]
        public ActionResult<Breed> GetBreed(int breedId)
        {
            return Ok(breedDAO.GetBreed(breedId));
        }
    }
}
