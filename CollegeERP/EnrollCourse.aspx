<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EnrollCourse.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading" >Enroll Courses:</div>
        <div class="panel-body">
            
          <div class="row">
             
              <asp:Label runat="server" ID="Heading" CssClass="heading-desc col-md-12 text-center"></asp:Label>
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
                              <asp:ListItem Text="New" Value="New"></asp:ListItem>
              </asp:DropDownList>  
                     </div>
                      <br /><br /><br />              
                  <div class="col-sm-12">
                                    <table class="table table-responsive">
                                        <tr class="blue-background" align="center"><th>Course</th><th>Max Marks</th><th>Course Fee</th><th>Student Level</th><th> Semester</th><th></th></tr>
                   <asp:Label ID="coursetablelbl" runat="server" ></asp:Label>                     
                   
                                        </table>
                                        </div>
                      <div class="col-sm-12">
                          <div class="col-sm-9">

                          </div>
                          <div class="col-sm-3">
                              <strong>Total Credits : </strong><label id="TotalCredits"></label><br /><br />
                              <strong>Selected Credits : </strong><label id="SelectedCredits"></label>
                              <button id="Submit" class="btn btn-primary btn-block" onclick="SubmitCources();">Submit</button>
                          </div>
                      </div>
                      </ContentTemplate>
                  </asp:UpdatePanel>
          
                  

              </div>
            </div>
        </div>
    <script type="text/javascript">
        var TotalSelected = parseInt('<%=Credits%>');
        alert(TotalSelected)
        var AllowedCredits = 18;
        var CourcesArray = new Array();
        $(document).ready(function () {
           

                document.getElementById("TotalCredits").textContent = AllowedCredits;
                document.getElementById("SelectedCredits").textContent = TotalSelected;
            
           
        });
        $(function () {

            $(document).on("click", ".enroll", function () {
               
            var courseid = $(this).data("courseid");
            if (document.getElementById("Check_" + courseid).textContent == "Enroll")
            {
                var CreditHour = $(this).data("credithours");
                if (TotalSelected + CreditHour > AllowedCredits) {
               
                   
                    alert("Limit exceeded");
                }
                else {
                    CourcesArray.push(courseid);
                    document.getElementById("Check_" + courseid).textContent = "Selected";
                    document.getElementById("Check_" + courseid).style.backgroundColor = "green";
                    TotalSelected = TotalSelected + CreditHour;
                }
            }
            else if (document.getElementById("Check_"+courseid).textContent == "Selected")
            {
               
                var courseid = $(this).data("courseid");
                var CreditHour = $(this).data("credithours");
                for(var i=0;i<CourcesArray.length;i++)
                {
                    if(Array.indexOf(CourcesArray,courseid)>-1)
                    {
                        CourcesArray.splice(i, 1);
                    }
                }
                TotalSelected = TotalSelected - CreditHour;
                document.getElementById("Check_"+ courseid).textContent = "Enroll";
                document.getElementById("Check_"+ courseid).style.backgroundColor = "#337ab7";
            }
            else if (document.getElementById("Check_" + courseid).textContent == "ReEnroll") {
                var CreditHour = $(this).data("credithours");
                alert(CreditHour)
                if (TotalSelected + CreditHour > AllowedCredits) {


                    alert("Limit exceeded");
                }
                else {
                    CourcesArray.push(courseid);
                    document.getElementById("Check_" + courseid).textContent = "Selected";
                    document.getElementById("Check_" + courseid).style.backgroundColor = "green";
                    TotalSelected = TotalSelected + CreditHour;
                }
            }
            document.getElementById("TotalCredits").textContent = AllowedCredits;
            document.getElementById("SelectedCredits").textContent = TotalSelected;
                
        })
        })
        function SubmitCources()
        {
            
            if (TotalSelected <= AllowedCredits) {

                $.ajax({
                    type: "POST",
                    url: "EnrollCourse.aspx/EnrollCourse",
                    data:JSON.stringify({ cid: CourcesArray,credithours:TotalSelected }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "text",
                    success: function (response) {
                        window.location = "EnrollCourse.aspx";
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
            }
        }
    </script>
</asp:Content>

