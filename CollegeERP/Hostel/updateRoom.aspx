<%@ Page Title="" Language="C#" MasterPageFile="~/Hostel/MasterPage.master" AutoEventWireup="true" CodeFile="updateRoom.aspx.cs" Inherits="Hostel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading" ">Rooms List</div>
        <div class="panel-body">
            <div class="row ">

              
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Select Hostel:</label>
                                     <div class="col-sm-9">
                                    
                                      <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDownHostel">
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="" ControlToValidate="DropDownHostel"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Hostel" />      
                                    </div>
            </div>
              <br />
              <br />
               <br />

               <div class="form-group">
                                    <label class="col-sm-3 control-label">Price:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="price" placeholder="Please enter Price"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="price" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Price" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
              
              <div class="form-group">
                                    <label class="col-sm-3 control-label">Capacity:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="capacity" placeholder="Please enter Capacity"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="capacity" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Capacity" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Description:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" TextMode="MultiLine" CssClass="form-control" runat="server" ID="description" placeholder="Please enter Description"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="description" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Description" />
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnupdateroom" ValidationGroup="addprogramme" Text="Update Room" OnClick="btnupdateroom_Click"  runat="server" />
                                     
                                    </div>
            </div>
          </div>
            </div>
        </div>
</asp:Content>

