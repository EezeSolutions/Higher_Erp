<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="eWalletHistory.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h2>
        eWallet History
</h2>
    

         <span class="btn btn-info" id="totalAmount"> </span>   &nbsp; &nbsp; &nbsp; &nbsp;  
              <span class="btn btn-info" id="totalRecords"> </span> &nbsp; &nbsp; &nbsp; &nbsp; 
            <span class="btn btn-info" id="totalTranscationFee"> </span>
     <asp:ScriptManager runat="server" ID="scriptUpdate" EnablePageMethods="true"></asp:ScriptManager>
     <asp:UpdatePanel runat="server" id="update1">
     <ContentTemplate>
         <div style="float:right" class="clearfix">
    <asp:TextBox ID="SearchButton" runat="server"></asp:TextBox> 
    <asp:Button runat="server" CssClass="btn btn-info" OnClientClick="document.getElementById('loderImg').style.display='inline';" OnClick="Button1_Click" Text="Search" /> &nbsp;&nbsp;&nbsp;<img id="loderImg" style="display:none" src="Images/ajax-loader.gif" />
    </div>
    <br />
    <br />
    
    <asp:GridView ID="GridView1" BorderStyle="Solid" runat="server"  AutoGenerateColumns="false" CssClass="user-profile" >
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="ewalletNumber" HeaderText="ewalletNumber" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Description" HeaderText="Description" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Amount" HeaderText="Amount" />
        <asp:BoundField ItemStyle-Width="150px" DataField="FeeType" HeaderText="Fee Type" />
        <asp:BoundField ItemStyle-Width="150px" DataField="TransasctionRef" HeaderText="TransactionRef" />
        <asp:BoundField ItemStyle-Width="150px" DataField="portal" HeaderText="portal" />
        
        <asp:BoundField ItemStyle-Width="150px" DataField="DateTime" HeaderText="Date Time" />
    </Columns>
</asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <div class="Pager"></div> 
    <br />
    <br />
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script src="ASPSnippets_Pager.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        GeteWalletHistory(1);
    });
    $(".Pager .page").live("click", function () {
        GeteWalletHistory(parseInt($(this).attr('page')));
    });
    function GeteWalletHistory(pageIndex) {
        $.ajax({
            type: "POST",
            url: "eWalletHistory.aspx/GeteWalletHistory",
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
        var records = xml.find("eWalletHistory");
        var tAmount = document.getElementById("totalAmount");

        var trecord = document.getElementById("totalRecords");

        var trtag = document.getElementById("totalTranscationFee");



        var row = $("[id*=GridView1] tr:last-child").clone(true);
        $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
        $.each(records, function () {
            var records = $(this);
            $("td", row).eq(0).html($(this).find("ewalletNumber").text());
            $("td", row).eq(1).html($(this).find("Description").text());
            $("td", row).eq(2).html($(this).find("Amount").text());
            $("td", row).eq(3).html($(this).find("FeeType").text());
            $("td", row).eq(4).html($(this).find("TransasctionRef").text());
            $("td", row).eq(5).html($(this).find("portal").text());
            $("td", row).eq(6).html($(this).find("DateTime").text());
            $("[id*=GridView1]").append(row);
            row = $("[id*=GridView1] tr:last-child").clone(true);
        });
        var pager = xml.find("Pager");

        var totaltranscationAmount = parseInt(pager.find("RecordCount").text()) * parseInt(300);
        tAmount.innerHTML = "Total Amount = " + pager.find("TotalAmount").text();
        trecord.innerHTML = "Total Records = " + pager.find("RecordCount").text();
        trtag.innerHTML = "Total Transaction Fee = " + totaltranscationAmount;


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

