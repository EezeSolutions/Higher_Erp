<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ViewLeaveRequests.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="panel panel-default">
        <div class="panel-heading" >Leave Requests:</div>
        <div class="panel-body">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <p style="float:left; margin-left:0px; margin-bottom:20px;"><span> Displaying </span><span style="font-weight:bold;"><asp:Literal runat="server" ID="literalStart"></asp:Literal><span>-</span><asp:Literal runat="server" ID="literalEnd"></asp:Literal></span><span> of </span> <asp:Literal runat="server" ID="literalTotal"></asp:Literal><span> results</span></p>
            
          <div class="row">
                <div class="col-sm-3" style="text-align:right;float:right">
                  <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDownstatus" AutoPostBack="true" OnSelectedIndexChanged="DropDownstatus_SelectedIndexChanged">
                                     
                      <asp:ListItem Value="0" Text="Pending"></asp:ListItem>
                      <asp:ListItem Value="1" Text="Approved"></asp:ListItem>
                      <asp:ListItem Value="-1" Text="Rejected"></asp:ListItem>
                      <asp:ListItem Value="All" Text="All"></asp:ListItem>

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="" ControlToValidate="DropDownstatus"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Department" />      
               </div>
                                  
           
             <table class="table table-responsive">
                 <tr class="blue-background"><th>Employee Name</th><th>Department</th><th>Leave Type</th><th>Day(s)</th><th>Leave From</th><th>Leave To</th><th>Action</th></tr>
                  <asp:Label ID="LeaveRequeststbl" runat="server"></asp:Label>
                 </table>
              <br /><br /><br />
                <div class="col-sm-12">
                        <ul class="pagination">
                        <asp:Literal runat="server" ID="literalPaging" ></asp:Literal>
                            </ul>
                            </div>
              <div class="col-sm-12 clearfix">
                            <div style="float:right;margin-right:10px">
                             <asp:Button CssClass="btn btn-info" ID="dashboardbtn" runat="server" OnClick="dashboardbtn_Click" Text="Go To Dashboard" />
                        </div>
                            </div>
              </div>
                </ContentTemplate>
                </asp:UpdatePanel>
            
            </div>
        </div>
</asp:Content>

