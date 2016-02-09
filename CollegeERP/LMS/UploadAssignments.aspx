<%@ Page Title="" Language="C#" MasterPageFile="~/LMS/MasterPage.master" AutoEventWireup="true" CodeFile="UploadAssignments.aspx.cs" Inherits="LMS_Default" %>

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
.btn-action{
    padding:5px;
    font-size:9px;
}
.calendericon{
    background-image:url("../images/icon-calendar-blue.png")  ;
    background-repeat:no-repeat;
    background-size:30px 30px;
    width:33px;
}
.calenderpadding
{
    margin-top:3px;

}
</style>

            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

<div id="UpdateModal" tabindex="-1" class="modal fade" role="dialog">

        
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content"  role="document">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Update Assignment</h4>
      </div>
      <div class="modal-body clearfix">
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Assignment Title:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Updateasgmttitle" placeholder="Please enter your Assignment Title"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                                     Display="Dynamic" runat="server" ControlToValidate="Updateasgmttitle" ValidationGroup="updateassignment" CssClass="field-validation-error" ErrorMessage="Please enter Assignment title" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
           <input type="hidden" id="duedateupdatelbl" class="duedateupdatelbl"  runat="server"   />
          <asp:UpdatePanel ID="update5" runat="server"><ContentTemplate>
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Due Date:</label>
                   <div class="col-sm-3">
                                   
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Assgnmentduedatetext" placeholder="Please enter your Assignment Title"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="Assgnmentduedatetext" ValidationGroup="updateassignment" CssClass="field-validation-error" ErrorMessage="Please enter Assignment title" />
                                    
                              <br />
                                    </div>
                        <div class="col-cm-2"> 
                       <asp:Button ID="changedatebtn" runat="server"  Text="" CssClass="btn btn-default calendericon " OnClick="changedatebtn_Click" />
                                    </div>    


                                    <div class="col-sm-5" id="Assgnmentduedatediv">
                                    
                                        <asp:Calendar ID="Assgnmentduedate" TitleStyle-BackColor="#2ECCFA" TitleStyle-ForeColor="White" BorderColor="#2ECCFA" NextPrevStyle-BackColor="#2ECCFA" NextPrevStyle-ForeColor="White" SelectedDayStyle-BackColor="#2ECCFA" TitleStyle-Height="20px" TitleStyle-CssClass="calenderpadding" Visible="false" ClientIDMode="Static" runat="server"></asp:Calendar>
                                    </div>
            </div>
            
              </ContentTemplate></asp:UpdatePanel>
            <div class="form-group">
                                    <label class="col-sm-12 control-label"></label>
                </div>
             
         
               <div class="form-group" style="margin-bottom:10px">
                                    <label class="col-sm-3 control-label">Assignment Marks:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="updateasgmtmarks" placeholder="Please enter  Total Marks"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator12"
                                     Display="Dynamic" runat="server" ControlToValidate="updateasgmtmarks" ValidationGroup="updateassignment" CssClass="field-validation-error" ErrorMessage="Please enter Total Marks" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
       
            
              <div class="form-group">
                                    <label class="col-sm-3 control-label"></label>
                  <div class="col-sm-9">
          <asp:FileUpload ID="FileAssignmentupdate" runat="server" /> 
                      </div>
                  </div>
      </div>
      <div class="modal-footer">
        
<asp:Label ID="asgmtid" runat="server" Visible="false" ClientIDMode="Static"></asp:Label>
          <asp:Button ID="UpdateAsignment" class="btn btn-primary" runat="server" ValidationGroup="updateassignment" OnClick="UpdateAsignment_Click" Text="Submit" />
            
        <button type="button" class="btn btn-default close-updateform" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>


    <div id="UploadResultAsssignment" tabindex="-1" class="modal fade" role="dialog">

        
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content"  role="document">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Upload Assignment Result</h4>
      </div>
              <asp:Label ID="errorassignmentresult" runat="server" CssClass="col-lg-offset-5 col-lg-7" ForeColor="Red" ClientIDMode="Static" Text=""></asp:Label>

      <div class="modal-body">
          <asp:FileUpload ID="AssignmentResultUplaod" ClientIDMode="Static" runat="server" /> 
      </div>
      <div class="modal-footer">
        
