<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>cPanel | Login Page</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>
<body>
    <form id="form1" runat="server">
   <header>
      <div class="page-container">
        <a href="#" class="logo"><img src="images/logo.png" /></a>
      </div>
    </header>
        </header>
    <div class="content-area">
      <div class="page-container">
          <div style="margin-top:50%;">
              <h2 style="text-align:center">Login</h2>
              <br />
              <div style="text-align:center">

              <asp:Label ID="Message" runat="server" Visible="false" Text="Wrong Username or Password" ForeColor="Red"></asp:Label>
             </div>
                  <br />
              <asp:validationsummary id="valSummary" runat="server" headertext="Validation Errors:" cssclass="ValidationSummary" />
              <br />
               <div class="form-signin mg-btm">
                  <asp:TextBox ID="username" CssClass="form-control" ValidationGroup="CheckLogin" Placeholder="username" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="UserNameValidator" ValidationGroup="CheckLogin" ControlToValidate="username" runat="server" Display="Dynamic" ErrorMessage="Please enter the user name." ForeColor="Red"></asp:RequiredFieldValidator>
                  <asp:TextBox ID="password" TextMode="Password" ValidationGroup="CheckLogin" Placeholder="Password" runat="server" CssClass="form-control"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="CheckLogin" ControlToValidate="username" runat="server" Display="Dynamic" ErrorMessage="Please enter the password" ForeColor="Red"></asp:RequiredFieldValidator>
                   <div class="social-box">
                      <div class="row mg-btm">
                          <div class="col-md-12">
                              <asp:Button ID="btnlogin" CausesValidation="true" runat="server" Text="Login" ValidationGroup="CheckLogin" OnClick="btnlogin_Click" CssClass="btn login-button btn-block" />         
                          </div>
                      </div>


                  </div>
                  <div class="loginpage-footer text-center">
                      <a href="#">Forgot your password?</a>

                  </div>
                  <div class="loginpage-footer text-center">
                      <a href="Registration.aspx">New User? Register Here</a>

                  </div>
                  <p>By signing in or signing up, you agree to our Terms and that you have read our Privacy Policy.</p>
             </div>
          </div>


</div>
    </div>
    </form>
</body>
</html>
