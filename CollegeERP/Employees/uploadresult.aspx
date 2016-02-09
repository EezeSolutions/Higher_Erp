<%@ Page Title="" Language="C#" MasterPageFile="~/Employees/MasterPage.master" AutoEventWireup="true" CodeFile="uploadresult.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">

        #Resultfile{

            background:none;
            border:none;
        }

    </style>
    <div class="panel panel-default">
        <div class="panel-heading">Upload Result</div>
        <div class="panel-body">
          <div class="row">
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Programme:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="DropDownprogram_SelectedIndexChanged" AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDownprogram">
                                     
                                       

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="" ControlToValidate="DropDownprogram"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Programme" />      
                                    </div>
            </div>
              <br />
              <br />
              <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Course:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:DropDownList  CssClass="form-control" runat="server" ID="DropDownCourse">
                                     
                                       

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="" ControlToValidate="DropDownCourse"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Course" />      
                                    </div>
            </div>

              <br />
              <br />

               <div class="form-group">
                                    <label class="col-sm-3 control-label">Select File:</label>
                                    <div class="col-sm-9">
                                    <asp:FileUpload ID="Resultfile" runat="server"/> 
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="" ControlToValidate="Resultfile"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select File" />      
                                     
                                    </div>
                   </div>

              <br />
              <br />
              <br />
              <br />
              <div class="form-group">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9">
                                   <asp:Button ID="uplaodfile" CssClass="btn btn-success fa fa-upload" ValidationGroup="addprogramme" OnClick="uplaodfile_Click" runat="server" Text="Upload File"/>    
                                    </div>
                   </div>
              <asp:Label ID="LabelUpload" runat="server" Visible="false" ></asp:Label>
              </div>
            </div>
        </div>
</asp:Content>

