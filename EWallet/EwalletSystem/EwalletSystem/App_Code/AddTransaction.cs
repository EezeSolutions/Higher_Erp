using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for AddTransaction
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AddTransaction : System.Web.Services.WebService
{

    public AddTransaction()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public int AddEwallet(string userid,string Enumber, string pin, string Name, string address, string portal)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        Enumber = utilities.Encrypt(Enumber);
        pin = utilities.Encrypt(pin);
        Name = utilities.Encrypt(Name);
        address = utilities.Encrypt(address);
        portal = utilities.Encrypt(portal);
        int flag = db.createeWalletAccount(userid, Enumber, pin, Name, address, portal);
        return flag;
    }
    [WebMethod]
    public string inserteWalletTranscation(string ewalletnumber, string description, string Amount, string tType, string transcationnum
        , string Portal)
    {
       
        DatabaseFunctions db = new DatabaseFunctions();
        db.inserteWalletTranscationrow(ewalletnumber, description, Amount, tType, transcationnum, Portal);

        return "Done";
    }
    [WebMethod]
    public int InserteWalletDepositForm(string Enumber, string Formtype, string paymentdate, string amountpaid, string trnum, string bankname, string OnlineBankAccountName, string BankTransactionNo, byte[] imagefile,string imageName)
    {
        int id=-1;
        try { 
        MemoryStream ms = new MemoryStream(imagefile);
        FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath
                   ("~/depositSlipScans/") + imageName, FileMode.Create);
        ms.WriteTo(fs);
         
        DatabaseFunctions db = new DatabaseFunctions();

        Enumber = utilities.Encrypt(Enumber);
        Formtype = utilities.Encrypt(Formtype);
        amountpaid=    utilities.Encrypt(amountpaid);
        trnum    =utilities.Encrypt(trnum);
        bankname = utilities.Encrypt(bankname);
        OnlineBankAccountName = utilities.Encrypt(OnlineBankAccountName);
        BankTransactionNo = utilities.Encrypt(BankTransactionNo);
        imageName = utilities.Encrypt(imageName);
        
       id=  db.InserteWalletDepositForm(Enumber,Formtype,paymentdate,amountpaid,trnum,bankname,OnlineBankAccountName,BankTransactionNo,imageName);
        ms.Close();
        fs.Close();
        fs.Dispose();
        
        }
        catch (Exception e) { 
            
            }
                return id;
    }

    [WebMethod]
    public string getEwalletNumber(string userid,string portal)
    {
        DatabaseFunctions db = new DatabaseFunctions();


        return db.getEwalletNumber(userid,portal);

    }
    [WebMethod]
    public DataSet getEwalletNumber_new(string userid,string portal)
    {
        DatabaseFunctions db = new DatabaseFunctions();


        return db.getEwalletNumber_New(userid,portal);

    }

    

    [WebMethod]
    public int insertTransactionNumber(string txnref, string amount,string userID,string paymentMethod,string paymentType,string portal,string enumber)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        return db.insertTransactionNumber(txnref, amount, userID, paymentMethod, paymentType, portal, enumber);

    }

    [WebMethod]
    public DataSet getTransactionDetails_User_Paging(int start, int end, string ewalletNumber)
    {

        DatabaseFunctions db = new DatabaseFunctions();
        return db.getTransactionDetails_User_Paging(start, end, ewalletNumber);
    }

    [WebMethod]
    public int getCountTransactionRows_User(string ewalletNumber)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        return db.getCountTransactionRows_User(ewalletNumber);
       
    }
    [WebMethod]
    public int getTransactionID_txtRef(string txNum)
    {
        DatabaseFunctions db = new DatabaseFunctions();

        int ID = db.getTransactionID_txtRef(txNum);
        return ID;
    }

    [WebMethod]
    public int getTransactionID_txtRef_depostiFOrm(string transactionnumber){

        DatabaseFunctions db = new DatabaseFunctions();
       return db.getTransactionID_txtRef_depostiFOrm(transactionnumber);
    }

    [WebMethod]
    public DataSet getTransactionDetails_txtRef_simple(string transactionnumber)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        return db.getTransactionDetails_txtRef_simple(transactionnumber);
    }

    [WebMethod]
    public int geteWalletBalancebyEnum(string enumber)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        return db.geteWalletBalancebyEnum(enumber);
    }

    [WebMethod]
    public DataSet getEwalletNumber_pin(string enumber)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        return db.getEwalletNumber_pin(enumber);
    }
    [WebMethod]
    public void transferFunds_WalletBalance(int amount, string userID,string receiverUser,string sendereWallet,string desc,string txref,string portal)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        db.transferFunds_WalletBalance( amount,  userID, receiverUser, sendereWallet, desc, txref,portal);
    }

    [WebMethod]
    public void deductewalletBalance(string Enumber, int amount, string FeeType, string TransactionNumber, string TransactionDate, string ResponseCode, string ResponseDescription, string StudentID, string PaidUsing,string portal)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        db.deductewalletBalance(Enumber, amount, FeeType, TransactionNumber, TransactionDate, ResponseCode, ResponseDescription, StudentID, PaidUsing, portal);
    }

    [WebMethod]
    public void InsertEwalletlog(string FeeType, string TransactionNumber, string amount, string TransactionDate, string ResponseCode, string ResponseDescription, string StudentID, string PaidUsing,string portal)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        db.InsertEwalletlog(FeeType, TransactionNumber, amount, TransactionDate, ResponseCode, ResponseDescription, StudentID, PaidUsing,portal);
    }

    [WebMethod]
    public void updatePincode(string pincode, string userID)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        db.updatePincode(pincode, userID);
    }
  
    [WebMethod]
public int insertInvalideWalletAttempt(string userID, string enumber, string pincode, string feetype, string amount,string txref)
    {
        DatabaseFunctions db = new DatabaseFunctions();
      return  db.insertInvalideWalletAttempt(userID, enumber, pincode, feetype, amount.ToString(), txref);

    }

}
