using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Management.Models
{
    public class UserModel
    {
        public int USERID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string EMAIL { get; set; }
        public string UPASSWORD { get; set; }
        public System.DateTime DOB { get; set; }
        public UserModel(int USERID,string FIRSTNAME,string LASTNAME,string EMAIL,string UPASSWORD,System.DateTime DOB)
        {
            this.USERID = USERID;
            this.FIRSTNAME = FIRSTNAME;
            this.LASTNAME = LASTNAME;
            this.EMAIL = EMAIL;
            this.UPASSWORD = UPASSWORD;
            this.DOB = DOB;
        }
     
    }
}