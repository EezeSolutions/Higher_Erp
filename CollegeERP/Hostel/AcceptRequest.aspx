<%@ Page Title="" Language="C#" MasterPageFile="~/Hostel/MasterPage.master" AutoEventWireup="true" CodeFile="AcceptRequest.aspx.cs" Inherits="Hostel_Default" %>

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
                                    <label class="col-sm-3 control-label">Student Department:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" ReadOnly="true" TextMode="MultiLine" CssClass="form-control" runat="server" ID="dept" placeholder="Please enter Description"></asp:TextBox>
                                     
                                    </div>
            </div>
                <br />
               <br />
                <br />

                 <div class="form-group">
                                    <label class="col-sm-3 control-label">Acadamic Year:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" ReadOnly="true" TextMode="MultiLine" CssClass="form-control" runat="server" ID="acadamicYear" placeholder="Please enter Description"></asp:TextBox>
                                     
                                    </div>
            </div>
                <br />
               <br />
                <br /> 
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Student Name:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" ReadOnly="true" TextMode="MultiLine" CssClass="form-control" runat="server" ID="studentname" placeholder="Please enter Description"></asp:TextBox>
                                     
                                    </div>
            </div>
                <br />
               <br />
                <br /> 
                
           
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnacceptorderroom" Text="Accept Request" OnClick="btnacceptorderroom_Click" Visible="false"  runat="server" />
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnrejectroom" Visible="false" Text="Reject Request" OnClick="btnrejectroom_Click"  runat="server" />
                                        <asp:Button Class="btn btn-block btn-primary" ID="Acceptbtns" Visible="false" Text="Accept Request" OnClick="Acceptbtns_Click"  runat="server" />
                                     
                                    </div>
                   
            </div>
                </div>
            </div>
        </div>
</asp:Content>

