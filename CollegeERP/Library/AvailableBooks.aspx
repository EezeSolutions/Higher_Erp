<%@ Page Title="" Language="C#" MasterPageFile="~/Library/MasterPage.master" AutoEventWireup="true" CodeFile="AvailableBooks.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading" ">Available Books</div>
        <div class="panel-body">
            <div id="pagingdiv" runat="server"><p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p></div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br />
                     <br />
                     <div style="float:right" class="clearfix" runat="server" id="searchcontrols">
                      <asp:TextBox ID="SearchButton" placeholder="   Enter ISBN Number"  runat="server" ></asp:TextBox> 
                         &nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Button ID="SearchBtn" CssClass="btn btn-info" runat="server" Text="Search Book" />&nbsp;&nbsp;&nbsp;<img id="loderImg" style="display:none" src="../images/ajax-loader.gif" />
    
                        <br />
                       <br />
                      </div>


                    <div class="row">
                        <div class="col-lg-offset-3 col-lg-6">
        <p class="alert alert-danger" runat="server" id="membermsg" visible="false">

        </p>
                             <div class="col-lg-offset-3 col-lg-6">
            <a href="RequestMemberShip.aspx" runat="server" id="linkmemebrship" visible="false" class="btn btn-primary">Request Membership</a>
                           </div>
    </div>
                        
                        <div class="col-sm-12" runat="server" id="tblbooks">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Book Name</th><th>Category</th><th>ISBN</th><th>Author</th><th>Quantity</th><th>Action</th></tr>
                        <asp:Label ID="programstbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>
                        <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalPaging" ></asp:Literal>
                            </ul>
                            </div>
                        <br />
                        <br />
                        </div>

                    

                           </ContentTemplate>
                </asp:UpdatePanel>
                       <asp:Label id="backlink" runat="server" ></asp:Label>

        </div>
     </div>

     <script type="text/javascript">
        

         $(function () {
             $(".btn-action").click(function () {

                 var action = $(this).attr("class").split(" ")[3];
                 var id = $(this).data("id");

                 if (action == "Disable" || action == "Enable") {
                     var res = confirm("Are You Sure? Press OK to continue.....")
                     if (res == false)
                         return;
                 }
                 window.location = "orderBook.aspx?Bookid=" + id + "&action=" + action;

             });



         })
    </script>
</asp:Content>

