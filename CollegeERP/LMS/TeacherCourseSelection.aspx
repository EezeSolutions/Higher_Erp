<%@ Page Title="" Language="C#" MasterPageFile="~/LMS/MasterPage.master" AutoEventWireup="true" CodeFile="TeacherCourseSelection.aspx.cs" Inherits="LMS_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading" ">Courses List</div>
        <div class="panel-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
    <div class="form-group">
        <label class="col-sm-3 control-label">Select Your Course:</label>
        <div class="col-sm-9">

            <asp:DropDownList AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropDownCourses_SelectedIndexChanged" CssClass="form-control" runat="server" ID="DropDownCourses">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="" ControlToValidate="DropDownCourses"
                CssClass="field-validation-error" Display="Static" ValidationGroup="addProgramme" ErrorMessage="Please Select Course" />
        </div>
    </div>
    <br />
    <br />
    <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
</asp:Content>

