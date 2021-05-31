<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="FrontView.Signin" Async="true" %>

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
    
    <center> <h1 class="heading">SigIn Form</h1></center>
     <div class="card">
        
         <center>
        
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server" ToolTip="Enter Email" CssClass="textbox"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
    ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
    ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
    Display = "Dynamic" ErrorMessage = "Invalid email address"/><br />

            <asp:Label ID="Label2" runat="server" Text="Enter Password"></asp:Label><br />
            <asp:TextBox ID="TextBox2" runat="server" ToolTip="Enter Password" CssClass="textbox"></asp:TextBox><br />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
    ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />
              <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3"
Display = "Dynamic"
ControlToValidate = "TextBox2"
ValidationExpression = "^[\s\S]{8,8}$"
ErrorMessage="8 characters required."/><br />

        <asp:Button ID="Button1" runat="server" Text="Signin" OnClick="Button1_Click"  class="btn btn-primary btn-lg btn-block" style="width:50%"/><br />


<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Signup.aspx" style="font-size:large">New User?Signup</asp:HyperLink><br />
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
         </center>
     </div>
       
    </div>
  

    </form>
</body>
</html>
