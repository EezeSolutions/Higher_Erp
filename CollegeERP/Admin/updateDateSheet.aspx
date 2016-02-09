<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="updateDateSheet.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
    <div class="panel-heading" ">Update Date Sheet</div>
        <div class="panel-body">
    <div class="row ">
      
    <div class="form-group">
        
  
    
  <div class="form-group">
    <label class="col-sm-3 control-label"> Course</label>
      
      <div class="col-sm-9">
      <asp:DropDownList ID="CourseList" CssClass="form-control" runat="server" >
        
        <%--<option selected="selected" disabled="disabled">Select a program</option>--%>
    </asp:DropDownList>
    </div>
  </div>
        <br /><br /><br /><br />
            <div class="form-group">
    <label class="col-sm-3 control-label"> Exam Type</label>
      
                <div class="col-sm-9">
      <asp:DropDownList ID="ExamTypeList" CssClass="form-control" runat="server" >
        <asp:ListItem Text="Select Option" Value=""></asp:ListItem>
        <asp:ListItem Text="Mid" Value="Mid"></asp:ListItem>
        <asp:ListItem Text="Final" Value="Final"></asp:ListItem>
        
    </asp:DropDownList>
    </div>
  </div>
      <br /><br /><br />
         <div class="form-group">
    <label class="col-sm-3 control-label">Starting Time</label>
             
             <div class="col-sm-9">
            <asp:TextBox ID="StartTime"  CssClass="form-control" runat="server"></asp:TextBox>
                 </div>
  </div>
        <br /><br /><br />
                <div class="form-group">
    <label class="col-sm-3 control-label">Ending Time</label>
             
                    <div class="col-sm-9">
            <asp:TextBox ID="EndTime"  CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
  </div>
        <br /><br />
               <br />
         <div class="form-group">
             <label class="col-sm-3 control-label"> </label>
             <div class="col-sm-9">
      <asp:Button ID="updateDateSheetBtn" CssClass="btn btn-brown btn-block" runat="server" Text="Create" OnClick="updateDateSheetBtn_Click" />
      </div>
      <br />
      <span runat="server" id="Span2"  ></span>
      <br />
    
  <%--<button type="submit" class="btn btn-brown btn-block">Sign In</button>--%>
  </div>
            </div>
        </div>
             </div>
        </div>       
</asp:Content>

