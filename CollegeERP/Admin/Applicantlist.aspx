<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Applicantlist.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading" >Applicant List</div>
        <div class="panel-body">
            
          <div class="row">
              <div class="col-lg-12">
                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                      <div class="col-lg-12" >
                         <div class="col-sm-9" style="text-align:center">
                           <asp:Label ForeColor="Red" ID="ErrorMessagelbl" runat="server"></asp:Label>
                          </div>
                          <div class="col-sm-3" style="text-align:right">
                          <asp:DropDownList AppendDataBoundItems="true" OnSelectedIndexChanged="Dropdownprogramme_SelectedIndexChanged" AutoPostBack="true" ID="Dropdownprogramme" runat="server">
                              
                              
                          </asp:DropDownList>
                      </div>
                          
                          </div>

                      <br />
                      <br />
                      <table class="table table-responsive">
                      <tr class="blue-background"><th>Name</th><th>Address</th><th>Cut Off Points</th><th>Programme</th><th>Gender</th><th>Email</th><th>Phone</th><th>Action</th></tr>
                      <asp:Literal ID="Applicantlist" runat="server"></asp:Literal>

                  </table>
                  <br />
                  <br />
                  <div class="col-lg-12" ><div class="col-sm-6" style="text-align:left"><asp:Button OnClick="Printmeritlist_Click" ID="Printmeritlist" PostBackUrl="~/Admin/Applicantlist.aspx" CssClass="btn btn-success fa fa-paper-plane" Visible="false" runat="server"  Text="Print Merit List"/></div><div class="col-sm-6" style="text-align:right"><asp:Button OnClick="GenerateList_Click" ID="GenerateList" CssClass="btn btn-primary" runat="server"  Text="Generate Merit List"/></div></div>
                 
                  
                  <br />
                  <br />
                  <div style="text-align:center">
                  <asp:Label ID="Paging" Visible="false" runat="server" CssClass="pagination"></asp:Label>
                  </div>
                      
                  </ContentTemplate>
                      </asp:UpdatePanel>
                  </div>


              </div>
            </div>
        </div>
</asp:Content>

