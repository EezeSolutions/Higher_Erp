<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DiscussionTopic.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="panel panel-default">
        <div class="panel-heading" >Discussion Topics:</div>
        <div class="panel-body">

          <div class="row">
              <table class="table table-responsive">
                  <tr class="blue-background "><th>Topic</th><th>Last Updated</th></tr>
            <asp:Label ID="discussionstxt" runat="server"></asp:Label>
                  </table>
              <div class="col-sm-12">
                        <div style="float:right">
                            <a class="btn btn-default" onclick="showHide_Div('nameDiv');">Start New Discussion</a>
                        </div>
                            </div>
              <br />
              <br />
                <div id="nameDiv" class="hide">

    <div class="row ">
      
    <div class="col-lg-12">
        <div class="form-group">
                    <label class="col-sm-3 ">Topic: </label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="Topictxt" CssClass="form-control" placeholder="Enter Topic" runat="server" ></asp:TextBox>
                </div></div>
        <br /> <br /><br /> <br /><br /> <br />
  
         <div class="form-group">
             <label class="col-sm-3 control-label"></label>
             <div class="col-sm-9">
      <asp:Button ID="TopicBtn" CssClass="btn btn-brown btn-block" runat="server" Text="Submit" OnClick="TopicBtn_Click"/>
      
     
    </div>
 
  </div>
            </div>
        </div>
                </div>
              </div>
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

         
    </script>
</asp:Content>

