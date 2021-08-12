using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;

namespace HotelReservations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private static IHotelDao hotelDao;
        private static IReservationDao reservationDao;

        public ReservationsController(IHotelDao _hotelDao, IReservationDao _reservationDao)
        {
            hotelDao = _hotelDao;
            reservationDao = _reservationDao;
        }

        //GET: /reservations
        [HttpGet]
        public List<Reservation> ListReservations()
        {
            return reservationDao.List();
        }

        //GET: /reservations/4
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = reservationDao.Get(id);

            if (reservation != null)
            {
                return reservation;
            }
            else
            {
                return NotFound();
            }
        }

        //POST: /reservations
        [HttpPost]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            Reservation added = reservationDao.Create(reservation);
            return Created($"/reservations/{added.Id}", added);
        }
    }
}
