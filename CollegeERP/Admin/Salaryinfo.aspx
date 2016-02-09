<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Salaryinfo.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="panel panel-default">
        <div class="panel-heading" >Salary info</div>
        <div class="panel-body">
      <div class="row ">
          <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="Updatepanel1" runat="server"><ContentTemplate>
              <p class="alert-danger" style="text-align:center;font-size:20px" id="message" runat="server" visible="false"></p>
              <br />
              <br />
           <div class="form-group">
                                    <label class="col-sm-3 control-label">Employee Name:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="EmpNametxt" placeholder="Please Enter Employee Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="EmpNametxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Employee Name" />
                                    
                           
                                    </div>
            </div>
              <br />
              <br />
               <br />

            <div class="form-group">
               <label class="col-sm-3 control-label">Employee Department:</label>
              <div class="col-sm-9">
                  <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="DeptList" placeholder="Please Enter Department"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                     Display="Dynamic" runat="server" ControlToValidate="DeptList" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Department" />
                                         </div>
               </div>
              <br />
              <br />
               <br />
          <div class="form-group">
                                    <label class="col-sm-3 control-label">Basic Salary:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="basicsalary" placeholder="Please Enter Basic Salary"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="basicsalary" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Basic Salary" />
                                    
                           
                                    </div>
            </div>

          <br />
              <br />
               <br />

          <div class="form-group">
                                    <label class="col-sm-3 control-label">Medical Allownce:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="MedicalAllownce" placeholder="Please Enter Medical Allownce"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="MedicalAllownce" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Medical Allownce" />
                                    
                           
                                    </div>
            </div>

          <br />
              <br />
               <br />

          <div class="form-group">
                                    <label class="col-sm-3 control-label">Transport Allownce:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="TransportAllownce" placeholder="Please Enter Transport Allownce"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="TransportAllownce" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Transport Allownce" />
                                    
                           
                                    </div>
            </div>

          <br />
              <br />
               <br />
              <div class="form-group">
                                    <label class="col-sm-3 control-label">House Rent:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="HouseRent" placeholder="Please Enter House Rent"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="HouseRent" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter House Rent" />
                                    
                           
                                    </div>
            </div>

          <br />
              <br />
               <br />

              <div class="form-group">
                                    <label class="col-sm-3 control-label">Overtime:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="Overtime" placeholder="Please Enter Overtime"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                     Display="Dynamic" runat="server" ControlToValidate="Overtime" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Overtime" />
                                    
                           
                                    </div>
            </div>

          <br />
              <br />
               <br />


             <div class="form-group" style="text-align:center">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="EditSalary" Text="Edit Salary" runat="server" OnClick="EditSalary_Click" />
                                     
                                    </div>
            </div>
                  <br />
                  <br />
                  <br />

          <div class="form-group" style="text-align:center">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" Visible="false" ID="Update" Text="Update Salary" runat="server" OnClick="Update_Click" />
                                     
                                    </div>
            </div>
                  <br />
                  <br />
                  <br />
              <div class="col-9">
              <asp:Label ID="backlink" runat="server"></asp:Label>
              </div>
                  </ContentTemplate>
              </asp:UpdatePanel>

          </div>
            </div>
         </div>
</asp:Content>

