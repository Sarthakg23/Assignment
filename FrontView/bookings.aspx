<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookings.aspx.cs" Inherits="FrontView.bookings"  Async="true" MasterPageFile="~/Site.Master" EnableEventValidation="false"%>

<asp:content id="Content1" ContentPlaceHolderID="MainContent" runat="server" >
     
                
          <center><h1 class="heading">All Bookings</h1></center>
       <center><asp:GridView ID="GridView2" runat="server" CssClass="gridview"></asp:GridView> </center><br />
    <center><asp:Button ID="Button1" runat="server" Text="Cancel Booking" class="btn btn-primary btn-lg btn-block" onClick="Button1_Click" Visible="false"/></center><br />
  <center>  <asp:Label ID="Label1" runat="server" Text="Enter Booking ID" Visible="false"></asp:Label></center><br />
    <center><asp:TextBox ID="TextBox1" ToolTip="Enter DOB" runat="server"  CssClass="textbox" Visible="false"></asp:TextBox></center><br />
    <center><asp:Button ID="Button2" runat="server" Text="Cancel" class="btn btn-primary btn-lg btn-block" onClick="Button2_Click" Visible="false"/></center><br />
    <center><asp:Label ID="Label2" runat="server" Text=""></asp:Label></center>
    
         

         

   </asp:content> 
