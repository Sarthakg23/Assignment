using Hotel_Management.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_Management.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        DAL d = new DAL();
        [HttpGet]
        public HttpResponseMessage getUsers()
        {
            if (d.getUSers().Count == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Users");
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, d.getUSers());
            }
        }

        [HttpPost]
        [Route("signUp")]
        public HttpResponseMessage signUp(USER user)
        {
            using (HOTELBOOKINGEntities entities = new HOTELBOOKINGEntities())
            {
                USER u = entities.USERS.FirstOrDefault(x => x.EMAIL == user.EMAIL);
                if (u != null)
                    return Request.CreateResponse(HttpStatusCode.Found, "Email Already registered!");
                else
                {
                    entities.USERS.Add(user);
                    entities.SaveChanges();
                    UserModel um = new UserModel(user.USERID, user.FIRSTNAME, user.LASTNAME, user.EMAIL, user.UPASSWORD, user.DOB);
                    return Request.CreateResponse(HttpStatusCode.OK, um);
                }
            }
            
        }


        [HttpPost]
        [Route("signIn")]
        public HttpResponseMessage signIn([System.Web.Http.FromBody] Login lgn)
        {
           if(d.sigin(lgn.EMAIL,lgn.UPASSWORD)==null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Incorrect Email or password!");
           else
                return Request.CreateResponse(HttpStatusCode.OK, d.sigin(lgn.EMAIL, lgn.UPASSWORD));
        }
    }
}
