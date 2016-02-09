<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProgramApplication.aspx.cs" Inherits="ProgramApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
      <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>cPanle | Home Page</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link rel="stylesheet" href="css/style.css">
      <script src="js/jquery-1.9.1.js"></script>
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  
  
</head>
<body>
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
        <nav class="navbar navbar-default">
  <div class="container">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#"><img src="images/logo.png" class="img-responsive" /></a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav navbar-right">
          
        <li><a href="#" class="active" id="srchbtn"><i class="fa fa-search"></i>Search Features</a></li>
        <li><a href="ProgramApplication.aspx"><i class="fa fa-dashboard "></i>Dashboard</a></li>
          <li><a href="StudentProfile.aspx"><i class="fa fa-user"></i>My Profile</a></li>
           <li><a href="Mails.aspx"><i class="fa fa-inbox"></i>Inbox<span class='rednum' id="inboxcount"></span></a></li>
        <li><a href="Logout.aspx"><i class="fa fa-sign-out"></i>Logout</a></li>
      </ul>
        <div class="col-sm-2 pull-right">
            <form class="navbar-form" role="search">
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search" name="q" id="seachtab">
                    
                </div>
            </form>
        </div>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>
    <div class="container">
  <div class="row">
    <div class="col-sm-3">
      <div class="panel panel-default">
        <div class="panel-heading">Dpppolyib</div>
        <div class="panel-body">
        
                             <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" href="#collapse1" style="font-size:12px">Program Application </a>
        </h4>
      </div>
      <div id="collapse1" class="panel-collapse collapse">
        <ul class="list-group">
          <li class="list-group-item"><a href="ProgramApplication.aspx">Start new Application.</a></li>
            <li class="list-group-item"><a href="AskQuestion.aspx">Ask a question.</a></li>
          
            <li class="list-group-item"><a href="discussions.aspx">Join discussion.</a></li>
            <li class="list-group-item"><a href="Questionare.aspx">Get program suggestion.</a></li>
          
        </ul>
        
      </div>
    </div>

            </div>
        </div>

    </div>
      <div class="col-sm-9">
               <div class="panel panel-default">
        <div class="panel-heading">Admission/Enrolment Management</div>
        <div class="panel-body">
               <form runat="server">
                    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
          <div class="row">
            <div class="col-sm-3">
              <a href="AskQuestion.aspx" class="main-links">
                <img src="images/1-file-manager.jpg">
                <span>Ask a question.</span>
              </a>
            </div>
            <div class="col-sm-5">
              <a  onclick="ShowApplicationForm('nameDiv')" class="main-links">
                <img src="images/2-images.jpg">
                <span>Start new application.</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="discussions.aspx" class="main-links">
                <img src="images/3-privacy.jpg">
                <span>Join discussion.</span>
              </a>
            </div>
                          <div class="col-sm-4">
              <a href="Questionaire.aspx" class="main-links">
                <img src="images/3-privacy.jpg">
                <span>Get program suggestion.</span>
              </a>
            </div>
       
          </div>
                     </ContentTemplate>

            </asp:UpdatePanel>
                  
        </div>
      </div>
      </div>

  </div>
                    <div class="col-sm-3">

                    </div>
                    <div class="col-sm-9">
               <div id="nameDiv" class="hide">

<div class="row ">
      
    <div class="form-group" style="width:100%">
        
           <div class="panel panel-default">
     <div class="panel-heading">Questionaire</div>
        <div class="panel-body">
          <div class="row">
    <div class="col-sm-12">
      <br />
        <br />
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
      
           
        <asp:Label ID="Questionlbl" runat="server" Text=""></asp:Label>
     
        
       
        <div class="form-group">
      <asp:Button ID="NextBtn" ClientIDMode="Static" CssClass="btn btn-success" runat="server" Text="Next" OnClick="NextBtn_Click" />
      <asp:Button ID="submitbtn" Visible="false" ClientIDMode="Static" CssClass="btn btn-success" runat="server" Text="Submit"  />
      
              
      
        
        </div>
    
  <%--<button type="submit" class="btn btn-brown btn-block">Sign In</button>--%>
  </div>
        </div>
              </div>

         
        </div>
                </div>    
                        </div>

         </ContentTemplate>
             </asp:UpdatePanel>
       
                   </form>
    </div>

     


    
    <div class="footer">
  <div class="container">
    <p>&copy; Copyright all Reserved 2000-2016</p>
  </div>
</div>
</body>
        <script type="text/javascript" src="../js/bootstrap.min.js"></script>
     <script type="text/javascript">
         $("#srchbtn").click(function () {

             $("#seachtab").toggle();

         });
         $(function () {
             //
             $("#seachtab").hide();
             getinboxcounts();

             setInterval(getinboxcounts, 5000);
         })

         function getinboxcounts() {
             $.ajax({
                 type: "POST",
                 url: "StudentDashboard.aspx/getinboxcount",
                 data: "",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {

                     $("#inboxcount").text(response.d);
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
         }
         function ShowApplicationForm(name)
         {
             var tagitem = document.getElementById(name);
             if (tagitem.className == "hide") {
                 tagitem.className = "show";
             }
             else { tagitem.className = "hide"; }
             return false;
         }
      

    $(function () {
        var ans = new Array();
        var questions = new Array();
        var i = 0;
        $(document).on("click", "#NextBtn", function () {

                
            $(".radioButtonList").each(function () {

                var qid = $("#question" + (i + 1)).data("id");
                questions[i] = $("#question" + (i+1)).text();

                //alert(qid);
                ans[i] = $(this).find("input[name=" + qid + "]:checked").val();
                i++;
            });
            
        });

        $(document).on("click", "#submitbtn", function () {
            $(".radioButtonList").each(function () {

                var qid = $("#question" + (i + 1)).data("id");
                questions[i] = $("#question" + (i + 1)).text();
                    
                alert(i);
                ans[i] = $(this).find("input[name=" + qid + "]:checked").val();
                i++;
            });
            $.ajax({
                type: "POST",
                url: "Questionaire.aspx/submitquestions",
                data: JSON.stringify({ questions: questions, answers: ans }),
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


        });


    })
    </script>
    
</html>
