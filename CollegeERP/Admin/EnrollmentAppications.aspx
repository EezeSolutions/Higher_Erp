<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="EnrollmentAppications.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading" >Enroll Courses:</div>
        <div class="panel-body">
            
          <div class="row">
             
              <asp:Label runat="server" ID="Heading" CssClass="heading-desc col-md-12 text-center" Text="Enrollment Applcations"></asp:Label>
                              <br />
                               <br /> 
                                <br />  
              <br /> 
              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
             <div class="col-sm-2" style="float:right;height:40px">
                       <asp:DropDownList Height="30px" runat="server" ID="dropdownstatus" OnSelectedIndexChanged="dropdownstatus_SelectedIndexChanged" AutoPostBack="true">
                  <asp:ListItem Text="All" Value="All"></asp:ListItem>
                  <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Rejected" Value="-1"></asp:ListItem>
                  <asp:ListItem Text="Enrolled" Value="1"></asp:ListItem>
              </asp:DropDownList>  
                     </div>
                      <br /><br /><br />
                  <div class="col-sm-12">
                                    <table class="table table-responsive">
                                        <tr class="blue-background" align="center"><th>Course</th><th>Max Marks</th><th>Course Fee</th><th>Credit hours</th><th>Student Name</th><th>Metric#</th><th></th></tr>
                   <asp:Label ID="coursetablelbl" runat="server" ></asp:Label>                     
                  
                                        </table>
                                        </div>
           </ContentTemplate>
                      </asp:UpdatePanel>
                  

              </div>
            </div>
        </div>
    <script type="text/javascript">
        $(function () {
            $(document).on("click",".enroll",function () {

                var appid = $(this).data("appid").split(',')[0];
                var status = $(this).data("appid").split(',')[1];;

              
             //   alert(appid);
                $.ajax({
                    type: "POST",
                    url: "EnrollmentAppications.aspx/Enroll",
                    data: '{appid: ' + appid + ',status: ' + status + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        window.location = "EnrollmentAppications.aspx";
                    },
                    failure: function (response) {
                        //tagimgLoad.style.display = "none";
                        alert(response.d);
                    },
                    error: function (response) {
                        // tagimgLoad.style.display = "none";
                        alert(response.d);
                    }
                });


            })


        })

    </script>
</asp:Content>

