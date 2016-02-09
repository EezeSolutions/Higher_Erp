<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddForm.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="panel panel-default">
     <div class="panel-heading">Add Form Field</div>
        <div class="panel-body">
          <div class="row">
              
               <div class="form-group">
                                    <label class="col-sm-2 control-label">Program:</label>

                   
                                    <div class="col-sm-9">
                                    
                                        <asp:DropDownList ClientIDMode="Static" ID="Programtxt" runat="server" CssClass="form-control"></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                     Display="Dynamic" runat="server" ControlToValidate="Programtxt" ValidationGroup="addForm" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
                                    </div>
            </div>
              <br />
              <br />
              <div class="form-group">
                  <label class="col-sm-2 control-label"></label>
                  <div class="col-sm-9">
              <a href="#0" style="text-align:right;float:right">Add Program:</a>
                  </div>
             </div>
              <br />
               <div class="form-group">
                                    <label class="col-sm-2 control-label">Form Section:</label>

                   
                                    <div class="col-sm-9">
                                    
                                        <asp:DropDownList ClientIDMode="Static" ID="Sectiontxt" runat="server" CssClass="form-control"></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                     Display="Dynamic" runat="server" ControlToValidate="Sectiontxt" ValidationGroup="addForm" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
                                    </div>
            </div>
              <br />
              <br />
              <div class="form-group">
                  <label class="col-sm-2 control-label"></label>
                  <div class="col-sm-9">
              <a href="#0" style="text-align:right;float:right">Add Form Section</a>
                  </div>
             </div>
              <br />

               <div class="form-group">
                                    <label class="col-sm-2 control-label">Form Field</label>
                                    <div class="col-sm-9">
                                    
                                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" runat="server" ID="FormFieldtxt" placeholder="Please enter field name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                     Display="Dynamic" runat="server" ControlToValidate="FormFieldtxt" ValidationGroup="addForm" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
                                    </div>
            </div>
              <br />
              <br />
              <br />
               <div class="form-group">
                                    <label class="col-sm-2 control-label">Data Type:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:DropDownList ClientIDMode="Static" ID="Datatypetxt" runat="server" CssClass="form-control"></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                     Display="Dynamic" runat="server" ControlToValidate="Datatypetxt" ValidationGroup="addForm" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
                                    </div>
            </div>

              <br />
              <br />
              <br />

               <div class="form-group">
                                    <label class="col-sm-2 control-label">Form Control:</label>
                                    <div class="col-sm-9">
                                    
                                       <asp:DropDownList  ID="Controltxt" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                     Display="Dynamic" runat="server" ControlToValidate="Controltxt" ValidationGroup="addForm" CssClass="field-validation-error" ErrorMessage="Please enter Question" />
                                    
                                    </div>
            </div>

              <br />
              <br />
              <br />
              <div class="form-group">
                  <label class="col-sm-2 control-label"></label>
                   <div class="col-sm-9" id="fieldoptions">
              
                       </div>

              </div>

               <br />
              <br />
              <div class="form-group">
                  <label class="col-sm-2 control-label"></label>
                  <div class="col-sm-9">
              <a href="#0" id="addoption" style="text-align:right;float:right; display:none">Add Option</a>
                  </div>
             </div>
              <br />

            
               <div class="form-group" style="text-align:center"><br />
                                    <label class="col-sm-2 control-label"> </label>
                                    <div class="col-sm-9">
                                 
                                        <a Class="btn btn-block btn-primary" ID="btnAddField"  >Add Field</a>
                                     
                                    </div>
            </div>
              </div>
            </div>
    </div>
    <script type="text/javascript">

        $(function () {
            var control;
            var options = new Array();
            $("#Controltxt").change(function () {



                if ($(this).val() != "Text") {
                    if (control == null)
                        control = $(this).val();
                    if (control != $(this).val()) {
                        $("#fieldoptions").html(" ");
                        $("#fieldoptions").append("<input type='text' id='options' class='form-control'/> <br />");

                        control = $(this).val();
                        $("#addoption").show();
                    }
                    else {
                        $("#fieldoptions").append("<input type='text' id='options' class='form-control'/> <br />");
                        $("#addoption").show();
                    }
                    control = $(this).val();
                }
                else {
                    $("#fieldoptions").html(" ");
                    $("#addoption").hide();
                }

            });


            var i=0;
            $("#addoption").click(function(){
                options[i] = $("#options").val();
                $("#options").attr("id","old");
                $("#fieldoptions").append("<input type='text' id='options' class='form-control'/> <br /><br />");
                
                i++;
            })


            ///////////////////////////////////////////////////////////

            $("#btnAddField").click(function () {
                options[i] = $("#options").val();
                $.ajax({
                    type: "POST",
                    url: "AddForm.aspx/AddField",
                    data: JSON.stringify({ Field: $("#FormFieldtxt").val(),Data:$("#Datatypetxt").val(),Program:$("#Programtxt").val(),Section:$("#Sectiontxt").val(),cont:$("#Controltxt").val(), options: options }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        alert(response.d);
                    },
                    failure: function (response) {
                        tagimgLoad.style.display = "none";
                        alert(response.d);
                    },
                    error: function (response) {
                        tagimgLoad.style.display = "none";
                        alert(response.d);
                    }
                });

            })


        })


    </script>
</asp:Content>

