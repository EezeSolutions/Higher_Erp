<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewTimeTable.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading" >Enroll Courses Fee:</div>
        <div class="panel-body">
            
          <div class="row">

                                  
           
             <table class="table table-responsive">
                 <tr class="blue-background"><th>Course</th><th>Day</th><th>Tutor Name</th><th>Start Time</th><th>End Time</th></tr>
                  <asp:Label ID="timetabletbl" runat="server"></asp:Label>
                 </table>
              </div>
            </div>
        </div>
</asp:Content>

