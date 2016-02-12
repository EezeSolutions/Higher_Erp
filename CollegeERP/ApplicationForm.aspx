<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApplicationForm.aspx.cs" Inherits="ApplicationForm" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <script type="text/javascript">

          function alertNew(mgd, status) {
              alert(mgd);
              if (status == "0") {
                  window.location = "ProfilePage.aspx";
              }
          }
          function uploadStarted(sender, args) {


              $get("imgDisplay").style.display = "none";

          }

          function onUploadError(sender, args) {
              alert(args.get_errorMessage());
          }

          function uploadComplete(sender, args) {

              var fileName = args.get_fileName();
              var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1);

              var imgTagHidden = document.getElementById('<%= hidden_dpImage.ClientID %>');

            if (fileExtension == 'png' || fileExtension == 'jpg' || fileExtension == 'PNG' || fileExtension == 'JPG') {

                if (args.get_length() > 2000000) {
                    alert("Max file size of 2MB is allowed");
                    var fu = document.getElementById("AsyncFileUpload1_ctl04");
                    fu.value = "";
                    imgTagHidden.value = "";
                    return false;
                }
                else {
                    var imgDisplay = $get("imgDisplay");
                    imgDisplay.src = "images/loader.gif";

                    var path = '<%=FllUploadFolderPath %>';
                imgDisplay.src = path + args.get_fileName();
                imgDisplay.style.display = "inline";
                imgTagHidden.value = args.get_fileName();


            }
        }
        else {
            alert("Only PNG and JPG Files are supported !");
            imgTagHidden.value = "";
            var fu = document.getElementById("AsyncFileUpload1_ctl04");
            fu.value = "";
            return false;
        }
    }
    </script>



</asp:Content>

