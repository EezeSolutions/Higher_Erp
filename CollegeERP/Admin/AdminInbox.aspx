<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminInbox.aspx.cs" Inherits="Admin_Default" %>

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
             <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="Updatepanel1" runat="server" EnableViewState="true" UpdateMode="Conditional">
                    <ContentTemplate>
                      
            <table class="table table-responsive">
                <tr class="blue-background"><th>From</th><th>Subject</th><th>Date</th></tr>
               
                <asp:Label ID="Inboxttbl" runat="server"></asp:Label>
                     

            </table>
     
                    </ContentTemplate>
                    <Triggers>
      <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
   </Triggers>
                        </asp:UpdatePanel>

              <asp:Timer ID="timer1" runat="server" Enabled="true" Interval="5000" OnTick="timer1_Tick"></asp:Timer>
            <br />
            <br />
            <div style="text-align:center"><asp:Label ID="Paging" CssClass="pagination" runat="server"></asp:Label></div>


        </div>    
        </div>
        </div>
    <script type="text/javascript">
        $(function () {

            $(document).on("click", ".read", function () {


                var mailid = $(this).data("mailid");
                //alert(mailid);
                window.location="reademail.aspx?mailid="+mailid;



            })


        })

    </script>
    
</asp:Content>

