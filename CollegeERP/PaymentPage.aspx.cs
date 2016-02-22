using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaymentPage : System.Web.UI.Page
{
    private readonly static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    private readonly static ReaderWriterLockSlim _lockForm = new ReaderWriterLockSlim();
    public String tnx_ref;
    public String product_id = "";
    public String pay_item_id = "";
    public String amount = "";
    public String site_redirect_url = "";
    public String macKey = "";
    public String hash = "";
    public String cust_id = "";
    public String pay_item_name = "";
    public String paymentType = "";
    public String feeamount = "";
    public String studentName = "";
    public String completeName = "";
    public string eWalletFee = "";
    public string feeType = "";
    public string enumber = "";
    public string applicationID = "";
    public string admissionID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
        bool loggedStatus = false;
        if (System.Web.HttpContext.Current.User != null)
        {
            loggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (loggedStatus)
            {
                if (General.Session.Course2 == "Select Course")
                {
                    General.Session.Course2 = "";
                }
                if (Request.QueryString["depositFunds_eWallet"] != null)
                {
                    paymentFrom_eWalletPage();
                }
                else
                {
                    paymentFromApplicationPage();
                }
            }
            else
            {
                Response.Redirect("Login.aspx?ReturnUrl=" + pageName + ".aspx");
            }
        }

    }

    public void paymentFromApplicationPage()
    {
        string userId = Membership.GetUser().ProviderUserKey.ToString();
        //  loadprogrammes();
        // if (!IsPostBack)
        if ((General.Session.totalAmount != "" && General.Session.programID != "" && General.Session.OptionalCourse != "") || Request.QueryString["resetform"] != null || Request.QueryString["acceptanceFee"] != null || Request.QueryString["resetCourseOrIns"] != null)
        {
            DatabaseFunctions db = new DatabaseFunctions();

            string getprogtrypebyID = db.getProgramTypeByID(userId);
            double programFee = 0;
            int getAmount = 0;
            string userfullName = string.Empty;

            if (Request.QueryString["resetform"] != null || Request.QueryString["acceptanceFee"] != null || Request.QueryString["resetCourseOrIns"] != null)
            {
                userfullName = db.getStudent_CompleteName(userId);
                if (Request.QueryString["acceptanceFee"] != null)
                {
                    programFee = Convert.ToDouble(ConfigurationManager.AppSettings["acceptanceFee"].ToString());
                    literalFeeType.Text = "Acceptance Fee";
                    paymentType = "Acceptance Fee";
                }
                else if (Request.QueryString["resetCourseOrIns"] != null)
                {
                    programFee = Convert.ToDouble(ConfigurationManager.AppSettings["ChangeProgramOrInstitution"].ToString());
                    literalFeeType.Text = "Change of Course/Institution Fee";
                    paymentType = "Change of Course/Institution Fee";
                }
                else
                {
                    programFee = Convert.ToDouble(ConfigurationManager.AppSettings["formresetFee"].ToString());
                    literalFeeType.Text = "Application Reset Fee";
                    paymentType = "Application Reset Fee";
                    // btnPayNow.Visible = false;
                }


                literalTranscationFee.Text = ConfigurationManager.AppSettings["transcationFee"].ToString();

                double totalFee = 0;
                if (Request.QueryString["acceptanceFee"] != null)
                {
                    totalFee = (Convert.ToDouble(ConfigurationManager.AppSettings["acceptanceFee"].ToString()) + Convert.ToDouble(ConfigurationManager.AppSettings["transcationFee"].ToString()));
                }
                else if (Request.QueryString["resetCourseOrIns"] != null)
                {
                    totalFee = (Convert.ToDouble(ConfigurationManager.AppSettings["ChangeProgramOrInstitution"].ToString()) + Convert.ToDouble(ConfigurationManager.AppSettings["transcationFee"].ToString()));
                }
                else
                {
                    totalFee = (Convert.ToDouble(ConfigurationManager.AppSettings["formresetFee"].ToString()) + Convert.ToDouble(ConfigurationManager.AppSettings["transcationFee"].ToString()));
                }
                totalFee = totalFee * 100;

                literalTotalFee.Text = (totalFee / 100).ToString();


                literalFeeAmount.Text = programFee.ToString();
                literalapplicantName.Text = userfullName;
                //getAmount = Convert.ToInt32(ConfigurationManager.AppSettings["formresetFee"].ToString());
                //feeamount = ((totalFee * 100)).ToString();

                //amount = Math.Round(totalFee).ToString();

                amount = Math.Round(totalFee).ToString();
                getAmount = 0;

                if (Request.QueryString["acceptanceFee"] != null)
                {
                    getAmount = Convert.ToInt32(ConfigurationManager.AppSettings["acceptanceFee"].ToString());
                    feeamount = ((getAmount * 100) - 1499900).ToString();

                    if (getprogtrypebyID.Trim() == "Part-Time")
                    {
                        literaladdComission.Text = "<item_detail item_id=\"2\" item_name=\"DPP ACCEPTANCE\" item_amt=\"1394900\" bank_id=\"17\" acct_num=\"0008773310\" />";
                        literaladdComission.Text += "<item_detail item_id=\"3\" item_name=\"NEWAGE\" item_amt=\"105000\" bank_id=\"307\" acct_num=\"6002399309\" />";
                    }
                    else
                    {
                        literaladdComission.Text = "<item_detail item_id=\"2\" item_name=\"NEWAGE\" item_amt=\"105000\" bank_id=\"307\" acct_num=\"6002399309\" />";
                        literaladdComission.Text += "<item_detail item_id=\"3\" item_name=\"Acceptance Fees\" item_amt=\"1394900\" bank_id=\"16\" acct_num=\"0120598847\" />";
                    }
                }
                else if (Request.QueryString["resetCourseOrIns"] != null)
                {
                    getAmount = Convert.ToInt32(ConfigurationManager.AppSettings["ChangeProgramOrInstitution"].ToString());
                    feeamount = ((getAmount * 100) - 40000).ToString();

                    if (getprogtrypebyID.Trim() == "Part-Time")
                    {
                        literaladdComission.Text = "<item_detail item_id=\"2\" item_name=\"NEWAGE\" item_amt=\"40000\" bank_id=\"307\" acct_num=\"6002399309\" />";
                    }
                    else
                        literaladdComission.Text = "<item_detail item_id=\"2\" item_name=\"NEWAGE\" item_amt=\"40000\" bank_id=\"307\" acct_num=\"6002399309\" />";
                }
                else
                {
                    getAmount = Convert.ToInt32(ConfigurationManager.AppSettings["formresetFee"].ToString());
                    feeamount = ((getAmount * 100) - 100).ToString();


                    if (getprogtrypebyID.Trim() == "Part-Time")
                    {
                        literaladdComission.Text = "<item_detail item_id=\"2\" item_name=\"NEWAGE\" item_amt=\"100\" bank_id=\"307\" acct_num=\"6002399309\" />";
                    }
                    else
                        literaladdComission.Text = "<item_detail item_id=\"2\" item_name=\"NEWAGE\" item_amt=\"100\" bank_id=\"307\" acct_num=\"6002399309\" />";
                }
                optionalfee.Style.Add("display", "none");
                pname.Style.Add("display", "none");
                courses.Style.Add("display", "none");
            }
            else
            {
                programFee = Convert.ToDouble(General.Session.totalAmount) - Convert.ToDouble(General.Session.OptionalCourse);

                if (General.Session.Course2 != "")
                {
                    literalCourses.Text = General.Session.Course1 + " , " + General.Session.Course2;
                }
                else { literalCourses.Text = General.Session.Course1; }

                literalFeeType.Text = "Application Fee ";
                paymentType = "Application Fee";


                literalOptionalCourseFee.Text = General.Session.OptionalCourse;
                literalProgramame.Text = Request.QueryString["Programname"].ToString();
                userfullName = db.getStudent_CompleteName(userId);
                literalTranscationFee.Text = ConfigurationManager.AppSettings["transcationFee"].ToString();

                double totalFee = (Convert.ToDouble(General.Session.totalAmount) + Convert.ToDouble(ConfigurationManager.AppSettings["transcationFee"].ToString())) * 100;

                literalTotalFee.Text = (totalFee / 100).ToString();

                literalFeeAmount.Text = programFee.ToString();
                literalapplicantName.Text = userfullName;


                amount = Math.Round(totalFee).ToString();
                getAmount = 0;

                getAmount = Convert.ToInt32(General.Session.totalAmount);
                feeamount = ((getAmount * 100) - 105000).ToString();


                if (getprogtrypebyID.Trim() == "Part-Time")
                {
                    literaladdComission.Text = "<item_detail item_id=\"2\" item_name=\"NEWAGE\" item_amt=\"105000\" bank_id=\"307\" acct_num=\"6002399309\" />";
                }
                else
                    literaladdComission.Text = "<item_detail item_id=\"2\" item_name=\"NEWAGE\" item_amt=\"105000\" bank_id=\"307\" acct_num=\"6002399309\" />";
            }
            macKey = ConfigurationManager.AppSettings["macKey"].ToString();

            eWalletFee = getAmount.ToString();

            enumber = db.getEwalletNumber(userId);
            int status = 0;
            DataSet eInfo = db.getEwalletUserInfo(userId);
            if (eInfo.Tables[0].Rows.Count > 0)
            {
                enumber = eInfo.Tables[0].Rows[0]["enumber"].ToString();
                status = Convert.ToInt32(eInfo.Tables[0].Rows[0]["status"].ToString());

            }


            if (enumber != "")
            {
                if (status == 0)
                {
                    literaleWalletbtn.Text = "<a ID=\"btneWallet\" href=\"#\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#myModal\">Pay using eWallet</a>";
                }
                else
                {
                    literaleWalletbtn.Text = "<a ID=\"btneWallet\" href=\"#\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#myModal_Suspended\">Account Suspended</a>";
                }
            }
            else
            {
                literaleWalletbtn.Text = "<a ID=\"btneWallet\" href=\"eWalletRegistration.aspx\" class=\"btn btn-info\" >Subscribe for eWallet</a>";
            }


            feeType = paymentType;

            int optcourse = 0;
            if (General.Session.OptionalCourse != "0")
            {
                optcourse = 1;
            }

            long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;
            Random rnd = new Random();
            int x = rnd.Next(1000, 9999);
            int y = rnd.Next(1000, 9999);
            int z = rnd.Next(1000, 9999);
            milliseconds = milliseconds + x + y + z;

            tnx_ref = milliseconds.ToString();


            int rID = db.insertTransactionNumber(tnx_ref, getAmount.ToString(), userId, "InterSwitch", paymentType);
            if (rID > 0)
            {
                int newApplicationID = 0;
                if (Request.QueryString["applicationID"] != null)
                {
                    newApplicationID = Convert.ToInt32(Request.QueryString["applicationID"]);
                }
                else if (Request.QueryString["acceptanceFee"] != null)
                {
                    newApplicationID = Convert.ToInt32(Request.QueryString["acceptanceFee"]);
                }
                else
                {
                    if (General.Session.Course2ID == "")
                    {
                        General.Session.Course2ID = "0";
                    }

                    if (General.Session.OptionalCourse == "")
                    {
                        General.Session.OptionalCourse = "0";
                    }
                    newApplicationID = db.createNewApplication(userId, Convert.ToInt16(General.Session.programID), Convert.ToInt16(General.Session.Course1ID), Convert.ToInt16(General.Session.Course2ID), General.Session.Campus, optcourse, tnx_ref);
                }

                applicationID = newApplicationID.ToString();

                if (newApplicationID > 0)
                {
                    if (Request.QueryString["acceptanceFee"] != null)
                    {
                        site_redirect_url = ConfigurationManager.AppSettings["site_redirect_url"].ToString() + "ApplicationID=" + newApplicationID + "&acceptanceFee=1";
                    }
                    else if (Request.QueryString["resetCourseOrIns"] != null)
                    {
                        DataSet ds = db.getNewCourseRequestINfo_byUSERID(userId);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int nID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());

                            site_redirect_url = ConfigurationManager.AppSettings["site_redirect_url"].ToString() + "ApplicationID=" + nID + "&resetCourseOrIns=1";
                        }
                    }
                    else
                    {
                        site_redirect_url = ConfigurationManager.AppSettings["site_redirect_url"].ToString() + "ApplicationID=" + newApplicationID;

                    }

                    if (Request.QueryString["resetform"] != null)
                    {
                        site_redirect_url = site_redirect_url + "&resetform=1";
                    }

                    product_id = ConfigurationManager.AppSettings["product_id"].ToString();
                    pay_item_id = ConfigurationManager.AppSettings["pay_item_id"].ToString();

                    cust_id = Membership.GetUser().UserName.ToString();
                    completeName = userfullName;


                    String text = tnx_ref + product_id + pay_item_id + amount.ToString() + site_redirect_url + macKey;
                    hash = utilities.GetSHA512(text);
                    hash = hash.ToUpper();



                }
                else
                {
                    Response.Redirect("ProfilePage.aspx");
                }

            }
            else
            {
                Response.Redirect("ProfilePage.aspx");
            }
        }
        else
        {

            Response.Redirect("ProfilePage.aspx");
        }
    }



    public void paymentFrom_eWalletPage()
    {
        string userId = Membership.GetUser().ProviderUserKey.ToString();
        //  loadprogrammes();
        // if (!IsPostBack)


        if (Request.QueryString["totalAmount"] != null && Request.QueryString["txRef"] != null)
        {
            string totalAmount = Request.QueryString["totalAmount"].ToString();
            DatabaseFunctions db = new DatabaseFunctions();

            double programFee = Convert.ToDouble(totalAmount);

            literalFeeType.Text = "eWallet Funds Deposit";

            paymentType = "eWallet Funds Deposit";
            string userfullName = db.getStudent_CompleteName(userId);
            literalTranscationFee.Text = ConfigurationManager.AppSettings["transcationFee_eWalletDeposit"].ToString();

            double totalFee = (Convert.ToDouble(totalAmount) + Convert.ToDouble(ConfigurationManager.AppSettings["transcationFee_eWalletDeposit"].ToString())) * 100;

            literalTotalFee.Text = totalFee.ToString();
            literalFeeAmount.Text = programFee.ToString();
            literalapplicantName.Text = userfullName;


            amount = Math.Round(totalFee).ToString();
            int getAmount = 0;

            getAmount = Convert.ToInt32(totalAmount);
            feeamount = ((getAmount * 100)).ToString();

            macKey = ConfigurationManager.AppSettings["macKey"].ToString();



            tnx_ref = Request.QueryString["txRef"].ToString();


            site_redirect_url = ConfigurationManager.AppSettings["site_redirect_url"].ToString();
            product_id = ConfigurationManager.AppSettings["product_id"].ToString();
            pay_item_id = ConfigurationManager.AppSettings["pay_item_id"].ToString();

            cust_id = userId;
            completeName = userfullName;


            String text = tnx_ref + product_id + pay_item_id + amount.ToString() + site_redirect_url + macKey;
            hash = utilities.GetSHA512(text);
            hash = hash.ToUpper();





        }
        else
        {
            Response.Redirect("ProfilePage.aspx");
        }

    }


    public static NameValueCollection GetQueryStringCollection(string url)
    {
        string keyValue = string.Empty;
        NameValueCollection collection = new NameValueCollection();
        string[] querystrings = url.Split('&');
        if (querystrings != null && querystrings.Count() > 0)
        {
            for (int i = 0; i < querystrings.Count(); i++)
            {
                string[] pair = querystrings[i].Split('=');
                collection.Add(pair[0].Trim('?'), pair[1]);
            }
        }
        return collection;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string eWalletPayment(int amount, string txnRef, string feetype, string enumber, string appID, string pinCode)
    {
        string messagetxt = string.Empty;
        StringBuilder sb = new StringBuilder();
        try
        {
            string userID = Membership.GetUser().ProviderUserKey.ToString();
            string reason = string.Empty;

            pinCode = utilities.EncodePassword(pinCode.ToString(), "p!NNumb#$");
            DatabaseFunctions db = new DatabaseFunctions();
            string fullName = db.getStudent_CompleteName(userID);
            string emailAddress = Membership.GetUser().Email.ToString();

            string actualeWalletnumber = db.getEwalletNumber(userID);

            string subject = string.Empty;
            string body = string.Empty;
            int balance = 0;
            string pin = string.Empty;
            int actualAmount = 0;
            int initialAmount = 0;

            actualAmount = db.getTransactionTable_Amount_New(txnRef);
            initialAmount = actualAmount;
            actualAmount = actualAmount + Convert.ToInt32(ConfigurationManager.AppSettings["transcationFee"]);
            DataSet ewalletinfo = new DataSet();
            int status = 0;
            lock (_lock)
            {
                Thread.Sleep(3000);
                ewalletinfo = db.getEwalletNumber_pinBYeNUMBER(enumber);

                //if (ewalletinfo.Tables[0].Rows.Count > 0)
                //{
                //    balance = Convert.ToInt32(ewalletinfo.Tables[0].Rows[0]["CurrentBalance"].ToString());
                //    pin = (ewalletinfo.Tables[0].Rows[0]["pin"].ToString());
                //    if (amount == actualAmount)
                //    {
                //        if (balance >= amount && pin == pinCode)
                //        {
                //            db.updateeWalletBalance(amount, enumber);
                //        }
                //    }
                //}



                if (ewalletinfo.Tables[0].Rows.Count > 0)
                {
                    balance = Convert.ToInt32(ewalletinfo.Tables[0].Rows[0]["CurrentBalance"].ToString());
                    pin = (ewalletinfo.Tables[0].Rows[0]["pin"].ToString());
                    status = Convert.ToInt32(ewalletinfo.Tables[0].Rows[0]["status"].ToString());
                    if (status == 0)
                    {
                        if (amount == actualAmount)
                        {
                            if (balance >= amount && pin == pinCode)
                            {
                                // db.updateeWalletBalance(amount, userID);



                                string query = string.Empty;

                                if (feetype == "Application Fee")
                                {
                                    query = @"begin tran update StudentApplications set status=1 , feepaid=1 where TxRefNumber=@tnumber;
                                UPDATE Ewallet SET CurrentBalance = CurrentBalance - @3 WHERE enumber = @6; 
                                Insert into transactionlog(FeeType,TransactionNumber,Amount,TransactionDate,ResponseCode,ResponseDescription,StudentID,PaidUsing)
                                Values(@feetype,@tnumber,@amount,@tdate,@rd,@rdx,@studentID,@paidusing);
                                update StudentApplications set status=1 , feepaid=1 , formnumber=@formnum , numbercount=@ncount where TxRefNumber=@tnumber ;
                                commit";
                                    bool flagform = false;

                                    while (flagform == false)
                                    {
                                        string startchar = string.Empty;
                                        int startNum = 0;
                                        int programID = db.getOnlyProgramIDbyApplicationID(Convert.ToInt32(appID));
                                        lock (_lockForm)
                                        {
                                            DataSet ds = db.getProgramInfo(txnRef);
                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                startchar = ds.Tables[0].Rows[0]["FormCh"].ToString();
                                                startNum = Convert.ToInt32(ds.Tables[0].Rows[0]["FormNumber"].ToString());

                                                int lastFormID = db.getLastProgramIdUser(startchar, programID);
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


                                        flagform = db.updateApplicationPaymentStatus_applicationFee(Convert.ToInt32(appID), txnRef, query, 1, initialAmount, enumber, feetype, startchar + startNum, startNum);
                                    }
                                }
                                else if (feetype == "Application Reset Fee")
                                {
                                    query = @"begin tran update StudentApplications set formfilled=0  where ID=@ID ; 
                                UPDATE Ewallet SET CurrentBalance = CurrentBalance - @3 WHERE enumber = @6; 
                                Insert into transactionlog(FeeType,TransactionNumber,Amount,TransactionDate,ResponseCode,ResponseDescription,StudentID,PaidUsing)
                                Values(@feetype,@tnumber,@amount,@tdate,@rd,@rdx,@studentID,@paidusing);
                                update StudentApplications set formfilled=0  where ID=@ID 
                                commit";

                                    db.updateApplicationPaymentStatus(Convert.ToInt32(appID), txnRef, query, 0, initialAmount, enumber, feetype);




                                }
                                else if (feetype == "Change of Course/Institution Fee")
                                {
                                    DataSet ds = db.getNewCourseRequestINfo_byUSERID(userID);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        int applicationID = Convert.ToInt32(ds.Tables[0].Rows[0]["ApplicationID"].ToString());
                                        string Original_JAMB_Choice_Polytechnic = ds.Tables[0].Rows[0]["Original_JAMB_Choice_Polytechnic"].ToString();
                                        string OrigJambIns = ds.Tables[0].Rows[0]["OrigJambIns"].ToString();
                                        string ChoiceCourseID = ds.Tables[0].Rows[0]["ChoiceCourseID"].ToString();
                                        string Choice_of_PolytechnicID = ds.Tables[0].Rows[0]["Choice_of_PolytechnicID"].ToString();
                                        int nID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());

                                        query = @"begin tran update StudentApplications set formfilled=0  where ID=@ID ; 
                                UPDATE Ewallet SET CurrentBalance = CurrentBalance - @3 WHERE enumber = @6; 
                                Insert into transactionlog(FeeType,TransactionNumber,Amount,TransactionDate,ResponseCode,ResponseDescription,StudentID,PaidUsing)
                                Values(@feetype,@tnumber,@amount,@tdate,@rd,@rdx,@studentID,@paidusing);
                                update JAMB_Data set OriginalJAMBChoiceofPolytechnic=@11,OriginalJambCourse=@22 ,ChoiceOfPolytechnic=@44
    where UserID=@studentID ;
update StudentApplications set FirstCourse=@33 Where UserID=@studentID;update ResetCourseIns_Requests set status=15 where ID=@rowID;
                                commit";

                                        db.updateApplicationPaymentStatus_resetCourse(Convert.ToInt32(appID), txnRef, query, 0, initialAmount, enumber, feetype, Original_JAMB_Choice_Polytechnic,
                                            OrigJambIns, ChoiceCourseID, Choice_of_PolytechnicID, nID);
                                    }
                                }
                                else if (feetype == "Acceptance Fee")
                                {
                                    query = @"begin tran update AdmissionList set AcceptanceFeePaid=1  where ID=@applicationID ;
                            Insert into AcceptanceFee_transcationMap(AmountPaid,TransactionRef,PaymentDate,AdmissionID) Values(@amount,@tnumber,@tdate,@applicationID);
                            UPDATE Ewallet SET CurrentBalance = CurrentBalance - @amount WHERE enumber = @6;
                            Insert into transactionlog(FeeType,TransactionNumber,Amount,TransactionDate,ResponseCode,ResponseDescription,StudentID,PaidUsing)
                                Values(@feetype,@tnumber,@amount,@tdate,@rd,@rdx,@studentID,@paidusing);
                                 update AdmissionList set acceptancefeepaid=1  where ID=@admissionID ;
                Insert into AcceptanceFee_transcationMap(AmountPaid,TransactionRef,PaymentDate,AdmissionID) Values(@amount,@tnumber,@tdate,@applicationID)
                                commit"; ;
                                    int accpFee = 0;
                                    int apID = 0;
                                    NameValueCollection collection = GetQueryStringCollection(HttpContext.Current.Request.UrlReferrer.Query);
                                    if (collection != null && collection.Count > 0)
                                    {
                                        accpFee = Convert.ToInt32(HttpContext.Current.Server.UrlDecode(collection["acceptanceFee"]));
                                        apID = Convert.ToInt32(HttpContext.Current.Server.UrlDecode(collection["admission"]));
                                    }


                                    db.updateApplicationPaymentStatus_AceptanceFee(accpFee, txnRef, DateTime.Now, initialAmount.ToString(), enumber, query, feetype, apID);
                                }


                                int rowID = db.inserteWalletTranscationrow(enumber, feetype, amount.ToString(), "Debit", txnRef, "", 1);
                                if (actualeWalletnumber != enumber)
                                {
                                    db.inserteWalletTranscationrow(actualeWalletnumber, feetype, initialAmount.ToString(), "Paid By eWallet # " + enumber, txnRef, userID, 1);
                                }


                                //db.updateeWalletBalance(amount, enumber);


                                messagetxt = "You transcation has been processed successfully";
                                messagetxt = @"<div style=""width:100%"" class=""btn btn-success"">
                         " + messagetxt + " <br />Transaction Refrence : " + txnRef + "<br/> Amount of " + amount + " has been deducted from your eWallet account : " + enumber + " </div>";

                                subject = "Your Transaction Number = " + txnRef + " has  been approved.";
                                body = "HI " + fullName + "<br />";
                                body += "Your payment for " + amount + " using eWallet: " + enumber + " has been approved .<br />";
                                body += "Your transaction refrence number is : " + txnRef + " .<br />";
                                body += "Contact support@polyibadan.edu.ng for any enquiries. <br />";
                                body += "Yours Faithfully, <br/>";
                                body += "Admission Portal Administrator <br />The Polytechnic, Ibadan";


                            }
                            else
                            {
                                if (pinCode != pin)
                                {

                                    messagetxt = "Incorrect pincode !";
                                    reason = "Incorrect Pin";
                                }
                                else
                                {
                                    messagetxt = "Your do not have sufficient funds in eWallet.";
                                    reason = "Your do not have sufficient funds in eWallet.";
                                }

                                messagetxt = @"<div style=""width:100%"" class=""btn btn-warning"">
                        Your transaction was not successfull <br />
                        Reason : " + messagetxt + " <br />Transaction Refrence : " + txnRef + " </div>";

                                subject = "Your Transaction Number = " + txnRef + " has not been approved.";
                                body = "HI " + fullName + "<br />";
                                body += "Your payment for " + amount + " using eWallet: " + enumber + " has not been approved .<br />";
                                body += "Reason : " + reason + "<br />";
                                body += "Your transaction refrence number is : " + txnRef + " .<br />";
                                body += "Contact support@polyibadan.edu.ng for any enquiries. <br />";
                                body += "Yours Faithfully, <br/>";
                                body += "Admission Portal Administrator <br />The Polytechnic, Ibadan";

                            }
                        }
                        else
                        {


                            messagetxt = "The is inconsistenty in amount please try again !";

                            messagetxt = @"<div style=""width:100%"" class=""btn btn-warning"">
                        Your transaction was not successfull <br />
                        Reason : " + messagetxt + " <br />Transaction Refrence : " + txnRef + " </div>";
                        }

                    }
                    else
                    {
                        messagetxt = "Your eWallet account has been suspended !";

                        messagetxt = @"<div style=""width:100%"" class=""btn btn-warning"">
                        Your transaction was not successfull <br />
                        Reason : " + messagetxt + " <br />Transaction Refrence : " + txnRef + " </div>";
                    }


                    try
                    {
                        //   utilities.sendEmail("noreply@polyibadan.edu.ng", emailAddress, subject, body);
                    }
                    catch (Exception ex)
                    { }
                }
                else
                {
                    messagetxt = "This pinode and eNumber does not exist in our records, we have also logged this invalid attempt.";
                    db.insertInvalideWalletAttempt(userID, enumber, pin, feetype, amount.ToString(), txnRef);
                }

            }
        }
        catch (Exception ex)
        {
            messagetxt = "Error processing payment, please contact administration";

        }

        return messagetxt;
    }
}