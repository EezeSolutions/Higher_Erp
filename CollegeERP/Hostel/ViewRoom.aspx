<%@ Page Title="" Language="C#" MasterPageFile="~/Hostel/MasterPage.master" AutoEventWireup="true" CodeFile="ViewRoom.aspx.cs" Inherits="Hostel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style type="text/css">
    .hide {
  display: none !important;
}
.show {
  display: block !important;
}
.btn-action{
    font-size:9px;
    padding:5px;
}
</style>
       <div class="panel panel-default">
        <div class="panel-heading" ">Rooms List</div>
        <div class="panel-body">
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Room #</th><th>Hostel Name</th><th>Price</th><th>Remaining Capacity</th><th>Action</th></tr>
                        <asp:Label ID="roomtbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                        <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalPaging" ></asp:Literal>
                            </ul>
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
                window.location = "OrderRoom.aspx?Roomid=" + id + "&action=" + action;

            });



        })
    </script>
</asp:Content>

