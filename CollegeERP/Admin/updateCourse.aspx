<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="updateCourse.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-default">
        <div class="panel-heading" ">Update Course</div>
        <div class="panel-body">
      <div class="row ">

            
               
              
              
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Course:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="coursename" placeholder="Please enter your Course Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="coursename" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Course Name" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Course Code:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="CourseCode" placeholder="Please enter your Course Code"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="CourseCode" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Course Code" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Fee:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Feetxt" placeholder="Please enter your Course Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="Feetxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Course Name" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Total Marks:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Markstxt" placeholder="Please enter  Total Marks"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                                     Display="Dynamic" runat="server" ControlToValidate="Markstxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Total Marks" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
              <div class="form-group">
                                    <label class="col-sm-3 control-label">Credit Hours:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="CreditHours" placeholder="Please enter  Credit Hours"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="CreditHours" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Credit Hours" />
                 
                                    </div>
            </div>
              <br />
               <br />
                <br />
              
                 <div class="form-group">
                                    <label class="col-sm-3 control-label">Offer To:</label>
                                    <div class="col-sm-9">
                                   <asp:CheckBoxList ID="checkbocprogamlist" RepeatDirection="Horizontal" CssClass="prgmcheckbox" runat="server"></asp:CheckBoxList>
                                     </div>
            </div>
              <br />
              <br />
               <br />

           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ValidationGroup="addprogramme" ID="btnupdatecourse" Text="Update Course" runat="server" OnClick="btnupdatecourse_Click"/>
                                     
                                    </div>
            </div>
          </div>
            </div>
        </div>
    
</asp:Content>

