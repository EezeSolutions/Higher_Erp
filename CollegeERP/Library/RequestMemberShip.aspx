<%@ Page Title="" Language="C#" MasterPageFile="~/Library/MasterPage.master" AutoEventWireup="true" CodeFile="RequestMemberShip.aspx.cs" Inherits="Library_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="panel panel-default">
    <div class="panel-heading" ">Place Order</div>
        <div class="panel-body">
    <div class="row ">
      
      <div class="col-lg-offset-3 col-lg-6">
        <p class="alert alert-info" runat="server" id="membermsg" visible="false"></p>
    </div>
          <div class="form-group" id="membershipform" runat="server">
         <div class="form-group">
                    <label class="col-sm-3 control-label"> Name</label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="nametxt" ReadOnly="true" CssClass="form-control" runat="server" ></asp:TextBox>
                </div></div>
        <br /><br /><br /><br /><br /><br /><br />
        <div class="form-group">
                    <label class="col-sm-3 control-label">Metrc #</label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="metricno" ReadOnly="true"  CssClass="form-control" runat="server"></asp:TextBox>
                </div></div>
        <br /><br /><br /><br /><br /><br /><br />
        <div class="form-group">
                    <label class="col-sm-3 control-label">Programme.</label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="programme" ReadOnly="true"  CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                </div></div>
        <br /><br /><br /><br /><br /><br /><br />
        
        <div class="form-group">
             <label class="col-sm-3 control-label"></label>
             <div class="col-sm-9">
      <asp:Button ID="Requestbtn" CssClass="btn btn-brown btn-block" runat="server" OnClick="Requestbtn_Click" Text="Send Request"/>
      
    </div>
  </div>
        </div>
        </div>
                       <asp:Label id="backlink" runat="server" ></asp:Label>

            </div>
        </div>

</asp:Content>

