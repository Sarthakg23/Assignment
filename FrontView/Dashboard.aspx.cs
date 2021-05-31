using Hotel_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontView
{
    public partial class Dashboard : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

           if(! Request.Cookies.AllKeys.Contains("usercookie"))
                Response.Redirect("Signin.aspx");

            //var resultList = new List<HotelModel>();
            //var client = new HttpClient();
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            //var getDataTask = client.GetAsync("https://localhost:44363/api/hotel")
            //    .ContinueWith(response =>
            //    {
            //        var result = response.Result;
            //        if (result.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            var readResult = result.Content.ReadAsAsync<List<HotelModel>>();
            //            readResult.Wait();

            //            resultList = readResult.Result;
            //        }
            //    });

            //getDataTask.Wait();



            //StringBuilder sb = new StringBuilder();
            //sb.Append("<ol>");

            //foreach (HotelModel h in resultList)
            //{
            //    sb.Append("<li>");
            //    sb.Append(h.HOTELNAME);
            //    sb.Append("</li>");
            //    sb.Append("<button type='button' onclick='myFunction()'>");
            //    sb.Append("click here");
            //    sb.Append("</button>");
            //    sb.Append("< script type = 'text/javascript' >");
            //    sb.Append("function myFunction() {alert('Clicked');}");
            //    sb.Append("</script>");
            //}

            //sb.Append("</ol>");

            //allhotels.InnerHtml = sb.ToString();
            else
            {
                var resultList = new List<HotelModel>();
                var client = new HttpClient();
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var getDataTask = client.GetAsync("https://localhost:44363/api/hotel")
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<HotelModel>>();
                            readResult.Wait();

                            resultList = readResult.Result;

                            GridView1.DataSource = resultList;

                            GridView1.DataBind();

                        }

                    });

                getDataTask.Wait();
            }
        }



        protected void Button1_Click(object sender, EventArgs e)

        {
            var resultList = new List<HotelModel>();
            var client = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var getDataTask = client.GetAsync("https://localhost:44363/api/hotel")
                .ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<List<HotelModel>>();
                        readResult.Wait();

                        resultList = readResult.Result;

                        //GridView2.DataSource = resultList;

                       // GridView2.DataBind();

                        //foreach(HotelModel h in resultList)
                        //{
                        //    Button b = new Button();

                        //    b.ID = i.ToString();

                        //    i++;

                        //    form1.Controls.Add(b);

                        //    b.Text ="Hotel Id:"+h.HOTELID+Environment.NewLine + "Hotel Name:"+h.HOTELNAME + Environment.NewLine + "Room Price:"+h.BOOKINGPRICE + Environment.NewLine + "Contact No.: "+h.CONTACTNO;


                        //}
                    }
                });

            getDataTask.Wait();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var resultList = new List<BookingModel>();
            var client = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var getDataTask = client.GetAsync("https://localhost:44363/api/booking")
                .ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<List<BookingModel>>();
                        readResult.Wait();

                        resultList = readResult.Result;

                        GridView1.DataSource = resultList;

                        GridView1.DataBind();

                        //foreach (BookingModel b in resultList)
                        //{
                        //    Button bt = new Button();

                        //    bt.ID = i.ToString();

                        //    i++;

                        //    form1.Controls.Add(bt);

                        //    bt.Text = "Booking Id:"+b.BOOKINGID + Environment.NewLine + "Book Date:"+b.BOOKINGDATE + Environment.NewLine + "Hotel Id:"+b.HOTELID + Environment.NewLine + "Rooms Booked"+b.ROOMS;


                        //}
                    }
                });

            getDataTask.Wait();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var resultList = new List<HotelModel>();
            var client = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var getDataTask = client.GetAsync("https://localhost:44363/api/hotel/available/")
                .ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<List<HotelModel>>();
                        readResult.Wait();

                        resultList = readResult.Result;

                        //GridView3.DataSource = resultList;


                        //GridView3.DataBind();
                    }
                   
                });

            getDataTask.Wait();
        }
    }
}