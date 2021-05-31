using Hotel_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_Management.Controllers
{
    public class BookingController : ApiController
    {
        DAL d = new DAL();

        [HttpGet]
        public HttpResponseMessage getAllBookings()
        {
            if(d.getBookings().Count == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Bookings!");
            else
                return Request.CreateResponse(HttpStatusCode.OK, d.getBookings());
        }

        [HttpGet]
        public HttpResponseMessage getBookingById(int id)
        {
            if (d.getBookingById(id) == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Booking found with that ID!");
            else
                return Request.CreateResponse(HttpStatusCode.OK,d.getBookingById(id));
        }
        [HttpPost]
        public HttpResponseMessage bookHotel(BOOKING booking)
        {
            BookingModel b = d.bookHotel(booking);
            if (b== null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Booking Unsuccessfull");
            else
                return Request.CreateResponse(HttpStatusCode.OK,b);
        }


        [HttpGet]
        [Route("api/booking/bookings/{userid}")]
        public HttpResponseMessage getBookedHotels(int userid)
        {
            if (d.getBookedHotels(userid).Count == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Hotels Booked with that user ID!");
            else
                return Request.CreateResponse(HttpStatusCode.OK, d.getBookedHotels(userid));
        }

        [HttpDelete]
        public HttpResponseMessage cancelBooking(int id)
        {
            if (d.cancelBooking(id) == false)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Cancelling Unsuccessfull please enter valid bookind Id!");
            else
                return Request.CreateResponse(HttpStatusCode.OK, "Booking Cancelled");
        }
    }
}
