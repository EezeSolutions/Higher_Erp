<%@ Page Title="" Language="C#" MasterPageFile="~/LMS/MasterPage.master" AutoEventWireup="true" CodeFile="AssignmentResult.aspx.cs" Inherits="LMS_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading" ">Assignment Result</div>
        <div class="panel-body">
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
            

    <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Course Title</th><th>Assignment Title</th><th>Total Marks</th><th>Student Name</th><th>Marks Obtained</th></tr>
                        <asp:Label ID="resulttbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>

         <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="AssignmentResultPaging" ></asp:Literal>
                            </ul>
                            </div>
                 </div></div>
           

</asp:Content>

