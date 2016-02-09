<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ManagePrograms.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
    ..hide {
  display: none !important;
}
.show {
  display: block !important;
}
.btn-action{
    font-size:9px;
    padding:5px;
}
</style>
       <div class="panel panel-default">
        <div class="panel-heading" ">Manage Programmes</div>
        <div class="panel-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-responsive "><tr class="blue-background"><th>Programme</th><th>Programme Type:</th><th>Department</th><th>Application Fee</th><th>Acceptence Fee</th><th>Action</th></tr>
                        <asp:Label ID="programstbl" runat="server" Text=""></asp:Label>
                                </table>
                            </div>

                        <br />
                        <br />
                        <div class="col-sm-12">
                        <div style="float:right">
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Create Program</a>
                        </div>
                            </div>
                        </div>

                    <br />
                    <br />
            <div id="nameDiv" class="hide">
                
          <div class="row ">

                <div class="form-group">
                                    <label class="col-sm-3 control-label">Department:</label>
                                    <div class="col-sm-9">
                                    
                                      <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="DropDownDept">
                                     
                                       

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="" ControlToValidate="DropDownDept"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Department " />      
                                    </div>
            </div>
              <br />
              <br />
               <br />
                 <div class="form-group">
                                    <label class="col-sm-3 control-label">Programme Name:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="ProgrammeNametxt" placeholder="Please enter your Programme Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="ProgrammeNametxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Programme Name" />
                                    
                                    </div>
            </div>
              <br />
              <br />
               <br />
              
           <div class="form-group">
               <label class="col-sm-3 control-label">Second Choice:</label>
              <div class="col-sm-9">
                  <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="dropdownSecondChoise">
                                     <asp:ListItem Text="Select Option" Value=""></asp:ListItem>
                                       <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="No" Value="0"></asp:ListItem>

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="" ControlToValidate="dropdownSecondChoise"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Second Choice Option" />      
               </div>
               </div>
             
               <br />
               <br />
                <br />

               <div class="form-group">
                                    <label class="col-sm-3 control-label">Cut Off Points:</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="Cuttofpointstxt" placeholder="Please enter  Cut Off Points"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                                     Display="Dynamic" runat="server" ControlToValidate="Cuttofpointstxt" ValidationGroup="addprogramme" CssClass="field-validation-error" ErrorMessage="Please enter Cut Off Points" />
                                    
                                    </div>
            </div>
              <br />
               <br />
                <br />
             <div class="form-group">
               <label class="col-sm-3 control-label">Has Campus:</label>
              <div class="col-sm-9">
              <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="dropdownCampus">
                                     <asp:ListItem Text="Select Option" Value=""></asp:ListItem>
                                       <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="No" Value="0"></asp:ListItem>

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="" ControlToValidate="dropdownCampus"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Campus Option" />
               </div>
               </div>
              
             
              <br />
               <br />
                <br />
              <div class="form-group">
               <label class="col-sm-3 control-label">Application Fee:</label>
              <div class="col-sm-9">
              <asp:TextBox runat="server" placeholder="Please enter application Fee" CssClass="form-control" ID="txtApplicationFee" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtApplicationFee"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Application Fee is Required" />             
               </div>
               </div>
              
               <br />
               <br />
                <br />

                <div class="form-group">
               <label class="col-sm-3 control-label">Acceptence Fee:</label>
              <div class="col-sm-9">
              <asp:TextBox runat="server" placeholder="Please enter Acceptence Fee" CssClass="form-control" ID="txtAcceptenceFee" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtAcceptenceFee"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Acceptence Fee is Required" />             
               </div>
               </div>
              
               <br />
               <br />
                <br />
              <div class="form-group">
               <label class="col-sm-3 control-label">Starting Form Character:</label>
              <div class="col-sm-9">
               <asp:TextBox runat="server" placeholder="Please enter starting Form Char (BH,AB etc)" CssClass="form-control" ID="txtFormCh" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFormCh"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Starting Form Character is Required" />
                                                  
               </div>
               </div>
              <br />
               <br />
                <br />
                <div class="form-group">
                                    <label class="col-sm-3 control-label">Starting Form# </label>
                                    <div class="col-sm-9">
                                     <asp:TextBox runat="server" placeholder="Please enter starting Form number (1234,345,1111 etc)" CssClass="form-control" ID="txtFormNum" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFormNum"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Starting Form Num is Required" />
                                    </div>
                                </div>
              <br />
               <br />
                <br />
              <div class="form-group">
               <label class="col-sm-3 control-label">Programme Type:</label>
              <div class="col-sm-9">
               <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="dropdownPrograms">
                                     <asp:ListItem Text="Select Program Type" Value=""></asp:ListItem>
                                     <asp:ListItem Text="Full-Time" Value="Full-Time"></asp:ListItem>
                                     <asp:ListItem Text="Part-Time" Value="Part-Time"></asp:ListItem>

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="" ControlToValidate="dropdownPrograms"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Program Type" />
                                              
               </div>
               </div>
              <br />
               <br />
                <br />
              <div class="form-group">
               <label class="col-sm-3 control-label">Has Jamb Data:</label>
              <div class="col-sm-9">
                <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="dropdownJamb">
                                     <asp:ListItem Text="Select Option" Value=""></asp:ListItem>
                                     <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="No" Value="0"></asp:ListItem>

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="" ControlToValidate="dropdownJamb"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Jamb Data Option" />
                                                     
               </div>
               </div>
              <br />
               <br />
                <br />
              <div class="form-group">
               <label class="col-sm-3 control-label">Has Bio Data Section:</label>
              <div class="col-sm-9">
                <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="dropdownBioData">
                                     <asp:ListItem Text="Select Option" Value=""></asp:ListItem>
                                       <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="No" Value="0"></asp:ListItem>

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" InitialValue="" ControlToValidate="dropdownBioData"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Bio Data Section Option" />               
               </div>
               </div>
              <br />
               <br />
                <br />
              <div class="form-group">
               <label class="col-sm-3 control-label">Has Previous Record:</label>
                  <div class="col-sm-9">
                    <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="dropdownPreviousRecord">
                                     <asp:ListItem Text="Select Option For Previous Academic Record" Value=""></asp:ListItem>
                                      <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="No" Value="0"></asp:ListItem>

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" InitialValue="" ControlToValidate="dropdownPreviousRecord"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Select Option For Previous Academic Record" />
                                    
                  </div>
               </div>
              
               <br />
               <br />
                <br />

            <div class="form-group">
               <label class="col-sm-3 control-label">Has CBT Schedule:</label>
                  <div class="col-sm-9">
                       <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="dropdownCbtSchedule">
                                     <asp:ListItem Text="Select Option" Value=""></asp:ListItem>
                                      <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="No" Value="0"></asp:ListItem>

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" InitialValue="" ControlToValidate="dropdownCbtSchedule"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select CBT Schedule" ></asp:RequiredFieldValidator>
                                  
                  </div>
               </div>
              
               <br />
               <br />
                <br />
               <div class="form-group">
               <label class="col-sm-3 control-label">Has O'Level Result:</label>
                  <div class="col-sm-9">
                      <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" runat="server" ID="dropdownOlevel">
                                     <asp:ListItem Text="Select Option" Value=""></asp:ListItem>
                                      <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="No" Value="0"></asp:ListItem>

                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" InitialValue="" ControlToValidate="dropdownOlevel"
                                    CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select O'Level Result Option" />
                            
                  </div>
               </div>
              
               <br />
               <br />
                <br />
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-3 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <asp:Button Class="btn btn-block btn-primary" ID="btnaddprogramme" ValidationGroup="addProgramme" Text="Create Programme" runat="server" OnClick="btnaddprogramme_Click" />
                                     
                                    </div>
            </div>
          </div>
                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </div>
      </div>

    <script type="text/javascript">
        function showHide_Div(tag) {
            var tagitem = document.getElementById(tag);
           
            if (tagitem.className == "hide") {
                tagitem.className = "show";
            }
            else { tagitem.className = "hide"; }
        }

        $(function () {
            $(".btn-action").click(function () {

                var action = $(this).attr("class").split(" ")[3];
                var id = $(this).data("id");

                if (action == "Disable" || action == "Enable") {
                    var res = confirm("Are You Sure? Press OK to continue.....")
                    if (res == false)
                        return;
                }
                window.location = "updateprogramme.aspx?Programmeid=" + id + "&action=" + action;

            });



        })
    </script>
</asp:Content>

