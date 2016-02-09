<%@ Page Title="" Language="C#" MasterPageFile="~/Library/MasterPage.master" AutoEventWireup="true" CodeFile="AddBooks.aspx.cs" Inherits="Default2" %>

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
        <div class="panel-heading" ">Manage Books</div>
        <div class="panel-body">
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
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
                        <div class="col-sm-12 clearfix">
                        <div style="float:right">
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Add Book</a>
                        </div>
                             
                            <div style="float:right;margin-right:10px">
                             <asp:Button CssClass="btn btn-info" ID="dashboardbtn" runat="server" OnClick="dashboardbtn_Click" Text="Go To Dashboard"/>
                                
                        </div>
                            
                            </div>
                        </div>

                    <br />
                    <br />
            <div id="nameDiv" class="hide" >
                
          <div class="row ">

                <div class="form-group">
                                    <label class="col-sm-3 control-label">Book Title:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="BookTitle" placeholder="Please enter Book Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="BookTitle" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Book Name" />      
                                    </div>
            </div>
              <br />
              <br />
               <br />
                <div class="form-group">
               <label class="col-sm-3 control-label">Category:</label>
              <div class="col-sm-9">
                  <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="category" placeholder="Please enter Category"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="category" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Category" />      
               </div>
               </div>
              <br />
              <br />
               <br />
              
           <div class="form-group">
               <label class="col-sm-3 control-label">ISBN No.:</label>
              <div class="col-sm-9">
                  <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="IsbnNo" placeholder="Please enter ISBN Number"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="IsbnNo" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter ISBN No." />     
               </div>
               </div>
             
               <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Author:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Authorname" placeholder="Please enter your Course Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="Authorname" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Course Name" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Edition:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Editiontxt" placeholder="Please enter your Course Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="Editiontxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Course Name" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Quantity:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Quantitytxt" placeholder="Please enter  Total Marks"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                                     Display="Dynamic" runat="server" ControlToValidate="Quantitytxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Total Marks" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />

               <div class="form-group">
                                    <label class="col-sm-3 control-label">Description:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" TextMode="MultiLine" runat="server" ID="description" placeholder="Please enter  Total Marks"></asp:TextBox>
                                     
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
             
              
             

           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnaddbook" ValidationGroup="addprogramme" Text="Add Book" OnClick="btnaddbook_Click" runat="server" />
                                     
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
                    var res = confirm("Are You Sure? Press OK to continue.....")
                    if (res == false)
                        return;
                }
                window.location = "updateBook.aspx?Bookid=" + id + "&action=" + action;

            });



        })
    </script>

</asp:Content>

