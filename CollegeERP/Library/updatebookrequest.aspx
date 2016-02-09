<%@ Page Title="" Language="C#" MasterPageFile="~/Library/MasterPage.master" AutoEventWireup="true" CodeFile="updatebookrequest.aspx.cs" Inherits="Library_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading" ">Update Book</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                      <div class="form-group">
                                    <label class="col-sm-3 control-label">Book Title:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="BookTitle" placeholder="Please enter Book Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="BookTitle" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Book Name" />      
                                    </div>
            </div>
                    <br />
                    <br />
                    <br />
                         <div class="form-group">
                                    <label class="col-sm-3 control-label">Issue To:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="Issueto" placeholder="Please enter Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="Issueto" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Name" />      
                                    </div>
            </div>
                    <br />
                    <br />
                    <br />
                         <div class="form-group">
                                    <label class="col-sm-3 control-label">Issue Date:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="IssueDate" placeholder="Please enter Book Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="IssueDate" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Book Name" />      
                                    </div>
            </div>

                    <br />
                    <br />
                    <br />
                        <div class="form-group">
                 <label class="col-sm-3 control-label">Due Date</label>
                            
                                                                <div class="col-sm-2">
Date:
                                                                    <asp:DropDownList runat="server" ID="dropdownDay">
                                                                    </asp:DropDownList>


                                                                </div>
                            <asp:Label Text="Please Select Valid Due Date" ID="datemessage" Visible="false" ForeColor="Red" runat="server"></asp:Label>
                                                                <div class="col-sm-3">
Month:
                                                                    <asp:DropDownList runat="server" ID="dropdownMonth">

                                                                        <asp:ListItem Value="1" Text="JAN"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="FEB"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="MAR"></asp:ListItem>
                                                                        <asp:ListItem Value="4" Text="APR"></asp:ListItem>
                                                                        <asp:ListItem Value="5" Text="MAY"></asp:ListItem>
                                                                        <asp:ListItem Value="6" Text="JUN"></asp:ListItem>
                                                                        <asp:ListItem Value="7" Text="JUL"></asp:ListItem>
                                                                        <asp:ListItem Value="8" Text="AUG"></asp:ListItem>
                                                                        <asp:ListItem Value="9" Text="SEP"></asp:ListItem>
                                                                        <asp:ListItem Value="10" Text="OCT"></asp:ListItem>
                                                                        <asp:ListItem Value="11" Text="NOV"></asp:ListItem>
                                                                        <asp:ListItem Value="12" Text="DEC"></asp:ListItem>

                                                                    </asp:DropDownList>


                                                                </div>
                                                              
               </div>

                      <br />
               <br />
                <br />
             
              
             

           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnIssuebook" Text="Issue Book" OnClick="btnIssuebook_Click" runat="server" />
                                     
                                    </div>
            </div>
                </div>


            </div>
            </div>
        </div>
</asp:Content>

