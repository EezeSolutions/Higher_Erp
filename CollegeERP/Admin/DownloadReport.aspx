<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="DownloadReport.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
    <div class="panel-heading" ">Questions Details</div>
        <div class="panel-body">
    <div class="row ">
      <asp:ScriptManager runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div class="form-group">
        <p style="float:left; margin-left:15px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
               <div class="col-sm-12">
                   <span><label id="temp"></label></span>
                       
                   <div id="questionairTableDiv"> <asp:Label ID="questionairelbl" runat="server" Text=""></asp:Label> </div>
                        
                                
                   <%--<button id="SubmitComments" class="btn btn-success" onclick="SaveComments();">Send Messages</button>--%>
                            </div>

                <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ClientIDMode="Static" ID="literalPaging" ></asp:Literal>
                            </ul>
                            </div>
        
        
        </div>
        </div>
            </div>
        </div>
    <script type="text/javascript">
        var TotalRequests = '<%=Count%>';
        var Recipients = "";
        var Comments = "";

        function onSucceed(result) {
            var array = result.split('?');
            
            document.getElementById("questionairTableDiv").innerHTML = array[0];
            //alert(array[1])
            document.getElementById("literalPaging").textContent = array[1];
        }
        function onError(result) {
        }
        var page = 1;
        function SaveComments(i) {

            //for(var i=1;i<TotalRequests;i++)
            //{
            Recipients = i;
            // alert(document.getElementById("Text_" + i).innerHTML);
            Comments = document.getElementById("Text_" + i).value;
            var url = window.location.search;
            url = url.replace("?page=", ''); // remove the ?
            if(url=="")
            {
                page = 1;
            }
            else {
                page = url;
            }
            //}

            PageMethods.SubmitCommentsToStudents(Recipients, Comments, page, onSucceed, onError);

       

        }
    </script>
</asp:Content>

