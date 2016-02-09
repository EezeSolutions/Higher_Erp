<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddNotices.aspx.cs" Inherits="Default2" %>

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
        <div class="panel-heading" ">Notices</div>
        <div class="panel-body">
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-responsive"><tr class="blue-background"><th>Notice Type</th><th>Date</th><th>Action</th></tr>
                        <asp:Label ID="programstbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                        <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalPaging" ></asp:Literal>
                            </ul>
                            </div>
                        <br />
                        
                        <div class="col-sm-12">
                        <div style="float:right">
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Add New Notice</a>
                        </div>
                            </div>
                        </div>
                    <br />
      <span runat="server" id="Span1"  ></span>
      <br />
                    <br />
                    <br />

                    <div id="nameDiv" class="hide">

    <div class="row ">
      
    <div class="form-group">
         <div class="form-group">
    <label class="col-sm-3 control-label"> Notice Type</label>
        
        <div class="col-sm-9">
      <asp:DropDownList ID="NoticTypeList" CssClass="form-control" runat="server" >
        
        <%--<option selected="selected" disabled="disabled">Select a program</option>--%>
    </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="" ControlToValidate="NoticTypeList"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Notic Type" />
                       
    </div>
  </div>
        
             <div class="form-group">
    <label class="col-sm-3 control-label">Notice Message</label>
            <br /><br /><br />
                 <div class="col-sm-9">
                 <asp:TextBox ID="NoticeMsg" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" InitialValue="" ControlToValidate="NoticeMsg"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Add Notic Message" />
                            
     </div>
  </div>
            <br /><br /><br /><br />
              <div class="form-group">
                  <label class="col-sm-3 control-label"></label>
                  <div class="col-sm-9">
      <asp:Button ID="NoticeBtn" CssClass="btn btn-brown btn-block" ValidationGroup="addProgramme" runat="server" Text="Create" OnClick="NoticeBtn_Click" />
      </div>
      <br />
      <span runat="server" id="Span2"  ></span>
      <br />
    
  <%--<button type="submit" class="btn btn-brown btn-block">Sign In</button>--%>
  </div>
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
                window.location = "updateNotice.aspx?Noticeid=" + id + "&action=" + action;

            });



        })
    </script>
</asp:Content>

