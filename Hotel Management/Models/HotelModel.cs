using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Management.Models
{
    public class HotelModel 
    {
        public int HOTELID { get; set; }
        public string HOTELNAME { get; set; }
        public string HCITY { get; set; }
        public string HSTATE { get; set; }
        public Nullable<int> TOTALROOMS { get; set; }
        public Nullable<int> BOOKEDROOMS { get; set; }
        public Nullable<float> ROOMPRICE { get; set; }
        public string CONTACTNO { get; set; }

        public HotelModel(int hOTELID, string hOTELNAME, string hCITY, string hSTATE, int? tOTALROOMS, int? bOOKEDROOMS, float? rOOMPRICE, string cONTACTNO)
        {
            HOTELID = hOTELID;
            HOTELNAME = hOTELNAME;
            HCITY = hCITY;
            HSTATE = hSTATE;
            TOTALROOMS = tOTALROOMS;
            BOOKEDROOMS = bOOKEDROOMS;
            ROOMPRICE = rOOMPRICE;
            CONTACTNO = cONTACTNO;
        }
    }
}