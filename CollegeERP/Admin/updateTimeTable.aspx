<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="updateTimeTable.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
    <div class="panel-heading" ">Update Date Sheet</div>
        <div class="panel-body">
    <div class="row ">
      
    <div class="form-group">
        <div class="form-group">

                <div class="form-group">
    <label class="col-sm-3 control-label"> Course</label>
     
                    <div class="col-sm-9">
      <asp:DropDownList ID="CourseList" CssClass="form-control" runat="server" >
        
       
    </asp:DropDownList>
    </div>
                    <br /><br />
  </div>
        <div class="form-group">
    <label class="col-sm-3 control-label">Start Time</label>
            
            <div class="col-sm-9">
            <asp:TextBox ID="STime"  CssClass="form-control" runat="server"></asp:TextBox>
     </div>
  </div>
        <br /><br /><br />
         <div class="form-group">
    <label class="col-sm-3 control-label">End Time</label>
             
             <div class="col-sm-9">
            <asp:TextBox ID="ETime"  CssClass="form-control" runat="server"></asp:TextBox>
                 </div>
  </div>
        <br /><br />
        <div class="form-group">
    <label class="col-sm-3 control-label"> Day</label>
           
            <div class="col-sm-9">
      <asp:DropDownList ID="DropDownDay" CssClass="form-control" runat="server" >
          <asp:ListItem>Monday</asp:ListItem>
          <asp:ListItem>Tuesday</asp:ListItem>
          <asp:ListItem>Wednesday</asp:ListItem>
          <asp:ListItem>Thusday</asp:ListItem>
          <asp:ListItem>Friday</asp:ListItem>
        <%--<option selected="selected" disabled="disabled">Select a program</option>--%>
    </asp:DropDownList>
                </div>
            <br /><br /><br />
        <div class="form-group">
    <label class="col-sm-3 control-label"> Teacher</label>
            
            <div class="col-sm-9">
      <asp:DropDownList ID="TeacherList" CssClass="form-control" runat="server" >
        
        
    </asp:DropDownList>
    </div>
  </div>
            <br /><br /><br />
         <div class="form-group">
             <label class="col-sm-3 control-label"></label>
             <div class="col-sm-9">
      <asp:Button ID="TimeTableUpdateBtn" CssClass="btn btn-brown btn-block" runat="server" Text="Update" OnClick="TimeTableUpdateBtn_Click" />
      
      </div>
    
  <%--<button type="submit" class="btn btn-brown btn-block">Sign In</button>--%>
  </div>
    

         </div>
        </div>
             </div>
        </div> 
</asp:Content>

