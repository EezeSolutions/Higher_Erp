<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>



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
        
    <div class="content-area">
      <div class="page-container"  style="padding-right:650px">
          <div style="padding-top:100px;">
              <br />
              <div style="text-align:center">

              <asp:Label ID="Message" runat="server" Visible="false" Text="Wrong Username or Password" ForeColor="Red"></asp:Label>
             </div>
                  <br />
              <br />
               <div class="form-signin mg-btm">
                 
                   <div style="width:700px;" class="panel panel-default">
        <div class="panel-heading" >New User Registration </div>
        <div class="panel-body">
            
          <div class="row">
              <input type="hidden" runat="server" id="hidden_dpImage" />
              
          
                 <div class="form-group">
                                    <label class="col-sm-2 control-label">Name:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Nametxt" placeholder="Please enter your Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="Nametxt" ValidationGroup="RegisterUser" CssClass="field-validation-error" ErrorMessage="Please enter your name" />
                                    
                  </div>
            </div>
              <br />
              <br />
               <br /> <br />
       
           <div class="form-group">
               <label class="col-sm-2 control-label">Email:</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Emailtxt" placeholder="Please enter your Email"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="Emailtxt" ValidationGroup="RegisterUser" CssClass="field-validation-error" ErrorMessage="Please enter your email" />
                       <asp:Label ID="LabelEmail" runat="server" Visible="false"></asp:Label>             
               </div>
               </div>
             
               <br />
               <br />
                <br />
             <div class="form-group">
               <label class="col-sm-2 control-label">Phone:</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Phonetxt" placeholder="Please enter your Phone"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="Phonetxt" ValidationGroup="RegisterUser" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
               </div>
               </div>
               <br />
               <br />
                <br />
              <div class="form-group">
               <label class="col-sm-2 control-label">Username:</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Usernametxt" placeholder="Please enter your username"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="Usernametxt" ValidationGroup="RegisterUser" CssClass="field-validation-error" ErrorMessage="Please enter your username" />
                                    
               </div>
               </div>
              
               <br />
               <br />
                <br />
              <div class="form-group">
               <label class="col-sm-2 control-label">Password:</label>
              <div class="col-sm-9">
               <asp:TextBox TextMode="Password" ClientIDMode="Static" CssClass="form-control" runat="server" ID="Passwordtxt" placeholder="Please enter Password"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="Passwordtxt" ValidationGroup="RegisterUser" CssClass="field-validation-error" ErrorMessage="Please enter password" />
                                    
               </div>
               </div>
               <br />
               <br />
                <br />
               <div class="form-group"><br />
                                    <label class="col-sm-2 control-label"></label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn login-button btn-block" ID="btnRegister" Text="Register" ValidationGroup="RegisterUser"  runat="server" OnClick="btnRegister_Click"/><br />
                                        <asp:Label CssClass="field-validation-error" ID="RegistrationLabel" runat="server" Visible="false" Text=""></asp:Label>
                                     
                                    </div>
                                    
            </div>

          </div>
              
        </div>
      </div>

             </div>
          </div>


</div>
    </div>
    </form>

</body>
</html>


     



