<%@ Page Title="" Language="C#" MasterPageFile="~/LMS/MasterPage.master" AutoEventWireup="true" CodeFile="StudentAcademicRecord.aspx.cs" Inherits="LMS_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="panel panel-default">
        <div class="panel-heading" >Student Record:</div>
        <div class="panel-body">
            
          <div class="row">
               <div class="col-sm-12">
       <div class="col-sm-offset-10 col-sm-2 text-right"><Button ID="Print_btn" runat="server" Class="btn btn-primary"  onserverclick="Print_btn_Click"><i class="fa fa-print"></i> Print</Button></div>
                                 
                   
                   <asp:Label ID="Recordlbl" runat="server" ></asp:Label>                     
                  
                                        
                                        </div>
              
              </div>

            </div>
         </div>
</asp:Content>