<asp:Label ID="Label1" runat="server" Visible="false" ClientIDMode="Static"></asp:Label>
          <asp:Button ID="UplaodAsgmtresult" class="btn btn-primary" ClientIDMode="Static" runat="server" OnClick="UplaodAsgmtresult_Click" Text="Submit" />
            
        <button type="button" class="btn btn-default " data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>

    <div id="ekkoLightbox-player" class="ekko-lightbox modal fade in" tabindex="-1" aria-hidden="true" style="display: none; padding-right: 17px;"><div class="modal-dialog" style="width: auto; max-width: 592px;"><div class="modal-content"><div class="modal-header"> <button type="button" class="close close-player" data-dismiss="ekkoLightbox-player" aria-hidden="true">×</button><h4 class="modal-title video-title-modal">Title</h4></div><div class="modal-body"><div class="ekko-lightbox-container"><div><div class="embed-responsive embed-responsive-16by9"><video id="videoplayer" width="320" height="240" controls>
  <source id="player"  type="video/mp4">
 
Your browser does not support the video tag.
</video></div></div></div></div><div class="modal-footer" style="display:none">null</div></div></div></div>
 <div class="panel panel-default">
        <div class="panel-heading" ">Learning Management System</div>
        <div class="panel-body">
           
              

        <div class="col-sm-12">          


     
     
   <div class="panel panel-default col-sm-12 " padding: 10px; margin: 10px">
    <div id="Tabs" role="tabpanel">
        <!-- Nav tabs -->
        <ul class="nav nav-tabs" role="tablist">
            <%--<li class="active"><a href="#Attendance" aria-controls="Attendance" role="tab" data-toggle="tab">Attendance</a></li>
            <li ><a href="#result" aria-controls="result" role="tab" data-toggle="tab">
                Result</a></li>
            
            <li><a href="#books" aria-controls="books" role="tab" data-toggle="tab">Books</a></li>
            <li><a href="#lectures" aria-controls="lectures" role="tab" data-toggle="tab">Lectures</a></li>--%>
            <li class="active"><a href="#assignments" aria-controls="assignments" role="tab" data-toggle="tab">Assignments</a></li>
            <li><a href="#quizz" aria-controls="quizz" role="tab" data-toggle="tab">Quizzes</a></li>
            <li><a href="#videos" aria-controls="videos" role="tab" data-toggle="tab">Video Lectures</a></li>
            <li><a href="#Lectures" aria-controls="Lectures" role="tab" data-toggle="tab"> Lectures</a></li>
            <li><a href="#books" aria-controls="books" role="tab" data-toggle="tab">Books</a></li>

        </ul></div>
        <!-- Tab panes -->
        <div class="tab-content" style="padding-top: 20px">
           
            <div role="tabpanel" class="tab-pane active" id="assignments">
                <div class="row">
                 <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Assignment Title</th><th>Assignment Marks</th><th>File</th><th>Date</th><th>Action</th></tr>
                        <asp:Label ID="assignmentLable" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalPaging" ></asp:Literal>
                            </ul>
                            </div>
                <div class="col-sm-12">
                        <div style="float:right">
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Add Assignment</a>
                        </div></div>
                            </div><br /><br />


                <div id="nameDiv" class="hide">
                
          <div class="row ">
              
              <asp:Label ID="errormessageassignment" runat="server" CssClass="col-lg-offset-5 col-lg-7" ForeColor="Red" ClientIDMode="Static" Text=""></asp:Label>
              <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Assignment Title:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="AssignmentTitle" placeholder="Please enter your Assignment Title"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="AssignmentTitle" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Assignment title" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                   <asp:UpdatePanel ID="update4" runat="server"><ContentTemplate>
                                    <label class="col-sm-3 control-label">Due Date:</label>
                                    <div class="col-sm-9">
                                        <asp:Calendar ID="DueDate" TitleStyle-BackColor="#2ECCFA" TitleStyle-ForeColor="White" BorderColor="#2ECCFA" NextPrevStyle-BackColor="#2ECCFA" NextPrevStyle-ForeColor="White" SelectedDayStyle-BackColor="#2ECCFA" TitleStyle-Height="20px" TitleStyle-CssClass="calenderpadding" runat="server"></asp:Calendar>
                                    </div>
                       </ContentTemplate></asp:UpdatePanel>
            </div>
                <br />
               <br />
                <br />



              <div class="form-group">
                  <label class="col-sm-3 control-label"></label>
                  <div class="col-sm-9">
                  <br />
                      </div>
                  </div>


               <div class="form-group">
                                    <label class="col-sm-3 control-label">Assignment Marks:</label>
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
                  <label class="col-sm-3 control-label"></label>
                  <div class="col-sm-9">
                  <br />
                      </div>
                  </div>

             <div class="form-group">
                                    <label class="col-sm-3 control-label">Upload Assignment:</label>
                                    <div class="col-sm-9">
                                    
                                    <asp:FileUpload ID="AssignmentUpload" ClientIDMode="Static" runat="server"></asp:FileUpload>
                                    </div>
            </div>
              <br />
               <br />
                <br />
              
             <div class="form-group">
                  <label class="col-sm-3 control-label"></label>
                  <div class="col-sm-9">
                  <br />
                      </div>
                  </div>

           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="uploadAssignment" ClientIDMode="Static" Text="Upload" runat="server" ValidationGroup="addprogramme" OnClick="uploadAssignment_Click" />
                                     
                                    </div>

            </div><br /><br /><br />
          </div>
                </div>

            </div>

             <%--<div role="tabpanel" class="tab-pane " id="result">--%>
                
                 
                      <%--  <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Course Title</th><th>Obtained Marks</th><th>Total Marks</th><th>Session</th><th>Action</th></tr>
                        <asp:Label ID="programstbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                        
                       
                        
                      


            </div>--%>

