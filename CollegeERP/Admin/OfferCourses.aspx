<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="OfferCourses.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link href="../css/bootstrap-toggle.min.css" rel="stylesheet" />
    <div class="panel panel-default">
        <div class="panel-heading" >Enroll Courses:</div>
        <div class="panel-body">
            
          <div class="row">
              <div class="col-sm-12">

                  <div class="form-group">

                      <label class="col-sm-3 control-label">Select Prrogramme:</label>

                     
                                    
                                       <div class="col-sm-9">
                  <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ClientIDMode="Static" AutoPostBack="true" ID="Programlist" OnSelectedIndexChanged="Programlist_SelectedIndexChanged">
                                     <asp:ListItem Text="Select Programme" Value=""></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" InitialValue="" ControlToValidate="Programlist"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Programme" />      
               </div>
                           
                              



                  </div>

                  <br />
                  <br />
                  <br />
                           <div class="form-group">

                      <label class="col-sm-3 control-label">Select Batch:</label>

                       
                                    
                                       <div class="col-sm-9">
                  <asp:DropDownList AppendDataBoundItems="true" ClientIDMode="Static" CssClass="form-control" runat="server" ID="Batchlist">
                                     <asp:ListItem Text="Select Batch" Value=""></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="" ControlToValidate="Batchlist"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Batch" />      
               </div>
                           
                                  



                  </div>

                          <br />
                  <br />
                  <br />
                           <div class="form-group">

                      <label class="col-sm-3 control-label">Select Semester:</label>

                       
                                    
                                       <div class="col-sm-9">
                  <asp:DropDownList CssClass="form-control" ClientIDMode="Static" runat="server" ID="Semesterlist">
                                  <asp:ListItem Text="Select Programme First" Value=""></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="" ControlToValidate="Semesterlist"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Semester" />      
               </div>
                           
                                  



                  </div>
                  <br />
                  <br />
                  <br />
                   <div class="form-group" style="text-align:center">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ValidationGroup="addProgramme" ID="btnsubmit" Text="Submit" runat="server" OnClick="btnsubmit_Click" />
                                     
                                    </div>
            </div>
                  <br />
                  <br />
                  <br />
              </div>



              </div>

              <div class="row">
              <div class="col-sm-12">

                    <table class="table table-responsive "><tr class="blue-background"><th>Course</th><th>Course Fee</th><th>Total Marks</th><th>Credit Hours</th><th>Action</th></tr>
                        <asp:Label ID="coursestbl" runat="server" Text=""></asp:Label>
                                </table>
                      <div class="form-group" style="text-align:center">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9">
                                 
                                        <a Class="btn btn-block btn-primary  offercourse"   id="offercourse" runat="server" visible="false">Offer Selected Courses</a>
                                     
                                    </div>
            </div>
                  </div>
                  </div>
            </div>
        </div>
        <script src="../js/bootstrap-toggle.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(".offercourse").click(function () {

            var batch = $("#Batchlist").val();
            var prgram = $("#Programlist").val();
            var offercourses = new Array();
            var i=0;
            var semester = $("#Semesterlist").val();
            $('#corsesdiv input:checked').each(function () {
                offercourses[i] = $(this).data("id");
                i++;
            });

            $.ajax({
                type: "POST",
                url: "OfferCourses.aspx/Offercourses",
                data: JSON.stringify({ courses: offercourses, semester: semester, batch: batch,progid:prgram }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    alert(response.d);
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

    </script>
</asp:Content>

