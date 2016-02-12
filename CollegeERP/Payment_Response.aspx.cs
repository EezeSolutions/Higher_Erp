using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

public partial class Payment_Response : System.Web.UI.Page
{
 
    private readonly static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

    public string hashKey = "";
    public string productID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["txnref"] != null)
        {
          //  if (Request.QueryString["ApplicationID"] != null)
            {

                int transcationFee = 0;
                int applicationID = 0;
                if (Request.QueryString["ApplicationID"] != null)
                {
                    transcationFee = Convert.ToInt16(ConfigurationManager.AppSettings["transcationFee"].ToString());
                    applicationID = Convert.ToInt32(Request.QueryString["ApplicationID"].ToString());
                }
                else if (Request.QueryString["eWalletNumber"] != null)
                {
                    transcationFee = Convert.ToInt16(ConfigurationManager.AppSettings["transcationFee_eWalletDeposit"].ToString());
                }
              
                //int applicationID = Convert.ToInt16(Request.QueryString["ApplicationID"].ToString());

                NameValueCollection qscollection = Request.Params;
                Console.WriteLine("Size: " + qscollection.Count);
                //GETTING PAMENT RESPONSE
                string txnRef = qscollection["txnref"].ToString();

                //GET AMOUNT FROM DB
                //string amount = "2300";

                DatabaseFunctions db = new DatabaseFunctions();

                int actualAmount = db.getTransactionTable_Amount(txnRef);
                int amounPost = (actualAmount + transcationFee) * 100;

                hashKey = ConfigurationManager.AppSettings["macKey"].ToString();
                productID = ConfigurationManager.AppSettings["product_id"].ToString();


                string url = "https://stageserv.interswitchng.com/test_paydirect/api/v1/gettransaction.json?productid=" + productID + "&transactionreference=" + txnRef + "&amount=" + amounPost + "";

                string newHash = productID + txnRef + hashKey;
                string hash = utilities.GetSHA512(newHash);
                string html = gethtml(url, hash);

                var rawJson = html;
                var json = JObject.Parse(rawJson);

                int ret_Amount = Convert.ToInt32(json["Amount"].ToObject<string>());
                string ret_Cardnumber = json["CardNumber"].ToObject<string>();
                string retMerchantReference = json["MerchantReference"].ToObject<string>();
                string retPaymentReference = json["PaymentReference"].ToObject<string>();
                string retRetrievalReferenceNumber = json["RetrievalReferenceNumber"].ToObject<string>();
                string retTransactionDate = json["TransactionDate"].ToObject<string>();
                string retResponseCode = json["ResponseCode"].ToObject<string>();
                string retResponseDescription = json["ResponseDescription"].ToObject<string>();
                string txtResponseLiteral = string.Empty;
                string userId = Membership.GetUser().ProviderUserKey.ToString();
                string emailAddress = Membership.GetUser().Email.ToString();

                string fullName = db.getStudent_CompleteName(userId);


                if (retResponseDescription == null)
                {
                    retResponseDescription = "Null";
                }
                if (Convert.ToInt32(ret_Amount) == (actualAmount + transcationFee) * 100)
                {
                    //RECORD TRANSACTIN IN DB

                    if (Request.QueryString["ApplicationID"] != null)
                    {
                        int programid = db.getOnlyProgramIDbyApplicationID(Convert.ToInt32(Request.QueryString["ApplicationID"]));
                        bool flag = false;
                        while (flag == false)
                        {
                            string startchar = string.Empty;
                            int startNum = 0;

                            lock (_lock)
                            {
                                DataSet ds = db.getProgramInfo(txnRef);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    startchar = ds.Tables[0].Rows[0]["StartingFormn_Char"].ToString();
                                    startNum = Convert.ToInt32(ds.Tables[0].Rows[0]["StartingFormnum"].ToString());
                                    
                                    int lastFormID = db.getLastProgramIdUser(startchar,programid);
                                    if (lastFormID == 0)
                                    {
                                        startNum = startNum + 1;

                                    }
                                    else
                                    {
                                        startNum = lastFormID + 1;
                                    }
                                }
                            }

                            if (Request.QueryString["acceptanceFee"] != null || Request.RawUrl.Contains("acceptanceFee=1"))
                            {
                                flag = db.updateTransactionStatus_acceptanceFee(ret_Cardnumber, retMerchantReference, retPaymentReference, retRetrievalReferenceNumber,
                                             retTransactionDate, retResponseCode, retResponseDescription, txnRef, applicationID.ToString(),actualAmount.ToString());
                                try
                                {
                                    DataSet bt = new DataSet();
                                    bt = db.getinfoForBiometric_Api(applicationID);
                                    if (bt.Tables[0].Rows.Count > 0)
                                    {
                                        string fnum = bt.Tables[0].Rows[0]["regno"].ToString();
                                        string sname = bt.Tables[0].Rows[0]["surname"].ToString();
                                        string oname = bt.Tables[0].Rows[0]["Othername"].ToString();


                                        //SEND API FOR BIOMETIRC
                                        //http://admission.polyibadan.edu.ng/eregistration/dbapi.php?cmd=insert&num=12345&sname=razzaq&onames=ade&paymentinfo=123hks
                                        string bUrl = "http://admission.polyibadan.edu.ng/eregistration/dbapi.php?cmd=insert&num=" + fnum + "&sname=" + sname + "&onames=" + oname + "&paymentinfo=" + txnRef;
                                        string bhtml = gethtml_BiometricApi(bUrl);
                                    }
                                }
                                catch (Exception error)
                                {
                                    //try
                                    //{
                                    //    utilities.sendEmail("e_kayani@hotmail.com", emailAddress, "Error Sending INFO", "");
                                    //}
                                    //catch (Exception ex)
                                    //{ }
                                }
                            }
                            else if (Request.QueryString["resetform"] != null || Request.RawUrl.Contains("resetform"))
                            {
                                flag = db.updateTransactionStatus_resetForm(ret_Cardnumber, retMerchantReference, retPaymentReference, retRetrievalReferenceNumber,
                                         retTransactionDate, retResponseCode, retResponseDescription, txnRef, applicationID.ToString());
                            }
                            else if (Request.QueryString["resetCourseOrIns"] != null || Request.RawUrl.Contains("resetCourseOrIns"))
                            {
                                DataSet ds = db.getNewCourseRequestINfo(applicationID.ToString());
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    string Original_JAMB_Choice_Polytechnic = ds.Tables[0].Rows[0]["Original_JAMB_Choice_Polytechnic"].ToString();
                                    string OrigJambIns = ds.Tables[0].Rows[0]["OrigJambIns"].ToString();
                                    string ChoiceCourseID = ds.Tables[0].Rows[0]["ChoiceCourseID"].ToString();
                                    string Choice_of_PolytechnicID = ds.Tables[0].Rows[0]["Choice_of_PolytechnicID"].ToString();
                                    int nID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());


                                    flag = db.updateTransactionStatus_ChangeCourseOrIns(ret_Cardnumber, retMerchantReference, retPaymentReference, retRetrievalReferenceNumber,
                                            retTransactionDate, retResponseCode, retResponseDescription, txnRef, applicationID.ToString(),
                                            Original_JAMB_Choice_Polytechnic,
                                              OrigJambIns,ChoiceCourseID,Choice_of_PolytechnicID,nID
                                            );
                                }
                            }
                            else
                            {
                                flag = db.updateTransactionStatus(ret_Cardnumber, retMerchantReference, retPaymentReference, retRetrievalReferenceNumber,
                                     retTransactionDate, retResponseCode, retResponseDescription, txnRef, startchar + startNum,startNum.ToString());


                            }

                        }

                    }
                    else if (Request.QueryString["eWalletNumber"] != null)
                    {
                        db.updateTransactionStatus_eWallet(ret_Cardnumber, retMerchantReference, retPaymentReference, retRetrievalReferenceNumber,
                                 retTransactionDate, retResponseCode, retResponseDescription, txnRef, Request.QueryString["eWalletNumber"].ToString(),actualAmount);

                    }

                    if (retResponseCode == "00")
                    {
                        string query = string.Empty;
                    
                        txtResponseLiteral = @"<div style=""width:100%"" class=""btn btn-info"">";
                       
                        if (Request.QueryString["eWalletNumber"] != null)
                        {
                            txtResponseLiteral += "   Your transaction is approved successfully and amount is deposited into eWallet <br />";
                        }
                        else
                        {
                            txtResponseLiteral += "   Your transaction is Approved Successfully <br />";
                        }
                        txtResponseLiteral += " An email has been sent to you on [" + emailAddress + "] <br />Transaction Refrence : " + txnRef + " <br /> ";
                        if (Request.QueryString["eWalletNumber"] == null && Request.QueryString["resetform"] == null && Request.QueryString["acceptanceFee"] == null && Request.QueryString["resetCourseOrIns"] == null)
                        {
                            txtResponseLiteral += " Please <a href=\"ApplicationForm.aspx?ApplicationID=" + applicationID + "\"> Click Here </a> to fill application form . </div>";
                        }
                        else if (Request.QueryString["acceptanceFee"]!= null)
                        {
                            txtResponseLiteral += " Please now complete the biometric section.</div>";
                        }
                        else if (Request.QueryString["resetCourseOrIns"] != null)
                        {
                            txtResponseLiteral += " Please <a href=\"ChangeCourseOrIns.aspx?ApplicationID=" + applicationID + "\"> Click Here </a> to update details . </div>";
                        }
                        else if (Request.QueryString["eWalletNumber"] == null)
                        {
                            txtResponseLiteral += " And your application is now open again to make changes.</div>";
                        }

                        string subject = "Your Transaction Number = " + txnRef + " has been approved.";
                        string body = "HI " + fullName + "<br />";
                        if (Request.QueryString["eWalletNumber"] != null)
                        {
                            body += "Your payment for " + actualAmount + " has been approved successfully.And deposited into your eWallet Account : " + Request.QueryString["eWalletNumber"] + "<br />";
                        }
                        else
                        {
                            body += "Your payment for " + actualAmount + " has been approved successfully.<br />";
                        }
                        body += "Your transaction refrence number is : " + txnRef + " .<br />";
                        body += "Contact support@polyibadan.edu.ng for any enquiries. <br />";
                        body += "Yours Faithfully, <br/>";
                        body += "Admission Portal Administrator <br />The Polytechnic, Ibadan";

                        try
                        {
                            utilities.sendEmail("noreply@polyibadan.edu.ng", emailAddress, subject, body);
                        }
                        catch (Exception ex)
                        { }
                    }

             
                }
                else
                {
                    if (Request.QueryString["resetform"] == null)
                    {
                        db.updateTransaction_ERROR(DateTime.Now, retResponseCode, retResponseDescription, txnRef);
                    }
                    txtResponseLiteral = @"<div style=""width:100%"" class=""btn btn-warning"">
                        Your transaction was not successfull <br />
                        Reason : " + retResponseDescription + " <br />Transaction Refrence : " + txnRef + " </div>";

                    string subject = "Your Transaction Number = " + txnRef + " has not been approved.";
                    string body = "HI " + fullName + "<br />";
                    body += "Your payment for " + actualAmount + " has not been approved .<br />";
                    body += "Reason : " + retResponseDescription + "<br />";
                    body += "Your transaction refrence number is : " + txnRef + " .<br />";
                    body += "Contact support@polyibadan.edu.ng for any enquiries. <br />";
                    body += "Yours Faithfully, <br/>";
                    body += "Admission Portal Administrator <br />The Polytechnic, Ibadan";
                    try
                    {
                        utilities.sendEmail("noreply@polyibadan.edu.ng", emailAddress, subject, body);
                    }
                    catch (Exception ex)
                    { }
                }

                literalTranscationResponse.Text = txtResponseLiteral;

            }
          
        }
        else
        {
            Response.Redirect("ProfilePage.aspx");
        }

    }

    public static string gethtml(string url, string hash)
    {
        string responseData = "";
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "Content-Type: application/json";
            request.Headers.Add("HASH", hash);
            request.UserAgent =
                "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            request.Timeout = 60000;
            request.Method = "GET";
            request.KeepAlive = true;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(responseStream);
                responseData = myStreamReader.ReadToEnd();

                //foreach (Cookie cook in response.Cookies)
                //{
                //    yummycookies.Add(cook);
                //}

            }
            response.Close();

        }
        catch (WebException e)
        {
            if (e.Response != null)
                using (var sr = new StreamReader(e.Response.GetResponseStream()))
                    responseData = sr.ReadToEnd();
        }

        return responseData;

    }

    public static string gethtml_BiometricApi(string url)
    {
        string responseData = "";
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent =
                "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            request.Timeout = 60000;
            request.Method = "GET";
            request.KeepAlive = true;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(responseStream);
                responseData = myStreamReader.ReadToEnd();

                //foreach (Cookie cook in response.Cookies)
                //{
                //    yummycookies.Add(cook);
                //}

            }
            response.Close();

        }
        catch (WebException e)
        {
            if (e.Response != null)
                using (var sr = new StreamReader(e.Response.GetResponseStream()))
                    responseData = sr.ReadToEnd();
        }

        return responseData;

    }
    
}