using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;
using Capstone.DAO.Interfaces;

namespace Capstone.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private ISpeciesDAO speciesDAO;

        public SpeciesController(ISpeciesDAO speciesDAO)
        {
            this.speciesDAO = speciesDAO;
        }
        [HttpGet]
        public ActionResult<List<Species>> GetAllSpecies()
        {
            return Ok(speciesDAO.GetAllSpecies());
        }

        [HttpGet("{speciesId}")]
        public ActionResult<Species> GetSpecies(int speciesId)
        {
            return Ok(speciesDAO.GetSpecies(speciesId));
        }

        [HttpGet("{speciesId}/breeds")]
        public ActionResult<List<Breed>> GetSpeciesBreeds(int speciesId)
        {
            return Ok(speciesDAO.GetSpeciesBreeds(speciesId));
        }
    }
}
