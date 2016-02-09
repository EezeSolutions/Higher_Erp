<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AskQuestion.aspx.cs" Inherits="Default2" %>

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
</style>
       <div class="panel panel-default">
        <div class="panel-heading" ">Queries</div>
        <div class="panel-body">
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            
                        <asp:Label ID="programstbl" runat="server" Text=""></asp:Label>
                                
                            </div>
                        <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalPaging" ></asp:Literal>
                            </ul>
                            </div>
                        <br />
                        
                        <div class="col-sm-12">
                        <div style="float:right">
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Ask Question</a>
                        </div>
                            </div>
                        </div>
                    <br />
      <span runat="server" id="Span1"  ></span>
      <br />
                    <br />
                    <br />
            <div id="nameDiv" class="hide">

    <div class="row ">
      
    <div class="form-group">
        <div class="form-group">
                    <label class="col-sm-3 control-label">Question</label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="SenderQuestion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div></div>
        <br /> <br /><br /> <br /><br /> <br />
  
         <div class="form-group">
             <label class="col-sm-3 control-label"></label>
             <div class="col-sm-9">
      <asp:Button ID="QuestionBtn" CssClass="btn btn-brown btn-block" runat="server" Text="Send" OnClick="QuestionBtn_Click"  />
      
     
    </div>
 
  </div>
            </div>
        </div>
                </div>
                     </ContentTemplate>
                </asp:UpdatePanel>
       </div>
        </div>
    <script type="text/javascript">
        function showHide_Div(tag) {
            var tagitem = document.getElementById(tag);

            if (tagitem.className == "hide") {
                tagitem.className = "show";
            }
            else { tagitem.className = "hide"; }
        }

        $(function () {
            $(".btn-action").click(function () {

                var action = $(this).attr("class").split(" ")[3];
                var id = $(this).data("id");

                if (action == "Disable" || action == "Enable") {
                    //var res = confirm("Are You Sure? Press OK to continue.....")
                    //if (res == false)
                    //    return;
                    window.location = "viewQuestionDetails.aspx?Questionid=" + id + "&action=" + action;
                }
                //window.location = "updateDateSheet.aspx?Datesheetid=" + id + "&action=" + action;

            });



        })
    </script>
</asp:Content>

