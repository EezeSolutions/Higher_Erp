<%@ Page Title="" Language="C#" MasterPageFile="~/Employees/MasterPage.master" AutoEventWireup="true" CodeFile="Attendance.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../css/bootstrap-toggle.min.css" rel="stylesheet" />
    <div class="panel panel-default">
        <div class="panel-heading">Add Attendance</div>
        <div class="panel-body">
          <div class="row">
              <div class="col-sm-3">
                  <label class="label">Select Course</label>
              </div>
              <div class="col-sm-9">
                  <asp:DropDownList ID="Dropdowncrs" ClientIDMode="Static" runat="server" OnSelectedIndexChanged="Dropdowncrs_SelectedIndexChanged" AutoPostBack="true">


                  </asp:DropDownList>
              </div>

              <table class="table table-responsive">
                  <asp:Label ID="studentslbl" runat="server"></asp:Label>

              </table>
               <div class="col-sm-3">
                  <label class="label"></label>
              </div>
              <div class="col-sm-9 ">
              <a  ID="BtnSumit"   Class="btn btn-primary btn-block">Submit</a>
              </div>
              </div>
            </div>
        </div>
    <script src="../js/bootstrap-toggle.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(document).on("click", "#BtnSumit", function () {
                var count = <%=this.studetncount%>
             //   alert(count)
                var atd = new Array();
                var stdid = new Array();
                var courseid = $("#Dropdowncrs").val();
               
                for (var i = 0; i < count; i++)
                {
                    atd[i] = $("#attendance" + i + ":checked").length;
                 //   alert($("#attendance" + i).data("stdid"));
                    
                    stdid[i] = ($("#attendance" + i).data("stdid"));
                }
               
                $.ajax({
                    type: "POST",
                    url: "Attendance.aspx/AddAttendance",
                    data: JSON.stringify({ student: stdid, attendance: atd, courseid: courseid }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        alert("Attendance Successfuly Entered..!!")
                   //     alert(response.d);
                    },
                    failure: function (response) {
                        tagimgLoad.style.display = "none";
                        alert(response.d);
                    },
                    error: function (response) {
                        tagimgLoad.style.display = "none";
                        alert(response.d);
                    }
                });


            })

        })

    </script>
</asp:Content>

