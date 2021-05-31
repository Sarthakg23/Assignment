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
    public partial class book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Request.Cookies.AllKeys.Contains("usercookie"))
                Response.Redirect("Signin.aspx");

            else
            {
                
                var resultList = new List<HotelModel>();
                var client = new HttpClient();
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var getDataTask = client.GetAsync("https://localhost:44363/api/hotel/available")
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<HotelModel>>();
                            readResult.Wait();

                            resultList = readResult.Result;

                           foreach(HotelModel h in resultList)
                            {
                                if(DropDownList1.Items.FindByValue(h.HSTATE)==null)
                                DropDownList1.Items.Add(h.HSTATE);
                            }


                            foreach (HotelModel h in resultList)
                            {
                                if (h.HSTATE.Equals(DropDownList1.Text) && DropDownList2.Items.FindByValue(h.HCITY) == null)
                                    DropDownList2.Items.Add(h.HCITY);
                            }

                            foreach (HotelModel h in resultList)
                            {
                                if (h.HCITY.Equals(DropDownList2.Text) && DropDownList3.Items.FindByValue(h.HOTELNAME) == null)
                                    DropDownList3.Items.Add(h.HOTELNAME);
                            }

                            foreach (HotelModel h in resultList)
                            {
                                if (h.HSTATE.Equals(DropDownList1.Text) && h.HCITY.Equals(DropDownList2.Text) && h.HOTELNAME.Equals(DropDownList3.Text))
                                {
                                    TextBox3.Text = (h.TOTALROOMS - h.BOOKEDROOMS).ToString();
                                    TextBox4.Text = h.ROOMPRICE.ToString();
                                    Label11.Text = h.HOTELID.ToString();
                                }
                            }

                            int rooms = Convert.ToInt32(TextBox5.Text);
                            int price = Convert.ToInt32(TextBox4.Text);
                            TextBox6.Text = (rooms * price).ToString();
                        }

                    });

             
                getDataTask.Wait();
        }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            var resultList = new List<HotelModel>();
            var client = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var getDataTask = client.GetAsync("https://localhost:44363/api/hotel/available")
                .ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<List<HotelModel>>();
                        readResult.Wait();

                        resultList = readResult.Result;

                        foreach (HotelModel h in resultList)
                        {
                            if(h.HSTATE.Equals(DropDownList1.Text) && DropDownList2.Items.FindByValue(h.HCITY) == null)
                            DropDownList2.Items.Add(h.HCITY);
                        }

                        foreach (HotelModel h in resultList)
                        {
                            if (h.HCITY.Equals(DropDownList2.Text) && DropDownList3.Items.FindByValue(h.HOTELNAME) == null)
                                DropDownList3.Items.Add(h.HOTELNAME);
                        }

                        foreach (HotelModel h in resultList)
                        {
                            if (h.HSTATE.Equals(DropDownList1.Text) && h.HCITY.Equals(DropDownList2.Text) && h.HOTELNAME.Equals(DropDownList3.Text))
                            {
                                TextBox3.Text = (h.TOTALROOMS - h.BOOKEDROOMS).ToString();
                                TextBox4.Text = h.ROOMPRICE.ToString();
                                Label11.Text = h.HOTELID.ToString();
                            }
                        }

                        int rooms = Convert.ToInt32(TextBox5.Text);
                        int price = Convert.ToInt32(TextBox4.Text);
                        TextBox6.Text = (rooms * price).ToString();

                    }

                });

            getDataTask.Wait();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            var resultList = new List<HotelModel>();
            var client = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var getDataTask = client.GetAsync("https://localhost:44363/api/hotel/available")
                .ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<List<HotelModel>>();
                        readResult.Wait();

                        resultList = readResult.Result;

                        foreach (HotelModel h in resultList)
                        {
                            if (h.HCITY.Equals(DropDownList2.Text) && DropDownList3.Items.FindByValue(h.HOTELNAME) == null)
                                DropDownList3.Items.Add(h.HOTELNAME);
                        }

                        foreach (HotelModel h in resultList)
                        {
                            if (h.HSTATE.Equals(DropDownList1.Text) && h.HCITY.Equals(DropDownList2.Text) && h.HOTELNAME.Equals(DropDownList3.Text))
                            {
                                TextBox3.Text = (h.TOTALROOMS - h.BOOKEDROOMS).ToString();
                                TextBox4.Text = h.ROOMPRICE.ToString();
                                Label11.Text = h.HOTELID.ToString();
                            }
                        }

                        int rooms = Convert.ToInt32(TextBox5.Text);
                        int price = Convert.ToInt32(TextBox4.Text);
                        TextBox6.Text = (rooms * price).ToString();

                    }

                });

            getDataTask.Wait();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

            var resultList = new List<HotelModel>();
            var client = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var getDataTask = client.GetAsync("https://localhost:44363/api/hotel/available")
                .ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<List<HotelModel>>();
                        readResult.Wait();

                        resultList = readResult.Result;

                        foreach (HotelModel h in resultList)
                        {
                            if (h.HSTATE.Equals(DropDownList1.Text) && h.HCITY.Equals(DropDownList2.Text) && h.HOTELNAME.Equals(DropDownList3.Text))
                            {
                                TextBox3.Text = (h.TOTALROOMS - h.BOOKEDROOMS).ToString();
                                TextBox4.Text = h.ROOMPRICE.ToString();
                                Label11.Text = h.HOTELID.ToString();
                            }
                        }

                        int rooms = Convert.ToInt32(TextBox5.Text);
                        int price = Convert.ToInt32(TextBox4.Text);
                        TextBox6.Text = (rooms * price).ToString();
                    }

                });

            getDataTask.Wait();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Calendar2.Visible == false)
                Calendar2.Visible = true;
            else
                Calendar2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible == false)
                Calendar1.Visible = true;
            else
                Calendar1.Visible = false;

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {

            TextBox2.Text = Calendar2.SelectedDate.ToShortDateString();
        }

        protected async void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "")
            { Label10.Text = "Choose Both Dates!"; }
            else
            {
                string current = DateTime.Today.ToString("yyyy-MM-dd");
                string start = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
                string end = Calendar2.SelectedDate.ToString("yyyy-MM-dd");

                var values = new Dictionary<string, string>
            {
                { "BOOKINGSTATUS", "BOOKED" },
                { "USERID" , Request.Cookies["usercookie"]["userid"]},
                { "HOTELID", Label11.Text },// email constraint
                { "BOOKINGDATE",current },// 8 character constraint
                { "ROOMS",TextBox5.Text},
                    {"BOOKEDFROM",start },
                    {"BOOKEDTILL",end },
                    {"AMOUNT",TextBox6.Text }
            };
                HttpClient client = new HttpClient();

                var content = new FormUrlEncodedContent(values);

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var response = await client.PostAsync("https://localhost:44363/api/booking", content);

                if (response.IsSuccessStatusCode)
                {

                    var responseString = await response.Content.ReadAsStringAsync();

                    var readResult = response.Content.ReadAsAsync<BookingModel>();

                    readResult.Wait();

                    var user = readResult.Result;

                   

                    Response.Redirect("bookings.aspx");


                }

                else
                    Label10.Text = "Booking Unsuccessfull";

            }
        }


            protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            int rooms = Convert.ToInt32(TextBox5.Text);
            int price = Convert.ToInt32(TextBox4.Text);
            TextBox6.Text = (rooms * price).ToString();
        }
    }
}