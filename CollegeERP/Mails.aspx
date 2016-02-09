<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Mails.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <style type="text/css">
        .read-mail{
            background:#e3efff;
            cursor:pointer;
            
        }
        .new-mail{
            font-weight:bold;
            cursor:pointer;
        }
        
    </style>
    <div class="panel panel-default">
        <div class="panel-heading" ">Inbox</div>
        <div class="panel-body">
        <div class="row">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Timer ID="Timer1" runat="server" Interval="2500" OnTick="Timer1_Tick"></asp:Timer>
            <asp:UpdatePanel ID="UpdatePanel1"  runat="server">
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
                <ContentTemplate>
             <table class="table table-responsive">
                <tr class="blue-background"><th>From</th><th>Subject</th><th>Date</th></tr>
                <asp:Label ID="Inboxttbl" runat="server"></asp:Label>


            </table>

            <br />
            <br />
</ContentTemplate>
</asp:UpdatePanel>
            <div style="text-align:center"><asp:Label ID="Paging" CssClass="pagination" runat="server"></asp:Label></div>

        </div>    
        </div>
        </div>
    <script type="text/javascript">
        $(function () {

            $(document).on("click", ".read", function () {


                var mailid = $(this).data("mailid");
                //alert(mailid);
                window.location = "reademail.aspx?mailid=" + mailid;



            })


        })

    </script>
</asp:Content>

