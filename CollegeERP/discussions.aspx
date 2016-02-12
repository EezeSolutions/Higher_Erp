<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="discussions.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .commenttxt{
            padding:0px;
        }
    </style>
    <div class="panel panel-default">
        <div class="panel-heading" >Discussions (<asp:Label ID="topicnamelbl" runat="server"></asp:Label>)</div>
        <div class="panel-body">
          <div class="row ">
              <div class="col-lg-12">
                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server" ><ContentTemplate>
              <asp:Label ID="discusion" runat="server"></asp:Label>

                  <asp:Label ID="pageing" CssClass="pagination" runat="server"></asp:Label>
                      <br />
                      <br />
                      <br />
                      <div class="form-group">
                          
                  <h4 class="h4">Enter Your Comment:</h4>
                  <textarea cols="100" rows="10" id="commenttxt" runat="server" autofocus></textarea>
                  </div>
                          <br />
                  <br />
                         
                  <asp:Button ID="submitcommentbtn" runat="server" CssClass="btn btn-primary btn-block" Text="Submit" OnClick="submitcommentbtn_Click" />
              </ContentTemplate>
                      </asp:UpdatePanel>
              </div>
              </div>
            </div>
        </div>
</asp:Content>

