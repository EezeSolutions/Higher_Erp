<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterCandidate.aspx.cs" Inherits="Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <head id="head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Application Form</title>

    <!-- Bootstrap -->
    <link href="../css - New/bootstrap.min.css" rel="stylesheet">
    <link href="../css - New/style.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->


</head>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="panel panel-default">
        <div class="panel-heading" >Register</div>
        <div class="panel-body">
            
          <div class="row">
              <input type="hidden" runat="server" id="hidden_dpImage" />
              <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
               <div class="form-group">
                                    <label class="col-sm-2 control-label">Department:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:DropDownList  CssClass="form-control" AutoPostBack="true" runat="server" ID="DropDownDept" OnSelectedIndexChanged="DropDownDept_SelectedIndexChanged">
                                         
                                                                    </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="" ControlToValidate="DropDownDept"
                                                      CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Department is required" />

                  </div>
                   <br />
                   <br />
                   <br />
            </div>
               <div class="form-group">
                                    <label class="col-sm-2 control-label">Programme:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:DropDownList  CssClass="form-control" runat="server" ID="DropDownprogramme">

                                                                    </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="" ControlToValidate="DropDownprogramme"
                                                      CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Programme is required" />

                  </div>
                   <br />
                   <br />
                   <br />
            </div>

                 <div class="form-group">
                                    <label class="col-sm-2 control-label">Name:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Nametxt" placeholder="Please enter your Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="Nametxt" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
                  </div>
            </div>
              <br />
              <br />
               <br /> <br />

               <div class="form-group">
                                    <label class="col-sm-2 control-label">Gender:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:DropDownList AppendDataBoundItems="True" CssClass="form-control" runat="server" ID="dropdownGender">
                                                                        <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                                                    </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" InitialValue="" ControlToValidate="dropdownGender"
                                                      CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Gender is required" />

                  </div>
            </div>
              <br />
              <br />
               <br />

               <div class="form-group">
                 <label class="col-sm-2 control-label">Date of Birth</label>
                                                                <div class="col-sm-1">

                                                                    <asp:DropDownList runat="server" ID="dropdownDay">
                                                                    </asp:DropDownList>


                                                                </div>
                   
                                                                <div class="col-sm-1">

                                                                    <asp:DropDownList runat="server" ID="dropdownMonth">

                                                                        <asp:ListItem Value="1" Text="JAN"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="FEB"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="MAR"></asp:ListItem>
                                                                        <asp:ListItem Value="4" Text="APR"></asp:ListItem>
                                                                        <asp:ListItem Value="5" Text="MAY"></asp:ListItem>
                                                                        <asp:ListItem Value="6" Text="JUN"></asp:ListItem>
                                                                        <asp:ListItem Value="7" Text="JUL"></asp:ListItem>
                                                                        <asp:ListItem Value="8" Text="AUG"></asp:ListItem>
                                                                        <asp:ListItem Value="9" Text="SEP"></asp:ListItem>
                                                                        <asp:ListItem Value="10" Text="OCT"></asp:ListItem>
                                                                        <asp:ListItem Value="11" Text="NOV"></asp:ListItem>
                                                                        <asp:ListItem Value="12" Text="DEC"></asp:ListItem>

                                                                    </asp:DropDownList>


                                                                </div>
                                                                <div class="col-sm-1">
                                                                    <asp:DropDownList runat="server" ID="dropdownyears">
                                                                    </asp:DropDownList>
                                                                </div>
               </div>
             
               <br />
               <br />
                <br />
               <div class="form-group">
               <label class="col-sm-2 control-label">Home Address:</label>
              <div class="col-sm-9">
               <asp:TextBox CssClass="form-control" Height="60px" Rows="2" TextMode="MultiLine" MaxLength="50" runat="server" ID="txtHomeaddress" placeholder="Enter Home Address"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtHomeaddress"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Home address is required." />
                   
               </div>
               </div>
             <br />
               <br />
                <br />
               <br />
               <br />
                <br />
           <div class="form-group">
               <label class="col-sm-2 control-label">Email:</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Emailtxt" placeholder="Please enter your Email"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="Emailtxt" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
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
                                     Display="Dynamic" runat="server" ControlToValidate="Phonetxt" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
               </div>
               </div>
              
               <br />
               <br />
                <br />
              
               <div class="form-group">
               <label class="col-sm-2 control-label">State of Origin:</label>
              <div class="col-sm-9">
                <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="dropdownSto_SelectedIndexChanged" CssClass="form-control" AppendDataBoundItems="true" DataTextField="State" DataValueField="ID" runat="server" ID="dropdownSto">
                                                                        <asp:ListItem Value="" Text="Select STO"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" InitialValue="" ControlToValidate="dropdownSto"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Select State of Origin" />
                   
               </div>
               </div>
             
               <br />
               <br />
                <br />

               <div class="form-group">
               <label class="col-sm-2 control-label">Local Govt Area:</label>
              <div class="col-sm-9">
                <asp:DropDownList CssClass="form-control"  runat="server" ID="dropdownLocalGovtarea">
                                                                        <asp:ListItem Value="" Text="Select Local Government Area"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" InitialValue="" ControlToValidate="dropdownLocalGovtarea"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Select Local Government Area" />

               </div>
               </div>
             </ContentTemplate>
                  </asp:UpdatePanel>
               <br />
               <br />
                <br />

               <div class="form-group">
               <label class="col-sm-2 control-label">Upload Picture:</label>
              <div class="col-sm-4">
                 <div class="col-sm-8">

                                                                      <%--<cc1:AsyncFileUpload OnClientUploadStarted = "uploadStarted" Width="220px" OnClientUploadComplete="uploadComplete" OnUploadedComplete="uploadFile_UploadedComplete" Font-Size="X-Small"  ID="uploadFile" CssClass="btn btn-brown" runat="server" />--%> 
                                                                   <%--<cc1:AsyncFileUpload Width="220px" OnClientUploadComplete="uploadComplete" OnClientUploadError="onUploadError" runat="server" ID="AsyncFileUpload1"
                                                                        UploaderStyle="Modern" CompleteBackColor="White" UploadingBackColor="#CCFFFF"
                                                                        ThrobberID="imgLoader" OnUploadedComplete="FileUploadComplete" OnClientUploadStarted="uploadStarted" />--%>
                     <asp:FileUpload runat="server" ID="FileUpload" />
                                                               
                      </div>
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
                                     Display="Dynamic" runat="server" ControlToValidate="Usernametxt" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
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
                                     Display="Dynamic" runat="server" ControlToValidate="Passwordtxt" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
               </div>
               </div>
              
               <br />
               <br />
                <br />
                <div class="form-group">
               <label class="col-sm-2 control-label">Obtained Marks(Secondary):</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="SecondaryObtained" placeholder="Please enter your secondary obtained marks"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                     Display="Dynamic" runat="server" ControlToValidate="SecondaryObtained" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter marks" />
                                     <asp:Label ID="CheckMarksSecondary" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
               </div>
               </div>
                             <br />
               <br />
                <br />
                <div class="form-group">
               <label class="col-sm-2 control-label">Total Marks(Secondary):</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="TotalSecondary" placeholder="Please enter total secondary marks."></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                     Display="Dynamic" runat="server" ControlToValidate="TotalSecondary" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter marks" />
                                    
               </div>
               </div>
                  <br />
                   <br />
                   <br />
               <div class="form-group">
               <label class="col-sm-2 control-label">Obtained Marks(Intermediate):</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="ObtainedIntermediate" placeholder="Please enter your secondary obtained marks"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                                     Display="Dynamic" runat="server" ControlToValidate="ObtainedIntermediate" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter marks" />
                                    <asp:Label ID="CheckMarks" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
               </div>
               </div>
                             <br />
               <br />
                <br />
                <div class="form-group">
               <label class="col-sm-2 control-label">Total Marks(Intermediate):</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="TotalIntermediate" placeholder="Please enter total secondary marks."></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                                     Display="Dynamic" runat="server" ControlToValidate="TotalIntermediate" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter marks" />
                                    
               </div>
               </div>
               <br />
               <br />
                <br />
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-2 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnRegister" Text="Register"  runat="server" OnClick="btnRegister_Click"/>
                                     
                                    </div>
            </div>

          </div>
              
        </div>
      </div>
     <script type="text/javascript">
         function uploadStarted(sender, args) {


             $get("imgDisplay").style.display = "none";

         }

         function onUploadError(sender, args) {
             alert(args.get_errorMessage());
         }

         function uploadComplete(sender, args) {

             var fileName = args.get_fileName();
             var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1);

             var imgTagHidden = document.getElementById('<%= hidden_dpImage.ClientID %>');

             if (fileExtension == 'png' || fileExtension == 'jpg' || fileExtension == 'PNG' || fileExtension == 'JPG') {

                 if (args.get_length() > 2000000) {
                     alert("Max file size of 2MB is allowed");
                     var fu = document.getElementById("AsyncFileUpload1_ctl04");
                     fu.value = "";
                     imgTagHidden.value = "";
                     return false;
                 }
                 else {
                     var imgDisplay = $get("imgDisplay");
                     imgDisplay.src = "images/loader.gif";

                     var path = '<%=FllUploadFolderPath %>';
                    imgDisplay.src = path + args.get_fileName();
                    imgDisplay.style.display = "inline";
                    imgTagHidden.value = args.get_fileName();


                }
            }
            else {
                alert("Only PNG and JPG Files are supported !");
                imgTagHidden.value = "";
                var fu = document.getElementById("AsyncFileUpload1_ctl04");
                fu.value = "";
                return false;
            }
        }
    </script>
</asp:Content>

