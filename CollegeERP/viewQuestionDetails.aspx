<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewQuestionDetails.aspx.cs" Inherits="Default2" %>

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
                    <asp:TextBox ID="SenderQuestion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div></div>
        <br /><br /><br /><br /><br /><br /><br />
        <div class="form-group">
                    <label class="col-sm-3 control-label">Answer</label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="answer" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div></div>
        <br /><br /><br /><br /><br /><br /><br />
        <div class="form-group">
                    <label class="col-sm-3 control-label">Date</label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="date" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                </div></div>
        </div>
        </div>
            </div>
        </div>
</asp:Content>

