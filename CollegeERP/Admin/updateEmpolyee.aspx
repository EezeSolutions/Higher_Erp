<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="updateEmpolyee.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="panel panel-default">
        <div class="panel-heading" ">Manage Courses</div>
        <div class="panel-body">

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
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ValidationGroup="addprogramme" ID="btnupdateEmployee" Text="Update Employee" runat="server" OnClick="btnupdateEmployee_Click" />
                                     
                                    </div>
            </div>
                  <br />
                  <br />
                  <br />
                  
                </div>
              </div>


            </div>
          </div>
</asp:Content>

