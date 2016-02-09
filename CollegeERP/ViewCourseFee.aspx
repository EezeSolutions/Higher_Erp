<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCourseFee.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="panel panel-default">
        <div class="panel-heading" >Enroll Courses Fee:</div>
        <div class="panel-body">
            
          <div class="row">

                                  
           
             <table class="table table-responsive">
                                        <tr class="blue-background" align="center"><th>Course</th><th>Max Marks</th><th>Course Fee</th><th>Status</th><th></th></tr>
              
              <asp:Label ID="coursefeetbl" runat="server"></asp:Label>
                  </table>

              </div>
            </div>
            </div>
</asp:Content>

