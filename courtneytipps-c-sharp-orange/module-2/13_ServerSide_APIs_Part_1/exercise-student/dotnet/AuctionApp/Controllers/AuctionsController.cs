using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
            {
                dao = new AuctionDao();
            }
            else
            {
                dao = auctionDao;
            }
        }

        [HttpGet]
        public List<Auction> ListAuctions(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                if (currentBid_lte != 0)
                {
                    return dao.SearchByTitleAndPrice(title_like, currentBid_lte);
                }
                else
                {
                    return dao.SearchByTitle(title_like);
                }
            }
            else
            {
                if (currentBid_lte != 0)
                {
                    return dao.SearchByPrice(currentBid_lte);
                }
                else
                {
                    return dao.List();
                }
            }
        }

        public Auction GetAuctionById(int id)
        {
            return dao.Get(id);
        }

        [HttpPost]
        public Auction CreateNewAuction(Auction newAuction)
        {
            return dao.Create(newAuction);
        }


    }
}
