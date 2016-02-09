<%@ Page Title="" Language="C#" MasterPageFile="~/LMS/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAssignmentResult.aspx.cs" Inherits="LMS_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

     <div class="panel panel-default">
    <div class="panel-heading" ">Assignment Result</div>
        <div class="panel-body">
    <div class="row ">
         <div class="form-group">
        
  
    
  <div class="form-group">
    <label class="col-sm-3 control-label">Total Marks</label>
      
      <div class="col-sm-9">
      <asp:TextBox ID="TotalMarks" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
    </div>
      
  </div>
        <br /><br /><br /><br /><br /><br />
            <div class="form-group">
    <label class="col-sm-3 control-label"> Obtained Marks</label>
      
                <div class="col-sm-9">
      <asp:TextBox ID="ObtainedMarks" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
    </div>
  </div>
             </div>
        </div>
            </div>
         </div>

</asp:Content>

