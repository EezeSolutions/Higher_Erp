<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AssignCourseToEmplloyee.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="panel panel-default">
        <div class="panel-heading">Assign Course</div>
        <div class="panel-body">
          <div class="row">
              <asp:ScriptManager ID="manaer1" runat="server"></asp:ScriptManager>
              <asp:UpdatePanel ID="Upanel1" runat="server">
                  <ContentTemplate>
                      <asp:Label ID="mesg" runat="server"></asp:Label>
                      <%--<p class="alert alert-danger col-lg-offset-3 col-lg-9" runat="server" id="mesg" visible="false"></p>--%>
           <div class="col-lg-12">
                         <div class="form-group">
              <div class="col-sm-3"><label>Select Department</label></div>
                      <div class="col-sm-9">
                  <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDowndepartment" AutoPostBack="true" OnSelectedIndexChanged="DropDowndepartment_SelectedIndexChanged">
                                     <asp:ListItem Text="Select Departments" Value=""></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="" ControlToValidate="DropDowndepartment"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Department" />      
               </div>
                  </div>
              <br />
              <br /><br />

                 <div class="form-group">
              <div class="col-sm-3"><label>Select Programme</label></div>
                      <div class="col-sm-9">
                  <asp:DropDownList  CssClass="form-control" runat="server" ID="DropDownprogramme" AutoPostBack="true" OnSelectedIndexChanged="DropDownprogramme_SelectedIndexChanged">
                                     <asp:ListItem Text="Select Programme" Value=""></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="" ControlToValidate="DropDownprogramme"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Programme" />      
               </div>
                  </div>
              <br />
              <br /><br />

                  <div class="form-group">
              <div class="col-sm-3"><label>Select Course</label></div>
                      <div class="col-sm-9">
                  <asp:DropDownList  CssClass="form-control" runat="server" ID="DropDownCourse" AutoPostBack="true" >
                                     <asp:ListItem Text="Select Course" Value=""></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="" ControlToValidate="DropDownCourse"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Course" />      
               </div>
                  </div>
              <br />
              <br /><br />

                  <div class="form-group">
              <div class="col-sm-3"><label>Select Teacher</label></div>
                      <div class="col-sm-9">
                  <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDownteacher" AutoPostBack="true">
                                     <asp:ListItem Text="Select Teacher" Value=""></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="" ControlToValidate="DropDownteacher"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Teacher" />      
               </div>
                  </div>
              <br />
              <br /><br />
               <div class="form-group">
                <div class="col-sm-3">
                  <label class="label"></label>
              </div>
              <div class="col-sm-9 ">
              <asp:Button  ID="BtnSumit" runat="server" ValidationGroup="addProgramme" OnClick="BtnSumit_Click" CausesValidation="true" cssClass="btn btn-primary btn-block" Text="Assign Course"/>
              </div>
                   </div>
               </div>
            </ContentTemplate>
              </asp:UpdatePanel>
              </div>
            </div>
         </div>
</asp:Content>

