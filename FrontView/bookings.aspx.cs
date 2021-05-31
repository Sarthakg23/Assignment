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
    public partial class bookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.Cookies.AllKeys.Contains("usercookie"))
                Response.Redirect("Signin.aspx");
            else
            {
                var resultList = new List<BookingModel>();
                var client = new HttpClient();
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var getDataTask = client.GetAsync("https://localhost:44363/api/booking/bookings/" + Request.Cookies["usercookie"]["userid"])
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<BookingModel>>();
                            readResult.Wait();

                            resultList = readResult.Result;


                            GridView2.DataSource = resultList;

                            GridView2.DataBind();

                            Button1.Visible = true;

                        }
                        else
                        {
                            Label2.Text = "No Booking Made so far.";
                         
                            
                        }

                    });

                getDataTask.Wait();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Label1.Visible == false)
                Label1.Visible = true;
            else
                Label1.Visible = false;

            if (TextBox1.Visible == false)
                TextBox1.Visible = true;
            else
                TextBox1.Visible = false;


            if (Button2.Visible == false)
                Button2.Visible = true;
            else
                Button2.Visible = false;


        }

        protected async void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
                Label2.Text = "Enter Booking ID!";
            else
            {

                HttpClient client = new HttpClient();

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var response = await client.DeleteAsync("https://localhost:44363/api/booking/" + TextBox1.Text);

                if (response.IsSuccessStatusCode)
                { 

                    Response.Redirect("bookings.aspx");


                }

                else
                    Label2.Text = "Cancelling Unsuccessfull";

            }
        }
    }
}
