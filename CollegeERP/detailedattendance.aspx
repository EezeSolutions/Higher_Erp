<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="detailedattendance.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="panel panel-default">
        <div class="panel-heading" >View Attendance</div>
        <div class="panel-body">
          <div class="row">
              <div class="col-lg-9">
                <table class="table table-responsive" >

                 <asp:Label ID="attendancelbl" runat="server"></asp:Label>
                 </table>
              <br />
              <br />
              <a href="ViewAttendance.aspx" class="btn btn-default">Back To Attandence Page</a>
              </div>
              </div>
            </div>
        </div>
</asp:Content>

