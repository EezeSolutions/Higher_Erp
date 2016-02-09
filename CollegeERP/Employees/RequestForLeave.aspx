<%@ Page Title="" Language="C#" MasterPageFile="~/Employees/MasterPage.master" AutoEventWireup="true" CodeFile="RequestForLeave.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading">Leave Request</div>
        <div class="panel-body">
          <div class="row">
                      <div class="form-group">
                                    <label class="col-sm-3 control-label">Employee Name:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="EmpNametxt" placeholder="Please Enter Employee Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="EmpNametxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Employee Name" />
                                    
                           
                                    </div>
            </div>
              <br />
              <br />
               <br />


                      <div class="form-group">
                                    <label class="col-sm-3 control-label">Leave Type:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="LeaveType">
                                     <asp:ListItem Text="Select Leave Type" Value=""></asp:ListItem>
                                     <asp:ListItem Text=" Half Day " Value="Half Day"></asp:ListItem>
                                     <asp:ListItem Text=" Full Day" Value="Full Day"></asp:ListItem>
                      
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" InitialValue="" ControlToValidate="LeaveType"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Leave Type" />      
              
                           
                                    </div>
            </div>
              <br />
              <br />
               <br />

                 <div class="form-group">
                                    <label class="col-sm-3 control-label">Leave From:</label>
                                       <div class="col-sm-1">

                                                                    <asp:DropDownList runat="server" ID="dropdownfromday">
                                                                    </asp:DropDownList>


                                                                </div>
                   
                                                                <div class="col-sm-1">

                                                                    <asp:DropDownList runat="server" ID="dropdownfrommonth">

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
                                                                <div class="col-sm-1">
                                                                    <asp:DropDownList runat="server" ID="dropdownfromyear">
                                                                    </asp:DropDownList>
                                                                </div>
            </div>
              <br />
              <br />
               <br />


                 <div class="form-group">
                                    <label class="col-sm-3 control-label">Leave To:</label>
                                  
                                    
                                        <div class="col-sm-1">

                                                                    <asp:DropDownList runat="server" ID="dropdownDay">
                                                                    </asp:DropDownList>


                                                                </div>
                   
                                                                <div class="col-sm-1">

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
                                                                <div class="col-sm-1">
                                                                    <asp:DropDownList runat="server" ID="dropdownyears">
                                                                    </asp:DropDownList>
                                                                </div>  
                           
                                    </div>
            
              <br />
              <br />
               <br />

              
                 <div class="form-group">
                                    <label class="col-sm-3 control-label">Reason:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:TextBox ClientIDMode="Static" TextMode="MultiLine" Height="100px" CssClass="form-control" runat="server" ID="Reason" placeholder="Please Enter Reason"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                     Display="Dynamic" runat="server" ControlToValidate="Reason" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please Enter Reason" />
                                    
                           
                                    </div>
            </div>
              <br />
              <br />
               <br />

              <br />
              <br />
               <br />

              <br /><br />
               <br />

              <br />

              <div class="form-group" style="text-align:center">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnrequestleave" ValidationGroup="addprogramme" Text="Send Request" runat="server" OnClick="btnrequestleave_Click"/>
                                     
                                    </div>
            </div>
                  <br />
                  <br />
                  <br />
              </div>


              
            </div>
        </div>
    <script type="text/javascript">
        $(function () {
            $("#EmpNametxt").attr("readonly","readonly");

        })


    </script>

</asp:Content>

