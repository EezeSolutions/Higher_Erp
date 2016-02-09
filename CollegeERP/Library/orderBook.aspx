<%@ Page Title="" Language="C#" MasterPageFile="~/Library/MasterPage.master" AutoEventWireup="true" CodeFile="orderBook.aspx.cs" Inherits="Library_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="panel panel-default">
    <div class="panel-heading" ">Place Order</div>
        <div class="panel-body">
    <div class="row ">
      
    <div class="form-group">
         <div class="form-group">
                    <label class="col-sm-3 control-label">Book Name</label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="bookname" ReadOnly="true" CssClass="form-control" runat="server" ></asp:TextBox>
                </div></div>
        <br /><br /><br /><br /><br /><br /><br />
        <div class="form-group">
                    <label class="col-sm-3 control-label">Category</label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="category" ReadOnly="true"  CssClass="form-control" runat="server"></asp:TextBox>
                </div></div>
        <br /><br /><br /><br /><br /><br /><br />
        <div class="form-group">
                    <label class="col-sm-3 control-label">ISBN No.</label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="daIsbnNo" ReadOnly="true"  CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                </div></div>
        <br /><br /><br /><br /><br /><br /><br />
        
        <div class="form-group">
             <label class="col-sm-3 control-label"></label>
             <div class="col-sm-9">
      <asp:Button ID="OrderBtn" CssClass="btn btn-brown btn-block" runat="server" OnClick="OrderBtn_Click" Text="Order"/>
      
    </div>
  </div>
        </div>
        </div>
            </div>
        </div>
</asp:Content>

