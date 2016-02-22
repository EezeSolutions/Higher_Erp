<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="eWallet_invalid_payment_attempts.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2 style="margin-left: 0px">
eWALLET INVALID PAYMENT ATTEMPTS
</h2>
<div class="Pager"></div> 
<br />
<br />
    <br />

    <asp:ScriptManager runat="server" ID="scriptUpdate" EnablePageMethods="true"></asp:ScriptManager>
     <asp:UpdatePanel runat="server" id="update1">
     <ContentTemplate>
         <div class="clearfix" style="float:right">
    <asp:TextBox ID="SearchButton" runat="server"></asp:TextBox> 
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-brown" OnClientClick="document.getElementById('loderImg').style.display='inline';" OnClick="Button1_Click" Text="Search" /> &nbsp;&nbsp;&nbsp;<img id="loderImg" style="display:none" src="Images/ajax-loader.gif" />
    <br />
    <br />
         </div>

    
    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="false" CssClass="user-profile" Width="100%">
    <Columns>
       <asp:BoundField ItemStyle-Width="150px" DataField="Portal" HeaderText="Portal" />
        <asp:BoundField ItemStyle-Width="150px" DataField="eNumber" HeaderText="eNumber" />
        <asp:BoundField ItemStyle-Width="150px" DataField="FeeType" HeaderText="FeeType" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Amount" HeaderText="Amount" />
        <asp:BoundField ItemStyle-Width="150px" DataField="txref" HeaderText="txref" />
        <asp:BoundField ItemStyle-Width="150px" DataField="TriedDate" HeaderText="TriedDate" />
        
    </Columns>
</asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>


<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script src="ASPSnippets_Pager.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        GeteWallet_invalid_payment_attempts(1);
    });
    $(".Pager .page").live("click", function () {
        GeteWallet_invalid_payment_attempts(parseInt($(this).attr('page')));
    });
    function GeteWallet_invalid_payment_attempts(pageIndex) {
        $.ajax({
            type: "POST",
            url: "eWallet_invalid_payment_attempts.aspx/GeteWallet_invalid_payment_attempts",
            data: '{pageIndex: ' + pageIndex + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    }

    function OnSuccess(response) {
        var xmlDoc = $.parseXML(response.d);
        var xml = $(xmlDoc);
        var attempts = xml.find("eWallet_invalid_payment_attempts");
        var row = $("[id*=GridView1] tr:last-child").clone(true);
        $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
        $.each(attempts, function () {
            var attempts = $(this);
            $("td", row).eq(0).html($(this).find("Portal").text());
            $("td", row).eq(1).html($(this).find("eNumber").text());
            $("td", row).eq(2).html($(this).find("FeeType").text());
            $("td", row).eq(3).html($(this).find("Amount").text());
            $("td", row).eq(4).html($(this).find("txref").text());
            $("td", row).eq(5).html($(this).find("TriedDate").text());
            $("[id*=GridView1]").append(row);
            row = $("[id*=GridView1] tr:last-child").clone(true);
        });
        var pager = xml.find("Pager");
        $(".Pager").ASPSnippets_Pager({
            ActiveCssClass: "current",
            PagerCssClass: "pager",
            PageIndex: parseInt(pager.find("PageIndex").text()),
            PageSize: parseInt(pager.find("PageSize").text()),
            RecordCount: parseInt(pager.find("RecordCount").text())
        });
    };
</script>

</asp:Content>

