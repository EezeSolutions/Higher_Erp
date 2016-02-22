<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApplicationForm.aspx.cs" Inherits="ApplicationForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <script type="text/javascript">

       function alertNew(mgd, status) {
           alert(mgd);
           if (status == "0") {
               window.location = "ProfilePage.aspx";
           }
       }
       function uploadStarted(sender, args) {


           $get("ContentPlaceHolder1_imgDisplay").style.display = "none";

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
                    var imgDisplay = $get("ContentPlaceHolder1_imgDisplay");
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
 
    
         
               <asp:ScriptManager runat="server"></asp:ScriptManager>
      
        <div class="middle-content">
            <div class="main-container">
                <div class="panel panel-default">
             <div class="panel-heading">APPLICATION FORM </div>
               
                
                <asp:UpdateProgress runat="server" ID="panelProgress" AssociatedUpdatePanelID="updateMainPanel">
                    <ProgressTemplate>

                         <div id="loadingGif" style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: none;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/loader.gif" AlternateText="Performing Selected Action, Please Wait ..."  style="padding: 10px;position:fixed;top:45%;left:50%;" />
          </div>

                    </ProgressTemplate>
                    
                </asp:UpdateProgress>
                    </div>
                <div class="panel panel-default">
                <asp:UpdatePanel runat="server" ID="updateMainPanel">
                    <ContentTemplate>

                        <div class="row">
                            <div class="col-lg-12" style="min-height:426px">
                                <input type="hidden" runat="server" id="hidden_dpImage" />
                                <div class="panel panel-default">
                                  
                                    <div class="panel-body" style="padding:0px">

                                        <div class="progress" id="progressBar" style="height:30px" runat="server">

                                            <%--<div aria-valuemax="100" aria-valuemin="0"  role="progressbar" class="progress-bar progress-bar-striped active" style="width: 100%;font-size:20px;">100%</div>--%>
                                        </div>

                                        <asp:UpdatePanel runat="server" ID="update">
                                            <Triggers>

                                                <%--<asp:AsyncPostBackTrigger ControlID="nextBtn"  EventName="Click"/>--%>
                                            </Triggers>
                                            <ContentTemplate>
                                                
                                                <asp:Panel ID="HasJambData" runat="server" Visible="false">
                                                    <div class="loginPanel" style="width: 850px;min-height:300px">
                                                        <%--<div class="site-logo text-center"><img src="../Images/logo.jpg" /></div>--%>
                                                        <br />
                                                        <h2 class="panel-heading" style="background: #293a4a;
                                                color: #FFF;">The Polytechnic Ibadan Application Form - JAMB-UTME Examination</h2>
                                                        <br />


                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Reg No</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" runat="server" ID="txtJambRegNo" placeholder="Enter JAMB Registration number"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtJambRegNo"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="The Registration # is required." />
                                                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="field-validation-error" ID="RegularExpressionValidator1" runat="server"
                                                                        ValidationExpression="(?=^.{10}$)[0-9a-zA-Z]*$"
                                                                        ControlToValidate="txtJambRegNo" ValidationGroup="appForm" ErrorMessage="JAMB Reg# should be 10 characters  <br/>"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">UTME Score</label>
                                                                <div class="col-sm-8">
                                                                    <%--<asp:TextBox CssClass="form-control"  runat="server" ID="txtJambUtmeScore1" placeholder="Enter JAMB Score 1 - 4 (0 - 400)"></asp:TextBox>--%>
                                                                    <input type="text" style="text-align: center" class="form-control" runat="server" readonly="true" id="txtJambUtmeScore" placeholder="Your JAMB Score 1 - 4 (0 - 400)" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtJambUtmeScore"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="JAMB UTME Score is required." />
                                                                    <%--<asp:RegularExpressionValidator Display="Dynamic" CssClass="field-validation-error" ID="RegularExpressionValidator2" runat="server"
                                                                        ValidationExpression="(400)|[1-9]\d?"
                                                                        ControlToValidate="txtJambUtmeScore" ValidationGroup="appForm" ErrorMessage="UTME Score should be between 0- 400  <br/>"></asp:RegularExpressionValidator>--%>
                                                                </div>
                                                            </div>


                                                        </div>

                                                        <asp:SqlDataSource ID="sqlsourceJamb_Subjects" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Application_JambSubjects]"></asp:SqlDataSource>
                                                        <br />
                                                        <br />
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Subject 1</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="true"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="dropdownSubject1_SelectedIndexChanged" DataSourceID="sqlsourceJamb_Subjects" DataTextField="SubjectName" DataValueField="ID"
                                                                        CssClass="form-control" runat="server" ID="dropdownSubject1">
                                                                        <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="" ControlToValidate="dropdownSubject1"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="Select subject 1" />
                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Score 1</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="txtscore4_TextChanged" Style="text-align: center" ID="txtScore1" placeholder="(0 - 100) Strict  - Numeric" class="form-control"></asp:TextBox>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtScore1"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="Score 1 is required." />

                                                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="field-validation-error" ID="RegularExpressionValidator5" runat="server"
                                                                        ValidationExpression="(100)|[0-9]\d?"
                                                                        ControlToValidate="txtScore1" ValidationGroup="appForm" ErrorMessage=" Score should be between 0- 100  <br/>"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>


                                                        </div>

                                                        <br />
                                                        <br />
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Subject 2</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="true"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="dropdownSubject2_SelectedIndexChanged" DataSourceID="sqlsourceJamb_Subjects" DataTextField="SubjectName" DataValueField="ID"
                                                                        CssClass="form-control" runat="server" ID="dropdownSubject2">
                                                                        <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="" ControlToValidate="dropdownSubject2"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="Select subject 2" />
                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Score 2</label>
                                                                <div class="col-sm-8">

                                                                    <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="txtscore4_TextChanged" Style="text-align: center" ID="txtscore2" placeholder="(0 - 100) Strict  - Numeric" class="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtscore2"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="Score 2 is required." />


                                                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="field-validation-error" ID="RegularExpressionValidator6" runat="server"
                                                                        ValidationExpression="(100)|[0-9]\d?"
                                                                        ControlToValidate="txtscore2" ValidationGroup="appForm" ErrorMessage=" Score should be between 0- 100  <br/>"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>


                                                        </div>

                                                        <br />
                                                        <br />
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Subject 3</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="dropdownSubject3_SelectedIndexChanged" DataSourceID="sqlsourceJamb_Subjects" DataTextField="SubjectName" DataValueField="ID"
                                                                        runat="server" ID="dropdownSubject3">
                                                                        <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="" ControlToValidate="dropdownSubject3"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="Select subject 3" />
                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Score 3</label>
                                                                <div class="col-sm-8">

                                                                    <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="txtscore4_TextChanged" Style="text-align: center" ID="txtscore3" placeholder="(0 - 100) Strict  - Numeric" class="form-control"></asp:TextBox>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtscore3"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="Score 3 is required." />

                                                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="field-validation-error" ID="RegularExpressionValidator7" runat="server"
                                                                        ValidationExpression="(100)|[0-9]\d?"
                                                                        ControlToValidate="txtscore3" ValidationGroup="appForm" ErrorMessage=" Score should be between 0- 100  <br/>"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>


                                                        </div>

                                                        <br />
                                                        <br />
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Subject 4</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList OnSelectedIndexChanged="dropdownSubject4_SelectedIndexChanged" AppendDataBoundItems="true"
                                                                        AutoPostBack="true" DataSourceID="sqlsourceJamb_Subjects" DataTextField="SubjectName" DataValueField="ID"
                                                                        CssClass="form-control" runat="server" ID="dropdownSubject4">
                                                                        <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" InitialValue="" ControlToValidate="dropdownSubject4"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="Select subject 4" />
                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Score 4</label>
                                                                <div class="col-sm-8">

                                                                    <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="txtscore4_TextChanged" Style="text-align: center" ID="txtscore4" placeholder="(0 - 100) Strict  - Numeric" class="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtscore4"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="Score 4 is required." />

                                                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="field-validation-error" ID="RegularExpressionValidator8" runat="server"
                                                                        ValidationExpression="(100)|[0-9]\d?"
                                                                        ControlToValidate="txtscore4" ValidationGroup="appForm" ErrorMessage=" Score should be between 0- 100  <br/>"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>


                                                        </div>

                                                        <br />
                                                        <br />
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Choice of Polytechnic</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList DataSourceID="sourceInstitutions_Jamb" DataTextField="InstitutionName"
                                                                        DataValueField="ID" AppendDataBoundItems="True" CssClass="form-control" runat="server" ID="dropdownJambchoice">
                                                                        <asp:ListItem Text="Select Institution" Value=""></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:SqlDataSource ID="sourceInstitutions_Jamb" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Application_JambInstitutions]"></asp:SqlDataSource>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" InitialValue="" ControlToValidate="dropdownJambchoice"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="Select JAMB Choice of Polytechnic" />

                                                                </div>
                                                            </div>





                                                        </div>


                                                    </div>
                                                    <%-- <hr />
              <div class="row">

                  
              <div class="form-group">
                   <div class="col-lg-12">

                     <label class="col-sm-4 control-label"></label>
                       
                        <div class="col-sm-4">
                                    
                                        <asp:Button runat="server" ID="Button1" Width="220px" CssClass="btn btn-brown"  ValidationGroup="appForm" OnClick="saveinfo_Click"  Text="Save & Continue"/>

                                    </div>
                                    
                       <div class="col-sm-4">
                                    
                                        <asp:Button runat="server" ID="nextBtn" Width="220px" CssClass="btn btn-brown"  ValidationGroup="appForm" OnClick="nextBtn_Click"  Text="Next"/>

                                    </div>
                       
                </div>
                  </div>

              </div>--%>
                                                </asp:Panel>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <asp:UpdatePanel runat="server" ID="updatePanel_StudentBio">


                                            <ContentTemplate>
                                                <asp:Panel ID="HasBioDataSection" runat="server" Visible="false">
                                                    <!-- Modal -->
                                                    <div class="loginPanel" style="width: 850px;min-height:300px">
                                                        <%--<div class="site-logo text-center"><img src="../Images/logo.jpg" /></div>--%>
                                                        <br />
                                                        <h2 class="panel-heading" style="background: #293a4a;
                                                color: #FFF;">The Polytechnic Ibadan Application Form - JAMB-UTME Examination</h2>
                                                        <br />


                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Surname</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" MaxLength="30" runat="server" ID="txtSurname" placeholder="Enter Surname"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtSurname"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Surname is required." />

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">First Name</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" MaxLength="30" runat="server" ID="txtFirstName" placeholder="Enter First Name"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFirstName"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="First Name is required." />

                                                                </div>
                                                            </div>



                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Other Name</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" MaxLength="30" runat="server" ID="txtOtherName" placeholder="Enter Other Name"></asp:TextBox>
                                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtOtherName"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Other Name is required." />--%>

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Gender</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="True" CssClass="form-control" runat="server" ID="dropdownGender">
                                                                        <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" InitialValue="" ControlToValidate="dropdownGender"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Gender is required" />

                                                                </div>
                                                            </div>



                                                        </div>


                                                        <br />
                                                        <br />
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Date of Birth</label>
                                                                <div class="col-sm-2">

                                                                    <asp:DropDownList runat="server" ID="dropdownDay">
                                                                    </asp:DropDownList>


                                                                </div>
                                                                <div class="col-sm-2">

                                                                    <asp:DropDownList runat="server" ID="dropdownMonth">

                                                                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                                                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                                                        <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                                                        <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                                                        <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                                                        <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                                                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                                        <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                                        <asp:ListItem Value="12" Text="12"></asp:ListItem>

                                                                    </asp:DropDownList>


                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <asp:DropDownList runat="server" ID="dropdownyears">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Phone Number</label>
                                                                <div class="col-sm-8">
                                                                    <input type="text" style="text-align: center" class="form-control" runat="server" id="txtPhonenumber" placeholder="(11-13 Max) e.g. 2348133356895" />

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtPhonenumber"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Phone number is required." />

                                                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="field-validation-error" ID="RegularExpressionValidator3" runat="server"
                                                                        ValidationExpression="^[0-9]{11,13}$"
                                                                        ControlToValidate="txtPhonenumber" ValidationGroup="appForm_biodata" ErrorMessage="Only 11-13 digits allowed  <br/>"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>




                                                        </div>

                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Email Address</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" MaxLength="40" runat="server" ID="txtEmail" placeholder="Enter EmailAddress"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtEmail"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Email address is required." />
                                                                    <asp:RegularExpressionValidator Display="Static" ValidationGroup="appForm_biodata" ID="regexEmailValid" runat="server"
                                                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                        ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" CssClass="field-validation-error"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Home Address</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" Height="43px" Rows="2" TextMode="MultiLine" MaxLength="50" runat="server" ID="txtHomeaddress" placeholder="Enter Home Address"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtHomeaddress"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Home address is required." />


                                                                </div>
                                                            </div>



                                                        </div>

                                                        <br />
                                                        <br />
                                                        <br /><br /><br />
                                                        <div class="form-group">
                                                            
                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">State of Origin</label>

                                                                <div class="col-sm-8">

                                                                   <%-- <asp:SqlDataSource ID="sqlDatasource_STO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Application_States] where status = 0 "></asp:SqlDataSource>--%>

                                                                    <asp:DropDownList OnSelectedIndexChanged="dropdownSto_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" AppendDataBoundItems="true" DataTextField="State" DataValueField="ID" runat="server" ID="dropdownSto">
                                                                        <asp:ListItem Value="" Text="Select STO"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" InitialValue="" ControlToValidate="dropdownSto"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Select State of Origin" />

                                                                </div>

                                                            </div>
                                                                <div class="col-lg-6">
                                                                </div>

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Local Govt Area</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList CssClass="form-control" AppendDataBoundItems="true" runat="server" ID="dropdownLocalGovtarea">
                                                                        <asp:ListItem Value="" Text="Select Local Government Area"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" InitialValue="" ControlToValidate="dropdownLocalGovtarea"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_biodata" ErrorMessage="Select Local Government Area" />

                                                                </div>
                                                            </div>




                                                        </div>

                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Upload Picture</label>
                                                                <div class="col-sm-8">

                                                                    <%--   <cc1:AsyncFileUpload OnClientUploadStarted = "uploadStarted" Width="220px" OnClientUploadComplete="uploadComplete" OnUploadedComplete="uploadFile_UploadedComplete" Font-Size="X-Small"  ID="uploadFile" CssClass="btn btn-brown" runat="server" />  --%>
                                                                    <cc1:AsyncFileUpload Width="220px" OnClientUploadComplete="uploadComplete" OnClientUploadError="onUploadError" runat="server" ID="AsyncFileUpload1"
                                                                        UploaderStyle="Modern" CompleteBackColor="White" UploadingBackColor="#CCFFFF"
                                                                        ThrobberID="imgLoader" OnUploadedComplete="FileUploadComplete" OnClientUploadStarted="uploadStarted" />
                                                                </div>

                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Picture</label>
                                                                <div class="col-sm-8">

                                                                    <img id="imgDisplay" runat="server" style="width: 200px; height: 100px; display: none" alt="" src="" />
                                                                    <asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" />

                                                                </div>
                                                            </div>

                                                            <br />
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <br />

                                                        </div>



                                                    </div>

                                                </asp:Panel>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <asp:UpdatePanel runat="server" ID="updatePanel1">


                                            <ContentTemplate>
                                                <asp:Panel ID="HasOlevelResult" runat="server" Visible="false">
                                                    <!-- Modal -->
                                                    <div class="loginPanel" style="width: 850px;min-height:300px">
                                                        <%--<div class="site-logo text-center"><img src="../Images/logo.jpg" /></div>--%>
                                                        <br />
                                                        <h2 class="panel-heading" style="background: #293a4a;
                                                color: #FFF;">The Polytechnic Ibadan Application Form - JAMB-UTME Examination</h2>
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label"></label>
                                                                <div class="col-sm-8">
                                                                    <label class="btn btn-brown">First Sitting</label>
                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label"></label>
                                                                <div class="col-sm-8">
                                                                    <label class="btn btn-brown">Second Sitting</label>
                                                                </div>
                                                            </div>


                                                        </div>
                                                        <br /><br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Exam Type</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="True" CssClass="form-control" runat="server" ID="dropdownExam">
                                                                        <asp:ListItem Text="Select Exam Type" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="WAEC" Value="WAEC"></asp:ListItem>
                                                                        <asp:ListItem Text="NECO" Value="NECO"></asp:ListItem>
                                                                        <asp:ListItem Text="NABTEB" Value="NABTEB"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" InitialValue="" ControlToValidate="dropdownExam"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Exam Type" />


                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Exam Type</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="True" CssClass="form-control" runat="server" ID="dropdownExamType2">
                                                                        <asp:ListItem Text="Select Exam Type" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="WAEC" Value="WAEC"></asp:ListItem>
                                                                        <asp:ListItem Text="NECO" Value="NECO"></asp:ListItem>
                                                                        <asp:ListItem Text="NABTEB" Value="NABTEB"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" InitialValue="" ControlToValidate="dropdownExamType2"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Exam Type" />--%>


                                                                </div>
                                                            </div>



                                                        </div>
                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Exam Month</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="True" CssClass="form-control" runat="server" ID="dropdownExamMonth">
                                                                        <asp:ListItem Text="Select Exam Month" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="May/June" Value="May/June"></asp:ListItem>
                                                                        <asp:ListItem Text="June/July" Value="June/July"></asp:ListItem>
                                                                        <asp:ListItem Text="November/December" Value="November/December"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" InitialValue="" ControlToValidate="dropdownExamMonth"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Exam Month" />


                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Exam Month</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="True" CssClass="form-control" runat="server" ID="dropdownExamMonth2">
                                                                        <asp:ListItem Text="Select Exam Month" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="May/June" Value="May/June"></asp:ListItem>
                                                                        <asp:ListItem Text="June/July" Value="June/July"></asp:ListItem>
                                                                        <asp:ListItem Text="November/December" Value="November/December"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" InitialValue="" ControlToValidate="dropdownExamMonth2"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Exam Month" />--%>


                                                                </div>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Examination Number</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" MaxLength="15" runat="server" ID="txtExamNum" placeholder="Enter Examination Number"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtExamNum"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Examination Number is required." />

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Examination Number</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" MaxLength="15" runat="server" ID="txtExamNum2" placeholder="Enter Examination Number"></asp:TextBox>
                                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtExamNum2"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Examination Number is required." />--%>

                                                                </div>
                                                            </div>



                                                        </div>

                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Examination Year</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="True" CssClass="form-control" runat="server" ID="dropdownExamYear">
                                                                        <asp:ListItem Text="Select Year" Value=""></asp:ListItem>

                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" InitialValue="" ControlToValidate="dropdownExamYear"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Exam Year" />

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Examination Year</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="True" CssClass="form-control" runat="server" ID="dropdownListexamyear2">
                                                                        <asp:ListItem Text="Select Year" Value=""></asp:ListItem>

                                                                    </asp:DropDownList>

                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" InitialValue="" ControlToValidate="dropdownListexamyear2"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Exam Year" />--%>

                                                                </div>
                                                            </div>



                                                        </div>
                                                        <br />
                                                        <br />

                                                        <asp:SqlDataSource ID="sqlDataSouceOlevelSubjects" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Application_OlevelSubjects]"></asp:SqlDataSource>

                                                        

                                                       

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">O'Lvl Subject 1</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="true"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction" DataTextField="SubjectName" DataValueField="ID"
                                                                        CssClass="form-control" runat="server" ID="dropdownOlevelSub1">
                                                                        <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" InitialValue="" ControlToValidate="dropdownOlevelSub1"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 1" />
                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">O'Lvl Subject 1</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="true"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction2"  DataTextField="SubjectName" DataValueField="ID"
                                                                        CssClass="form-control" runat="server" ID="dropdownOlevelsubject1b">
                                                                        <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" InitialValue="" ControlToValidate="dropdownOlevelsubject1b"
                                    CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 1" /> --%>
                                    </div>
                                                                </div>


                                                            </div>

                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 1</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownolevelGrade1">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" InitialValue="" ControlToValidate="dropdownolevelGrade1"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 1</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownListGrade2">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                              <%--                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" InitialValue="" ControlToValidate="dropdownListGrade2"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>

                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 2</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownOlevelSub2">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" InitialValue="" ControlToValidate="dropdownOlevelSub2"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 2" />
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 2</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction2"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownOlevelSub2b">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" InitialValue="" ControlToValidate="dropdownOlevelSub2b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 2" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>

                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 2</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade2">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" InitialValue="" ControlToValidate="dropdownGrade2"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 2</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade2b">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" InitialValue="" ControlToValidate="dropdownGrade2b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 3</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownolevelSub3">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" InitialValue="" ControlToValidate="dropdownolevelSub3"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 3" />
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 3</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction2"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownolevelSub3b">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" InitialValue="" ControlToValidate="dropdownolevelSub3b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 3" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>

                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 3</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade3">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" InitialValue="" ControlToValidate="dropdownGrade3"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade " />
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 3</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade3b">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" InitialValue="" ControlToValidate="dropdownGrade3b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 4</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownOlvlSub4">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" InitialValue="" ControlToValidate="dropdownOlvlSub4"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 4" />
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 4</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction2"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownOlvlSub4b">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                     <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" InitialValue="" ControlToValidate="dropdownOlvlSub4b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 4" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>

                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 4</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade4">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" InitialValue="" ControlToValidate="dropdownGrade4"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade " />
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 4</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade4b">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" InitialValue="" ControlToValidate="dropdownGrade4b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 5</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownOlevelsub5">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" InitialValue="" ControlToValidate="dropdownOlevelsub5"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 5" />
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 5</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction2"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownOlevelsub5b">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" InitialValue="" ControlToValidate="dropdownOlevelsub5b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 5" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 5</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade5">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" InitialValue="" ControlToValidate="dropdownGrade5"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade " />
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 5</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade5b">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" InitialValue="" ControlToValidate="dropdownGrade5b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 6</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownOlevelSub6">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" InitialValue="" ControlToValidate="dropdownOlevelSub6"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 6" />--%>
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 6</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction2"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownOlevelSub6b">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" InitialValue="" ControlToValidate="dropdownOlevelSub6b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 6" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 6</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade6">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" InitialValue="" ControlToValidate="dropdownGrade6"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade " />--%>
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 6</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade6b">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" InitialValue="" ControlToValidate="dropdownGrade6b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 7</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownOlevelSub7">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" InitialValue="" ControlToValidate="dropdownOlevelSub7"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 7" />--%>
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 7</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction2"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownOlevelSub7b">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" InitialValue="" ControlToValidate="dropdownOlevelSub7b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 7" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 7</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdonGrade7">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" InitialValue="" ControlToValidate="dropdonGrade7"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade " />--%>
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 7</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdonGrade7b">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                     <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" InitialValue="" ControlToValidate="dropdonGrade7b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 8</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownolevelSub8">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" InitialValue="" ControlToValidate="dropdownolevelSub8"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 8" />--%>
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 8</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction2"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdownolevelSub8b">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" InitialValue="" ControlToValidate="dropdownolevelSub8b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 8" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 8</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade8">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                     <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" InitialValue="" ControlToValidate="dropdownGrade8"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade " />--%>
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 8</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade8b">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" InitialValue="" ControlToValidate="dropdownGrade8b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>

                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 9</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdowOlevelSub9">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                     <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" InitialValue="" ControlToValidate="dropdowOlevelSub9"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 9" />--%>
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Subject 9</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="newMatchingFunction2"  DataTextField="SubjectName" DataValueField="ID"
                                                                            CssClass="form-control" runat="server" ID="dropdowOlevelSub9b">
                                                                            <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" InitialValue="" ControlToValidate="dropdowOlevelSub9b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Olevel subject 9" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>

                                                            <br />
                                                            <br />

                                                            <div class="form-group">

                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 9</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade9">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" InitialValue="" ControlToValidate="dropdownGrade9"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade " />--%>
                                                                    </div>
                                                                </div>


                                                                <div class="col-lg-6">

                                                                    <label class="col-sm-4 control-label">O'Lvl Grade 9</label>
                                                                    <div class="col-sm-8">
                                                                        <asp:DropDownList AppendDataBoundItems="true"
                                                                            AutoPostBack="true"
                                                                            CssClass="form-control" runat="server" ID="dropdownGrade9b">
                                                                            <asp:ListItem Text="Select Grade" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                                                            <asp:ListItem Text="B2" Value="B2"></asp:ListItem>
                                                                            <asp:ListItem Text="B3" Value="B3"></asp:ListItem>
                                                                            <asp:ListItem Text="C4" Value="C4"></asp:ListItem>
                                                                            <asp:ListItem Text="C5" Value="C5"></asp:ListItem>
                                                                            <asp:ListItem Text="C6" Value="C6"></asp:ListItem>
                                                                            <asp:ListItem Text="D7" Value="D7"></asp:ListItem>
                                                                            <asp:ListItem Text="E8" Value="E8"></asp:ListItem>
                                                                            <asp:ListItem Text="F9" Value="F9"></asp:ListItem>
                                                                            <asp:ListItem Text="Awaiting Result" Value="Awaiting Result"></asp:ListItem>

                                                                        </asp:DropDownList>

                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" InitialValue="" ControlToValidate="dropdownGrade9b"
                                                                            CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm_Olevel" ErrorMessage="Select Grade" />--%>
                                                                    </div>
                                                                </div>


                                                            </div>

                                                        </div>
                                                </asp:Panel>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                            <Triggers>
                                            </Triggers>
                                            <ContentTemplate>


                                                <asp:Panel ID="HasPreviousRecord" runat="server" Visible="false">
                                                   <div class="loginPanel" style="width: 850px;min-height:300px">
                                                        <%--<div class="site-logo text-center"><img src="../Images/logo.jpg" /></div>--%>
                                                        <br />
                                                        <h2 class="panel-heading" style="background: #293a4a;
                                                color: #FFF;">The Polytechnic Ibadan Application Form - JAMB-UTME Examination</h2>
                                                        <br />

                                                         <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">ND Matric Number</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" runat="server" ID="txtNdMetricNum" placeholder="Enter ND Matric Number"></asp:TextBox>
                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6a5" runat="server" ControlToValidate="txtNdMetricNum"
                                    CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="ND Matric Number is required." />
                                                                    
                                                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="field-validation-error" ID="RegularExpressionValidator2" runat="server"
                                                                        ValidationExpression="(?=^.{5,25}$)[0-9a-zA-Z!@#$%*()_+^&]*$"
                                                                        
                                                                        ControlToValidate="txtNdMetricNum" ValidationGroup="appPreviousRecord" ErrorMessage="txtNdMetricNum should be 10- 15 characters  <br/>"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                             <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label"></label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" Visible="false" runat="server" ID="TextBox1"></asp:TextBox>
                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ControlToValidate="txtjaRegno_previous"
                                    CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="The Registration # is required." />--%>
                                                                    
                                                                </div>
                                                            </div>

                                                             </div>
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">JAMB Reg No</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox CssClass="form-control" runat="server" ID="txtjaRegno_previous" placeholder="Enter JAMB Registration number"></asp:TextBox>
                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ControlToValidate="txtjaRegno_previous"
                                    CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appForm" ErrorMessage="The Registration # is required." />--%>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="field-validation-error" ID="RegularExpressionValidator4" runat="server"
                                                                        ValidationExpression="(?=^.{10,15}$)[0-9a-zA-Z]*$"
                                                                        
                                                                        ControlToValidate="txtjaRegno_previous" ValidationGroup="appPreviousRecord" ErrorMessage="JAMB Reg# should be 10  - 15 characters  <br/>"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                            <br /><br /><br />

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">JAMB Exam Year</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="True" CssClass="form-control" runat="server" ID="dropdownJambExamYear_Previous">
                                                                        <asp:ListItem Text="Select Year" Value=""></asp:ListItem>

                                                                    </asp:DropDownList>

                                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" InitialValue="" ControlToValidate="dropdownJambExamYear_Previous"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Select Exam Year" />--%>

                                                                </div>
                                                            </div>
                                                            <br />

                                                        </div>

                                                        <br />
                                                        <br />
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">JAMB Full Name</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox runat="server" CssClass="form-control" MaxLength="50" ID="txtJambFullName_previous" placeholder="Enter JAMB Full Name"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="txtJambFullName_previous"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Full Name is required" />--%>

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Institution Attended</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="true"
                                                                        DataTextField="InstitutionName" DataValueField="ID"
                                                                        CssClass="form-control" runat="server" ID="dropdwnJamIns_Previous">
                                                                        <asp:ListItem Text="Select Institution" Value=""></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" InitialValue="" ControlToValidate="dropdwnJamIns_Previous"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Select subject 1" />

                                                                </div>
                                                            </div>


                                                        </div>

                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Course Name</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox runat="server" CssClass="form-control" MaxLength="30" ID="txtJambCourseName_previous" placeholder="Enter JAMB Course Name"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ControlToValidate="txtJambCourseName_previous"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Course Name is required" />

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Course Type</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="true"
                                                                        CssClass="form-control" runat="server" ID="dropdownCourseType_Previous">
                                                                        <asp:ListItem Text="Select Course Type" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="Full Time" Value="Full Time"></asp:ListItem>
                                                                        <asp:ListItem Text="Part-Time" Value="Part-Time"></asp:ListItem>
                                                                        <asp:ListItem Text="Daily Part-Time" Value="Daily Part-Time"></asp:ListItem>
                                                                        <asp:ListItem Text="Sandwich" Value="Sandwich"></asp:ListItem>
                                                                        


                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator69" runat="server" InitialValue="" ControlToValidate="dropdownCourseType_Previous"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Select Course Type" />

                                                                </div>
                                                            </div>


                                                        </div>


                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Course Grade</label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="true"
                                                                        CssClass="form-control" runat="server" ID="dropdownCourseGrade_Prvious">
                                                                        <asp:ListItem Text="Select Course Grade" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="First Class" Value="First Class"></asp:ListItem>
                                                                        <asp:ListItem Text="Upper Credit" Value="Upper Credit"></asp:ListItem>
                                                                        <asp:ListItem Text="Lower Credit" Value="Lower Credit"></asp:ListItem>
                                                                        <asp:ListItem Text="Pass" Value="Pass"></asp:ListItem>


                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" InitialValue="" ControlToValidate="dropdownCourseGrade_Prvious"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Select Course Grade" />

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Year Completed </label>
                                                                <div class="col-sm-8">
                                                                    <asp:DropDownList AppendDataBoundItems="true"
                                                                         CssClass="form-control" runat="server" ID="dropdownyearCompleted_Previous">
                                                                        <asp:ListItem Text="Select Year" Value=""></asp:ListItem>

                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator71" runat="server" InitialValue="" ControlToValidate="dropdownyearCompleted_Previous"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Select Completed Year" />

                                                                </div>
                                                            </div>


                                                        </div>


                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Industrial Training Starts</label>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList runat="server" ID="dropdownIndustrialtrainingStart">
                                                                        <asp:ListItem Value="" Text="Select Month"></asp:ListItem>
                                                                        <asp:ListItem Value="Jan" Text="Jan"></asp:ListItem>
                                                                        <asp:ListItem Value="Feb" Text="Feb"></asp:ListItem>
                                                                        <asp:ListItem Value="Mar" Text="Mar"></asp:ListItem>
                                                                        <asp:ListItem Value="Apr" Text="Apr"></asp:ListItem>
                                                                        <asp:ListItem Value="May" Text="May"></asp:ListItem>
                                                                        <asp:ListItem Value="Jun" Text="Jun"></asp:ListItem>
                                                                        <asp:ListItem Value="Jul" Text="Jul"></asp:ListItem>
                                                                        <asp:ListItem Value="Aug" Text="Aug"></asp:ListItem>
                                                                        <asp:ListItem Value="Sep" Text="Sep"></asp:ListItem>
                                                                        <asp:ListItem Value="Oct" Text="Oct"></asp:ListItem>
                                                                        <asp:ListItem Value="Nov" Text="Nov"></asp:ListItem>
                                                                        <asp:ListItem Value="Dec" Text="Dec"></asp:ListItem>

                                                                    </asp:DropDownList>

                                                                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator72" runat="server" InitialValue="" ControlToValidate="dropdownIndustrialtrainingStart"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Select Training Starts Month" />--%>

                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="dropdownIndustrialTrainingEndYear">
                                                                        <asp:ListItem Value="" Text="Select Year"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                 <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator74" runat="server" InitialValue="" ControlToValidate="dropdownIndustrialTrainingEndYear"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Select Industrial Training End year" />--%>

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label">Industrial Training Ends</label>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList runat="server" ID="dropdownIndustrialStarmonth2">
                                                                        <asp:ListItem Value="" Text="Select Month"></asp:ListItem>
                                                                        <asp:ListItem Value="Jan" Text="Jan"></asp:ListItem>
                                                                        <asp:ListItem Value="Feb" Text="Feb"></asp:ListItem>
                                                                        <asp:ListItem Value="Mar" Text="Mar"></asp:ListItem>
                                                                        <asp:ListItem Value="Apr" Text="Apr"></asp:ListItem>
                                                                        <asp:ListItem Value="May" Text="May"></asp:ListItem>
                                                                        <asp:ListItem Value="Jun" Text="Jun"></asp:ListItem>
                                                                        <asp:ListItem Value="Jul" Text="Jul"></asp:ListItem>
                                                                        <asp:ListItem Value="Aug" Text="Aug"></asp:ListItem>
                                                                        <asp:ListItem Value="Sep" Text="Sep"></asp:ListItem>
                                                                        <asp:ListItem Value="Oct" Text="Oct"></asp:ListItem>
                                                                        <asp:ListItem Value="Nov" Text="Nov"></asp:ListItem>
                                                                        <asp:ListItem Value="Dec" Text="Dec"></asp:ListItem>

                                                                    </asp:DropDownList>

