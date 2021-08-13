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
    public class AgencyController : ControllerBase
    {
        private IAgencyDAO agencyDAO;
        private IPetDAO petDAO;

        public AgencyController(IAgencyDAO agencyDAO, IPetDAO petDAO)
        {
            this.agencyDAO = agencyDAO;
            this.petDAO = petDAO;
        }
        
        [HttpGet]
        public ActionResult<List<Agency>> GetAllAgencies()
        {
            return Ok(agencyDAO.GetAllAgencies());
        }

        [HttpGet("{agencyId}")]
        public ActionResult<Agency> GetAgency(int agencyId)
        {
            return Ok(agencyDAO.GetAgency(agencyId));
        }
        
        [HttpGet("{agencyId}/pets")]
        public ActionResult<List<Pet>> GetAgencyPets(int agencyId)
        {
            return Ok(petDAO.GetAgencyPets(agencyId));
        }

        //todo Add Authorization
        [HttpPost]
        public ActionResult<Agency> AddAgency(Agency agency)
        {
            return Ok(agencyDAO.AddAgency(agency));
        }

        [HttpPut]
        public ActionResult<bool> UpdateAgency(Agency agency)
        {
            return Ok(agencyDAO.UpdateAgency(agency));
        }

        [HttpDelete("{agencyId}")]
        public ActionResult<bool> DeleteAgency(int agencyId)
        {
            return Ok(agencyDAO.DeleteAgency(agencyId));
        }
    }
}