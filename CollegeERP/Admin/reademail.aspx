<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="reademail.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div class="panel panel-default">
        <div class="panel-heading" ">Mail</div>
        <div class="panel-body">
        <div class="row">
            <div class="col-lg-12">
            <b class="h4">From:</b> <asp:Label runat="server" ID="fromlbl"></asp:Label>  <br /><br /><br />
            <b class="h4">Subject:</b><asp:Label runat="server" ID="subjectlbl"></asp:Label><br />
            <br />
            <br />
            <b class="h4" >Message</b> <br /><br /><asp:Label runat="server" ID="Messagelbl"></asp:Label>
                           <br />
            <br />
            <br />
            <br />
            
                <a href="AdminInbox.aspx" class="btn btn-success fa fa-inbox">Back To Inbox</a>
            
                 </div>

            </div>
            </div>
       </div>
    
</asp:Content>

