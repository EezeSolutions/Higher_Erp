<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ManageEmployee.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     
                <style type="text/css">
    ..hide {
  display: none !important;
}
.show {
  display: block !important;
}
.btn-action{
    font-size:9px;
    padding:5px;
}
</style>
       <div class="panel panel-default">
        <div class="panel-heading" ">Manage Employee</div>
        <div class="panel-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>

                    <div class="row">
                    <div class="col-sm-3" style="text-align:right;float:right">
                  <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDowndepartment" AutoPostBack="true" OnSelectedIndexChanged="DropDowndepartment_SelectedIndexChanged">
                                     <asp:ListItem Text="All Departments" Value="All"></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="" ControlToValidate="DropDowndepartment"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Department" />      
               </div>
                            <div class="col-sm-12">
                            <table class="table table-responsive "><tr class="blue-background"><th>Employee Name</th><th>Designation</th><th>Phone</th><th>Email</th><th>Deprtment</th><th>Action</th></tr>
                        <asp:Label ID="Employeetbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                        <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalPaging" ></asp:Literal>
                            </ul>
                            </div>
                        <br />
                        <br />
                        <div class="col-sm-12 clearfix">
                        <div style="float:right;margin-right:10px">
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Add Employee</a>
                        </div>
                            <div style="float:right;margin-right:10px">
                             <asp:Button CssClass="btn btn-info" ID="dashboardbtn" runat="server" OnClick="dashboardbtn_Click" Text="Go To Dashboard" />
                        </div>
                            </div>
                        </div>

                    <br />
                    <br />
            <div id="nameDiv" class="hide">
                
          <div class="row ">
              <div class="col-lg-12">
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Employee Name:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="EmpNametxt" placeholder="Please Enter Employee Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="EmpNametxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Employee Name" />
                                    
                           
                                    </div>
            </div>
              <br />
              <br />
               <br />

                    
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Employee Qualification:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Qualificationtxt" placeholder="Please Enter Employee Qualification"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="Qualificationtxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Employee Qualification" />
                                    
                           
                               
            </div>
                    </div>
              <br />
              <br />
               <br />
                <div class="form-group">
               <label class="col-sm-3 control-label">Employee Department:</label>
              <div class="col-sm-9">
                  <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DeptList">
                                     <asp:ListItem Text="Select Department" Value=""></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" InitialValue="" ControlToValidate="DeptList"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Department" />      
               </div>
               </div>
              <br />
              <br />
               <br />
                     <div class="form-group">
               <label class="col-sm-3 control-label">Employee Type:</label>
              <div class="col-sm-9">
                  <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDownEmpType">
                                     <asp:ListItem Text="Select Type" Value=""></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="" ControlToValidate="DropDownEmpType"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Employee Type" />      
               </div>
               </div>
              <br />
              <br />
               <br />
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Designation:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Designationtxt" placeholder="Please Enter Designation"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                     Display="Dynamic" runat="server" ControlToValidate="Designationtxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Designation" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
           <div class="form-group">
               <label class="col-sm-3 control-label" for="dropdownGender">Gender:</label>
              <div class="col-sm-9">
                  <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="dropdownGender">
                                     <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                                     <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                     <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                  

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="" ControlToValidate="dropdownGender"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Gender" />      
               </div>
               </div>
             
               <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label" for="CNICtxt">CNIC:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="CNICtxt" placeholder="Please enter CNIC"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="CNICtxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter CNIC" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
             <div class="form-group">
                 <label class="col-sm-3 control-label" for="dropdownDay">Date of Birth:</label>
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
                                    <label class="col-sm-3 control-label">Phone Number:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="phonetxt" placeholder="Please enter Phone Number"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                                     Display="Dynamic" runat="server" ControlToValidate="phonetxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Phone Number" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
             <div class="form-group">
                                    <label class="col-sm-3 control-label">Address:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Addresstxt" placeholder="Please enter Address"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                     Display="Dynamic" runat="server" ControlToValidate="Addresstxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Address" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
                  <div class="form-group">
               <label class="col-sm-3 control-label">City:</label>
              <div class="col-sm-9">
                   
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Citytxt" placeholder="Please enter City"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                     Display="Dynamic" runat="server" ControlToValidate="Citytxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter City" />
                                    
                          </div>
               </div>
             
               <br />
               <br />
                <br />
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Email Address:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Emailtxt" placeholder="Please Enter Email"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                     Display="Dynamic" runat="server" ControlToValidate="Addresstxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Email" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
                  <div class="form-group">
                                    <label class="col-sm-3 control-label">Username:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="usernametxt" placeholder="Please Enter Username"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                                     Display="Dynamic" runat="server" ControlToValidate="usernametxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Username" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
                  <div class="form-group">
                                    <label class="col-sm-3 control-label">Password:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Passwordtxt" TextMode="Password" placeholder="Please enter Password"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator15"
                                     Display="Dynamic" runat="server" ControlToValidate="Passwordtxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Password" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
                      <div class="form-group">
                                    <label class="col-sm-3 control-label">Account No:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Accounttxt" placeholder="Please Enter Account Number"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                                     Display="Dynamic" runat="server" ControlToValidate="Accounttxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Account Number" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />

                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Bank Name:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Banktxt" placeholder="Please Enter Bank Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                                     Display="Dynamic" runat="server" ControlToValidate="Accounttxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Bank Name" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
               <div class="form-group" style="text-align:center">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnaddEmployee" ValidationGroup="addProgramme" Text="Add Employee" runat="server" OnClick="btnaddEmployee_Click" />
                                     
                                    </div>
            </div>
                  <br />
                  <br />
                  <br />
                  
                </div>
              </div>
          
                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
           
        </div>
           </div>
    

     <script type="text/javascript">
         function showHide_Div(tag) {
             var tagitem = document.getElementById(tag);

             if (tagitem.className == "hide") {
                 tagitem.className = "show";
             }
             else { tagitem.className = "hide"; }
         }

         $(function () {
             $(".btn-action").click(function () {

                 var action = $(this).attr("class").split(" ")[3];
                 var id = $(this).data("id");

                 if (action == "Disable" || action == "Enable") {
                     var res = confirm("Are You Sure? Press OK to continue.....")
                     if (res == false)
                         return;
                 }
                 window.location = "updateCourse.aspx?Courseid=" + id + "&action=" + action;

             });



         })
    </script>
   
</asp:Content>

