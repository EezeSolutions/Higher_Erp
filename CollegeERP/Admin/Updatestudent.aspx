<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Updatestudent.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading" ">Update Course</div>
        <div class="panel-body">
      <div class="row ">
           <div class="form-group">
                                    <label class="col-sm-3 control-label">Name:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="StudentName" placeholder="Please enter  Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="StudentName" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Name" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />

           <div class="form-group">
                 <label class="col-sm-3 control-label">Date of Birth</label>
                                                                <div class="col-sm-1">

                                                                    <asp:DropDownList runat="server" ID="dropdownDay">
                                                                    </asp:DropDownList>


                                                                </div>
                                                                <div class="col-sm-1">

                                                                    <asp:DropDownList runat="server" ID="dropdownMonth">

                                                                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                                                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                                                        <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                                                        <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                                                        <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                                                        <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                                                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                                        <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                                        <asp:ListItem Value="12" Text="12"></asp:ListItem>

                                                                    </asp:DropDownList>


                                                                </div>
                                                                <div class="col-sm-1">
                                                                    <asp:DropDownList runat="server" ID="dropdownyears">
                                                                    </asp:DropDownList>
                                                                </div>
               </div>
             
               <br />
               <br />
                <br />


            <div class="form-group">
                                    <label class="col-sm-3 control-label">Metric #:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ReadOnly="true" ClientIDMode="Static" CssClass="form-control" runat="server" ID="MetricNo" placeholder="Please enter Metric No"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="MetricNo" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Metric No" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
            <div class="form-group">
                                    <label class="col-sm-3 control-label">Program:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDownProgram">
                                     
                                       

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="" ControlToValidate="DropDownProgram"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Programme" />      
                                    </div>
            </div>
              <br />
              <br />
               <br />
            <div class="form-group">
                                    <label class="col-sm-3 control-label">Semester:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Semester" placeholder="Please enter Semester"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="Semester" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Semester" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />

           <div class="form-group">
                                    <label class="col-sm-3 control-label">Acadamic Year:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ReadOnly="true" ClientIDMode="Static" CssClass="form-control" runat="server" ID="Ayear" placeholder="Please enter Year"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="Ayear" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Year" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />

            <div class="form-group">
                                    <label class="col-sm-3 control-label">Fee Discount:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="FeeDiscount" placeholder="Please enter Semester"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="FeeDiscount" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Semester" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
           
          
          <div class="form-group">
               <label class="col-sm-3 control-label">Home Address:</label>
              <div class="col-sm-9">
               <asp:TextBox CssClass="form-control" Height="60px" Rows="2" TextMode="MultiLine" MaxLength="50" runat="server" ID="txtHomeaddress" placeholder="Enter Home Address"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtHomeaddress"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Home address is required." />
                   
               </div>
               </div>
             <br />
               <br />
                <br />
               <br />
               <br />
                <br />
          <div class="form-group">
               <label class="col-sm-3 control-label">Email:</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Emailtxt" placeholder="Please enter your Email"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                     Display="Dynamic" runat="server" ControlToValidate="Emailtxt" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
               </div>
               </div>
             
               <br />
               <br />
                <br />

            <div class="form-group">
               <label class="col-sm-3 control-label">Phone:</label>
              <div class="col-sm-9">
               <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Phonetxt" placeholder="Please enter your Phone"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                     Display="Dynamic" runat="server" ControlToValidate="Phonetxt" ValidationGroup="addFunds" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
               </div>
               </div>
              
               <br />
               <br />
                <br />
              
               <div class="form-group">
               <label class="col-sm-3 control-label">State of Origin:</label>
              <div class="col-sm-9">
                <asp:DropDownList AutoPostBack="true"  OnSelectedIndexChanged="dropdownSto_SelectedIndexChanged" CssClass="form-control" AppendDataBoundItems="true" DataTextField="State" DataValueField="ID" runat="server" ID="dropdownSto">
                                                                        <asp:ListItem Value="" Text="Select STO"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" InitialValue="" ControlToValidate="dropdownSto"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Select State of Origin" />
                   
               </div>
               </div>
             
               <br />
               <br />
                <br />

               <div class="form-group">
               <label class="col-sm-3 control-label">Local Govt Area:</label>
              <div class="col-sm-9">
                <asp:DropDownList CssClass="form-control"  runat="server" ID="dropdownLocalGovtarea">
                                                                        <asp:ListItem Value="" Text="Select Local Government Area"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" InitialValue="" ControlToValidate="dropdownLocalGovtarea"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Select Local Government Area" />

               </div>
               </div>
          <br />
               <br />
                <br />
             <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnupdatestudent" ValidationGroup="addprogramme" Text="Update" runat="server" OnClick="btnupdatestudent_Click"/>
                                     
                                    </div>
            </div>
          </div>
            </div>
        </div>
</asp:Content>