<%--                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator73" runat="server" InitialValue="" ControlToValidate="dropdownIndustrialStarmonth2"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Select Training Starts Month" />--%>

                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="dropdownIndustrialTrainingYearStart2">
                                                                        <asp:ListItem Value="" Text="Select Year"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                              <%--      <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" InitialValue="" ControlToValidate="dropdownIndustrialTrainingYearStart2"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appPreviousRecord" ErrorMessage="Select Industrial Training End year" />--%>

                                                                </div>
                                                            </div>


                                                        </div>

                                                    </div>



                                                </asp:Panel>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                            <Triggers>
                                            </Triggers>
                                            <ContentTemplate>

                                                <asp:Panel ID="HasCBTSchedule" runat="server" Visible="false">
                                                 <div class="loginPanel" style="width: 850px;min-height:300px">
                                                        <%--<div class="site-logo text-center"><img src="../Images/logo.jpg" /></div>--%>
                                                        <br />
                                                        <h2 class="panel-heading" style="background: #293a4a;
                                                color: #FFF;">The Polytechnic Ibadan Application Form - JAMB-UTME Examination</h2>
                                                        <br />


                                                        <div class="form-group">

                                                            <div class="col-lg-12">


                                                                <label class="col-sm-2 control-label">Select Date</label>
                                                                <div class="col-sm-5">
                                                                    <asp:DropDownList CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropdownScheduleDate_SelectedIndexChanged" AppendDataBoundItems="true" DataTextField="ScheduleDate" DataValueField="ScheduleDate" runat="server" ID="dropdownScheduleDate">
                                                                        <asp:ListItem Value="" Text="Select Date"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server" InitialValue="" ControlToValidate="dropdownScheduleDate"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appCBT" ErrorMessage="Select Date" />

                                                                </div>
                                                            </div>





                                                        </div>

                                                        <br />
                                                        <br />
                                                        <div class="form-group">

                                                            <div class="col-lg-12">

                                                                <label class="col-sm-2 control-label">Select Time</label>
                                                                <div class="col-sm-5">
                                                                    <asp:DropDownList OnSelectedIndexChanged="dropdownTime_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true" DataTextField="ScheduleTime" DataValueField="ID" AppendDataBoundItems="true" runat="server" ID="dropdownTime">

                                                                        <asp:ListItem Value="" Text="Select Time"></asp:ListItem>

                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator76" runat="server" InitialValue="" ControlToValidate="dropdownTime"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appCBT" ErrorMessage="Select Time" />

                                                                </div>
                                                            </div>





                                                        </div>

                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-12">

                                                                <label class="col-sm-2 control-label">Your CBT Schedule:</label>
                                                                <div class="col-sm-8">

                                                                    <asp:Label CssClass="form-control" runat="server" ID="labelScheduleTxt" Text=""></asp:Label>
                                                                    <asp:Label ForeColor="Red" Visible="false" runat="server" ID="lblError" Text=""></asp:Label>

                                                                </div>
                                                            </div>



                                                        </div>


                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-12">

                                                                <label class="col-sm-2 control-label">CBT Username:</label>
                                                                <div class="col-sm-8">

                                                                    <asp:TextBox CssClass="form-control" ReadOnly="true" runat="server" ID="lblCbtUsername" Text=""></asp:TextBox>

                                                                </div>
                                                            </div>



                                                        </div>

                                                        <br />
                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-12">

                                                                <label class="col-sm-2 control-label">CBT Password:</label>
                                                                <div class="col-sm-8">

                                                                    <asp:TextBox CssClass="form-control" runat="server" ID="lblCbtPassword" ReadOnly="true" Text=""></asp:TextBox>


                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator77" runat="server" ControlToValidate="lblCbtPassword"
                                                                        CssClass="field-validation-error" Display="Dynamic" ValidationGroup="appCBT" ErrorMessage="Please select available time slot to get a CBT password" />
                                                                </div>
                                                            </div>



                                                        </div>

                                                    </div>



                                                </asp:Panel>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>


                                        <asp:UpdatePanel runat="server" ID="updatePanel4">


                                            <ContentTemplate>
                                                <asp:Panel ID="panelPreview" runat="server" Visible="false">
                                                    <!-- Modal -->
                                                   <div class="loginPanel" style="width: 850px;min-height:300px">
                                                        <%--<div class="site-logo text-center"><img src="../Images/logo.jpg" /></div>--%>
                                                        <br />
                                                        <h2 class="panel-heading" style="background: #293a4a;
                                                color: #FFF;">The Polytechnic Ibadan Application Form - JAMB-UTME Examination</h2>
                                                        <br />
                                                <div class="row" style="font-size:large">

                                                        <div class="form-group">

                                                            <div class="col-lg-4">

                                                                
                                                                <div class="col-sm-12">
                                                                   <img id="imgDp" runat="server" style="width:200px;height:200px" src="" />
                                                                </div>
                                                            </div>
                                                           
                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Sur Name :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label  runat="server" ID="lblSuname" ></asp:Label>
                                                                   
                                                                </div>
                                                            </div>



                                                        </div>
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">First Name :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label  runat="server" ID="lblFname"></asp:Label>
                                                                    
                                                                </div>
                                                            </div>


                                                        </div>

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Other Name:</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label  runat="server" ID="lblOtherName"></asp:Label>
                                                                    
                                                                </div>
                                                            </div>


                                                        </div>

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Gender :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label runat="server" ID="lblGender"></asp:Label>
                                                                    
                                                                </div>
                                                            </div>


                                                        </div>

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Phone # :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label  runat="server" ID="lblPhonenum"></asp:Label>
                                                                    
                                                                </div>
                                                            </div>


                                                        </div>
                                                      <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">STO :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label  runat="server" ID="lblstateoforigin"></asp:Label>
                                                                    
                                                                </div>
                                                            </div>


                                                        </div>
                                                      <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">LGA :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label  runat="server" ID="lblLocalGotArea"></asp:Label>
                                                                    
                                                                </div>
                                                            </div>


                                                        </div>

                                                </div>
                                                        <br />
                                                <div class="row">
                                                   
                                                    <div class="form-group" style="font-size:large;margin-left: 12px;margin-right: 12px" >

                                                            <div class="col-lg-12" style="background-color:#293a4a;COLOR:WHITE;height: 33px;">

                                                                <label class="col-sm-3 control-label">Registration No :</label>
                                                                <div class="col-sm-8">
                                                                  <b>  <asp:Label runat="server" Text="" ID="lblRegistrationNum" ></asp:Label></b>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    <div class="form-group">

                                                            <div class="col-lg-12">
                                                    <hr />
                                                                </div></div>
                                                    

                                                    <br />
                                                    <div class="form-group">

                                                        <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Program :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label   runat="server" ID="lblProgram" ></asp:Label>
                                                                   
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Course :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label runat="server" ID="lblCourse"></asp:Label>
                                                                    

                                                                </div>
                                                            </div>



                                                        </div>
                                                    <br />
                                                      <div class="form-group">

                                                            <div class="col-lg-12">
                                                   <br />
                                                                </div></div>
                                                  <asp:Panel runat="server" ID="panelpreview_PreviousRecord" Visible="true">
                                                 

                                                    <div class="form-group" style="font-size:large;margin-left: 12px;margin-right: 12px" >

                                                            <div class="col-lg-12" style="background-color:#293a4a;COLOR:WHITE;height: 33px;">

                                                                <label class="col-sm-12 control-label">Previous Academic Record</label>
                                                                
                                                            </div>

                                                    </div>
                                                 
                                                      <div class="form-group">

                                                            <div class="col-lg-12">
                                                    <hr />
                                                                </div></div>

                                                    
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">JAMB Reg No :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label runat="server" ID="lblJambRegno" ></asp:Label>
                                                                   
                                                                   
                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">JAMB Exm Year :</label>
                                                                <div class="col-sm-8">
                                                                   
                                                                    <asp:Label runat="server" ID="lblJambExamyear" ></asp:Label>

                                                                </div>
                                                            </div>


                                                        </div>

                                                        <br />
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">JAMB Full Name :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label runat="server" ID="lblJambFullName" ></asp:Label>
                                                                    

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Institution Attended :</label>
                                                                <div class="col-sm-8">
                                                                   <asp:Label runat="server" ID="lblInstitutionAttended" ></asp:Label>

                                                                </div>
                                                            </div>


                                                        </div>

                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Course Name :</label>
                                                                <div class="col-sm-8">
                                                                 <asp:Label runat="server" ID="lblCourseName" ></asp:Label>

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Course Type :</label>
                                                                <div class="col-sm-8">
                                                                   <asp:Label runat="server" ID="courseType" ></asp:Label>

                                                                </div>
                                                            </div>


                                                        </div>


                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Course Grade :</label>
                                                                <div class="col-sm-8">
                                                                   <asp:Label runat="server" ID="lblCourseGrade" ></asp:Label>

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Year Completed : </label>
                                                                <div class="col-sm-8">
                                                                   <asp:Label runat="server" ID="yearCompleted" ></asp:Label>

                                                                </div>
                                                            </div>


                                                        </div>


                                                        <br />

                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Industrial Training Starts :</label>
                                                                <div class="col-sm-8">
                                                                   

                                                                   <asp:Label runat="server" ID="lblIndustrialStart" ></asp:Label>

                                                                </div>
                                                            </div>


                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">Industrial Training Ends :</label>
                                                                <div class="col-sm-8">
                                                                    
                                                                    <asp:Label runat="server" ID="lblIndustrialEnd" ></asp:Label>
                                                                </div>
                                                            </div>


                                                        </div>
                                                  <div class="form-group">

                                                            <div class="col-lg-12">
                                                   <br />
                                                                </div></div>


                                                      </asp:Panel>
                                                       <div class="form-group" style="font-size:large;margin-left: 12px;margin-right: 12px" >

                                                            <div class="col-lg-12" style="background-color:#293a4a;COLOR:WHITE;height: 33px;">

                                                                <label class="col-sm-12 control-label">CBT Schedule</label>
                                                                
                                                            </div>

                                                      </div>
                                                    <div class="form-group">

                                                            <div class="col-lg-12">
                                                    <hr />
                                                                </div></div>
                                                    <div class="form-group">

                                                            <div class="col-lg-6">
                                                              
                                                                <label class="col-sm-4 control-label" style="color:brown">Your Cbt Schedule :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label   runat="server" ID="lblCbtSchedule" ></asp:Label>
                                                                   
                                                                </div>
                                                            </div>



                                                        </div>
                                                        <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">CBT UserName :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label  runat="server" ID="labelCbtUser"></asp:Label>
                                                                    
                                                                </div>
                                                            </div>


                                                        </div>

                                                    <div class="form-group">

                                                            <div class="col-lg-6">

                                                                <label class="col-sm-4 control-label" style="color:brown">CBT Password :</label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label  runat="server" ID="lblCbtPass"></asp:Label>
                                                                    
                                                                </div>
                                                            </div>


                                                        </div>
                                                      <div class="form-group">
                                            <div class="col-lg-12">
                                                    <hr />
                                                </div></div>
                                                    <div class="form-group">
                                            <div class="col-lg-12">

                                                <label class="col-sm-2 control-label"></label>


                                                <div class="col-sm-3">

                                                    <asp:Button runat="server" Visible="true" OnClick="Button1_Click" ID="Button1" Width="150px" CssClass="btn btn-info" Text="Edit Application" />

                                                </div>

                                                <div class="col-sm-3">

                                                    <asp:Button runat="server" Visible="true" OnClick="btnSubmit_Click" ID="btnSubmit" Width="150px"  CssClass="btn btn-success" Text="Submit Application" />
                                                     

                                                </div>

                                            </div>
                                        </div>
                                                    

                                                </div>

                                                    </div>

                                                </asp:Panel>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <hr />

                                        <div class="form-group">
                                            <div class="col-lg-12">

                                                <label class="col-sm-2 control-label"></label>


                                                <div class="col-sm-3">

                                                    <asp:Button runat="server" Visible="false" OnClick="btnPrevious_Click" ID="btnPrevious" Width="150px" CssClass="btn btn-info" Text="Previous Page" />

                                                </div>

                                                <div class="col-sm-3">

                                                    <asp:Button runat="server" Visible="true" ID="btnSave" Width="150px" OnClick="saveinfo_Click" CssClass="btn btn-success" Text="Save Application" />

                                                </div>

                                                <div class="col-sm-3">

                                                    <asp:Button runat="server" Visible="false" ID="btnNext" Width="150px" CssClass="btn btn-info" OnClick="nextBtn_Click" Text="Next Page" />
                                                    <asp:Button runat="server" Visible="false" ID="btnPreview" Width="150px" OnClick="btnPreview_Click" CssClass="btn btn-brown" Text="Preview Form" />
                                                     

                                                </div>
                                                

                                            </div>
                                            <div class="col-sm-12">
                                                <br /><br />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>



                    </ContentTemplate>

                </asp:UpdatePanel>
            </div>
        </div>
                      
         </div>

</asp:Content>

