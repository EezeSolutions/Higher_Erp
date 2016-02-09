<%@ Page Title="" Language="C#" MasterPageFile="~/Library/MasterPage.master" AutoEventWireup="true" CodeFile="StudentIssuedBooks.aspx.cs" Inherits="Library_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="panel panel-default">
        <div class="panel-heading" ">Available Books</div>
        <div class="panel-body">
            <div><p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p></div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br />
                     <br />
                     <div style="float:right" class="clearfix">
                      <asp:TextBox ID="SearchButton" placeholder="   Enter ISBN Number"  runat="server" ></asp:TextBox> 
                         &nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Button ID="SearchBtn" CssClass="btn btn-info" runat="server" Text="Search Book" OnClick="SearchBtn_Click" />&nbsp;&nbsp;&nbsp;<img id="loderImg" style="display:none" src="../images/ajax-loader.gif" />
    
                        <br />
                       <br />
                      </div>


                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-responsive table-hover"><tr class="blue-background"><th>Book Name</th><th>Category</th><th>ISBN</th><th>Issue Date</th><th>Due Date</th><th>Action</th></tr>
                        <asp:Label ID="issuebookstbl" runat="server" Text=""></asp:Label>
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
        </div>
     </div>
</asp:Content>

