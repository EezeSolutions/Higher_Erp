<%@ Page Title="" Language="C#" MasterPageFile="~/LMS/MasterPage.master" AutoEventWireup="true" CodeFile="ShowCourseDetail.aspx.cs" Inherits="LMS_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">

 #assignments .btn{
     padding:3px;
     font-size:9px;
 }

 
    </style>
     <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div id="myModal" tabindex="-1" class="modal fade" role="dialog">

        
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content"  role="document">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Submit Assignment</h4>
      </div>
      <div class="modal-body">
          <asp:FileUpload ID="FileUpload1" runat="server" /> 
      </div>
      <div class="modal-footer">
        
<asp:Label ID="asgmtid" runat="server" Visible="false" ClientIDMode="Static"></asp:Label>
          <asp:Button ID="Submitbtn" class="btn btn-primary" runat="server" OnClick="Submitbtn_Click" Text="Submit" />
            
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>




     <div id="ekkoLightbox-player" class="ekko-lightbox modal fade in" tabindex="-1" aria-hidden="true" style="display: none; padding-right: 17px;"><div class="modal-dialog" style="width: auto; max-width: 592px;"><div class="modal-content"><div class="modal-header"><button type="button" class="close close-player" data-dismiss="ekkoLightbox-player" aria-hidden="true">×</button><h4 class="modal-title">&nbsp;</h4></div><div class="modal-body"><div class="ekko-lightbox-container"><div><div class="embed-responsive embed-responsive-16by9"><video id="videoplayer" width="320" height="240" controls>
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
            <li class="active"><a href="#Attendance" aria-controls="Attendance" role="tab" data-toggle="tab">Attendance</a></li>
            <li ><a href="#result" aria-controls="result" role="tab" data-toggle="tab">
                Result</a></li>
            
            <li><a href="#books" aria-controls="books" role="tab" data-toggle="tab">Books</a></li>
            <li><a href="#lectures" aria-controls="lectures" role="tab" data-toggle="tab">Lectures</a></li>
            <li><a href="#assignments" aria-controls="assignments" role="tab" data-toggle="tab">Assignments</a></li>
            <li><a href="#quizz" aria-controls="quizz" role="tab" data-toggle="tab">Quizzes</a></li>
            <li><a href="#videos" aria-controls="videos" role="tab" data-toggle="tab">Video Lectures</a></li>
        </ul>
        <!-- Tab panes -->
        <div class="tab-content" style="padding-top: 20px">
           
            <div role="tabpanel" class="tab-pane active" id="Attendance">
                 <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Course Title</th><th>Attendance</th><th>Date</th></tr>
                        <asp:Label ID="attendancelbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalPaging" ></asp:Literal>
                            </ul>
                            </div>
            </div>

             <div role="tabpanel" class="tab-pane " id="result">
                
                 
                        <div class="col-sm-12">
                            <div class="col-lg-offset-9 col-lg-3" style="margin-bottom:5px;"><a href="StudentAcademicRecord.aspx" target="_new" class="btn btn-primary">Veiw Full Record</a></div>
                           
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Course Title</th><th>Obtained Marks</th><th>Total Marks</th><th>Session</th><th>Semester</th><th>Grade</th></tr>
                        <asp:Label ID="programstbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                        
                       
                        
                      


            </div>

             <div role="tabpanel" class="tab-pane" id="books">
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
            </div>

            <div role="tabpanel" class="tab-pane" id="lectures">
                <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="lecturestart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="lectureEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="lecturetotal"></asp:Literal><span> results</span></p>
               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Lecture Title</th><th>Course</th><th>Lecture</th><th>Lecture Date</th></tr>
                        <asp:Label ID="lectureLabel" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="lecturepaging" ></asp:Literal>
                            </ul>
                            </div>
            </div>


            <div role="tabpanel" class="tab-pane" id="assignments">
                <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="assignmentstart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="assignmentEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="assignmenttotal"></asp:Literal><span> results</span></p>
               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Assignment Title</th><th>Assignment Marks</th><th>File</th><th>Date</th><th>Action</th></tr>
                        <asp:Label ID="assignmentLable" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="Assignmentpaging" ></asp:Literal>
                            </ul>
                            </div>
        
                
                    </div>

            <div role="tabpanel" class="tab-pane" id="quizz">
                <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="quizzstart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="quizzEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="quizztotal"></asp:Literal><span> results</span></p>

               <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Course Title</th><th>Quizz Title</th><th>Total Marks</th><th>Date</th><th>Action</th></tr>
                        <asp:Label ID="QuizzLabel" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="quizzpaging" ></asp:Literal>
                            </ul>
                            </div>
            </div>

            <div role="tabpanel" class="tab-pane" id="videos">
               <%--<div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Course Title</th><th>Attendance</th><th>Date</th><th>Action</th></tr>
                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                </table>
                            </div>--%>
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
   

     
    </div>
                       <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalvideopaging" ></asp:Literal>
                            </ul>
                            </div>
                  </div>
            </div>
        </div>
    </div>
</div>
           </div>  

          
                         
            </div>

        </div>
    <script type="text/javascript">
        $(function () {
            $(".btn-action").click(function () {

             var asgmtid=   $(this).data("id");

             PageMethods.setasgmt(asgmtid, onSucceed, onError);

                
             function onSucceed() {
                    alert();
                }
                function onError(result) {
                }
            })

        })

    </script>

    <script type="text/javascript">
       
        $(function () {

            var currtab = getUrlVars()["tab"];
            if (currtab != null) {
                currtab = "#" + currtab;
                $(".active").attr("class", "tab-pane");
                $menuChildren = $('a[href="' + currtab + '"]').parent().attr("class", "active");
                $(currtab).attr("class", "tab-pane active");
            }

            $(document).ready(function () {
                $('#list').click(function (event) { event.preventDefault(); $('#products .item').addClass('list-group-item'); });
                $('#grid').click(function (event) { event.preventDefault(); $('#products .item').removeClass('list-group-item'); $('#products .item').addClass('grid-group-item'); });
            });

            ////delegate calls to data-toggle="lightbox"
            $(document).on('click', ".playVideo", function () {
                var video = $(this).data("video");
                $("#player").attr("src", "Videos/" + video);
                $("#videoplayer").load();
                $("#ekkoLightbox-player").css("display", "block");



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

            //$(document).delegate('*[data-toggle="lightbox"]', 'click', function (event) {
            //    alert("ss");
            //    event.preventDefault();
            //    $("#ekkoLightbox-370").ekkoLightbox();
            //});
        })

        $(function () {
            $(".btn-action-quizz").click(function () {
                var action = $(this).attr("class").split(" ")[3];
                var id = $(this).data("id");
               
                //window.location = "QuizzResult.aspx?Quizzid=" + id + "&action=" + action;
                window.open("QuizzResult.aspx?Quizzid=" + id + "&action=" + action + "");

            });



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
    <%--<script src="//code.jquery.com/jquery.js"></script>
		<%--<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
		<script src="//cdnjs.cloudflare.com/ajax/libs/ekko-lightbox/3.3.0/ekko-lightbox.min.js"></script>--%>
    <%--<script src="../js/bootstrap.min.js"></script>--%>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>--%>
<%--<script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>--%>
    <script src="../js/bootstrap.min.js"></script>
</asp:Content>

