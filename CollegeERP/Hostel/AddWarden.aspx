<%@ Page Title="" Language="C#" MasterPageFile="~/Hostel/MasterPage.master" AutoEventWireup="true" CodeFile="AddWarden.aspx.cs" Inherits="Hostel_Default" %>

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
        <div class="panel-heading" ">Warden List</div>
        <div class="panel-body">
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Warden Name</th><th>Phone</th><th>Email</th><th>Warden Hostel</th><th>Action</th></tr>
                        <asp:Label ID="wardentbl" runat="server" Text=""></asp:Label>
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
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Add Warden</a>
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
                                    <label class="col-sm-3 control-label">Warden Name:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="wardenname" placeholder="Please enter Warden Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="wardenname" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Warden Name" />      
                                    </div>
            </div>
              <br />
              <br />
               <br />
                <div class="form-group">
               <label class="col-sm-3 control-label">Phone Number:</label>
              <div class="col-sm-9">
                  <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="wardenphone" placeholder="Please enter Warden Phone"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="wardenphone" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Warden Phone" />      
               </div>
               </div>
              <br />
              <br />
               <br />

               <div class="form-group">
                                    <label class="col-sm-3 control-label">Email:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="email" placeholder="Please enter Email"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="email" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Email" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Select Hostel:</label>
                                     <div class="col-sm-9">
                                    
                                      <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDownHostel">
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="" ControlToValidate="DropDownHostel"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Hostel" />      
                                    </div>
            </div>
                <br />
               <br />
                <br />

           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnaddwarden" ValidationGroup="addprogramme" Text="Add Warden" OnClick="btnaddwarden_Click"  runat="server" />
                                     
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
            $(".btn-action").click(function () {

                var action = $(this).attr("class").split(" ")[3];
                var id = $(this).data("id");

                if (action == "Disable" || action == "Enable") {
                    var res = confirm("Are You Sure? Press OK to continue.....")
                    if (res == false)
                        return;
                }
                window.location = "updateWarden.aspx?Wardenid=" + id + "&action=" + action;

            });



        })
    </script>
</asp:Content>