<%--             <div role="tabpanel" class="tab-pane" id="books">
               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Course Title</th><th>Attendance</th><th>Date</th><th>Action</th></tr>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
            </div>--%>

           <%-- <div role="tabpanel" class="tab-pane" id="lectures">
               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Course Title</th><th>Attendance</th><th>Date</th><th>Action</th></tr>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
            </div>--%>


           <%-- <div role="tabpanel" class="tab-pane" id="Attendance">
               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Course Title</th><th>Due Date</th><th>Attendance</th><th>Action</th></tr>
                        <asp:Label ID="attendancelbl" runat="server" Text="">

                        </asp:Label>
                                </table>
                            
                            
                
           </div>
                
                    </div>--%>


            <div role="tabpanel" class="tab-pane" id="videos">
                 <div class="col-sm-12">
                        <div style="float:right">
                            

                            <a class="btn btn-default" onclick="showHide_Div('VideosDiv');">Upload Lecture</a>
                        </div></div>
                            <br /><br />

                 <br /><br /> <br /><br />
                <div id="VideosDiv" class="hide">
                


          <div class="row ">
                            <asp:Label ID="errorvideo" runat="server" CssClass="col-lg-offset-5 col-lg-7" ForeColor="Red" ClientIDMode="Static" Text=""></asp:Label>

            
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Video Title:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="videoTitle" placeholder="Please enter your Video Title"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="videoTitle" ValidationGroup="addvideo" CssClass="field-validation-error" ErrorMessage="Please enter Video title" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />

                <div class="form-group">
                                    <label class="col-sm-3 control-label">Description:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" TextMode="MultiLine" Height="100px" CssClass="form-control" runat="server" ID="Description" placeholder="Please enter Description"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="Description" ValidationGroup="addvideo" CssClass="field-validation-error" ErrorMessage="Please enter Description" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
              <br />
              <br />   <br />
              <br />
              <br />
              <br />
                 <div class="form-group">
                                    <label class="col-sm-3 control-label">Upload Video:</label>
                                    <div class="col-sm-9">
                                    
                                    <asp:FileUpload ID="Videoupload" ClientIDMode="Static" runat="server"></asp:FileUpload>
                                    </div>
            </div>
              <br />
               <br />
                <br />
             
    
               
           
              
             

           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ClientIDMode="Static" ID="Uploadvideobtn" ValidationGroup="addvideo" Text="Upload" runat="server" OnClick="Uploadvideobtn_Click" />
                                     
                                    </div>

            </div>
              <br /><br /><br />
                     
          </div>
                </div>
                 <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalVideostart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalVideoEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalvideototal"></asp:Literal><span> results</span></p>

               <div class="col-sm-12">


                           <div class="well well-sm">
        <strong>Category Title</strong>
        <div class="btn-group">
            <a href="#" id="list" class="btn btn-default btn-sm"><span class="glyphicon glyphicon-th-list">
            </span>List</a> <a href="#" id="grid" class="btn btn-default btn-sm"><span
                class="glyphicon glyphicon-th"></span>Grid</a>
        </div>
    </div>

    <div id="products" class="row list-group">
                   <asp:Literal  ID="videolbl" runat="server"></asp:Literal>
    <%--    <div class="item  col-xs-4 col-lg-4">
            <div class="thumbnail">
                <img class="group list-group-image" src="http://placehold.it/400x250/000/fff" alt="" />
                <div class="caption">
                    <h4 class="group inner list-group-item-heading">
                        Product title</h4>
                    <p class="group inner list-group-item-text">
                        Product description... Lorem ipsum dolor sit amet, consectetuer adipiscing elit,
                        sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
                    <div class="row">
                        
                        
                    </div>
                </div>
            </div>
        </div>--%>

     
    </div>

                    <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalvideopaging" ></asp:Literal>
                            </ul>
                            </div>
                  </div>
            </div>
       
            <div role="tabpanel" class="tab-pane" id="quizz">
                <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="quizzstart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="quizzEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="quizztotal"></asp:Literal><span> results</span></p>
              
               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Course Title</th><th>Quizz #</th><th>Total Marks</th><th>Date</th><th>Action</th></tr>
                        <asp:Label ID="QuizzLabel" runat="server" Text=""></asp:Label>
                                </table>
                            </div>


                <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="quizzpaging" ></asp:Literal>
                            </ul>
                            </div>
                <div class="col-sm-12">
                        <div style="float:right">
                            <a class="btn btn-default" onclick="showHide_Div('quizzDiv');">Add Quizz</a>
                        </div><br /> <br /> <br />
                      


                <div id="quizzDiv" class="hide">
                
          <div class="row ">
                            <asp:Label ID="errorquiz" runat="server" CssClass="col-lg-offset-5 col-lg-7" ForeColor="Red" ClientIDMode="Static" Text=""></asp:Label>

            
              <div class="form-group">
                                    <label class="col-sm-3 control-label">Quizz Title:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="quizzTitle" placeholder="Please enter Quizz Title"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                     Display="Dynamic" runat="server" ControlToValidate="quizzTitle" ValidationGroup="addquizz" CssClass="field-validation-error" ErrorMessage="Please enter Quizz Title" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
              
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Total Marks:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="quizzmarks" placeholder="Please enter Total Marks"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                     Display="Dynamic" runat="server" ControlToValidate="quizzmarks" ValidationGroup="addquizz" CssClass="field-validation-error" ErrorMessage="Please enter Total Marks" />
                                    
                                    </div>
            </div>
                <br />
               <br />
             
               <asp:UpdatePanel ID="updatepanel3" runat="server"><ContentTemplate>
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Quizz Date:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:Calendar ID="QuizzCalendar" TitleStyle-BackColor="#2ECCFA" TitleStyle-ForeColor="White" BorderColor="#2ECCFA" NextPrevStyle-BackColor="#2ECCFA" NextPrevStyle-ForeColor="White" SelectedDayStyle-BackColor="#2ECCFA" TitleStyle-Height="20px" TitleStyle-CssClass="calenderpadding" runat="server"></asp:Calendar>
                                    
                                    </div>
            </div>
                   </ContentTemplate>
                   </asp:UpdatePanel>
               <div class="form-group"><div class="col-lg-12"><br /></div></div>
             
            
             <div class="form-group">
                                    <label class="col-sm-3 control-label">Upload Result:</label>
                                    <div class="col-sm-9">
                                    
                                    <asp:FileUpload ID="QuizzUpload" ClientIDMode="Static" runat="server"></asp:FileUpload>
                                    </div>
            </div>
              <br />
               <br />
                
              <div class="form-group">
                  <label class="col-sm-3 control-label"></label>
                  <div class="col-sm-9">
                  <br />
                      </div>
                  </div>
             

           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ClientIDMode="Static" ID="Quizzbtn" ValidationGroup="addquizz" Text="Upload" runat="server" OnClick="Quizzbtn_Click" />
                                     
                                    </div>

            </div></div><br />
          </div>
                </div></div><br /><br />
            






            <div role="tabpanel" class="tab-pane" id="Lectures" >
               <div class="row">
                 <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="lecturestart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="lectureEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="lecturetotal"></asp:Literal><span> results</span></p>
               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Lecture Title</th><th>Course</th><th>Lecture</th><th>Lecture Date</th></tr>
                        <asp:Label ID="lecturelbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                   
                <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="lecturePaging" ></asp:Literal>
                            </ul>
                            </div>
                       
                <div class="col-sm-12">
                        <div style="float:right">
                            <a class="btn btn-default" onclick="showHide_Div('LecturesDiv');">Upload Lecture</a>
                        </div></div>
                            </div><br /><br />


                <div id="LecturesDiv" class="hide">
                
          <div class="row ">

                            <asp:Label ID="errorlecture" runat="server" CssClass="col-lg-offset-5 col-lg-7" ForeColor="Red" ClientIDMode="Static" Text=""></asp:Label>
            
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Lecture Title:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="LectureTitle" placeholder="Please enter your Lecture Title"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="LectureTitle" ValidationGroup="addlecture" CssClass="field-validation-error" ErrorMessage="Please enter Lecture title" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
                 <div class="form-group">
                                    <label class="col-sm-3 control-label">Upload Lecture:</label>
                                    <div class="col-sm-9">
                                    
                                    <asp:FileUpload ID="LectureUpload" ClientIDMode="Static" runat="server"></asp:FileUpload>
                                    </div>
            </div>
              <br />
               <br />
                <br />
              
                                        <asp:updatepanel id="UpdatePanel1" runat="server"><ContentTemplate>
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Lecture Date:</label>
                                    <div class="col-sm-9">
                                        
                                        <asp:Calendar ID="Calendar1" TitleStyle-BackColor="#2ECCFA" TitleStyle-ForeColor="White" BorderColor="#2ECCFA" NextPrevStyle-BackColor="#2ECCFA" NextPrevStyle-ForeColor="White" SelectedDayStyle-BackColor="#2ECCFA" TitleStyle-Height="20px" TitleStyle-CssClass="calenderpadding" runat="server"></asp:Calendar>
                                           
                                        <%--<asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="TextBox1" placeholder="Please enter your Lecture Title"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="LectureTitle" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Lecture title" />
                                    --%>
                                    </div>
            </div>
                <br />
               <br />
                <br />
               
           <br /><br /><br /><br /><br /><br />
              
             
