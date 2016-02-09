<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewResult.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div class="panel panel-default">
        <div class="panel-heading" >View Result</div>
        <div class="panel-body">
            
          <div class="row">
             
                    <div class="form-group">
               <label class="col-sm-2 control-label">Select Exam Term:</label>
              <div class="col-sm-9">
                <asp:DropDownList AutoPostBack="true"  CssClass="form-control" OnSelectedIndexChanged="dropdownterm_SelectedIndexChanged" AppendDataBoundItems="true" runat="server" ID="dropdownterm">
                     <asp:ListItem Value="" Text="--Select Exam Term--"></asp:ListItem>
                                                                       
                     <asp:ListItem Value="Mid" Text="Mid Term"></asp:ListItem>
                     <asp:ListItem Value="Final" Text="Final Term"></asp:ListItem>

                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" InitialValue="" ControlToValidate="dropdownterm"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Select Term" />
                   
               </div>
               </div>
             
               <br />
               <br />
                <br />
                                  
           
             <table class="table table-responsive" >

                 <asp:Label ID="Resultlbl" runat="server"></asp:Label>
                 </table>

              <asp:Label ID="Totalmarkslbl" runat="server"></asp:Label>
              </div>
            
        </div>
    </div>
</asp:Content>

