<%@ Page Title="" Language="C#" MasterPageFile="~/Hostel/MasterPage.master" AutoEventWireup="true" CodeFile="updateWarden.aspx.cs" Inherits="Hostel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading" ">Update Warden</div>
        <div class="panel-body">
            <div class="row ">

                <div class="form-group">
                                    <label class="col-sm-3 control-label">Warden Name:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="wardenname" placeholder="Please enter Warden Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="wardenname" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Warden Name" />      
                                    </div>
            </div>
              <br />
              <br />
               <br />
                <div class="form-group">
               <label class="col-sm-3 control-label">Phone Number:</label>
              <div class="col-sm-9">
                  <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="wardenphone" placeholder="Please enter Warden Phone"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="wardenphone" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Warden Phone" />      
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
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Select Hostel:</label>
                                     <div class="col-sm-9">
                                    
                                      <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDownHostel">
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="" ControlToValidate="DropDownHostel"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Hostel" />      
                                    </div>
            </div>
                <br />
               <br />
                <br />

           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnupdatewarden" ValidationGroup="addprogramme" Text="Update Warden" OnClick="btnupdatewarden_Click"  runat="server" />
                                     
                                    </div>
            </div>
          </div>
            </div>
        </div>
</asp:Content>

