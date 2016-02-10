<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentProfile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .user-row {
    margin-bottom: 14px;
}

.user-row:last-child {
    margin-bottom: 0;
}

.dropdown-user {
    margin: 13px 0;
    padding: 5px;
    height: 100%;
}

.dropdown-user:hover {
    cursor: pointer;
}

.table-user-information > tbody > tr {
    border-top: 1px solid rgb(221, 221, 221);
}

.table-user-information > tbody > tr:first-child {
    border-top: 0;
}


.table-user-information > tbody > tr > td {
    border-top: 0;
}
.toppad
{margin-top:20px;
}
    </style>
     
     
        
   
          <div class="panel panel-default">
        <div class="panel-heading" ><asp:Label ID="namelbl" runat="server"></asp:Label></div>
        <div class="panel-body">
            
          <div class="row">
                <div class="col-md-3 col-lg-3 " align="center"><asp:Label runat="server" ID="imglbl"></asp:Label>  </div>
                
                <!--<div class="col-xs-10 col-sm-10 hidden-md hidden-lg"> <br>
                  <dl>
                    <dt>DEPARTMENT:</dt>
                    <dd>Administrator</dd>
                    <dt>HIRE DATE</dt>
                    <dd>11/12/2013</dd>
                    <dt>DATE OF BIRTH</dt>
                       <dd>11/12/2013</dd>
                    <dt>GENDER</dt>
                    <dd>Male</dd>
                  </dl>
                </div>-->
                <div class=" col-md-9 col-lg-9 "> 
                  <table class="table table-user-information">
                    <tbody>
                      <tr>
                        <td>Programe:</td>
                        <td><asp:Label ID="programmelbl" runat="server"></asp:Label></td>
                      </tr>

                        <tr>
                        <td>Semester:</td>
                        <td><asp:Label ID="semesterlbl" runat="server"></asp:Label></td>
                      </tr>

                        <tr>
                        <td>Metric #:</td>
                        <td><asp:Label ID="metriclbl" runat="server"></asp:Label></td>
                      </tr>
                        <tr>
                        <td>Department:</td>
                        <td><asp:Label ID="deptlbl" runat="server"></asp:Label></td>
                      </tr>
                      
                      <tr>
                        <td>Date of Birth</td>
                        <td><asp:Label runat="server" ID="Doblbl"></asp:Label></td>
                      </tr>
                   
                         <tr>
                      <tr>
                        <td>Gender</td>
                        <td><asp:Label runat="server" ID="Genderlbl"></asp:Label></td>
                      </tr>
                        <tr>
                        <td>Home Address</td>
                        <td><asp:Label runat="server" ID="Addresslbl"></asp:Label></td>
                      </tr>
                      <tr>
                        <td>Email</td>
                        <td><a href=#0"><asp:Label runat="server" ID="Emaillbl"></asp:Label></a></td>
                      </tr>
                        <td>Phone Numbers</td>
                        <td><asp:Label runat="server" ID="phonenumberlbl"></asp:Label>
                        </td>
                         

                             <tr>
                        <td>State</td>
                        <td><asp:Label runat="server" ID="statelbl"></asp:Label></td>
                      </tr>
                          <tr>
                        <td>Local Government Area</td>
                        <td><asp:Label runat="server" ID="arealbl"></asp:Label></td>
                      </tr>
                             
                            
                      </tr>
                     
                    </tbody>
                  </table>
                  
                  
                </div>
              </div>
            </div>
                 <div class="panel-footer">
                        <a data-original-title="Broadcast Message" id="msgicon" data-toggle="tooltip" type="button" class="btn btn-sm btn-primary"><i class="glyphicon glyphicon-envelope"></i></a>
                        <span class="pull-right">
                            <a href="edit.html" data-original-title="Edit this user" data-toggle="tooltip" type="button" class="btn btn-sm btn-warning"><i class="glyphicon glyphicon-edit"></i></a>
                            <a data-original-title="Remove this user" data-toggle="tooltip" type="button" class="btn btn-sm btn-danger"><i class="glyphicon glyphicon-remove"></i></a>
                        </span>
                    </div>
            
          </div>
       <script type="text/javascript">
           $("#msgicon").click(function () {
               window.location="AskQuestion.aspx";
           });
       </script>
   
</asp:Content>

