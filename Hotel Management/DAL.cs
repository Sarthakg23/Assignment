using Hotel_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Management
{
    public class DAL
    {
        public DAL()
        {

        }

        public List<HotelModel> getHotels()
        {
            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                List<HotelModel> list = new List<HotelModel>();
                foreach (HOTEL hotel in entities.HOTELs)
                {
                    HotelModel h = new HotelModel(hotel.HOTELID,hotel.HOTELNAME,hotel.HCITY,hotel.HSTATE,hotel.TOTALROOMS,hotel.BOOKEDROOMS,hotel.ROOMPRICE,hotel.CONTACTNO);
                    list.Add(h);
                }
                return list;
            }
        }

        public List<BookingModel> getBookings()
        {
            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                List<BookingModel> list = new List<BookingModel>();
                foreach (BOOKING booking in entities.BOOKINGS)
                {
                    BookingModel b = new BookingModel(booking.BOOKINGID,booking.BOOKINGSTATUS,booking.USERID,booking.HOTELID,booking.BOOKINGDATE,booking.ROOMS,booking.BOOKEDFROM,booking.BOOKEDTILL, booking.AMOUNT);
                    list.Add(b);
                }
                return list;
            }
        }
      
        public List<UserModel> getUSers()
        {
            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                List<UserModel> list = new List<UserModel>();
                foreach(USER user in entities.USERS)
                {
                    UserModel u = new UserModel(user.USERID, user.FIRSTNAME, user.LASTNAME, user.EMAIL, user.UPASSWORD, user.DOB);
                    list.Add(u);
                }
                return list;
            }
        }
        public UserModel sigin(string email,string password)
        {
            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                UserModel u = null;
                foreach (USER user in entities.USERS)
                {
                    if (user.EMAIL.Equals(email))
                    {
                        if (user.UPASSWORD.Equals(password))
                        {
                            u = new UserModel(user.USERID, user.FIRSTNAME, user.LASTNAME, user.EMAIL, user.UPASSWORD, user.DOB);
                        }
                    }
                 }
                return u;
            }
        }

        public HotelModel getHotelById(int id)
        {

            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                HOTEL hotel = entities.HOTELs.FirstOrDefault(h=> h.HOTELID==id);
                if (hotel == null)
                    return null;
                else
                {
                    HotelModel hm = new HotelModel(hotel.HOTELID, hotel.HOTELNAME, hotel.HCITY, hotel.HSTATE, hotel.TOTALROOMS, hotel.BOOKEDROOMS, hotel.ROOMPRICE, hotel.CONTACTNO);
                    return hm;
                }
            }
        }

        public bool cancelBooking(int id)
        {
            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                BOOKING booking = entities.BOOKINGS.FirstOrDefault(b => b.BOOKINGID == id);
                if (booking == null)
                    return false;
                else
                {
                    HOTEL hotel = entities.HOTELs.FirstOrDefault(h => h.HOTELID == booking.HOTELID);
                    hotel.BOOKEDROOMS -= booking.ROOMS;
                    entities.BOOKINGS.Remove(booking);
                    entities.SaveChanges();
                    return true;
                }
            }
        }

        public BookingModel getBookingById(int id)
        {

            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                BOOKING booking = entities.BOOKINGS.FirstOrDefault(b => b.BOOKINGID == id);
                if (booking == null)
                    return null;
                else
                {
                    BookingModel book = new BookingModel(booking.BOOKINGID, booking.BOOKINGSTATUS, booking.USERID, booking.HOTELID, booking.BOOKINGDATE, booking.ROOMS, booking.BOOKEDFROM, booking.BOOKEDTILL, booking.AMOUNT);
                    return book;
                }
            }
        }

        public List<BookingModel> getBookedHotels(int userid)
        {
            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                List<BOOKING> bookings = entities.BOOKINGS.Where(b => b.USERID == userid).ToList();
                List<BookingModel> list = new List<BookingModel>();
                foreach (BOOKING booking in bookings)
                {
                    BookingModel b = new BookingModel(booking.BOOKINGID, booking.BOOKINGSTATUS, booking.USERID, booking.HOTELID, booking.BOOKINGDATE, booking.ROOMS, booking.BOOKEDFROM, booking.BOOKEDTILL, booking.AMOUNT);
                    list.Add(b);
                }
                return list;
            }
        }

        public BookingModel bookHotel(BOOKING booking)
        {
            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                BookingModel b = null;
                HOTEL hotel = entities.HOTELs.FirstOrDefault(h => h.HOTELID == booking.HOTELID);
                if (hotel == null)
                    return null;
                else
                {
                    hotel.BOOKEDROOMS += booking.ROOMS;
                    entities.BOOKINGS.Add(booking);
                    entities.SaveChanges();
                    b = new BookingModel(booking.BOOKINGID, booking.BOOKINGSTATUS, booking.USERID, booking.HOTELID, booking.BOOKINGDATE, booking.ROOMS, booking.BOOKEDFROM, booking.BOOKEDTILL, booking.AMOUNT);
                    return b;
                }
            }
        }

        public List<HotelModel> getAvailableHotels()
        {
            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                List<HotelModel> list = new List<HotelModel>();
                foreach (HOTEL hotel in entities.HOTELs)
                {
                    if (hotel.BOOKEDROOMS < hotel.TOTALROOMS)
                    {
                        HotelModel h = new HotelModel(hotel.HOTELID, hotel.HOTELNAME, hotel.HCITY, hotel.HSTATE, hotel.TOTALROOMS, hotel.BOOKEDROOMS, hotel.ROOMPRICE, hotel.CONTACTNO);
                        list.Add(h);
                    }
                }
                return list;
            }
        }

    }

}