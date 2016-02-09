<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddDateSheet.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <style type="text/css">
    ..hide {
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
        <div class="panel-heading" ">Manage Date Sheets</div>
        <div class="panel-body">
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-responsive "><tr class="blue-background"><th>Exam Type</th><th>Exam Date(DD:MM:YYYY)</th><th>Course ID</th><th>Start Time</th><th>End Time</th><th>Action</th></tr>
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
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Add New DateSheet</a>
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
        
        <%--<option selected="selected" disabled="disabled">Select a program</option>--%>
    </asp:DropDownList>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="" ControlToValidate="CourseList"
          CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Course" />
    </div>
  </div>
        <br /><br /><br /><br />
            <div class="form-group">
    <label class="col-sm-3 control-label"> Exam Type</label>
      
                <div class="col-sm-9">
      <asp:DropDownList ID="ExamTypeList" CssClass="form-control" runat="server" >
        <asp:ListItem Text="Select Option" Value=""></asp:ListItem>
        <asp:ListItem Text="Mid" Value="Mid"></asp:ListItem>
        <asp:ListItem Text="Final" Value="Final"></asp:ListItem>
        
    </asp:DropDownList>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="" ControlToValidate="ExamTypeList"
          CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Type" />
    </div>
  </div>
      <br /><br /><br />
         <div class="form-group">
    <label class="col-sm-3 control-label">Starting Time</label>
             
             <div class="col-sm-9">
            <asp:TextBox ID="StartTime"  CssClass="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="" ControlToValidate="StartTime"
          CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Enter Time" />
                 </div>
  </div>
        <br /><br /><br />
                <div class="form-group">
    <label class="col-sm-3 control-label">Ending Time</label>
             
                    <div class="col-sm-9">
            <asp:TextBox ID="EndTime"  CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="" ControlToValidate="EndTime"
          CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Enter Ending Time" />
                        </div>
  </div>
        <br /><br />
               <br />

                     <div class="form-group">
    <label class="col-sm-3 control-label">Date Of Exam</label>
             
                    <div class="col-sm-9">
            <%--<asp:TextBox ID="Datetxt"  CssClass="form-control" runat="server"></asp:TextBox>--%>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="" ControlToValidate="Datetxt"--%>
          <%--CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Enter Ending Time" />--%>
                      <label>Date:</label>
                        <asp:DropDownList runat="server" ID="dropdownDate">
                           
                       </asp:DropDownList>
                        <label>Month:</label>
                        <asp:DropDownList runat="server" ID="DropDownMonth">
                           
                       </asp:DropDownList>
                        
                         </div>
  </div>
        <br /><br />
               <br />
         <div class="form-group">
             <label class="col-sm-3 control-label"></label>
             <div class="col-sm-9">
      <asp:Button ID="DateSheetBtn" CssClass="btn btn-brown btn-block" ValidationGroup="addProgramme" runat="server" Text="Create" OnClick="DateSheetBtn_Click" />
      
      <br />
      <span runat="server" id="Span2"  ></span>
      <br />
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
                window.location = "updateDateSheet.aspx?Datesheetid=" + id + "&action=" + action;

            });



        })
    </script>
</asp:Content>

