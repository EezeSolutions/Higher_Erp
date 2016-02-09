<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AnswerQuestion.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="panel panel-default">
    <div class="panel-heading" ">Questions Details</div>
        <div class="panel-body">
    <div class="row ">
      
    <div class="form-group">
         <div class="form-group">
                    <label class="col-sm-3 control-label">Question</label>
                    <div class="col-sm-9">
                    <asp:Label ID="SenderQuestion" Font-Bold="true" runat="server" ></asp:Label>
                </div></div>
        <br /><br /><br /><br /><br /><br /><br />
        <div class="form-group">
                    <label class="col-sm-3 control-label">Answer</label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="answerText" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div></div>
        <br /><br /><br /><br /><br /><br /><br />
        <div class="form-group">
                    <label class="col-sm-3 control-label">Date</label>
                    <div class="col-sm-9">
                    <asp:Label ID="date"  runat="server" ></asp:Label>
                </div></div>
        <br /><br /><br />
        <div class="form-group">
             <label class="col-sm-3 control-label"></label>
             <div class="col-sm-9">
      <asp:Button ID="AnswerBtn" CssClass="btn btn-brown btn-block" runat="server" Text="Answer" OnClick="AnswerBtn_Click"/>
      
    </div>
  </div>
        </div>
        </div>
            </div>
        </div>
</asp:Content>

