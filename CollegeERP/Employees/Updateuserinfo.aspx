<%@ Page Title="" Language="C#" MasterPageFile="~/Employees/MasterPage.master" AutoEventWireup="true" CodeFile="Updateuserinfo.aspx.cs" Inherits="Employees_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="panel panel-default">
        <div class="panel-heading">Update Login Info</div>
        <div class="panel-body">
          <div class="row">
                   <div class="form-group">
                                    <label class="col-sm-3 control-label">Username:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Usernametxt" placeholder="Please Enter Email"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                     Display="Dynamic" runat="server" ControlToValidate="Usernametxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Email" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />

               <div class="form-group">
                                    <label class="col-sm-3 control-label">Password:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Password" TextMode="Password" placeholder="Please Enter Password"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="Password" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Password" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />

               <div class="form-group">
                                    <label class="col-sm-3 control-label">Confirm Password:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" TextMode="Password" CssClass="form-control" runat="server" ID="cPassword" placeholder="Please Enter Confirm Password"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="cPassword" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Confirm Password" />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="addprogramme" ControlToCompare="Password" CssClass="field-validation-error" ErrorMessage="Password Does Not Match" ControlToValidate="cPassword"></asp:CompareValidator>
                                    </div>
            </div>
              <br />
               <br />
                <br />

               <div class="form-group" style="text-align:center">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn  btn-primary" ID="btnaupdate" Text="Update " ValidationGroup="addprogramme" runat="server" CausesValidation="true" OnClick="btnaupdate_Click" />
                                        <asp:Button Class="btn  btn-primary" ID="Button1" Text="Do Not Update " runat="server" OnClick="Button1_Click" />
                                     
                                    </div>
            </div>
                  <br />
                  <br />
                  <br />
              </div>

            </div>
         </div>

</asp:Content>

