<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddTimeTable.aspx.cs" Inherits="Default2" %>

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
        <div class="panel-heading" ">Manage Time Table</div>
        <div class="panel-body">
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-responsive "><tr class="blue-background"><th>Course</th><th>Start Time</th><th>End Time</th><th>Day</th><th>Teacher</th><th>Action</th></tr>
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
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Add New TimeTable</a>
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
    <label class="col-sm-3 control-label"> Course</label>
     
                    <div class="col-sm-9">
      <asp:DropDownList ID="CourseList" CssClass="form-control" runat="server" >
        
       
    </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="cousrValidate" runat="server" InitialValue="" ControlToValidate="CourseList"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Course" />  
    </div>
                    <br /><br />
  </div>
        <div class="form-group">
    <label class="col-sm-3 control-label">Start Time</label>
            
            <div class="col-sm-9">
            <asp:TextBox ID="STime"  CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="" ControlToValidate="STime"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Enetr Starting Time" />
     </div>
  </div>
        <br /><br /><br />
         <div class="form-group">
    <label class="col-sm-3 control-label">End Time</label>
             
             <div class="col-sm-9">
            <asp:TextBox ID="ETime"  CssClass="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="" ControlToValidate="ETime"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Enetr Ending time" />
                 </div>
  </div>
        <br /><br />
        <div class="form-group">
    <label class="col-sm-3 control-label"> Day</label>
           
            <div class="col-sm-9">
      <asp:DropDownList ID="DropDownDay" CssClass="form-control" runat="server" >
          <asp:ListItem></asp:ListItem>
          <asp:ListItem>Monday</asp:ListItem>
          <asp:ListItem>Tuesday</asp:ListItem>
          <asp:ListItem>Wednesday</asp:ListItem>
          <asp:ListItem>Thusday</asp:ListItem>
          <asp:ListItem>Friday</asp:ListItem>
        <%--<option selected="selected" disabled="disabled">Select a program</option>--%>
    </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="" ControlToValidate="DropDownDay"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select a day" />
                </div>
            </div>
            <br /><br /><br />
        
         <div class="form-group">
             <label class="col-sm-3 control-label"></label>
             <div class="col-sm-9">
      <asp:Button ID="TimeTableBtn" CssClass="btn btn-brown btn-block" runat="server" ValidationGroup="addProgramme" Text="Create" OnClick="TimeTableBtn_Click" />
      
      </div>
    
  <%--<button type="submit" class="btn btn-brown btn-block">Sign In</button>--%>
  
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
            window.location = "updateTimeTable.aspx?Timetableid=" + id + "&action=" + action;

        });



    })
    </script>
</asp:Content>

