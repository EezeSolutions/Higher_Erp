﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Student Portal | Login Page</title>

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
  <div class="loginPage">
  <div class="bg-maroon"></div>    
	<div class="loginPanel" >
		<div class="site-logo text-center"><img src="images/eWalletLogo.png" /></div>
		<h2>Use a student account to log in.</h2>
		
        <div class="form-group" id="errorText">
        <span style="color:Red;font-weight:bold" ><asp:Literal runat="server" id="literalError"></asp:Literal></span>
  </div>
  <div class="form-group">
    <label for="InputEmail">User Name</label>
      <asp:TextBox ID="InputEmail" CssClass="form-control" runat="server"></asp:TextBox>
    <%--<input type="text" class="form-control" id="exampleInputEmail1">--%>
  </div>
  <div class="form-group">
    <label for="InputPassword">Password</label>
            <asp:TextBox ID="InputPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>

    <%--<input type="password" class="form-control" id="exampleInputPassword1">--%>
  </div>

        <div class="form-group" id="captchaForm" >
  <label id="labelCaptcha" visible="false" runat="server" for="txtCaptcha">Please Enter Words Below</label>
  <input type="text" runat="server" class="form-control" visible="false"  id="txtCaptcha" placeholder="Captcha Text" />
  <br />
  <asp:Image width="320"  ID="Image1" runat="server" ImageUrl=""/>
  
  </div>
  <div class="checkbox">
    <label>
      <input type="checkbox"> Check me out
    </label>
  </div>
  <div class="form-group">
      <asp:Button ID="LoginBtn" CssClass="btn btn-brown btn-block" runat="server" OnClick="LoginBtn_Click" Text="Login" />
  <%--<button type="submit" class="btn btn-brown btn-block">Sign In</button>--%>
  </div>

 
<h5><a href="Register.aspx">Register</a> if you don't have an account.</h5>
	
	</div>
    </div>  
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
  
  </body>
  
</html>
    </form>
</body>
</html>
