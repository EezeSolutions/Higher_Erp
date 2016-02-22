<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="eWalletPaymentDepositApplication.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="imgLoad" style="display:none; position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/ajax-loader.gif" AlternateText="Please Wait ..." ToolTip="Please Wait ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    <h2>
eWALLET PAYMENT DEPOSIT APPLICATIONS
</h2>
 
<br />
<br />
    <br />
   

    <asp:ScriptManager runat="server" ID="scriptUpdate" EnablePageMethods="true"></asp:ScriptManager>
     <asp:UpdatePanel runat="server" id="update1">
     <ContentTemplate>
         <div style="float:right" class="clearfix">
    <asp:TextBox ID="SearchButton" runat="server"></asp:TextBox> 
    <%--<asp:Button ID="Button1" runat="server"  CssClass="btn btn-info" OnClientClick="searcheWallet();"  Text="Search" />--%>
    <a onclick="searcheWallet();" class="btn btn-brown" >Search Transcation</a> &nbsp;&nbsp;&nbsp;<img id="loderImg" style="display:none" src="Images/ajax-loader.gif" />
    </div>
    <br />
    <br />
    
    <asp:GridView ID="GridView1"  runat="server" CssClass="user-profile" AutoGenerateColumns="false">
     <Columns>

        <asp:BoundField ItemStyle-Width="150px" DataField="ImageName" HeaderText="Deposit/Slip" />
        <asp:BoundField ItemStyle-Width="150px" DataField="FormType" HeaderText="FormType" />
        <asp:BoundField ItemStyle-Width="150px" DataField="PaymentDate" HeaderText="PaymentDate" />
        <asp:BoundField ItemStyle-Width="150px" DataField="AmountPaid" HeaderText="AmountPaid" />
        <asp:BoundField ItemStyle-Width="150px" DataField="TransactionNo" HeaderText="TransactionNo" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Bankname" HeaderText="Bankname" />
        <asp:BoundField ItemStyle-Width="150px" DataField="OnlineBankAccountName" HeaderText="OnlineBankAccountName" />
        <asp:BoundField ItemStyle-Width="150px" DataField="BankTransactionNo" HeaderText="BankTransactionNo" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Status" HeaderText="Status" />

    </Columns>
</asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <div class="Pager"></div>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script src="ASPSnippets_Pager.min.js" type="text/javascript"></script>
<script type="text/javascript">


    $(function () {
        GeteWalletPayment(1);
    });
    $(".Pager .page").live("click", function () {
        GeteWalletPayment(parseInt($(this).attr('page')));
    });

    function onmanualSuccess(response) {
        document.getElementById("loderImg").style.display = "none";
        var xmlDoc = $.parseXML(response.d);

        var xml = $(xmlDoc);
        var transactions = xml.find("eWalletPaymentDepositApplication");
        var row = $("[id*=GridView1] tr:last-child").clone(true);
        $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
        $.each(transactions, function () {
            var transactions = $(this);
            var statusText = $(this).find("Status").text();
            alert(statusText)
            var trnum = $(this).find("TransactionNo").text();
            var tmpLink = $(this).find("TransactionNo").text();
            var userID = $(this).find("Enumber").text();
            var imagelink = $(this).find("ImageName").text();

            if (statusText == "Pending") {

                var tranNum =
                tmpLink = "<a class=\"btn btn-info\" onclick=\"updateDepositForm('" + trnum + "','" + userID + "');\">Verify Form</a>";
            }
            else {

                tmpLink = "<label class=\"btn btn-success\">Processed</label>";
            }
            if (imagelink.length > 0) {
                imagelink = "<a class=\"btn btn-info\" target=\"_blank\" href=\"http://88.150.227.83:8008/Students/depositSlipScans/" + imagelink + "\"> Show Slip</a>";
            }


            $("td", row).eq(0).html(imagelink);
            $("td", row).eq(1).html($(this).find("FormType").text());
            $("td", row).eq(2).html($(this).find("PaymentDate").text());
            $("td", row).eq(3).html($(this).find("AmountPaid").text());
            $("td", row).eq(4).html($(this).find("TransactionNo").text());
            $("td", row).eq(5).html($(this).find("Bankname").text());
            $("td", row).eq(6).html($(this).find("OnlineBankAccountName").text());
            $("td", row).eq(7).html($(this).find("BankTransactionNo").text());
            $("td", row).eq(8).html(tmpLink);

            $("[id*=GridView1]").append(row);
            row = $("[id*=GridView1] tr:last-child").clone(true);
        });
    }


    function updateDepositForm(trnum, userID) {

        var pageIndex;

        var pindex = $(this).attr('page');
        if (pageIndex == null) {

            pageIndex = 1;
        }
        else {
            pageIndex = parseInt($(this).attr('page'));

        }

        var delFlag = confirm('Are you Sure? Press OK to continue.');
        if (delFlag) {

            document.getElementById("imgLoad").style.display = "inline";
            $.ajax({
                type: "POST",
                url: "eWalletPaymentDepositApplication.aspx/depositFormUpdate",
                data: '{trnum: "' + trnum + '", userID: "' + userID + '",pageIndex: ' + pageIndex + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: OnSuccess_payment,
                failure: function (response) {
                    alert(response.d);
                    document.getElementById("imgLoad").style.display = "none";
                },
                error: function (response) {
                    alert(response.d);
                    document.getElementById("imgLoad").style.display = "none";
                }
            });
        }
    }

    function OnSuccess_payment(response) {

        document.getElementById("imgLoad").style.display = "none";

        var xmlDoc = $.parseXML(response.d);
        var xml = $(xmlDoc);
        var transactions = xml.find("eWalletPaymentDepositApplication");
        var row = $("[id*=GridView1] tr:last-child").clone(true);
        $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
        
        $.each(transactions, function () {
            var transactions = $(this);
            var statusText = $(this).find("Status").text();
            var trnum = $(this).find("TransactionNo").text();
            var tmpLink = $(this).find("TransactionNo").text();
            var userID = $(this).find("Enumber").text();
            var imagelink = $(this).find("ImageName").text();
            
            if (statusText == "Pending") {

                var tranNum =
                tmpLink = "<a class=\"btn btn-info\" onclick=\"updateDepositForm('" + trnum + "','" + userID + "');\">Verify Form</a>";
            }
            else {

                tmpLink = "<label class=\"btn btn-success\">Processed</label>";
            }
            if (imagelink.length > 0) {
                imagelink = "<a class=\"btn btn-info\" target=\"_blank\" href=\"http://88.150.227.83:8008/Students/depositSlipScans/" + imagelink + "\"> Show Slip</a>";
            }


            $("td", row).eq(0).html(imagelink);
            $("td", row).eq(1).html($(this).find("FormType").text());
            $("td", row).eq(2).html($(this).find("PaymentDate").text());
            $("td", row).eq(3).html($(this).find("AmountPaid").text());
            $("td", row).eq(4).html($(this).find("TransactionNo").text());
            $("td", row).eq(5).html($(this).find("Bankname").text());
            $("td", row).eq(6).html($(this).find("OnlineBankAccountName").text());
            $("td", row).eq(7).html($(this).find("BankTransactionNo").text());
            $("td", row).eq(8).html(tmpLink);

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



    }

    function GeteWalletPayment(pageIndex) {

        $.ajax({
            type: "POST",
            url: "eWalletPaymentDepositApplication.aspx/GeteWalletPayment",
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

    function searcheWallet() {
        document.getElementById("loderImg").style.display = "inline";
        var searchterm = document.getElementById('<%=SearchButton.ClientID %>').value;
        $.ajax({
            type: "POST",
            url: "eWalletPaymentDepositApplication.aspx/searchTran",
            data: '{searchterm: "' + searchterm + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onmanualSuccess,
            failure: function (response) {
                document.getElementById("loderImg").style.display = "none";
                alert(response.d);
            },
            error: function (response) {
                document.getElementById("loderImg").style.display = "none";
                alert(response.d);
            }
        });
    }

    function OnSuccess(response) {
        var xmlDoc = $.parseXML(response.d);
        var xml = $(xmlDoc);
        var transactions = xml.find("eWalletPaymentDepositApplication");
        var row = $("[id*=GridView1] tr:last-child").clone(true);
        $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
        $.each(transactions, function () {
            var transactions = $(this);
            var statusText = $(this).find("Status").text();
            var trnum = $(this).find("TransactionNo").text();
            var tmpLink = $(this).find("TransactionNo").text();
            var userID = $(this).find("Enumber").text();
            var imagelink = $(this).find("ImageName").text();
            
            if (statusText == "Pending") {

                var tranNum =
                tmpLink = "<a class=\"btn btn-info\" onclick=\"updateDepositForm('" + trnum + "','" + userID + "');\">Verify Form</a>";
            }
            else {

                tmpLink = "<label class=\"btn btn-success\">Processed</label>";
            }
            if (imagelink.length > 0) {
                imagelink = "<a class=\"btn btn-info\" target=\"_blank\" href=\"http://88.150.227.83:8008/Students/depositSlipScans/" + imagelink + "\"> Show Slip</a>";
            }


            $("td", row).eq(0).html(imagelink);
            $("td", row).eq(1).html($(this).find("FormType").text());
            $("td", row).eq(2).html($(this).find("PaymentDate").text());
            $("td", row).eq(3).html($(this).find("AmountPaid").text());
            $("td", row).eq(4).html($(this).find("TransactionNo").text());
            $("td", row).eq(5).html($(this).find("Bankname").text());
            $("td", row).eq(6).html($(this).find("OnlineBankAccountName").text());
            $("td", row).eq(7).html($(this).find("BankTransactionNo").text());
            $("td", row).eq(8).html(tmpLink);

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

