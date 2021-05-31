using Hotel_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontView
{
    public partial class Signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies.AllKeys.Contains("usercookie"))
                Response.Redirect("Dashboard.aspx");
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text=="" || TextBox2.Text=="")
            { Label3.Text = "Enter All Fields"; }

            else
            {
                var values = new Dictionary<string, string>
            {
                { "EMAIL", TextBox1.Text },
                { "UPASSWORD",TextBox2.Text }// 8 character constraint
               
            };

                HttpClient client = new HttpClient();

                var content = new FormUrlEncodedContent(values);

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var response = await client.PostAsync("https://localhost:44363/api/user/signIn", content);

                if (response.IsSuccessStatusCode)
                {


                    var responseString = await response.Content.ReadAsStringAsync();

                    var readResult = response.Content.ReadAsAsync<UserModel>();

                    readResult.Wait();

                    var user = readResult.Result;

                    HttpCookie userInfo = new HttpCookie("usercookie");

                    userInfo["userid"] = user.USERID.ToString();

                    Response.Cookies.Add(userInfo);

                    Response.Redirect("Dashboard.aspx");
                }
                else
                    Label3.Text = "Sigin Unsuccessfull";
            }
        }
    }
}