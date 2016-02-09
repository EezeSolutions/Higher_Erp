<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddQuestions.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="panel panel-default">
        <div class="panel-heading">Add Question</div>
        <div class="panel-body">
          <div class="row">
                 <div class="form-group">
                                    <label class="col-sm-2 control-label">Question:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Question" placeholder="Please enter amount to deposit"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="Question" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
                                    </div>
            </div>
              <br />
              <br />
               <br />
              
           <div class="form-group">
               <label class="col-sm-2 control-label">Answer:</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Answer" placeholder="Please enter amount to deposit"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="Answer" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
               </div>
               </div>
             
               <div id="answersdiv">
               </div>
                  
              
                <br />
               <div class="form-group" >
              <a href="#" id="addanswer" class="control-label">Add More</a>
                   </div>
              <br />
             
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-2 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <a Class="btn btn-block btn-primary" ID="btnAddQuestion" >Add</a>
                                     
                                    </div>
            </div>
          </div>
        </div>
      </div>
    <script type="text/javascript">
        $(function () {
            var answers = new Array();
            var i = 0;
            $("#addanswer").click(function () {
                answers[i] = $("#Answer").val();
                $("#Answer").attr('id', "#oldanswer");
              
                var input = "<br><br><div class='form-group' >";
                input += " <label class='col-sm-2 control-label'></label>";
                input += "<div class='col-sm-9'>";
                input += "<input type=text id=Answer class='form-control' />";
                input += "</div>";
                input += "</div>";
                i++;
                $("#answersdiv").append(input);
            })

            $("#btnAddQuestion").click(function(){
                    answers[i]=$("#Answer").val();
                $.ajax({
                type: "POST",
                url: "AddQuestions.aspx/AddQuestion",
                data: JSON.stringify({ question: $("#Question").val(), answers: answers }),
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

        });

    </script>
</asp:Content>

