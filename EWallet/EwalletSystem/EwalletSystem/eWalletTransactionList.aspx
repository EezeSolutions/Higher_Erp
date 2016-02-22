<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="eWalletTransactionList.aspx.cs" Inherits="Default2" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src="js/ASPSnippets_Pager.min.js"></script>
    <script type="text/javascript" src="js/jquery-migrate-1.2.1.min.js"></script>   
    <h2>
eWALLET Users
</h2>
    
    <%--<asp:GridView ID="gvewallet" runat="server" CssClass="user-profile" AutoGenerateColumns="false"
      Width="100%" BorderStyle="None" CellPadding="0" cellspacing="0">
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="Enumber" HeaderText="Enumber" />
        <asp:BoundField ItemStyle-Width="150px" DataField="CurrentBalance" HeaderText="CurrentBalance" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Address" HeaderText="Address" />
        <asp:BoundField ItemStyle-Width="150px" DataField="DateCreated" HeaderText="DateCreated" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Action" HeaderText="Action" />
        
    </Columns>
</asp:GridView>--%>
    

    <asp:ScriptManager runat="server" ID="scriptUpdate" EnablePageMethods="true" ></asp:ScriptManager>
     <asp:UpdatePanel runat="server" id="update1">
     <ContentTemplate>
         <div style="float:right" class="clearfix">
    <asp:TextBox ID="SearchButton" runat="server" ></asp:TextBox> 
    <a onclick="searchEnumber()" class="btn btn-brown"  >Search Enumber</a>&nbsp;&nbsp;&nbsp;<img id="loderImg" style="display:none" src="Images/ajax-loader.gif" />
    <br />
    <br />
             </div>
    
    <asp:GridView ID="GridView1"   runat="server" CssClass="user-profile" AutoGenerateColumns="false" Width="100%" BorderStyle="None" CellPadding="0" cellspacing="0">
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="Enumber" HeaderText="Enumber" />
        <asp:BoundField ItemStyle-Width="150px" DataField="CurrentBalance" HeaderText="CurrentBalance" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Address" HeaderText="Address" />
        <asp:BoundField ItemStyle-Width="150px" DataField="DateCreated" HeaderText="DateCreated" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Portal" HeaderText="Portal" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Action" HeaderText="Action" />
        
    </Columns>
</asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
  <br />
    <br />
<div class="Pager"></div> 
    <br />
    <br />
    <script type="text/javascript">



        $(function () {
            GeteWalletTransactions(1);
        });
        $(".Pager .page").live("click", function () {
            GeteWalletTransactions(parseInt($(this).attr('page')));
        });

        function onmanualSuccess(response) {
            document.getElementById("loderImg").style.display = "none";
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var transactions = xml.find("eWalletTransactionList");
            var row = $("[id*=GridView1] tr:last-child").clone(true);
            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
            $.each(transactions, function () {
                var transactions = $(this);

                var enumber = $(this).find("Enumber").text();
                var statusText = $(this).find("Status").text();


                if (statusText == "1") {

                    var tranNum =
                    tmpLink = "<a class=\"btn btn-success\" onclick=\"updateEUser('" + enumber + "','0');\">Activate </a>";
                }
                else {

                    tmpLink = "<a class=\"btn btn-danger\" onclick=\"updateEUser('" + enumber + "','1');\">De-Activate </a>";
                }

                $("td", row).eq(0).html($(this).find("Enumber").text());
                $("td", row).eq(1).html($(this).find("CurrentBalance").text());
                $("td", row).eq(2).html($(this).find("Name").text());
                $("td", row).eq(3).html($(this).find("Address").text());
                $("td", row).eq(4).html($(this).find("DateCreated").text());
                $("td", row).eq(5).html($(this).find("Portal").text());
                $("td", row).eq(6).html(tmpLink);
                $("[id*=GridView1]").append(row);
                row = $("[id*=GridView1] tr:last-child").clone(true);
                $(".Pager").hide();
            });

        }

        function searchEnumber() {
            document.getElementById("loderImg").style.display = "inline";
            var searchterm = document.getElementById('<%=SearchButton.ClientID %>').value;
            $.ajax({
                type: "POST",
                url: "eWalletTransactionList.aspx/searchterm",
                data: '{searchNu: "' + searchterm + '"}',
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


        function updateEUser(eUser, status) {
            var pageIndex;
            // alert(status);
            var pindex = $(this).attr('page');
            if (pageIndex == null) {

                pageIndex = 1;
            }
            else {
                pageIndex = parseInt($(this).attr('page'));

            }





            $.ajax({
                type: "POST",
                url: "eWalletTransactionList.aspx/changeUserStatus",
                data: '{enumber: "' + eUser + '", pageIndex: ' + pageIndex + ', status: "' + status + '"}',
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
        function GeteWalletTransactions(pageIndex) {
            $.ajax({
                type: "POST",
                url: "eWalletTransactionList.aspx/GeteWalletTransactions",
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
            var transactions = xml.find("eWalletTransactionList");

            //alert(response.d);



            var row = $("[id*=GridView1] tr:last-child").clone(true);
            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
            $.each(transactions, function () {

                var enumber = $(this).find("Enumber").text();
                var statusText = $(this).find("Status").text();

                //  alert(xml.text())   
                if (statusText == "1") {

                    var tranNum =
                    tmpLink = "<a class=\"btn btn-success\" onclick=\"updateEUser('" + enumber + "','0');\">Activate </a>";
                }
                else {

                    tmpLink = "<a class=\"btn btn-danger\" onclick=\"updateEUser('" + enumber + "','1');\">De-Activate </a>";
                }


                var transactions = $(this);
                $("td", row).eq(0).html($(this).find("Enumber").text());
                $("td", row).eq(1).html($(this).find("CurrentBalance").text());
                $("td", row).eq(2).html($(this).find("Name").text());
                $("td", row).eq(3).html($(this).find("Address").text());
                $("td", row).eq(4).html($(this).find("DateCreated").text());

                $("td", row).eq(5).html($(this).find("Portal").text());
                $("td", row).eq(6).html(tmpLink);

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

