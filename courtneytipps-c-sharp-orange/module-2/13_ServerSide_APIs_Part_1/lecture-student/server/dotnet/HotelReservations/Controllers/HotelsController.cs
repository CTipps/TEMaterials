using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;
using HotelReservations.DAO;

namespace HotelReservations.Controllers
{
    [Route("/")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static IHotelDao _hotelDao;
        private static IReservationDao _reservationDao;

        public HotelsController()
        {
            _hotelDao = new HotelDAO();
            _reservationDao = new ReservationDAO();
        }

        //GET: /
        [HttpGet]
            public string Ready()
        {
            return "Server is ready!";
        }

        //GET: /hotels
        [HttpGet("hotels")]
        public List<Hotel> ListHotels()
        {
            return _hotelDao.List();
        }

        //GET: /hotels/5
        [HttpGet("hotels/{id}")]
        public Hotel GetHotel(int id)
        {
            Hotel hotel = _hotelDao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }

            return null;
        }

        //GET: /reservations

        //GET: /reservations/4

        //GET: /hotels/4/reservations

        //POST /reservations
      
        //GET: /hotels/filter?state=OH&city=Cleveland



    }
}
