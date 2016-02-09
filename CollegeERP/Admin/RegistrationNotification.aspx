<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="RegistrationNotification.aspx.cs" Inherits="Admin_RegistrationNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="panel panel-default">
        <div class="panel-heading">Registration Notification</div>
        <div class="panel-body">
          <div class="row">
            
            <div class="col-sm-12">
                <asp:Literal ID="Message" runat="server"></asp:Literal>
            </div>
          </div>
        </div>
      </div>
</asp:Content>

