<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payment_Response.aspx.cs" Inherits="Payment_Response" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="panel panel-default">
            <div class="panel-heading">Payment Response Details</div>
                        <div class="panel-body">
         
		  <div class="loginPanel" style="width:850px" >
		<div class="site-logo text-center"><img src="../Images/logo.jpg" /></div>
        <br />
          
           <br />


                <div class="modal-dialog modal-lg" style="width:600px">
    <div  class="modal-content">
     <%-- <div style="width:100%" class="btn btn-info">--%>
      <asp:Literal runat="server" ID="literalTranscationResponse"></asp:Literal>

      
   
  </div>
  </div>
      

              </div></div></div>

</asp:Content>

