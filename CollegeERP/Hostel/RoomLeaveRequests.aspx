<%@ Page Title="" Language="C#" MasterPageFile="~/Hostel/MasterPage.master" AutoEventWireup="true" CodeFile="RoomLeaveRequests.aspx.cs" Inherits="Hostel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="panel panel-default">
        <div class="panel-heading" ">Leave Room Requests</div>
        <div class="panel-body">
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Room Name</th><th>Hostel Name</th><th>Student Name</th><th>Department</th><th>Acadamic Year</th><th>Action</th></tr>
                        <asp:Label ID="roomtbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                        <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalPaging" ></asp:Literal>
                            </ul>
                            </div>
                         <div class="col-sm-12">
                            <div style="float:right;margin-right:10px">
                             <asp:Button CssClass="btn btn-info" ID="dashboardbtn" runat="server" OnClick="dashboardbtn_Click" Text="Go To Dashboard"/>
                                
                        </div>
                            </div>
                        <br />
                        <br />
                        </ContentTemplate>
                </asp:UpdatePanel>
            
            </div>
           </div>

      <script type="text/javascript">
          $(function () {
              $(".btn-action").click(function () {

                  var action = $(this).attr("class").split(" ")[3];
                  var id = $(this).data("id");

                  if (action == "Disable" || action == "Enable") {
                      var res = confirm("Are You Sure? Press OK to continue.....")
                      if (res == false)
                          return;
                  }
                  window.location = "AcceptRequest.aspx?Requestid=" + id + "&action=" + action;

              });



          })
    </script>
</asp:Content>

