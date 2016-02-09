<%@ Page Title="" Language="C#" MasterPageFile="~/Hostel/MasterPage.master" AutoEventWireup="true" CodeFile="RoomsList.aspx.cs" Inherits="Hostel_Default" %>

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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Room #</th><th>Hostel Name</th><th>Price</th><th>No of Students</th><th>Action</th></tr>
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
                        <div class="col-sm-12">
                        <div style="float:right">
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Add Room</a>
                        </div>
                            <div style="float:right;margin-right:10px">
                             <asp:Button CssClass="btn btn-info" ID="dashboardbtn" runat="server" OnClick="dashboardbtn_Click" Text="Go To Dashboard"/>
                                
                        </div>
                            </div>
                        </div>

                    <br />
                    <br />
            <div id="nameDiv" class="hide" >
                
          <div class="row ">

              
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Select Hostel:</label>
                                     <div class="col-sm-9">
                                    
                                      <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDownHostel" ClientIDMode="Static">
                                          <asp:ListItem Value="" Text="Select Hostel"></asp:ListItem>
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="" ControlToValidate="DropDownHostel"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Hostel" />      
                                    </div>
            </div>
              <br />
              <br />
               <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Room #:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="RoomNo" placeholder="Please enter Room No"></asp:TextBox>
                                     <asp:RequiredFieldValidator  ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="RoomNo" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Room No" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Price:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="price" placeholder="Please enter Price"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="price" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Price" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
              
              <div class="form-group">
                                    <label class="col-sm-3 control-label">Capacity:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="capacity" placeholder="Please enter Capacity"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="capacity" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Capacity" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Description:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" TextMode="MultiLine" CssClass="form-control" runat="server" ID="description" placeholder="Please enter Description"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="description" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Description" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnaddroom" ValidationGroup="addprogramme" Text="Add Room" OnClick="btnaddroom_Click"  runat="server" />
                                     
                                    </div>
            </div>
          </div>
                </div>
                    
                    </ContentTemplate>
                </asp:UpdatePanel>
        </div>
     </div>

    <script type="text/javascript">
        function showHide_Div(tag) {
            var tagitem = document.getElementById(tag);

            if (tagitem.className == "hide") {
                tagitem.className = "show";
            }
            else { tagitem.className = "hide"; }
        }

        $(function () {

            $("#RoomNo").attr("readonly","readonly")

            $(document).on("change", "#DropDownHostel", function () {

                var hostelid = $(this).val();
                if (hostelid == "")
                {
                    $("#RoomNo").val("");
                    return;
                }
                $.ajax({
                    type: "POST",
                    url: "RoomsList.aspx/getnextroomno",
                    data: JSON.stringify({ hstlid: hostelid}),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                       $("#RoomNo").val(response.d);
                    },
                    failure: function (response) {
                        //tagimgLoad.style.display = "none";
                        alert(response.d);
                    },
                    error: function (response) {
                        //tagimgLoad.style.display = "none";
                        alert(response.d);
                    }
                });

            })




            $(".btn-action").click(function () {

                var action = $(this).attr("class").split(" ")[3];
                var id = $(this).data("id");

                if (action == "Disable" || action == "Enable") {
                    var res = confirm("Are You Sure? Press OK to continue.....")
                    if (res == false)
                        return;
                }
                window.location = "updateRoom.aspx?Roomid=" + id + "&action=" + action;

            });



        })
    </script>
</asp:Content>