</ContentTemplate>
                                            </asp:updatepanel>
           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ClientIDMode="Static" ID="lectureouploadbtn" ValidationGroup="addlecture" Text="Upload" runat="server" OnClick="lectureouploadbtn_Click" />
                                     
                                    </div>

            </div>
              <br /><br /><br />
                     
          </div>
                </div>
            </div>




                <div role="tabpanel" class="tab-pane" id="books" >
               <div class="row">
                 <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="bookstart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="bookEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="booktotal"></asp:Literal><span> results</span></p>
               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Book Title</th><th>Course</th><th>Book File</th><th>Description</th></tr>
                        <asp:Label ID="bookLabel" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="bookpaging" ></asp:Literal>
                            </ul>
                            </div>
                <div class="col-sm-12">
                        <div style="float:right">
                            <a class="btn btn-default" onclick="showHide_Div('BooksDiv');">Upload Book</a>
                        </div></div>
                            </div><br /><br />


                <div id="BooksDiv" class="hide">
                
          <div class="row ">

              <asp:Label ID="errorbook" runat="server" CssClass="col-lg-offset-5 col-lg-7" ForeColor="Red" ClientIDMode="Static" Text=""></asp:Label>
            
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Reference Book Title:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="bookTitle" placeholder="Please enter your Book Title"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                     Display="Dynamic" runat="server" ControlToValidate="bookTitle" ValidationGroup="addbook" CssClass="field-validation-error" ErrorMessage="Please enter Book title" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
                 <div class="form-group">
                                    <label class="col-sm-3 control-label">Upload Book:</label>
                                    <div class="col-sm-9">
                                    
                                    <asp:FileUpload ID="BookUpload" ClientIDMode="Static" runat="server"></asp:FileUpload>
                                    </div>
            </div>
              <br />
               <br />
                <br />
              <div class="form-group">
                                    <label class="col-sm-3 control-label">Book Description:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" TextMode="MultiLine" CssClass="form-control" runat="server" ID="bookdescription" placeholder="Please enter Description"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                     Display="Dynamic" runat="server" ControlToValidate="bookdescription" ValidationGroup="addbook" CssClass="field-validation-error" ErrorMessage="Please enter Description" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
              <br />
               <br />
                
              
                                     
           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ClientIDMode="Static" ID="BookUploadBtn" ValidationGroup="addbook" Text="Upload" runat="server" OnClick="BookUploadBtn_Click" />
                                     
                                    </div>

            </div>
              <br /><br /><br />
                     
          </div>
                </div>
            </div>




