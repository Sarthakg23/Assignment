using Hotel_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_Management.Controllers
{
    public class HotelController : ApiController
    {
        DAL d = new DAL();
        [HttpGet]
        public HttpResponseMessage getHotels()
        {
            if (d.getHotels().Count == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Hotels!");
            else
                return Request.CreateResponse(HttpStatusCode.OK, d.getHotels());
        }

        [HttpGet]
        public HttpResponseMessage getHotelById(int id)
        {
            if (d.getHotelById(id) == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Hotel found with that ID!");
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, d.getHotelById(id));
            }
        }

        [HttpGet]
        [Route("api/hotel/available/")]
        public HttpResponseMessage getAvailableHotels()
        {
            if (d.getAvailableHotels().Count == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Hotels Available!");
            else
                return Request.CreateResponse(HttpStatusCode.OK, d.getAvailableHotels());
        }

    }
}
