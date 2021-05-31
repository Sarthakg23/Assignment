<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="FrontView.book" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/mycss.css" rel="stylesheet" />
      <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body class="bodycss">
    <form id="form1" runat="server">
         <div class="content">
    <center> <h1 class="heading">Booking Form</h1></center>
     <div class="card">
         <center>
         <asp:Label ID="Label1" runat="server" Text="Choose State"></asp:Label><br />
         <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" cssClass="dropdown"></asp:DropDownList><br />
         <asp:Label ID="Label2" runat="server" Text="Choose City"></asp:Label><br />
         <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true" cssClass="dropdown"></asp:DropDownList><br />
         <asp:Label ID="Label3" runat="server" Text="Choose Hotel"></asp:Label><br />
         <asp:DropDownList ID="DropDownList3" runat="server"   OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true" cssClass="dropdown"></asp:DropDownList><br />

<asp:Label ID="Label6" runat="server" Text="Rooms Available"></asp:Label><br />
             <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox><br />

             <asp:Label ID="Label7" runat="server" Text="Room Price"></asp:Label><br />
             <asp:TextBox ID="TextBox4" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox><br /><br />

              <asp:Label ID="Label4" runat="server" Text= "Book From"></asp:Label>
             <asp:Button ID="Button1" runat="server" Text="Choose Date" OnClick="Button1_Click"></asp:Button><br />
             <asp:TextBox ID="TextBox1" ToolTip="Enter Date" runat="server"  CssClass="textbox" ReadOnly="true"></asp:TextBox><br />
              <asp:Calendar ID="Calendar1" runat="server" Visible="false" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar><br />
          

             <asp:Label ID="Label5" runat="server" Text= "Book Till"></asp:Label>
             <asp:Button ID="Button2" runat="server" Text="Choose Date" onClick="Button2_Click"></asp:Button><br />
             <asp:TextBox ID="TextBox2" ToolTip="Enter Date" runat="server"  CssClass="textbox" ReadOnly="true"></asp:TextBox><br />
              <asp:Calendar ID="Calendar2" runat="server" Visible="false" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar><br />
       
             <asp:Label ID="Label8" runat="server" Text="Number of Rooms to Book"></asp:Label><br />
<asp:TextBox ID="TextBox5" runat="server" CssClass="textbox" type="number" OnTextChanged="TextBox5_TextChanged" min="1" Text="1" AutoPostBack="true" ></asp:TextBox><br />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
    ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" /><br />

                <asp:Label ID="Label9" runat="server" Text="Total Amount"></asp:Label><br />
             <asp:TextBox ID="TextBox6" runat="server" ReadOnly="true" CssClass="textbox"></asp:TextBox><br /><br />

              <asp:Button ID="Button3" runat="server" Text="Book" OnClick="Button3_Click"  class="btn btn-primary btn-lg btn-block" style="width:50%"/><br />

<asp:Label ID="Label10" runat="server" Text="" ></asp:Label><br />
<asp:Label ID="Label11" runat="server" Text="Label" Visible="false"></asp:Label>
     </div>
         </center>
             <br />
    </form>
</body>
</html>