<input type="hidden" class="currenttab" runat="server" id="ctab" />
        </div>
    </div>
</div>
           </div>  
                         
            </div>
        </div>


    <script src="//code.jquery.com/jquery.js"></script>
		<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
		<script src="//cdnjs.cloudflare.com/ajax/libs/ekko-lightbox/3.3.0/ekko-lightbox.min.js"></script>
     <%--<script src="../js/bootstrap.min.js"></script>--%>
    <%--<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/ekko-lightbox/3.3.0/ekko-lightbox.min.js"></script>--%>
<%--<script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>--%>
    <script type="text/javascript">
        function showHide_Div(tag) {
            var tagitem = document.getElementById(tag);

            if (tagitem.className == "hide") {
                tagitem.className = "show";
            }
            else { tagitem.className = "hide"; }
        }
        $(function () {

            var currtab =  getUrlVars()["tab"];
            //alert(currtab)
           
            if (currtab != null) {
                currtab = "#" + currtab;

             //   $(".currenttab").val(currtab);
                
                $(".active").attr("class", "tab-pane");
                $menuChildren = $('a[href="' + currtab + '"]').parent().attr("class", "active");
                $(currtab).attr("class", "tab-pane active");
            }

            
                $('list').click(function (event) { event.preventDefault(); $('#products .item').addClass('list-group-item'); });
                $('#grid').click(function (event) { event.preventDefault(); $('#products .item').removeClass('list-group-item'); $('#products .item').addClass('grid-group-item'); });
            

             ////delegate calls to data-toggle="lightbox"
            $(document).on('click', ".playVideo", function () {
                var video = $(this).data("video");
                $("#player").attr("src", "Videos/" + video);
                $("#videoplayer").load();
                $("#ekkoLightbox-player").css("display", "block");

                var vtitle = $(this).next().find(".video-title-list").html();
                $(".video-title-modal").text(vtitle);

            })
            $(document).on("click", "#videoplayer", function () {
                if (this.paused == false) {
                    this.pause();
                    
                } else {
                    this.play();
                 
                }
            })
            $(document).on('click', ".close-player", function () {
                $("#videoplayer").get(0).pause();
                $("#ekkoLightbox-player").css("display", "none");



            })

            $(document).on("click", ".updateasgmt", function () {
                var month = new Array();
                month[0] = "January";
                month[1] = "February";
                month[2] = "March";
                month[3] = "April";
                month[4] = "May";
                month[5] = "June";
                month[6] = "July";
                month[7] = "August";
                month[8] = "September";
                month[9] = "October";
                month[10] = "November";
                month[11] = "December";
                var asgmtid = $(this).data("id");
                PageMethods.setasgmt(asgmtid, function onSucceed(result) {
                    var asgmt = result.split(",");
                    //var dt = new Date(asgmt[3]);
                  //  alert(dt);
                    //alert(month[dt.getMonth()] + "  " + dt.getDate());
                    $("#Updateasgmttitle").val(asgmt[1]);
                    $("#Assgnmentduedatetext").val(asgmt[3]);
                    $(".duedateupdatelbl").val(asgmt[3]);
                    //alert($(".duedateupdatelbl").val())
                    //var date = "'" + month[dt.getMonth()] + " " + dt.getDate() + "'";
                    //alert("a[title = " + date + "]");
                    //alert($("#Assgnmentduedatediv").find("a[title='January 22']").html());
                    //$(document).find("a[title=" + date.toString() + "]").parent().css("background-color", "Silver");
                    //$(document).find("a[title=" + date.toString() + "]").parent().css("color", "White");
                    //$(document).find("a[title=" + date.toString() + "]").css("color", "White");

                    $("#updateasgmtmarks").val(asgmt[2]);
                }, onError);


               
                function onError(result) {
                    alert(result)
                }


            })
            $(document).on("click", ".assignmentresult", function () {

                var asgmtid = $(this).data("id");
                PageMethods.setasgmtid(asgmtid, function onSucceed(result) {
                   
                    
                }, onError);



                function onError(result) {
                    alert(result)
                }


            })

            $(document).on("click", ".close-updateform", function () {
              
                $("#Assgnmentduedate").hide();
               


            })
          
        })

        $(document).on("click", "#uploadAssignment", function (e) {

            if ($("#AssignmentUpload").val() == "") {
                $("#errormessageassignment").text("Please Select File To upload..!!");
                e.preventDefault();
                return;
            }
            else {
                $("#errormessageassignment").text("");
            }

        })

        $(document).on("click", "#Uploadvideobtn", function (e) {

            if ($("#Videoupload").val() == "") {
                $("#errorvideo").text("Please Select File To upload..!!");
                e.preventDefault();
                return;
            }
            else {
                $("#errorvideo").text("");
            }

        })

        $(document).on("click", "#Quizzbtn", function (e) {

            if ($("#QuizzUpload").val() == "") {
                $("#errorquiz").text("Please Select File To upload..!!");
                e.preventDefault();
                return;
            }
            else {
                $("#errorquiz").text("");
            }

        })
        $(document).on("click", "#lectureouploadbtn", function (e) {

            if ($("#LectureUpload").val() == "") {
                $("#errorlecture").text("Please Select File To upload..!!");
                e.preventDefault();
                return;
            }
            else {
                $("#errorlecture").text("");
            }

        })
        $(document).on("click", "#BookUploadBtn", function (e) {

            if ($("#BookUpload").val() == "") {
                $("#errorbook").text("Please Select File To upload..!!");
                e.preventDefault();
                return;
            }
            else {
                $("#errorbook").text("");
            }

        })
        $(document).on("click", "#UplaodAsgmtresult", function (e) {

            if ($("#AssignmentResultUplaod").val() == "") {
                $("#errorassignmentresult").text("Please Select File To upload..!!");
                e.preventDefault();
                return;
            }
            else {
                $("#errorassignmentresult").text("");
            }

        })
        
        
        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }
        </script>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-43208246-2', 'ashleydw.github.io');
        ga('send', 'pageview');
		</script>
 
            
</asp:Content>

