<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Admittedstudents.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="panel panel-default">
        <div class="panel-heading" >Admitted Students</div>
        <div class="panel-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
             <div class="row">
               <div class="col-sm-2" style="float:right;height:40px">
                       <asp:DropDownList Height="30px" AppendDataBoundItems="true" runat="server" ID="dropdownprogramme" OnSelectedIndexChanged="dropdownprogramme_SelectedIndexChanged" AutoPostBack="true">
                 
                              
              </asp:DropDownList>  
                     </div>
                      <br /><br /><br /> 
    <table class="table table-responsive">
                 <tr class="blue-background"><th>Name</th><th>Programme</th><th>Metric #</th><th>Semester</th><th>Acadamic Year</th><th>Fee Discount</th><th></th></tr>
                  <asp:Label ID="Studentslbl" runat="server"></asp:Label>
                 </table>
              </div>
                </ContentTemplate></asp:UpdatePanel>
                </div>
         </div>
</asp:Content>

