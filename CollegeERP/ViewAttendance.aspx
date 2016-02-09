<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAttendance.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading" >View Attendance</div>
        <div class="panel-body">
          <div class="row">
              <div class="col-lg-12">
                <table class="table table-responsive" >

                 <asp:Label ID="attendancelbl" runat="server"></asp:Label>
                 </table>

              </div>
              </div>
            </div>
        </div>
</asp:Content>

