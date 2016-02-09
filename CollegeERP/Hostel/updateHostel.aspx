<%@ Page Title="" Language="C#" MasterPageFile="~/Hostel/MasterPage.master" AutoEventWireup="true" CodeFile="updateHostel.aspx.cs" Inherits="Hostel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading" ">Update Hostel</div>
        <div class="panel-body">
    <div class="row ">

                <div class="form-group">
                                    <label class="col-sm-3 control-label">Hostel Name:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="hostelname" placeholder="Please enter Hostel Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="hostelname" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Hostel Name" />      
                                    </div>
            </div>
              <br />
              <br />
               <br />
                <div class="form-group">
               <label class="col-sm-3 control-label">Address:</label>
              <div class="col-sm-9">
                  <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="hosteladdress" placeholder="Please enter Address"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="hosteladdress" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Address" />      
               </div>
               </div>
              <br />
              <br />
               <br />
              
           <div class="form-group">
               <label class="col-sm-3 control-label">Phone No.:</label>
              <div class="col-sm-9">
                  <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="phoneNo" placeholder="Please enter Phone Number"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="phoneNo" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Phone No." />     
               </div>
               </div>
             
               <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Email:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="email" placeholder="Please enter Email"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="email" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Email" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               

           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnupdatehostel" ValidationGroup="addprogramme" Text="Update Hostel" OnClick="btnupdatehostel_Click" runat="server" />
                                     
                                    </div>
            </div>
        </div>
            </div>
        </div>
</asp:Content>

