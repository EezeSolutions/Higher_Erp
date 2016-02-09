<%@ Page Title="" Language="C#" MasterPageFile="~/Library/MasterPage.master" AutoEventWireup="true" CodeFile="updateBook.aspx.cs" Inherits="Library_Default" %>

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
        <div class="panel-heading" ">Update Book</div>
        <div class="panel-body">
          
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
              
           
                
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
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnupdatebook" Text="Update Book" OnClick="btnupdatebook_Click" runat="server" />
                                     
                                    </div>
            </div>
          </div>
                
                    
                    </ContentTemplate>
                </asp:UpdatePanel>
        </div>
           </div>
     

</asp:Content>

