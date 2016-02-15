<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  EnableEventValidation = "false" CodeFile="Questionaire.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style type="text/css">
        .radioButtonList span{
            /*margin-right:20px;*/
        }
        .answerslbl{
            margin:0px;
            margin-right:15px;
            margin-bottom:5px;
            
        }

    </style>
    <div class="panel panel-default">
     <div class="panel-heading">Questionaire</div>
        <div class="panel-body">
          <div class="row">
    <div class="col-sm-12">
      <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <asp:Literal ID="Questionlbl"  runat="server" Text="sadsa"></asp:Literal>
     

       
        <div class="form-group">d
      <asp:Button ID="NextBtn" ClientIDMode="Static" CssClass="btn btn-success" runat="server" Text="Next" OnClick="NextBtn_Click" /><br /><br />
      <asp:Button ID="submitbtn" Visible="false" ClientIDMode="Static" CssClass="btn btn-success" runat="server"  OnClick="submitbtn_Click" Text="Submit"   /><br /><br />
      <asp:Label ID="errorlbl" runat="server" Text="Already Submitted" Visible="false"></asp:Label>
                </ContentTemplate>
      </asp:UpdatePanel>
        
        </div>
    
  <%--<button type="submit" class="btn btn-brown btn-block">Sign In</button>--%>
  </div>
        </div>
              </div>
  
    <script type="text/javascript">
        var Questions = "";
        $(function () {
            var ans = new Array();
            var questions = new Array();
            var i = 0;
            $(document).on("click", "#NextBtn", function () {

               

                $(".radioButtonList").each(function () {

                    var qid = $("#question" + (i + 1)).data("id");
                    questions[i] = $("#question" + (i+1)).text();

                    //alert(qid);
                    
                        ans.push($(this).find("input[name=" + qid + "]:checked").val());                 
                    
                    
                    i++;
                });
            
            });

            $(document).on("click", "#submitbtn", function () {
                Questions = document.getElementById("ContentPlaceHolder1_UpdatePanel1").innerHTML;
                
                $(".radioButtonList").each(function () {

                    var qid = $("#question" + (i + 1)).data("id");
                    questions[i] = $("#question" + (i + 1)).text();
                    
                    
                    

                        ans.push($(this).find("input[name=" + qid + "]:checked").val());
                                
                    i++;
                });
               
                $.ajax({
                    type: "POST",
                    url: "Questionaire.aspx/submitquestions",
                    data: JSON.stringify({ questions: questions,answers:ans }),
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

</asp:Content>

