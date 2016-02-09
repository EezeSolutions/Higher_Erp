<%@ Page Title="" Language="C#" MasterPageFile="~/Hostel/MasterPage.master" AutoEventWireup="true" CodeFile="OrderRoom.aspx.cs" Inherits="Hostel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading" ">Rooms List</div>
        <div class="panel-body">
            <div class="row ">
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Hostel Name:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="hostelname" placeholder="Please enter Price"></asp:TextBox>
                                    
                                    
                                    </div>
            </div>
                <br />
               <br />
                <br />
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Price:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="price" placeholder="Please enter Price"></asp:TextBox>
                                     
                                    </div>
            </div>
                <br />
               <br />
                <br />
              
              <div class="form-group">
                                    <label class="col-sm-3 control-label">Capacity:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" ReadOnly="true" CssClass="form-control" runat="server" ID="capacity" placeholder="Please enter Capacity"></asp:TextBox>
                                     
                                    </div>
            </div>
                <br />
               <br />
                <br />
               <div class="form-group">
                                    <label class="col-sm-3 control-label">Description:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" ReadOnly="true" TextMode="MultiLine" CssClass="form-control" runat="server" ID="description" placeholder="Please enter Description"></asp:TextBox>
                                     
                                    </div>
            </div>
                <br />
               <br />
                <br />
           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnorderroom" Visible="false" Text="Order Room" OnClick="btnorderroom_Click"  runat="server" />
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnReorder" Visible="false" Text="Reorder Room" OnClick="btnReorder_Click"  runat="server" />
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnLeaveroom" Visible="false" Text="Leave Room" OnClick="btnLeaveroom_Click"  runat="server" />
                                     
                                    </div>
            </div>

                <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-12 control-label" id="status" runat="server"> </label>
                                    
                                   
            </div>
                </div>
            </div>
        </div>
</asp:Content>

