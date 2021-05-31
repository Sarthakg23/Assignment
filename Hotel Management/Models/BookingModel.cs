using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Management.Models
{
    public class BookingModel
    {
        public int BOOKINGID { get; set; }
        public string BOOKINGSTATUS { get; set; }
        public int USERID { get; set; }
        public int HOTELID { get; set; }
        public System.DateTime BOOKINGDATE { get; set; }
        public int ROOMS { get; set; }
        public Nullable<System.DateTime> BOOKEDFROM { get; set; }
        public Nullable<System.DateTime> BOOKEDTILL { get; set; }
        public int AMOUNT { get; set; }

        public BookingModel(int bOOKINGID, string bOOKINGSTATUS, int uSERID, int hOTELID, DateTime bOOKINGDATE, int rOOMS, DateTime? bOOKEDFROM, DateTime? bOOKEDTILL, int aMOUNT)
        {
            BOOKINGID = bOOKINGID;
            BOOKINGSTATUS = bOOKINGSTATUS;
            USERID = uSERID;
            HOTELID = hOTELID;
            BOOKINGDATE = bOOKINGDATE;
            ROOMS = rOOMS;
            BOOKEDFROM = bOOKEDFROM;
            BOOKEDTILL = bOOKEDTILL;
            AMOUNT = aMOUNT;
        }
    }
}