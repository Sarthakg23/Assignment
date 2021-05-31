using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net;
using Hotel_Management.Models;

namespace FrontView
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies.AllKeys.Contains("usercookie"))
                Response.Redirect("Dashboard.aspx");
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
           
            if (TextBox5.Text=="")
            { Label6.Text = "Choose DOB!"; }
            else
            {
                string formatted = Calendar1.SelectedDate.ToString("yyyy-MM-dd");

                var values = new Dictionary<string, string>
            {
                { "FIRSTNAME", TextBox1.Text },
                { "LASTNAME" , TextBox2.Text },
                { "EMAIL", TextBox3.Text },// email constraint
                { "UPASSWORD",TextBox4.Text },// 8 character constraint
                { "DOB",formatted}
            };

                HttpClient client = new HttpClient();

                var content = new FormUrlEncodedContent(values);

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var response = await client.PostAsync("https://localhost:44363/api/user/signUp", content);

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
                    Label6.Text = "Signup Unsuccessfull";

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signin.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if(Calendar1.Visible==false)
            Calendar1.Visible = true;
            else
                Calendar1.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox5.Text = Calendar1.SelectedDate.ToShortDateString();
        }
    }
}


        //var content = new FormUrlEncodedContent(values);

        // var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

        // var responseString = await response.Content.ReadAsStringAsync();
    
  