<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ManageCourses.aspx.cs" Inherits="Default2" %>

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
        <div class="panel-heading" ">Manage Courses</div>
        <div class="panel-body">
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p></div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-responsive "><tr class="blue-background"><th>Course</th><th>Course Code</th><th>Credit Hours</th><th>Course Fee</th><th>Total Marks</th><th>Programmes</th><th>Action</th></tr>
                        <asp:Label ID="programstbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                        <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalPaging" ></asp:Literal>
                            </ul>
                            </div>
                        <br />
                        <br />
                        <div class="col-sm-12 clearfix">
                        <div style="float:right;margin-right:10px">
                            <a class="btn btn-default" id="createcourse">Create Course</a>
                        </div>
                            <div style="float:right;margin-right:10px">
                             <asp:Button CssClass="btn btn-info" ID="dashboardbtn" runat="server" OnClick="dashboardbtn_Click" Text="Go To Dashboard" />
                        </div>
                            </div>
                        </div>

                    <br />
                    <br />


            <div id="nameDiv" runat="server"  class="crsform hide">
                
                <asp:Label ID="messagae" runat="server" Visible="false"></asp:Label>
          <div class="row ">
              <div class="col-lg-12">
              
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Course:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="coursename" placeholder="Please enter your Course Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="coursename" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Course Name" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
                      <div class="form-group">
               <label class="col-sm-3 control-label">Course Code: </label>
              <div class="col-sm-9">
                                     <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="CourseCode" placeholder="Please enter  Course Code"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="CourseCode" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Course Code" />
                 
               </div>
             
             </div>
               <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Fee:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Feetxt" placeholder="Please enter your Course Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="Feetxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Course Name" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Total Marks:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Markstxt" placeholder="Please enter  Total Marks"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                                     Display="Dynamic" runat="server" ControlToValidate="Markstxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Total Marks" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />

             
                <div class="form-group">
               <label class="col-sm-3 control-label">Credit Hours: </label>
              <div class="col-sm-9">
                                     <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="CreditHours" placeholder="Please enter  Credit Hours"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="CreditHours" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Credit Hours" />
                 
               </div>
             
             </div>
               <br />
               <br />
                <br />
                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Select Programs:</label>
                                    <div class="col-sm-9">
                                        <asp:CheckBoxList ID="CheckBoxPrgramlist" RepeatDirection="Horizontal" CssClass="prgmcheckbox" runat="server"></asp:CheckBoxList>
                              <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="" ControlToValidate="CheckBoxPrgramlist"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Second Choice Option" />      
                             --%>       </div>
            </div>
              <br />
              <br />
               <br />

           
               <div class="form-group" style="text-align:center">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnaddprogramme" ValidationGroup="addprogramme" Text="Create Course" runat="server" OnClick="btnaddprogramme_Click" />
                                     
                                    </div>
            </div>
                  <br />
                  <br />
                  <br />
                  </div>
          </div>
                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </div>
    

    <script type="text/javascript">
        function showHide_Div() {
            //$("#nameDiv").attr("class","show");
           
            if ($("#nameDiv" ).attr("class") == "hide") {
                $("#nameDiv" ).attr("class", "show");
            }
            if ($("#nameDiv").attr("class") == "hide") {
                $("#nameDiv").attr("class", "show");
            }
        }

        $(function () {
            $("#createcourse").click(function () {
                
                if ($(".crsform").attr("class").indexOf("hide")>0) {
                    $(".crsform").attr("class", "crsform show");
                }
                else if ($(".crsform").attr("class").indexOf("show") > 0) {
                    $(".crsform").attr("class", "crsform hide");
                }
                //alert($("#nameDiv").show());

            });
            $(".btn-action").click(function () {

                var action = $(this).attr("class").split(" ")[3];
                var id = $(this).data("id");

                if (action == "Disable" || action == "Enable") {
                    var res = confirm("Are You Sure? Press OK to continue.....")
                    if (res == false)
                        return;
                }
                window.location = "updateCourse.aspx?Courseid=" + id + "&action=" + action;

            });



        })
    </script>
</asp:Content>

