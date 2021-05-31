using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Management.Models
{
    public class Login
    {
        public string EMAIL { get; set; }
        public string UPASSWORD { get; set; }

        public Login()
        { }

        public Login(string eMAIL, string uPASSWORD)
        {
            EMAIL = eMAIL;
            UPASSWORD = uPASSWORD;
        }
    }
}