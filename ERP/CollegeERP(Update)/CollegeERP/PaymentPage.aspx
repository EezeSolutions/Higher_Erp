<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentPage.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="PaymentPage" %>


<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <script type="text/javascript">
        function Check()
        {
            alert(document.getElementById("pid").value + "|" + document.getElementById("sd").value + "|" + document.getElementById("amount").value + "|" + document.getElementById("tid").value);
            alert(document.getElementById("hash").value);
        }
    </script>
  
 <asp:ScriptManager runat="server" EnablePageMethods="true"></asp:ScriptManager>
    
         <div class="panel panel-default">
             <div class="panel-heading">Confirm Payment Details</div>
                        <div class="panel-body">
          
		  <div class="loginPanel" style="width:850px;min-height:50px" >
		<div class="site-logo text-center"></div>
              <div class="col-sm-12">
                  <div class="col-sm-3"></div>
                  <div class="col-sm-3">
                  <img src="images/Interswitch1.png" />
                      </div>
                  <div class="col-sm-3"></div>
                  <div class="col-sm-6">
                  <img src="images/Interswitch2.png" />
                      </div>
              </div>
        <br />
              </div>
          
           <br />
                            <br /><br />


            <div class="form-group">
                                    <label class="col-sm-2 control-label">Applicant Name </label>
                                    <div class="col-sm-9">
                                    <label class="form-control"><asp:Literal runat="server" ID="literalapplicantName"></asp:Literal></label>
                                    
                                    </div>
            </div>
            
           <div class="form-group">
                                    <label class="col-sm-2 control-label">Fee Type </label>
                                    <div class="col-sm-9">
                                    <label class="form-control"><asp:Literal runat="server" ID="literalFeeType"></asp:Literal></label>
                                    
                                    </div>
            </div>
           <div id="pname" class="form-group" runat="server">
                                    <label class="col-sm-2 control-label">Program Name </label>
                                    <div class="col-sm-9">
                                    <label class="form-control"><asp:Literal runat="server" ID="literalProgramame"></asp:Literal></label>
                                    
                                    </div>
            </div>
          <div id="courses" class="form-group" runat="server">
                                    <label class="col-sm-2 control-label">Courses :</label>
                                    <div class="col-sm-9">
                                    <label class="form-control"><asp:Literal runat="server" ID="literalCourses"></asp:Literal></label>
                                    
                                    </div>
            </div>

           <div class="form-group">
                                    <label class="col-sm-2 control-label">Fee Amount </label>
                                    <div class="col-sm-9">
                                    <label class="form-control"><asp:Literal runat="server" ID="literalFeeAmount"></asp:Literal></label>
                                    
                                    </div>
            </div>
          <div class="form-group">
                                    <label class="col-sm-2 control-label">Transcation Fee </label>
                                    <div class="col-sm-9">
                                    <label class="form-control"><asp:Literal runat="server" ID="literalTranscationFee"></asp:Literal></label>
                                    
                                    </div>
            </div>
           <div id="optionalfee" class="form-group" runat="server">
                                    <label class="col-sm-2 control-label">Optional Fee </label>
                                    <div class="col-sm-9">
                                    <label class="form-control"><asp:Literal runat="server" ID="literalOptionalCourseFee"></asp:Literal></label>
                                    
                                    </div>
            </div>

          <div class="form-group">
                                    <label class="col-sm-2 control-label">Total Fee </label>
                                    <div class="col-sm-9">
                                    <label class="form-control"><asp:Literal runat="server" ID="literalTotalFee"></asp:Literal></label>
                                    
                                    </div>
            </div>

            <div class="form-group">
                                    <label class="col-sm-2 control-label"></label>
                                     <div class="col-lg-9">
   
    <input name="product_id" id="pid" type="hidden" value="<%= this.product_id %>" />
    <input name="amount" id="amount" type="hidden"  value="<%= this.amount %>" />
    <input name="currency" type="hidden" value="566" />
    <input name="site_redirect_url" id="url" type="hidden" value="<%= this.site_redirect_url %>" />
    <input name="txn_ref" id="sd" type="hidden" value="<%=this.tnx_ref %>" />
    <input name="pay_item_id" id="tid" type="hidden" value= "<%= this.pay_item_id %>" />
    <input name="cust_id" type="hidden" value= "<%= this.cust_id %>" />
    <input name="hash" id="hash" type="hidden" value="<%= this.hash %>" />
    <input name="payment_params" type="hidden" value="college_split" /> 
     <input name="cust_name" type="hidden" value="<%= this.completeName %>" /> 
     <input name="cust_name_desc" type="hidden" value="Customer Name" /> 

     <input name="xml_data" type="hidden" value='<payment_item_detail>
<item_details detail_ref="<%=this.tnx_ref %>" college="The Polytechnic, Ibadan" department="" faculty="">
<item_detail item_id="1" item_name="<%= this.paymentType %>" item_amt="<%= this.feeamount %>" bank_id="9" acct_num="0120598847" />
<asp:Literal runat="server" ID="literaladdComission"></asp:Literal>
</item_details>

</payment_item_detail>' />

<asp:ImageButton CssClass="btn btn-success"  ID="btnPayNow" runat="server" AlternateText="PAY USING INTERSWITCH"   
 PostBackUrl="https://stageserv.interswitchng.com/test_paydirect/pay" />
<asp:Literal runat="server" ID="literaleWalletbtn"></asp:Literal>
     
     
    </div>
    
            </div>




      

              </div></div></div>
  
    </asp:Content>
