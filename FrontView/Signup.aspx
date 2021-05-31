<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="FrontView.Signup" Async="true" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/mycss.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body class="bodycss">
    <form id="form1" runat="server">

        
    
  
    <div class="content">
    
    <center> <h1 class="heading">SignUp Form</h1></center>
     <div class="card">
        
         <center>
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server" ToolTip="Enter First Name" CssClass="textbox"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
    ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />
<br />
            <asp:Label ID="Label2" runat="server" Text="Last Name" ></asp:Label><br />
            <asp:TextBox ID="TextBox2" runat="server"  ToolTip="Enter Last Name" CssClass="textbox"></asp:TextBox><br />
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
    ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />
<br />     
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox ID="TextBox3" runat="server" ToolTip="Enter Email" CssClass="textbox"></asp:TextBox><br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3"
    ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
    Display = "Dynamic" ErrorMessage = "Invalid email address"/><br />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
    ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />
<br />
            <asp:Label ID="Label5" runat="server" Text="Enter Password" ></asp:Label><br />
            <asp:TextBox ID="TextBox4" runat="server" ToolTip="Enter Password" CssClass="textbox"></asp:TextBox><br />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4"
    ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />
             <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3"
Display = "Dynamic"
ControlToValidate = "TextBox4"
ValidationExpression = "^[\s\S]{8,8}$"
ErrorMessage="8 characters required."/><br />

             <asp:Label ID="Label3" runat="server" Text= "DOB"></asp:Label>
             <asp:Button ID="Button2" runat="server" Text="Choose DOB" OnClick="Button2_Click1"></asp:Button><br />
             <asp:TextBox ID="TextBox5" ToolTip="Enter DOB" runat="server"  CssClass="textbox" ReadOnly="true"></asp:TextBox><br />
           
<br />
           
            
            <asp:Calendar ID="Calendar1" runat="server" Visible="false" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar><br />
            <br />

            <asp:Button ID="Button1" runat="server" Text="Signup" OnClick="Button1_Click" class="btn btn-primary btn-lg btn-block" style="width:50%"/><br />

<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Signin.aspx" style="font-size:large">Already Registered?SignIn</asp:HyperLink><br />
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            </center>
  
       
    </div>
        <br />
        </div>
</div>
        </form>
    </body>
    </html>