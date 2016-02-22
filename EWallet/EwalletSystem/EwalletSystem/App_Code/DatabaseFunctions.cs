using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DM = General.DatabaseManager;
using System.Data;
using System.Web.Security;

/// <summary>
/// Summary description for DatabaseFunctions
/// </summary>
public class DatabaseFunctions
{
    public DatabaseFunctions()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int CheckValidUser(string username, string password)
    {

        int flag = -1;
        try
        {
            SqlDataReader reader = null;
            string userType = string.Empty;
            int ID = 0;
            DataSet ds = new DataSet();
            using (DM dbManager = new DM())
            {
                //                dbManager.Command.CommandText = @"SELECT * FROM AdminUsers 
                //                                                    WHERE  username= @UserName COLLATE SQL_Latin1_General_CP1_CS_AS AND Password=(SELECT HASHBYTES('SHA1',@Password))";
                dbManager.Command.CommandText = @"SELECT * FROM AdminUsers 
                                                    WHERE  username= @UserName COLLATE SQL_Latin1_General_CP1_CS_AS AND Password=@Password";



                dbManager.Command.Parameters.AddWithValue("@userName", username);
                dbManager.Command.Parameters.AddWithValue("@Password", password);
                reader = dbManager.GetDataReader();
                if (reader.Read() == true)
                {
                    General.Session.UserName = reader.GetValue(1).ToString();

                    ID = Convert.ToInt32(reader.GetValue(0).ToString());


                    flag = 1;
                }
            }

        }
        catch (Exception exp)
        {
            throw;
        }
        return flag;

    }

    public DataSet getTransactionDetails_ALL_Paging(int start, int end)
    {
        DataSet dt = new DataSet();
        using (DM dbManager = new DM())
        {
            dbManager.Command.CommandText = @"select * from 
                                               (select (ROW_NUMBER() OVER (ORDER BY TransactionLog.ID ))AS ROW,
                                                * from TransactionLog ) as res where row between " + start + " and " + end + " ";
            // dbManager.Command.CommandText = "Select id,title,substring(detail,1,500) as DetailsFirstHalf,detail,tags from articlesforposting";

            dbManager.LoadDataSet(dt);

        }
        return dt;
    }

    public DataSet getTransactionDetails_User_Paging(int start, int end, string ewalletNumber)
    {
        DataSet dt = new DataSet();
        using (DM dbManager = new DM())
        {
            dbManager.Command.CommandText = @"select * from 
                                               (select (ROW_NUMBER() OVER (ORDER BY eWallet_History.ID ))AS ROW,
                                                * from eWallet_History where ewalletNumber=@ewalletNumber ) as res where row between " + start + " and " + end + " ";
            dbManager.Command.Parameters.AddWithValue("@ewalletNumber", ewalletNumber);

            dbManager.LoadDataSet(dt);

        }
        return dt;
    }


    public DataSet getCourse_paging(int start, int end)
    {
        DataSet dt = new DataSet();
        using (DM dbManager = new DM())
        {
            dbManager.Command.CommandText = @"select * from 
                                               (select (ROW_NUMBER() OVER (ORDER BY ct.ID ))AS ROW,
                                                  ct.ID,Course,CourseDescription,(Select programname from ProgramsTable where ID=pc.ProgramID) as programName from CoursesTable ct
join  ProgramCourse_Mapping pc  on pc.CourseID=ct.ID 
) as res where row between " + start + " and " + end + " ";

            dbManager.LoadDataSet(dt);

        }
        return dt;
    }

    public DataSet getCBTSCHEDULE_paging(int start, int end)
    {
        DataSet dt = new DataSet();
        using (DM dbManager = new DM())
        {
            dbManager.Command.CommandText = @"select * from 
                                               (select (ROW_NUMBER() OVER (ORDER BY ct.ID ))AS ROW,
                                                 *,(Select ProgramName from programsTable where ID=ct.programID) as programName from CBT_Schedules ct
) as res where row between " + start + " and " + end + " ";

            dbManager.LoadDataSet(dt);

        }
        return dt;
    }


    public DataSet getTransactionDetails_User_All()
    {
        DataSet dt = new DataSet();
        using (DM dbManager = new DM())
        {
            dbManager.Command.CommandText = @"select * from 
                                                 TransactionLog where StudentID=@userid  and  responsecode is not null ";

            dbManager.Command.Parameters.AddWithValue("@userid", Membership.GetUser().ProviderUserKey.ToString());

            dbManager.LoadDataSet(dt);

        }
        return dt;
    }

    public DataSet geteTransactionDetails_User_Paging(int start, int end)
    {
        DataSet dt = new DataSet();
        using (DM dbManager = new DM())
        {
            dbManager.Command.CommandText = @"select * from 
                                               (select (ROW_NUMBER() OVER (ORDER BY eWallet_History.ID ))AS ROW,
                                                * from eWallet_History where userID=@userid ) as res where row between " + start + " and " + end + " ";
            dbManager.Command.Parameters.AddWithValue("@userid", Membership.GetUser().ProviderUserKey.ToString());

            dbManager.LoadDataSet(dt);

        }
        return dt;
    }

    public int getCountTransactionRows_ALL()
    {
        int countProduct = -1;
        DataSet ds = new DataSet();
        try
        {
            SqlDataReader reader = null;
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select count(id) from Transactionlog";


                //reader = dbManager.GetDataReader();
                // dbManager.LoadDataSet(ds);
                countProduct = dbManager.getScopeIdentity();
            }


        }
        catch (Exception exp)
        {

        }
        return countProduct;

    }

    public int getCountTransactionRows_User(string ewalletNumber)
    {
        int countProduct = -1;
        DataSet ds = new DataSet();
        try
        {
            SqlDataReader reader = null;
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select count(id) from eWallet_History where ewalletNumber=@ewalletNumber ";

                dbManager.Command.Parameters.AddWithValue("@ewalletNumber", ewalletNumber);
                //reader = dbManager.GetDataReader();
                // dbManager.LoadDataSet(ds);
                countProduct = dbManager.getScopeIdentity();
            }


        }
        catch (Exception exp)
        {

        }
        return countProduct;

    }
    public DataSet getTransactionDetails_txtRef_simple(string transactionnumber)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * FROM Transactionlog_eWallet 
                 where TransactionNumber=@tnumber
                  ";

                dbManager.Command.Parameters.AddWithValue("@tnumber", transactionnumber);
                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {

        }
        return ds;
    }

    public int getCountTableCourses()
    {
        int countProduct = -1;
        DataSet ds = new DataSet();
        try
        {
            SqlDataReader reader = null;
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select count(id) from coursesTable";

                countProduct = dbManager.getScopeIdentity();
            }


        }
        catch (Exception exp)
        {

        }
        return countProduct;

    }

    public int getCountTableCBTSCHEDULE()
    {
        int countProduct = -1;
        DataSet ds = new DataSet();
        try
        {
            SqlDataReader reader = null;
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select count(id) from CBT_Schedules";

                countProduct = dbManager.getScopeIdentity();
            }


        }
        catch (Exception exp)
        {

        }
        return countProduct;

    }

    public int getCounteTransactionRows_User()
    {
        int countProduct = -1;
        DataSet ds = new DataSet();
        try
        {
            SqlDataReader reader = null;
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select count(id) from eWallet_History where userID=@userid";

                dbManager.Command.Parameters.AddWithValue("@userid", Membership.GetUser().ProviderUserKey.ToString());
                //reader = dbManager.GetDataReader();
                // dbManager.LoadDataSet(ds);
                countProduct = dbManager.getScopeIdentity();
            }


        }
        catch (Exception exp)
        {

        }
        return countProduct;

    }

    public DataSet getApplication_allUser_Admin(int start, int end)
    {
        int count = 0;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select * from 
                                               (select (ROW_NUMBER() OVER (ORDER BY sp.ID ))AS ROW, sp.ID,sp.UserID,(Select ProgramName from ProgramsTable where id=sp.ProgramID) as programName,
(Select Course from CoursesTable where id=sp.FirstCourse) as Course1,
(Select Course from CoursesTable where id=sp.SecondCourse) as Course2,
(Select ScheduleDate +'<br />'+ScheduleTime from Students_CbtScheduleInfo where Userid=sp.UserID) as CbtSchedule,
Campus,
 CASE WHEN FeePaid = 1 THEN 'Yes' ELSE 'No' END AS FeePaid,
 CASE WHEN OptionalCourse = 1 THEN 'Yes' ELSE 'No' END AS OptionalCourse,
CASE WHEN FormFilled = 1 THEN 'Yes' ELSE 'No' END AS FormFilled
 ,txrefnumber,sp.DateCreated
 ,Status
,formnumber ,ct.cbtscore,ct.jambscore,ct.admissionscore  from StudentApplications sp 

left join   dbo.Students_CbtResults ct on ct.UserID=sp.userID where

sp.formfilled=1 and sp.AdmissionGranted=0 ) as res where row between " + start + " and " + end + " ";

                dbManager.LoadDataSet(ds);


            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public int countApplications()
    {
        int countProduct = -1;
        DataSet ds = new DataSet();
        try
        {
            SqlDataReader reader = null;
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select count(id) from  StudentApplications where formfilled=1 and AdmissionGranted=0";


                //reader = dbManager.GetDataReader();
                // dbManager.LoadDataSet(ds);
                countProduct = dbManager.getScopeIdentity();
            }


        }
        catch (Exception exp)
        {

        }
        return countProduct;

    }



    public string getStudent_CompleteName(string userID)
    {

        string fullName = string.Empty;
        try
        {
            SqlDataReader reader = null;
            string userType = string.Empty;
            DataSet ds = new DataSet();
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT  Fullname from user_otherinfo where [userID]=@userID";
                dbManager.Command.Parameters.AddWithValue("@userID", userID);

                reader = dbManager.GetDataReader();
                if (reader.Read() == true)
                {
                    fullName = reader.GetValue(0).ToString();
                }


            }

        }
        catch (Exception exp)
        {
            throw;
        }
        return fullName;

    }

    public int getAttempts(string userID)
    {

        int attempts = 0;
        try
        {
            SqlDataReader reader = null;
            string userType = string.Empty;
            DataSet ds = new DataSet();
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT  FailedPasswordAttemptCount from Memberships where [userID]=@userID";
                dbManager.Command.Parameters.AddWithValue("@userID", userID);

                reader = dbManager.GetDataReader();
                if (reader.Read() == true)
                {
                    attempts = Convert.ToInt16(reader.GetValue(0).ToString());
                }


            }

        }
        catch (Exception exp)
        {
            throw;
        }
        return attempts;

    }

    public int insertTransactionNumber(string txnref, string amount, string userID, string paymentMethod, string paymentType,string portal,string enumber)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Insert into TransactionLog_eWallet(TransactionNumber,Amount,UserID,PaidUsing,feetype,TransactionDate,portal,eWalletnum) Values (@trnumber,@amount,@studentID,@PaidUsing,@feetype,@trdate,@portal,@enumber) ; SELECT SCOPE_IDENTITY() ;";

                dbManager.Command.Parameters.AddWithValue("@trnumber", txnref);
                dbManager.Command.Parameters.AddWithValue("@amount", amount);
                dbManager.Command.Parameters.AddWithValue("@studentID", userID);
                dbManager.Command.Parameters.AddWithValue("@PaidUsing", paymentMethod);
                dbManager.Command.Parameters.AddWithValue("@feetype", paymentType);
                dbManager.Command.Parameters.AddWithValue("@trdate",DateTime.Now.ToString("yyyy-MM-dd"));
                dbManager.Command.Parameters.AddWithValue("@portal", portal);
                dbManager.Command.Parameters.AddWithValue("@enumber", enumber);


                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());
            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int insertTransactionNumber_eW(string txnref, string amount, string userID, string paymentMethod, string paymentType)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Insert into TransactionLog(TransactionNumber,Amount,studentID,PaidUsing,transactiondate,feetype) Values (@trnumber,@amount,@studentID,@PaidUsing,@date,@ptype) ; SELECT SCOPE_IDENTITY() ;";

                dbManager.Command.Parameters.AddWithValue("@trnumber", txnref);
                dbManager.Command.Parameters.AddWithValue("@amount", amount);
                dbManager.Command.Parameters.AddWithValue("@studentID", userID);
                dbManager.Command.Parameters.AddWithValue("@PaidUsing", paymentMethod);
                dbManager.Command.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                dbManager.Command.Parameters.AddWithValue("@ptype", paymentType);

                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());
            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int insertTransactionNumber_eWallet(string txnref, string amount, string enumber, string userID)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Insert into TransactionLog_eWallet(TransactionNumber,Amount,eWalletnum,userID) Values (@trnumber,@amount,@eWalletnum,@userID) ; SELECT SCOPE_IDENTITY() ;";

                dbManager.Command.Parameters.AddWithValue("@trnumber", txnref);
                dbManager.Command.Parameters.AddWithValue("@amount", amount);
                dbManager.Command.Parameters.AddWithValue("@eWalletnum", enumber);
                dbManager.Command.Parameters.AddWithValue("@userID", userID);

                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());
            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }


    public int createeWalletAccount(string userid,string enumber, string pin, string name, string address, string portal)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Insert into [Ewallet](
           [Enumber]
           ,[Pin]
           ,[Name]
           ,[Address]
           ,[Portal]
           ,[Datecreated],[Status],[CurrentBalance],[UserId]
) Values (@1,@2,@3,@4,@5,@6,@7,@8,@9) ; SELECT SCOPE_IDENTITY() ;";
                string date = DateTime.Now.Date.ToString("yyyy-MM-d") ;
                SqlParameter param1 = new SqlParameter("@1", enumber);
                
                SqlParameter param2= new SqlParameter("@2", pin);
                SqlParameter param3 = new SqlParameter("@3", name);
                SqlParameter param4 = new SqlParameter("@4", address);
                SqlParameter param5= new SqlParameter("@5", portal);
                SqlParameter param6 = new SqlParameter("@6",date);
                SqlParameter param7 = new SqlParameter("@7", "1");
                SqlParameter param8 = new SqlParameter("@8", "0");
                SqlParameter param9 = new SqlParameter("@9", userid);

                dbManager.Command.Parameters.Add(param1);
                dbManager.Command.Parameters.Add(param2);
                dbManager.Command.Parameters.Add(param3);
                dbManager.Command.Parameters.Add(param4);
                dbManager.Command.Parameters.Add(param5);
                dbManager.Command.Parameters.Add(param6);
                dbManager.Command.Parameters.Add(param7);
                dbManager.Command.Parameters.Add(param8);
                dbManager.Command.Parameters.Add(param9);
                //dbManager.Command.Parameters.AddWithValue("@2", pin);
                //dbManager.Command.Parameters.AddWithValue("@3", name);
                //dbManager.Command.Parameters.AddWithValue("@4", address);
                //dbManager.Command.Parameters.AddWithValue("@5", portal);

                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());
            }
        }
        catch (Exception exp)
        {

        }

        return id;
    }


    public int getTransactionTable_Amount(string transactionNumber)
    {

        int flag = -1;
        try
        {
            SqlDataReader reader = null;
            string userType = string.Empty;
            DataSet ds = new DataSet();
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT  Amount from TransactionLog Where TransactionNumber=@trnumber";
                dbManager.Command.Parameters.AddWithValue("@trnumber", transactionNumber);

                reader = dbManager.GetDataReader();
                if (reader.Read() == true)
                {
                    flag = Convert.ToInt32(reader.GetValue(0).ToString());
                }


            }

        }
        catch (Exception exp)
        {
            throw;
        }
        return flag;

    }

    public DataSet getTransactionTable_Amount_feetype(string transactionNumber)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT  Amount,feetype from TransactionLog Where TransactionNumber=@trnumber";

                dbManager.Command.Parameters.AddWithValue("@trnumber", transactionNumber);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }


    public int getTransactionTable_Amount_New(string transactionNumber)
    {

        int flag = -1;
        try
        {
            SqlDataReader reader = null;
            string userType = string.Empty;
            DataSet ds = new DataSet();
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT  Amount from TransactionLog Where TransactionNumber=@trnumber;
                delete from transactionLog where TransactionNumber=@trnumber ";
                dbManager.Command.Parameters.AddWithValue("@trnumber", transactionNumber);

                reader = dbManager.GetDataReader();
                if (reader.Read() == true)
                {
                    flag = Convert.ToInt32(reader.GetValue(0).ToString());
                }


            }

        }
        catch (Exception exp)
        {
            throw;
        }
        return flag;

    }


    public bool updateTransactionStatus(string cardnumber, string MerchantRefrence, string PaymentRefrence, string RetrievalRefrence,
    string transactionDate, string responseCode, string responseDescripton, string txnRef, string formnum)
    {
        bool flag = false;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Update TransactionLog 
                Set CardNumber=@cardnumber,MerchantRefrence=@mr,PaymentRefrence=@pr,RetrievalReferenceNumber=@rf,
                TransactionDate=@tdate,ResponseCode=@response,ResponseDescription=@rdescription 
                where TransactionNumber=@tnumber ;
                update StudentApplications set status=1 , feepaid=1 , formnumber=@formnum where TxRefNumber=@tnumber ;";

                dbManager.Command.Parameters.AddWithValue("@cardnumber", cardnumber);
                dbManager.Command.Parameters.AddWithValue("@mr", MerchantRefrence);
                dbManager.Command.Parameters.AddWithValue("@pr", PaymentRefrence);
                dbManager.Command.Parameters.AddWithValue("@rf", RetrievalRefrence);
                dbManager.Command.Parameters.AddWithValue("@tdate", transactionDate);
                dbManager.Command.Parameters.AddWithValue("@response", responseCode);
                dbManager.Command.Parameters.AddWithValue("@rdescription", responseDescripton);
                dbManager.Command.Parameters.AddWithValue("@tnumber", txnRef);
                dbManager.Command.Parameters.AddWithValue("@formnum", formnum);

                dbManager.Command.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (Exception exp)
        {
            flag = false;
        }

        return flag;
    }

    public bool updateTransactionStatus_resetForm(string cardnumber, string MerchantRefrence, string PaymentRefrence, string RetrievalRefrence,
 string transactionDate, string responseCode, string responseDescripton, string txnRef, string applicationID)
    {
        bool flag = false;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Update TransactionLog 
                Set CardNumber=@cardnumber,MerchantRefrence=@mr,PaymentRefrence=@pr,RetrievalReferenceNumber=@rf,
                TransactionDate=@tdate,ResponseCode=@response,ResponseDescription=@rdescription 
                where TransactionNumber=@tnumber ;
                update StudentApplications set formfilled=0  where ID=@applicationID ;";

                dbManager.Command.Parameters.AddWithValue("@cardnumber", cardnumber);
                dbManager.Command.Parameters.AddWithValue("@mr", MerchantRefrence);
                dbManager.Command.Parameters.AddWithValue("@pr", PaymentRefrence);
                dbManager.Command.Parameters.AddWithValue("@rf", RetrievalRefrence);
                dbManager.Command.Parameters.AddWithValue("@tdate", transactionDate);
                dbManager.Command.Parameters.AddWithValue("@response", responseCode);
                dbManager.Command.Parameters.AddWithValue("@rdescription", responseDescripton);
                dbManager.Command.Parameters.AddWithValue("@tnumber", txnRef);
                dbManager.Command.Parameters.AddWithValue("@applicationID", applicationID);

                dbManager.Command.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (Exception exp)
        {
            flag = false;
        }

        return flag;
    }


    public bool updateTransactionStatus_eWallet(string cardnumber, string MerchantRefrence, string PaymentRefrence, string RetrievalRefrence,
 string transactionDate, string responseCode, string responseDescripton, string txnRef, string ewalletNum, int amount)
    {
        bool flag = false;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Update TransactionLog 
                Set CardNumber=@cardnumber,MerchantRefrence=@mr,PaymentRefrence=@pr,RetrievalReferenceNumber=@rf,
                TransactionDate=@tdate,ResponseCode=@response,ResponseDescription=@rdescription 
                where TransactionNumber=@tnumber ;
                Insert into eWallet_History(ewalletNumber,Description,Amount,Type,TransasctionRef,portal,status)
                Values (@1,@2,@3,@4,@5,@6,@7) ;

               UPDATE Ewallet SET CurrentBalance = CurrentBalance + @3 WHERE Enumber = @1";

                dbManager.Command.Parameters.AddWithValue("@cardnumber", cardnumber);
                dbManager.Command.Parameters.AddWithValue("@mr", MerchantRefrence);
                dbManager.Command.Parameters.AddWithValue("@pr", PaymentRefrence);
                dbManager.Command.Parameters.AddWithValue("@rf", RetrievalRefrence);
                dbManager.Command.Parameters.AddWithValue("@tdate", transactionDate);
                dbManager.Command.Parameters.AddWithValue("@response", responseCode);
                dbManager.Command.Parameters.AddWithValue("@rdescription", responseDescripton);
                dbManager.Command.Parameters.AddWithValue("@tnumber", txnRef);
                dbManager.Command.Parameters.AddWithValue("@1", ewalletNum);
                dbManager.Command.Parameters.AddWithValue("@2", "Deposit Funds into eWallet Account");
                dbManager.Command.Parameters.AddWithValue("@3", amount);
                dbManager.Command.Parameters.AddWithValue("@4", "Debit");
                dbManager.Command.Parameters.AddWithValue("@5", txnRef);
                dbManager.Command.Parameters.AddWithValue("@6", Membership.GetUser().ProviderUserKey.ToString());
                dbManager.Command.Parameters.AddWithValue("@7", 1);




                dbManager.Command.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (Exception exp)
        {
            flag = false;
        }

        return flag;
    }


    public void updateeWalletBalance(int amount, string userID)
    {
        using (DM dbManager = new DM())
        {
            dbManager.Command.CommandText = @"
               UPDATE Ewallet SET CurrentBalance = CurrentBalance - @3 WHERE enumber = @6;";

            dbManager.Command.Parameters.AddWithValue("@3", amount);
            dbManager.Command.Parameters.AddWithValue("@6", userID);
            dbManager.Command.ExecuteNonQuery();
        }
    }

    public void Update_eWallet_Status_Balance(string trnum, string userID, int amount)
    {
        string a = trnum;
        String status = utilities.Encrypt("0");
        try
        {
            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"BEGIN tran
               UPDATE eWalletPaymentdeposit_application SET Status = 1 WHERE TransactionNo = @1; 
               update Ewallet set CurrentBalance= CurrentBalance + @amount  Where Enumber=@userID;
               update eWallet_history set status=1 where TransasctionRef=@2
              commit";

               dbManager.Command.Parameters.AddWithValue("@2",a);
                dbManager.Command.Parameters.AddWithValue("@1", utilities.Encrypt(trnum));
                dbManager.Command.Parameters.AddWithValue("@amount", amount.ToString());
                dbManager.Command.Parameters.AddWithValue("@userID", utilities.Encrypt(userID));
                dbManager.Command.ExecuteNonQuery();


            }
        }
        catch (Exception ex)
        { }
    }



    public void transferFunds_WalletBalance(int amount, string userID, string receiverUser, string sendereWallet, string desc, string txref,string portal)
    {
        receiverUser = utilities.Encrypt(receiverUser);
        sendereWallet = utilities.Encrypt(sendereWallet);


        using (DM dbManager = new DM())
        {
            try
            {
                dbManager.Command.CommandText = @"begin tran
            UPDATE Ewallet SET CurrentBalance = CurrentBalance + @1 WHERE Enumber = @3;
            UPDATE Ewallet SET CurrentBalance = CurrentBalance - @1 WHERE Enumber = @4; 
            Insert into eWallet_History(ewalletNumber,Description,Amount,FeeType,Status,TransasctionRef,Datetime,portal)
            Values(@4,@5,@1,@6,@7,@8,@9,@10)
            commit;";

                dbManager.Command.Parameters.AddWithValue("@1", amount);

                dbManager.Command.Parameters.AddWithValue("@3", receiverUser);

                dbManager.Command.Parameters.AddWithValue("@4", sendereWallet);
                dbManager.Command.Parameters.AddWithValue("@5", desc);
                dbManager.Command.Parameters.AddWithValue("@6", "Funds Transfer");
                dbManager.Command.Parameters.AddWithValue("@7", 1);
                dbManager.Command.Parameters.AddWithValue("@8", txref);
                dbManager.Command.Parameters.AddWithValue("@9", DateTime.Now.ToString("yyyy-MM-dd"));
                dbManager.Command.Parameters.AddWithValue("@10", portal);
                dbManager.Command.ExecuteNonQuery();
            }
            catch(Exception e){

            }
        }
    }
    public DataSet updateTransaction_ERROR(DateTime transactionDate, string responseCode, string responseDescripton, string txnRef)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Update TransactionLog 
                Set TransactionDate=@tdate ,ResponseCode=@response,ResponseDescription=@rdescription 
                where TransactionNumber=@tnumber;update StudentApplications set status=5 ";

                dbManager.Command.Parameters.AddWithValue("@response", responseCode);
                dbManager.Command.Parameters.AddWithValue("@tdate", transactionDate);
                dbManager.Command.Parameters.AddWithValue("@rdescription", responseDescripton);
                dbManager.Command.Parameters.AddWithValue("@tnumber", txnRef);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet updateTransaction_ERROR_ewallet(DateTime transactionDate, string responseCode, string responseDescripton, string txnRef, string ewalletNum, int amount)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Update TransactionLog 
                Set TransactionDate=@tdate ,ResponseCode=@response,ResponseDescription=@rdescription 
                where TransactionNumber=@tnumber;update StudentApplications set status=5 ;

                Insert into eWallet_History(ewalletNumber,Description,Amount,Type,TransasctionRef,UserID,status)
                Values (@1,@2,@3,@4,@5,@6,@7) ;";

                dbManager.Command.Parameters.AddWithValue("@response", responseCode);
                dbManager.Command.Parameters.AddWithValue("@tdate", transactionDate);
                dbManager.Command.Parameters.AddWithValue("@rdescription", responseDescripton);
                dbManager.Command.Parameters.AddWithValue("@tnumber", txnRef);

                dbManager.Command.Parameters.AddWithValue("@1", ewalletNum);
                dbManager.Command.Parameters.AddWithValue("@2", "Deposit Funds into eWallet Account");
                dbManager.Command.Parameters.AddWithValue("@3", amount);
                dbManager.Command.Parameters.AddWithValue("@4", "Debit");
                dbManager.Command.Parameters.AddWithValue("@5", txnRef);
                dbManager.Command.Parameters.AddWithValue("@6", Membership.GetUser().ProviderUserKey.ToString());
                dbManager.Command.Parameters.AddWithValue("@7", 5);


                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }


    public int insertUserOtherInfo(string Fullname, string Phonenumber, string userID)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Insert into User_OtherInfo(FullName,PhoneNum,UserID) Values (@fname,@phone,@userID) ; SELECT SCOPE_IDENTITY() ;";

                dbManager.Command.Parameters.AddWithValue("@fname", Fullname);
                dbManager.Command.Parameters.AddWithValue("@phone", Phonenumber);
                dbManager.Command.Parameters.AddWithValue("@userID", userID);


                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int inserteWalletTranscationrow(string ewalletnumber, string description, string Amount, string tType, string transcationnum
        , string Portal)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                string dt = DateTime.Now.ToString("yyyy-MM-dd");
                dbManager.Command.CommandText = @"INSERT INTO [eWallet_History]
           ([ewalletNumber]
           ,[Description]
           ,[Amount]
           ,[FeeType]
           ,[TransasctionRef]
           ,[portal]
           ,[Status]
           ,[Datetime]) Values (@1,@2,@3,@4,@5,@6,@7,@8) ; SELECT SCOPE_IDENTITY() ;";

                dbManager.Command.Parameters.AddWithValue("@1", ewalletnumber);
                dbManager.Command.Parameters.AddWithValue("@2", description);
                dbManager.Command.Parameters.AddWithValue("@3", Amount);
                dbManager.Command.Parameters.AddWithValue("@4", tType);
                dbManager.Command.Parameters.AddWithValue("@5", transcationnum);
                dbManager.Command.Parameters.AddWithValue("@6", Portal);
                dbManager.Command.Parameters.AddWithValue("@7", 0);
                dbManager.Command.Parameters.AddWithValue("@8", dt);
                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int insertInvalideWalletAttempt(string userID, string enumber, string pincode, string feetype, string amount, string txref
      )
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"INSERT INTO [eWallet_invalid_payment_attempts]
           ([userID]
           ,[eNumber]
           ,[Pincode]
           ,[FeeType]
           ,[Amount],txref
          ) Values (@1,@2,@3,@4,@5,@6) ; SELECT SCOPE_IDENTITY() ;";

                dbManager.Command.Parameters.AddWithValue("@1", userID);
                dbManager.Command.Parameters.AddWithValue("@2", enumber);
                dbManager.Command.Parameters.AddWithValue("@3", pincode);
                dbManager.Command.Parameters.AddWithValue("@4", feetype);
                dbManager.Command.Parameters.AddWithValue("@5", amount);
                dbManager.Command.Parameters.AddWithValue("@5", txref);

                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int insertLockedIpInfo(string userID, string ipaddress)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Insert into AccountLock_IpInfo(LockedUserID,Ipaddress) Values (@userID,@ip) ; SELECT SCOPE_IDENTITY() ;";

                dbManager.Command.Parameters.AddWithValue("@ip", ipaddress);
                dbManager.Command.Parameters.AddWithValue("@userID", userID);


                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int createCourseAndporgramMapping(string coursename, string courseDesc, int programID)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Insert into CoursesTable(Course,CourseDescription) Values (@cname,@cdesc) ; SELECT SCOPE_IDENTITY() ;";

                dbManager.Command.Parameters.AddWithValue("@cname", coursename);
                dbManager.Command.Parameters.AddWithValue("@cdesc", courseDesc);
                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());
                if (id > 0)
                {

                    using (DM dbManager2 = new DM())
                    {
                        dbManager2.Command.CommandText = @"Insert into ProgramCourse_Mapping(CourseID,ProgramID) Values (@cID,@pID) ; ";

                        dbManager2.Command.Parameters.AddWithValue("@cID", id);
                        dbManager2.Command.Parameters.AddWithValue("@pID", programID);

                        dbManager2.Command.ExecuteNonQuery();
                    }
                }

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int createCBTSchedule(int programID, string scheduleDate, string scheduleTime, int capacity)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"INSERT INTO [AdmissionPortal_Database].[dbo].[CBT_Schedules]
           ([ProgramID]
           ,[ScheduleDate]
           ,[ScheduleTime]
           ,[Capacity]
          ) Values (@pid,@date,@time,@capacity) ; SELECT SCOPE_IDENTITY() ;";

                dbManager.Command.Parameters.AddWithValue("@pid", programID);
                dbManager.Command.Parameters.AddWithValue("@date", scheduleDate);
                dbManager.Command.Parameters.AddWithValue("@time", scheduleTime);
                dbManager.Command.Parameters.AddWithValue("@capacity", capacity);

                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());


            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int createNewApplication(string userID, int ProgramameID, int course1, int course2, string campus, int hasoptionalCourse, string transactionnumber)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"INSERT INTO [AdmissionPortal_Database].[dbo].[StudentApplications]
           ([UserID]
           ,[ProgramID]
           ,[FirstCourse]
           ,[SecondCourse]
           ,[Campus]
           ,[OptionalCourse],[TxRefNumber]
          )
     VALUES
           (@UserID,@ProgramID,@FirstCourse,@SecondCourse,@Campus,@OptionalCourse,@TxRefNumber); SELECT SCOPE_IDENTITY() ;";

                dbManager.Command.Parameters.AddWithValue("@UserID", userID);
                dbManager.Command.Parameters.AddWithValue("@ProgramID", ProgramameID);
                dbManager.Command.Parameters.AddWithValue("@FirstCourse", course1);
                dbManager.Command.Parameters.AddWithValue("@SecondCourse", course2);
                dbManager.Command.Parameters.AddWithValue("@Campus", campus);
                dbManager.Command.Parameters.AddWithValue("@OptionalCourse", hasoptionalCourse);
                dbManager.Command.Parameters.AddWithValue("@TxRefNumber", transactionnumber);


                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }


    public DataSet getProgramByName(string programName)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT ID FROM ProgramsTable where programName = @pname ";
                dbManager.Command.Parameters.AddWithValue("@pname", programName);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;



    }

    public DataSet getProgramByID(int ID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * FROM ProgramsTable where ID = @pname ";
                dbManager.Command.Parameters.AddWithValue("@pname", ID);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;



    }

    public DataSet getProgramIDbyApplicationID(int ID)
    {
        int programID = 0;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT programID,FormNumber
                ,HasJambData,HasBioDataSection,HasOlevelResult,HasPreviousRecord,HasCBTSchedule

                FROM StudentApplications sp
                join ProgramsTable pt on pt.ID=sp.ProgramID
                where sp.ID = @ID ";
                dbManager.Command.Parameters.AddWithValue("@ID", ID);

                dbManager.LoadDataSet(ds);

            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;



    }

    public int createProgramm(string programame, string applicationfee, string startingFormnum, string programmtype, string hadJambdata, string hadBIoDataSection, string hadPreviousRecords, string hascbtschduled, string hasolevelresult, string hassecondchoise, string hascampus, string instanadmission, string formch)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"INSERT INTO [AdmissionPortal_Database].[dbo].[ProgramsTable]
           ([ProgramName]
           ,[ApplicationFee]
           ,[StartingFormnum]
           ,[ProgramType]
           ,[HasJambData]
           ,[HasBioDataSection]
           ,[HasPreviousRecord]
           ,[HasCBTSchedule]
           ,[HasOlevelResult],[SecondChoice],[HasCampus],[InstantAdmission],[StartingFormn_Char]
           )
     VALUES
           (@ProgramName,@ApplicationFee,@StartingFormnum,@ProgramType,@HasJambData,@HasBioDataSection,@HasPreviousRecord,@HasCBTSchedule,@HasOlevelResult,@secondchoice,@hascampus,@instantadmission,@formch); Select SCOPE_IDENTITY();";

                dbManager.Command.Parameters.AddWithValue("@ProgramName", programame);
                dbManager.Command.Parameters.AddWithValue("@ApplicationFee", applicationfee);
                dbManager.Command.Parameters.AddWithValue("@StartingFormnum", startingFormnum);
                dbManager.Command.Parameters.AddWithValue("@ProgramType", programmtype);
                dbManager.Command.Parameters.AddWithValue("@HasJambData", hadJambdata);
                dbManager.Command.Parameters.AddWithValue("@HasBioDataSection", hadBIoDataSection);
                dbManager.Command.Parameters.AddWithValue("@HasPreviousRecord", hadPreviousRecords);
                dbManager.Command.Parameters.AddWithValue("@HasCBTSchedule", hascbtschduled);
                dbManager.Command.Parameters.AddWithValue("@HasOlevelResult", hasolevelresult);

                dbManager.Command.Parameters.AddWithValue("@secondchoice", hassecondchoise);
                dbManager.Command.Parameters.AddWithValue("@hascampus", hascampus);
                dbManager.Command.Parameters.AddWithValue("@instantadmission", instanadmission);
                dbManager.Command.Parameters.AddWithValue("@formch", formch);

                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int UpdateProgramm(string programame, string applicationfee, string startingFormnum, string programmtype, string hadJambdata, string hadBIoDataSection, string hadPreviousRecords, string hascbtschduled, string hasolevelresult, string hassecondchoise, string hascampus, string instanadmission, string formch, string rowID)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Update [AdmissionPortal_Database].[dbo].[ProgramsTable]
            set [ProgramName]=@1,[ApplicationFee]=@2,[StartingFormnum]=@3,[ProgramType]=@4,[HasJambData]=@5
           ,[HasBioDataSection]=@6,[HasPreviousRecord]=@7,[HasCBTSchedule]=@8,[HasOlevelResult]=@9
           ,[SecondChoice]=@10,[HasCampus]=@11,[InstantAdmission]=@12,[StartingFormn_Char]=@13 where ID=@rowID
          ";

                dbManager.Command.Parameters.AddWithValue("@rowID", rowID);
                dbManager.Command.Parameters.AddWithValue("@1", programame);
                dbManager.Command.Parameters.AddWithValue("@2", applicationfee);
                dbManager.Command.Parameters.AddWithValue("@3", startingFormnum);
                dbManager.Command.Parameters.AddWithValue("@4", programmtype);
                dbManager.Command.Parameters.AddWithValue("@5", hadJambdata);
                dbManager.Command.Parameters.AddWithValue("@6", hadBIoDataSection);
                dbManager.Command.Parameters.AddWithValue("@7", hadPreviousRecords);
                dbManager.Command.Parameters.AddWithValue("@8", hascbtschduled);
                dbManager.Command.Parameters.AddWithValue("@9", hasolevelresult);

                dbManager.Command.Parameters.AddWithValue("@10", hassecondchoise);
                dbManager.Command.Parameters.AddWithValue("@11", hascampus);
                dbManager.Command.Parameters.AddWithValue("@12", instanadmission);
                dbManager.Command.Parameters.AddWithValue("@13", formch);

                dbManager.Command.ExecuteNonQuery();

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int updateeWalletUser(string status, string enumber)
    {
        int id = -1;
        enumber = utilities.Encrypt(enumber);
            try
            {

                using (DM dbManager = new DM())
                {
                    dbManager.Command.CommandText = @" update eWallet  set status=@status
              where Enumber=@enum ;";


                    dbManager.Command.Parameters.AddWithValue("@status", status);
                    dbManager.Command.Parameters.AddWithValue("@enum", enumber);

                    dbManager.Command.ExecuteNonQuery();

                }
            }
            catch (Exception exp)
            {
                throw;
            }

        return id;
    }


    public int updateCourseInfo(string coursename, string courseDesc, int programID, int rowID)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @" update CoursesTable set Course=@cname,CourseDescription=@cdesc where ID=@rowID ;
                update ProgramCourse_Mapping set programID=@pID where courseID=@rowID
                ";

                dbManager.Command.Parameters.AddWithValue("@cname", coursename);
                dbManager.Command.Parameters.AddWithValue("@cdesc", courseDesc);
                dbManager.Command.Parameters.AddWithValue("@rowID", courseDesc);
                dbManager.Command.Parameters.AddWithValue("@pID", programID);

                dbManager.Command.ExecuteNonQuery();

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }


    public int InsertJambData(string RegNo, string jambregno, string sub1, string score1, string sub2, string score2, string sub3, string score3, string sub4, string score4, string choicePoly, string userID)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @" IF EXISTS (Select ID from JAMB_Data Where RegNo=@1)
BEGIN    update   JAMB_Data set JambRegNo=@2,subject1=@3,score1=@4,subject2=@5,score2=@6,
subject3=@7,score3=@8,subject4=@9,score4=@10,ChoiceOfPolytechnic=@11   where userid=@12      END
ELSE  
BEGIN
INSERT INTO [AdmissionPortal_Database].[dbo].[JAMB_Data]
           ([RegNo]
           ,[JambRegNo]
           ,[Subject1]
           ,[Score1]
           ,[Subject2]
           ,[Score2]
           ,[Subject3]
           ,[Score3]
           ,[Subject4]
           ,[Score4],[ChoiceOfPolytechnic],[userID]
           )
     VALUES
           (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12);  Select SCOPE_IDENTITY(); END";

                dbManager.Command.Parameters.AddWithValue("@1", RegNo);
                dbManager.Command.Parameters.AddWithValue("@2", jambregno);
                dbManager.Command.Parameters.AddWithValue("@3", sub1);
                dbManager.Command.Parameters.AddWithValue("@4", score1);
                dbManager.Command.Parameters.AddWithValue("@5", sub2);
                dbManager.Command.Parameters.AddWithValue("@6", score2);
                dbManager.Command.Parameters.AddWithValue("@7", sub3);
                dbManager.Command.Parameters.AddWithValue("@8", score3);
                dbManager.Command.Parameters.AddWithValue("@9", sub4);

                dbManager.Command.Parameters.AddWithValue("@10", score4);
                dbManager.Command.Parameters.AddWithValue("@11", choicePoly);
                dbManager.Command.Parameters.AddWithValue("@12", userID);


                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int InsertBioData(string RegNo, string surname, string fname, string oname, string gender, string address, string phone, string email, string state, string localgov, string userID, string profilepic, string DOB)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @" IF EXISTS (Select ID from [Students_BioData] Where RegNo=@2)
BEGIN    update   [Students_BioData] 

set surname=@3,firstname=@4,othername=@5,gender=@6,
address=@7,Phonenumber=@8,email=@9,state=@10,localgovtarea=@11,ProfilePic=@12,DOB=@13  where Userid=@1

END
ELSE  
BEGIN
INSERT INTO [Students_BioData]
           ([UserID]
           ,[RegNo]
           ,[Surname]
           ,[Firstname]
           ,[Othername]
           ,[Gender]
           ,[Address]
           ,[Phonenumber]
           ,[Email]
           ,[State]
           ,[LocalGovtArea],[ProfilePic],[DOB]
           )
     VALUES
           (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13);  Select SCOPE_IDENTITY(); END";

                dbManager.Command.Parameters.AddWithValue("@1", userID);
                dbManager.Command.Parameters.AddWithValue("@2", RegNo);
                dbManager.Command.Parameters.AddWithValue("@3", surname);
                dbManager.Command.Parameters.AddWithValue("@4", fname);
                dbManager.Command.Parameters.AddWithValue("@5", oname);
                dbManager.Command.Parameters.AddWithValue("@6", gender);
                dbManager.Command.Parameters.AddWithValue("@7", address);
                dbManager.Command.Parameters.AddWithValue("@8", phone);
                dbManager.Command.Parameters.AddWithValue("@9", email);

                dbManager.Command.Parameters.AddWithValue("@10", state);
                dbManager.Command.Parameters.AddWithValue("@11", localgov);
                dbManager.Command.Parameters.AddWithValue("@12", profilepic);
                dbManager.Command.Parameters.AddWithValue("@13", DOB);

                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }

    public int InsertOlevelInfo_FirstSitting(string RegNo, string userid, string examtype, string exammonth, string examnumber, string examyear,
    string sub1, string grade1, string sub2, string grade2, string sub3, string grade3, string sub4, string grade4,
    string sub5, string grade5, string sub6, string grade6, string sub7, string grade7, string sub8, string grade8, string sub9, string grade9)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @" IF EXISTS (Select ID from [Student_OlevelInfo_FirstSitting] Where RegNo=@1)
BEGIN    update   [Student_OlevelInfo_FirstSitting] 

set Examtype=@3,exammonth=@4,examnumber=@5,examyear=@6,
subject1=@7,grade1=@8,subject2=@9,grade2=@10,subject3=@11,grade3=@12,subject4=@13,grade4=@14,
subject5=@15,grade5=@16,subject6=@17,grade6=@18,subject7=@19,grade7=@20,subject8=@21,grade8=@22,subject9=@23,grade9=@24

where UserID=@2

END
ELSE  
BEGIN
INSERT INTO [Student_OlevelInfo_FirstSitting]
           ([Regno]
           ,[UserID]
           ,[Examtype]
           ,[Exammonth]
           ,[Examnumber]
           ,[ExamYear]
           ,[Subject1]
           ,[Grade1]
           ,[Subject2]
           ,[Grade2]
           ,[Subject3]
           ,[Grade3]
           ,[Subject4]
           ,[Grade4]
           ,[Subject5]
           ,[Grade5]
           ,[Subject6]
           ,[Grade6]
           ,[Subject7]
           ,[Grade7]
           ,[Subject8]
           ,[Grade8]
           ,[Subject9]
           ,[Grade9]
           )
     VALUES
           (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24);  Select SCOPE_IDENTITY(); END";

                dbManager.Command.Parameters.AddWithValue("@1", RegNo);
                dbManager.Command.Parameters.AddWithValue("@2", userid);
                dbManager.Command.Parameters.AddWithValue("@3", examtype);
                dbManager.Command.Parameters.AddWithValue("@4", exammonth);
                dbManager.Command.Parameters.AddWithValue("@5", examnumber);
                dbManager.Command.Parameters.AddWithValue("@6", examyear);
                dbManager.Command.Parameters.AddWithValue("@7", sub1);
                dbManager.Command.Parameters.AddWithValue("@8", grade1);
                dbManager.Command.Parameters.AddWithValue("@9", sub2);

                dbManager.Command.Parameters.AddWithValue("@10", grade2);
                dbManager.Command.Parameters.AddWithValue("@11", sub3);
                dbManager.Command.Parameters.AddWithValue("@12", grade3);
                dbManager.Command.Parameters.AddWithValue("@13", sub4);
                dbManager.Command.Parameters.AddWithValue("@14", grade4);
                dbManager.Command.Parameters.AddWithValue("@15", sub5);
                dbManager.Command.Parameters.AddWithValue("@16", grade5);
                dbManager.Command.Parameters.AddWithValue("@17", sub6);
                dbManager.Command.Parameters.AddWithValue("@18", grade6);
                dbManager.Command.Parameters.AddWithValue("@19", sub7);
                dbManager.Command.Parameters.AddWithValue("@20", grade7);
                dbManager.Command.Parameters.AddWithValue("@21", sub8);
                dbManager.Command.Parameters.AddWithValue("@22", grade8);
                dbManager.Command.Parameters.AddWithValue("@23", sub9);
                dbManager.Command.Parameters.AddWithValue("@24", grade9);


                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }


    public int InsertOlevelInfo_SecondSitting(string RegNo, string userid, string examtype, string exammonth, string examnumber, string examyear,
   string sub1, string grade1, string sub2, string grade2, string sub3, string grade3, string sub4, string grade4,
   string sub5, string grade5, string sub6, string grade6, string sub7, string grade7, string sub8, string grade8, string sub9, string grade9)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @" IF EXISTS (Select ID from [Student_OlevelInfo_SecondSitting] Where RegNo=@1)
BEGIN    update   [Student_OlevelInfo_SecondSitting] 

set Examtype=@3,exammonth=@4,examnumber=@5,examyear=@6,
subject1=@7,grade1=@8,subject2=@9,grade2=@10,subject3=@11,grade3=@12,subject4=@13,grade4=@14,
subject5=@15,grade5=@16,subject6=@17,grade6=@18,subject7=@19,grade7=@20,subject8=@21,grade8=@22,subject9=@23,grade9=@24

where UserID=@2

END
ELSE  
BEGIN
INSERT INTO [Student_OlevelInfo_SecondSitting]
           ([Regno]
           ,[UserID]
           ,[Examtype]
           ,[Exammonth]
           ,[Examnumber]
           ,[ExamYear]
           ,[Subject1]
           ,[Grade1]
           ,[Subject2]
           ,[Grade2]
           ,[Subject3]
           ,[Grade3]
           ,[Subject4]
           ,[Grade4]
           ,[Subject5]
           ,[Grade5]
           ,[Subject6]
           ,[Grade6]
           ,[Subject7]
           ,[Grade7]
           ,[Subject8]
           ,[Grade8]
           ,[Subject9]
           ,[Grade9]
           )
     VALUES
           (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24);  Select SCOPE_IDENTITY(); END";

                dbManager.Command.Parameters.AddWithValue("@1", RegNo);
                dbManager.Command.Parameters.AddWithValue("@2", userid);
                dbManager.Command.Parameters.AddWithValue("@3", examtype);
                dbManager.Command.Parameters.AddWithValue("@4", exammonth);
                dbManager.Command.Parameters.AddWithValue("@5", examnumber);
                dbManager.Command.Parameters.AddWithValue("@6", examyear);
                dbManager.Command.Parameters.AddWithValue("@7", sub1);
                dbManager.Command.Parameters.AddWithValue("@8", grade1);
                dbManager.Command.Parameters.AddWithValue("@9", sub2);

                dbManager.Command.Parameters.AddWithValue("@10", grade2);
                dbManager.Command.Parameters.AddWithValue("@11", sub3);
                dbManager.Command.Parameters.AddWithValue("@12", grade3);
                dbManager.Command.Parameters.AddWithValue("@13", sub4);
                dbManager.Command.Parameters.AddWithValue("@14", grade4);
                dbManager.Command.Parameters.AddWithValue("@15", sub5);
                dbManager.Command.Parameters.AddWithValue("@16", grade5);
                dbManager.Command.Parameters.AddWithValue("@17", sub6);
                dbManager.Command.Parameters.AddWithValue("@18", grade6);
                dbManager.Command.Parameters.AddWithValue("@19", sub7);
                dbManager.Command.Parameters.AddWithValue("@20", grade7);
                dbManager.Command.Parameters.AddWithValue("@21", sub8);
                dbManager.Command.Parameters.AddWithValue("@22", grade8);
                dbManager.Command.Parameters.AddWithValue("@23", sub9);
                dbManager.Command.Parameters.AddWithValue("@24", grade9);


                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }


    public int InsertPreviousRecord(string RegNo, string userid, string jambregno, string jambexamyear, string jambfullname
    , string institutionattended, string coursename, string coursetype, string coursegrade, string yearcompleted, string indstart, string indend)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @" IF EXISTS (Select ID from [Students_PreviousRecord] Where UserID=@2)
BEGIN    update   [Students_PreviousRecord] 

set JAMBRegno=@3,JambExamyear=@4,JambFullName=@5,InstitutionAttented=@6,
CourseName=@7,CourseType=@8,CourseGrade=@9,YearCompleted=@10,IndTrainingStart=@11,IndTrainingEnd=@12  where Userid=@2

END
ELSE  
BEGIN
INSERT INTO [Students_PreviousRecord]
           ([RegNo]
           ,[UserID]
           ,[JAMBRegno]
           ,[JambExamyear]
           ,[JambFullName]
           ,[InstitutionAttented]
           ,[CourseName]
           ,[CourseType]
           ,[CourseGrade]
           ,[YearCompleted]
           ,[IndTrainingStart]
           ,[IndTrainingEnd]
           )
     VALUES
           (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12);  Select SCOPE_IDENTITY(); END";

                dbManager.Command.Parameters.AddWithValue("@1", RegNo);
                dbManager.Command.Parameters.AddWithValue("@2", userid);
                dbManager.Command.Parameters.AddWithValue("@3", jambregno);
                dbManager.Command.Parameters.AddWithValue("@4", jambexamyear);
                dbManager.Command.Parameters.AddWithValue("@5", jambfullname);
                dbManager.Command.Parameters.AddWithValue("@6", institutionattended);
                dbManager.Command.Parameters.AddWithValue("@7", coursename);
                dbManager.Command.Parameters.AddWithValue("@8", coursetype);
                dbManager.Command.Parameters.AddWithValue("@9", coursegrade);

                dbManager.Command.Parameters.AddWithValue("@10", yearcompleted);
                dbManager.Command.Parameters.AddWithValue("@11", indstart);
                dbManager.Command.Parameters.AddWithValue("@12", indend);

                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }


    public int InsertCbtScheduleIngo(string RegNo, string userid, string date, string time, string cbuser, string cbpass)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @" IF EXISTS (Select ID from [Students_CbtScheduleInfo] Where UserID=@2)
BEGIN    update   [Students_CbtScheduleInfo] 

set ScheduleDate=@3,ScheduleTime=@4,CbtUserName=@5,CbtPassword=@6  where Userid=@2 

END
ELSE  
BEGIN
INSERT INTO [Students_CbtScheduleInfo]
           ([RegNo]
           ,[UserID]
           ,[ScheduleDate]
           ,[ScheduleTime]
           ,[CbtUserName]
           ,[CbtPassword]
           )
     VALUES
           (@1,@2,@3,@4,@5,@6);  Select SCOPE_IDENTITY(); END";

                dbManager.Command.Parameters.AddWithValue("@1", RegNo);
                dbManager.Command.Parameters.AddWithValue("@2", userid);
                dbManager.Command.Parameters.AddWithValue("@3", date);
                dbManager.Command.Parameters.AddWithValue("@4", time);
                dbManager.Command.Parameters.AddWithValue("@5", cbuser);
                dbManager.Command.Parameters.AddWithValue("@6", cbpass);

                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }


    public int InserteWalletDepositForm(string userID, string Formtype, string paymentdate, string amountpaid, string trnum, string bankname, string OnlineBankAccountName, string BankTransactionNo, string imageName)
    {
        int id = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @" IF EXISTS (Select ID from [eWalletPaymentdeposit_application] Where TransactionNo=@5)
BEGIN    update   [eWalletPaymentdeposit_application] 

set Formtype=@2, PaymentDate=@3,AmountPaid=@4,Bankname=@6,OnlineBankAccountName=@7,BankTransactionNo=@8,ImageName=@9

where TransactionNo=@5
END
ELSE  
BEGIN
INSERT INTO [eWalletPaymentdeposit_application]
           ([Enumber]
           ,[FormType]
           ,[PaymentDate]
           ,[AmountPaid]
           ,[TransactionNo]
           ,[Bankname]
           ,[OnlineBankAccountName]
           ,[BankTransactionNo],[ImageName],[DateSubmitted]
           )
     VALUES
           (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10);  Select SCOPE_IDENTITY(); END";

                dbManager.Command.Parameters.AddWithValue("@1", userID);
                dbManager.Command.Parameters.AddWithValue("@2", Formtype);
                dbManager.Command.Parameters.AddWithValue("@3", paymentdate);
                dbManager.Command.Parameters.AddWithValue("@4", amountpaid);
                dbManager.Command.Parameters.AddWithValue("@5", trnum);
                dbManager.Command.Parameters.AddWithValue("@6", bankname);
                dbManager.Command.Parameters.AddWithValue("@7", OnlineBankAccountName);
                dbManager.Command.Parameters.AddWithValue("@8", BankTransactionNo);
                dbManager.Command.Parameters.AddWithValue("@9", imageName);
                dbManager.Command.Parameters.AddWithValue("@10", DateTime.Now.ToString("yyyy-MM-dd"));


                id = Convert.ToInt32(dbManager.Command.ExecuteScalar());

            }
        }
        catch (Exception exp)
        {
            throw;
        }

        return id;
    }




    public DataSet getProgrames(int status)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * FROM ProgramsTable where status = @status ";
                dbManager.Command.Parameters.AddWithValue("@status", status);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getCourses()
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * FROM CoursesTable ";

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getCoursINFObyID(int ID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select Course,CourseDescription,pc.ProgramID as programID from CoursesTable ct
join  ProgramCourse_Mapping pc  on pc.CourseID=ct.ID  where ct.ID=@rowID";

                dbManager.Command.Parameters.AddWithValue("@rowID", ID);
                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getCoursesComplete()
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select *,(Select programname from ProgramsTable where ID=pc.ProgramID) as programName from CoursesTable ct
join  ProgramCourse_Mapping pc  on pc.CourseID=ct.ID";

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }



    public DataSet getProgramInfo(string refno)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select StartingFormn_Char, StartingFormnum from ProgramsTable where ID in (

select programid from StudentApplications where TxRefNumber=@refno)";

                dbManager.Command.Parameters.AddWithValue("@refno", refno);
                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public int getLastProgramIdUser(string startChar)
    {
        int lastID = 0;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Select top 1 FormNumber from StudentApplications where Formnumber  like '%" + startChar + "%'";
                dbManager.LoadDataSet(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lastID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString().Replace(startChar, "").Trim());
                }
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return lastID;
    }

    public DataSet getCourses_byProgramID(int pid)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Select * from CoursesTable where ID in
(select courseid from ProgramCourse_Mapping where ProgramID=@pid)";

                dbManager.Command.Parameters.AddWithValue("@pid", pid);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet checkProgramRowMapping(string courseName, int programID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @" Select * from ProgramCourse_Mapping where ProgramID = @pID
                and   CourseID in (SELECT ID  FROM CoursesTable where course = @cname )";

                dbManager.Command.Parameters.AddWithValue("@cname", courseName);
                dbManager.Command.Parameters.AddWithValue("@pID", programID);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getProgramesAll()
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT [ID]
      ,[ProgramName]
      ,[ApplicationFee]
      ,[StartingFormnum],[StartingFormn_Char]
      ,[ProgramType]
      ,CASE WHEN [HasJambData] = 1 THEN 'Yes' ELSE 'No' END AS [HasJambData]
      ,CASE WHEN [HasBioDataSection] = 1 THEN 'Yes' ELSE 'No' END AS [HasBioDataSection]
      ,CASE WHEN [HasPreviousRecord] = 1 THEN 'Yes' ELSE 'No' END AS [HasPreviousRecord]
      ,CASE WHEN [HasCBTSchedule] = 1 THEN 'Yes' ELSE 'No' END AS [HasCBTSchedule]
      ,CASE WHEN [HasOlevelResult] = 1 THEN 'Yes' ELSE 'No' END AS [HasOlevelResult]
      ,CASE WHEN [SecondChoice] = 1 THEN 'Yes' ELSE 'No' END AS [SecondChoice]
      ,CASE WHEN [HasCampus] = 1 THEN 'Yes' ELSE 'No' END AS [HasCampus]
      ,CASE WHEN [InstantAdmission] = 1 THEN 'Yes' ELSE 'No' END AS [InstantAdmission]
      ,[Status]
      ,[DateCreated]
  FROM [AdmissionPortal_Database].[dbo].[ProgramsTable]";


                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public int getProgramesAll_Count()
    {
        DataSet ds = new DataSet();
        int rows = 0;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT count(id) from [ProgramsTable]";


                dbManager.LoadDataSet(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    rows = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                }
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return rows;
    }

    public DataSet getProgrames_pagination(int start, int end)
    {
        DataSet dt = new DataSet();
        using (DM dbManager = new DM())
        {
            dbManager.Command.CommandText = @"select * from 
                                               (select (ROW_NUMBER() OVER (ORDER BY ProgramsTable.ID ))AS ROW
                                                ,[ProgramName],ID
      ,[ApplicationFee]
      ,[StartingFormnum],[StartingFormn_Char]
      ,[ProgramType]
      ,CASE WHEN [HasJambData] = 1 THEN 'Yes' ELSE 'No' END AS [HasJambData]
      ,CASE WHEN [HasBioDataSection] = 1 THEN 'Yes' ELSE 'No' END AS [HasBioDataSection]
      ,CASE WHEN [HasPreviousRecord] = 1 THEN 'Yes' ELSE 'No' END AS [HasPreviousRecord]
      ,CASE WHEN [HasCBTSchedule] = 1 THEN 'Yes' ELSE 'No' END AS [HasCBTSchedule]
      ,CASE WHEN [HasOlevelResult] = 1 THEN 'Yes' ELSE 'No' END AS [HasOlevelResult]
      ,CASE WHEN [SecondChoice] = 1 THEN 'Yes' ELSE 'No' END AS [SecondChoice]
      ,CASE WHEN [HasCampus] = 1 THEN 'Yes' ELSE 'No' END AS [HasCampus]
      ,CASE WHEN [InstantAdmission] = 1 THEN 'Yes' ELSE 'No' END AS [InstantAdmission]
      ,[Status]
      ,[DateCreated] from ProgramsTable ) as res where row between " + start + " and " + end + " ";

            dbManager.LoadDataSet(dt);

        }
        return dt;
    }

    public DataSet getUserOtherInfo(string userID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * FROM User_OtherInfo where userID = @userID ";
                dbManager.Command.Parameters.AddWithValue("@userID", userID);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getUsersByName(string fullname)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT *,(Select username from users where userID=uo.userID ) as username FROM User_OtherInfo uo Join Memberships m on m.UserID=uo.UserID where uo.fullname like '%" + fullname + "%'      ";

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getAllusers()
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT *,(Select username from users where userID=uo.userID ) as username FROM User_OtherInfo uo Join Memberships m on m.UserID=uo.UserID      ";

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public string getEwalletNumber(string userID,string portal)
    {
        string enumber = string.Empty;
        portal = utilities.Encrypt(portal);
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT enumber from ewallet where userID=@userID and portal=@portal";

                dbManager.Command.Parameters.AddWithValue("@userID", userID);
                dbManager.Command.Parameters.AddWithValue("@portal", portal);

                dbManager.LoadDataSet(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    enumber = ds.Tables[0].Rows[0][0].ToString();
                }
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return enumber;
    }

    public int geteWalletBalance(string userID)
    {
        int balance = 0;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT CurrentBalance from ewallet where userID=@userID";

                dbManager.Command.Parameters.AddWithValue("@userID", userID);

                dbManager.LoadDataSet(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    balance = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return balance;
    }

    public int geteWalletBalancebyEnum(string enumber)
    {
        enumber = utilities.Encrypt(enumber);
        int balance = -1;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT CurrentBalance from ewallet where enumber=@enumber";

                dbManager.Command.Parameters.AddWithValue("@enumber", enumber);

                dbManager.LoadDataSet(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    balance = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return balance;
    }


    public DataSet getEwalletNumber_New(string enumber,string portal)
    {
        portal = utilities.Encrypt(portal);
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT enumber,CurrentBalance,status from ewallet where UserId=@enumber";

                dbManager.Command.Parameters.AddWithValue("@enumber", enumber);

                dbManager.LoadDataSet(ds);

            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet geteWalletrow(int rowID)
    {
        string enumber = string.Empty;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from eWallet_History where ID=@userID";

                dbManager.Command.Parameters.AddWithValue("@userID", rowID);

                dbManager.LoadDataSet(ds);

            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }
    public DataSet getEwalletNumber_pin(string enumber)
    {
        enumber = utilities.Encrypt(enumber);
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT enumber,CurrentBalance,pin,status from ewallet where enumber=@enumber";

                dbManager.Command.Parameters.AddWithValue("@enumber", enumber);

                dbManager.LoadDataSet(ds);

            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public void deductewalletBalance(string enumber, int amount, string FeeType, string TransactionNumber, string TransactionDate, string ResponseCode, string ResponseDescription, string StudentID, string PaidUsing,string portal)
    {
         using (DM dbManager = new DM())
            {
                try
                {
                    dbManager.Command.CommandText = @"UPDATE Ewallet SET CurrentBalance = CurrentBalance - @amount WHERE enumber = @enumber;
                                                    Insert into eWallet_History(ewalletNumber,Description,Amount,FeeType,Status,TransasctionRef,Datetime,portal)
                                                    Values(@enumber,@5,@amount,@6,@7,@8,@date,@portal)
                                                    ;";
                    dbManager.Command.Parameters.AddWithValue("@enumber", enumber);
                    dbManager.Command.Parameters.AddWithValue("@amount", amount);
                    dbManager.Command.Parameters.AddWithValue("@5", ResponseDescription);
                    dbManager.Command.Parameters.AddWithValue("@6",FeeType);
                    dbManager.Command.Parameters.AddWithValue("@7", "0");
                    dbManager.Command.Parameters.AddWithValue("@8", TransactionNumber);
                    dbManager.Command.Parameters.AddWithValue("@date", TransactionDate);
                    dbManager.Command.Parameters.AddWithValue("@portal", portal);




                    dbManager.Command.ExecuteNonQuery();
                }
             catch(Exception ex){

             }
         }
        

    }
    public void InsertEwalletlog(string FeeType,string TransactionNumber,string amount,string TransactionDate,string ResponseCode,string ResponseDescription,string StudentID,string PaidUsing,string portal)
    {
        using (DM dbManager = new DM())
            {
                try
                {
                    dbManager.Command.CommandText = @"Insert into transactionlog_eWallet(FeeType,TransactionNumber,Amount,TransactionDate,ResponseCode,ResponseDescription,StudentID,PaidUsing,portal)
                                Values(@feetype,@tnumber,@amount,@tdate,@rd,@rdx,@studentID,@paidusing,@portal);";
          
                    dbManager.Command.Parameters.AddWithValue("@tnumber", TransactionNumber);
                    


                    dbManager.Command.Parameters.AddWithValue("@feetype", FeeType);
                    dbManager.Command.Parameters.AddWithValue("@amount", amount);
                    dbManager.Command.Parameters.AddWithValue("@tdate", DateTime.Now);
                    dbManager.Command.Parameters.AddWithValue("@rd", "00");
                    dbManager.Command.Parameters.AddWithValue("@rdx", "Approved Successful");
                    dbManager.Command.Parameters.AddWithValue("@studentID", Membership.GetUser().ProviderUserKey.ToString());
                    dbManager.Command.Parameters.AddWithValue("@paidusing", "eWallet");
                    dbManager.Command.Parameters.AddWithValue("@portal",portal);

                    dbManager.Command.ExecuteNonQuery();
                }
             catch(Exception ex){

             }
         }
    }
    

    public bool checkUniqueEwalletNumber(string walletNumber)
    {
        bool flag = false;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT ID from ewallet where Enumber=@enum";

                dbManager.Command.Parameters.AddWithValue("@enum", walletNumber);

                dbManager.LoadDataSet(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return flag; ;
    }

    public DataSet getAreas_States(int stateID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from Application_Areas where state=@state and status=0 ";

                dbManager.Command.Parameters.AddWithValue("@state", stateID);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }


    public DataSet getStates()
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from Application_States where  status=0 ";

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getInstitutions()
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from Application_JambInstitutions where  status=0 ";

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getSubjects()
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from Application_OlevelSubjects where  status=0 ";

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }
    public DataSet getGrades()
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from Application_OlevelSubjects where  status=0 ";

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getAllTimes_CBT(string date, int pid)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from CBT_Schedules cb where programID=@pid and ScheduleDate=@date  and CAST(Capacity AS INT) >  CAST(Used AS INT) ";

                dbManager.Command.Parameters.AddWithValue("@pid", pid);
                dbManager.Command.Parameters.AddWithValue("@date", date);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getSingleTimes_CBT(string date, int pid, string time)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from CBT_Schedules where programID=@pid and ScheduleDate=@date and ScheduleTime=@time ";

                dbManager.Command.Parameters.AddWithValue("@pid", pid);
                dbManager.Command.Parameters.AddWithValue("@date", date);
                dbManager.Command.Parameters.AddWithValue("@time", time);


                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet getdates_CBT(int piD)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT distinct(ScheduleDate) from CBT_Schedules where programID=@pid and status=0 ";

                dbManager.Command.Parameters.AddWithValue("@pid", piD);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public int getApplicationCount_User(string userID)
    {
        int count = 0;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT Count(id) from StudentApplications where userID=@userID";

                dbManager.Command.Parameters.AddWithValue("@userID", userID);
                dbManager.LoadDataSet(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    count = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                }
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return count;
    }

    public DataSet getApplication_User(string userID)
    {
        int count = 0;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"delete from StudentApplications where FormNumber is null and userID=@userid; select sp.ID,sp.UserID,(Select ProgramName from ProgramsTable where id=sp.ProgramID) as programName,
(Select Course from CoursesTable where id=sp.FirstCourse) as Course1,
(Select Course from CoursesTable where id=sp.SecondCourse) as Course2,
(Select ScheduleDate +'<br />'+ScheduleTime from Students_CbtScheduleInfo where Userid=sp.UserID) as CbtSchedule,
Campus,
 CASE WHEN FeePaid = 1 THEN 'Yes' ELSE 'No' END AS FeePaid,
 CASE WHEN OptionalCourse = 1 THEN 'Yes' ELSE 'No' END AS OptionalCourse,
CASE WHEN FormFilled = 1 THEN 'Yes' ELSE 'No' END AS FormFilled
 ,txrefnumber,sp.DateCreated
 ,Status
,formnumber ,ct.cbtscore,ct.jambscore,ct.admissionscore  from StudentApplications sp 

left join   dbo.Students_CbtResults ct on ct.regno=sp.formnumber where

sp.UserID=@userID";

                dbManager.Command.Parameters.AddWithValue("@userID", userID);
                dbManager.LoadDataSet(ds);


            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet loadAdmission(string formnumber)
    {
        int count = 0;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"Select * from admissionlist where Regno=@regno";

                dbManager.Command.Parameters.AddWithValue("@regno", formnumber);
                dbManager.LoadDataSet(ds);


            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public int getApplicationID_transcationno(string txn)
    {
        DataSet ds = new DataSet();
        int ID = -1;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT ID from students_applications where TxRefNumber=@tr ";

                dbManager.Command.Parameters.AddWithValue("@tr", txn);

                dbManager.LoadDataSet(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ID;
    }
    public DataSet getApplication_ID(string ID)
    {
        int count = 0;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select sp.ID,sp.UserID,(Select ProgramName from ProgramsTable where id=sp.ProgramID) as programName,
(Select Course from CoursesTable where id=sp.FirstCourse) as Course1,
(Select Course from CoursesTable where id=sp.SecondCourse) as Course2,
cbt.ScheduleDate +', '+cbt.ScheduleTime as cbtschedule,
Campus,cb.firstname+' '+cb.surname as fullname,gender,address,phonenumber,email
,state+'/'+localgovtarea as state,cbtusername,cbtpassword,cb.profilepic,
 CASE WHEN FeePaid = 1 THEN 'Yes' ELSE 'No' END AS FeePaid,
 CASE WHEN OptionalCourse = 1 THEN 'Yes' ELSE 'No' END AS OptionalCourse,
CASE WHEN FormFilled = 1 THEN 'Yes' ELSE 'No' END AS FormFilled
 ,txrefnumber,sp.DateCreated ,Status,jmb.subject1+','+jmb.subject2+','+jmb.subject3+','+jmb.subject4 as jambsubjects ,
,formnumber ,ct.cbtscore,ct.jambscore,ct.admissionscore  
,spr.*,olvl.examtype,olvl.exammonth,olvl.examyear,olvl.examnumber
from StudentApplications sp 

left join   dbo.Students_CbtResults ct on ct.regno=sp.formnumber 
left join   dbo.Students_BioData cb  on cb.regno=sp.formnumber 
left join   dbo.Students_CbtScheduleInfo cbt on cbt.regno=sp.formnumber 
left join  dbo.Students_PreviousRecord spr on spr.regno=sp.formnumber 
left join  dbo.JAMB_Data jmb on jmb.regno=sp.formnumber 
left join  dbo.Student_OlevelInfo_FirstSitting olvl on olvl.regno=sp.formnumber where

sp.ID=@ID";

                dbManager.Command.Parameters.AddWithValue("@ID", ID);
                dbManager.LoadDataSet(ds);


            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }


    public void CUSTOMQUERYRUN(string query)
    {
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = query;

                dbManager.Command.ExecuteNonQuery();
            }
        }
        catch (Exception exp)
        {
            throw;
        }

    }


    public string getApplication_Courses(int programID)
    {
        int count = 0;
        DataSet ds = new DataSet();
        string courses = string.Empty;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select (Select Course from CoursesTable where id=sp.FirstCourse)  ,
(Select Course from CoursesTable where id=sp.SecondCourse) 
from StudentApplications sp where sp.programID=@ID";

                dbManager.Command.Parameters.AddWithValue("@ID", programID);
                dbManager.LoadDataSet(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    courses = ds.Tables[0].Rows[0][0].ToString();
                    if (ds.Tables[0].Rows[0][1].ToString() != "")
                    {
                        courses = courses + "," + ds.Tables[0].Rows[0][1].ToString();
                    }
                }

            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return courses;
    }

    public DataSet getTransactionDetails_txtRef(string transactionnumber)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * FROM Transactionlog where TransactionNumber=@tnumber ";

                dbManager.Command.Parameters.AddWithValue("@tnumber", transactionnumber);
                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {

        }
        return ds;
    }

    public int getDepositFormAmount(string transactionNumber)
    {
        DataSet ds = new DataSet();
        int amount = 0;
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT  AmountPaid from eWalletPaymentdeposit_application Where TransactionNo=@trnumber";
                SqlParameter param = new SqlParameter("@trnumber",transactionNumber);
                dbManager.Command.Parameters.Add(param);

                dbManager.LoadDataSet(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    String amt = ds.Tables[0].Rows[0][0].ToString();
                    amount = Convert.ToInt32(utilities.Decrypt(amt));
                }
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return amount;
    }

    public int getTransactionID_txtRef(string transactionnumber)
    {
        int id = -1;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT ID FROM Transactionlog_eWallet where TransactionNumber=@tnumber ";

                dbManager.Command.Parameters.AddWithValue("@tnumber", transactionnumber);

                id = Convert.ToInt32(dbManager.getScopeIdentity());
            }

        }
        catch (Exception exp)
        {

        }
        return id;
    }

    public int getTransactionID_txtRef_depostiFOrm(string transactionnumber)
    {
        int id = -1;
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT ID FROM eWalletPaymentdeposit_application where TransactionNo=@tnumber ";

                dbManager.Command.Parameters.AddWithValue("@tnumber", transactionnumber);

                id = Convert.ToInt32(dbManager.getScopeIdentity());
            }

        }
        catch (Exception exp)
        {

        }
        return id;
    }


    public void deleteListing(int rowID)
    {
        int mewID = 0;

        try
        {
            using (DM dbManager = new DM())
            {



                dbManager.Command.CommandText = @"delete from   ListingsTable  where ID=@ID";

                dbManager.Command.Parameters.AddWithValue("@ID", rowID);

                dbManager.Command.ExecuteNonQuery();


            }


        }
        catch (Exception exp)
        {
            throw;
        }



    }

    public void updatePrograme(string ID, int status)
    {
        int mewID = 0;

        try
        {
            using (DM dbManager = new DM())
            {



                dbManager.Command.CommandText = @"update ProgramsTable set status =@status   where ID=@ID";

                dbManager.Command.Parameters.AddWithValue("@ID", ID);
                dbManager.Command.Parameters.AddWithValue("@Status", status);

                dbManager.Command.ExecuteNonQuery();


            }


        }
        catch (Exception exp)
        {
            throw;
        }



    }

    public void updateStudentInfo(string fullname, string phone, string userID)
    {
        int mewID = 0;

        try
        {
            using (DM dbManager = new DM())
            {



                dbManager.Command.CommandText = @"update User_OtherInfo set FullName =@1,PhoneNum=@2   where userID=@ID";

                dbManager.Command.Parameters.AddWithValue("@ID", userID);
                dbManager.Command.Parameters.AddWithValue("@1", fullname);
                dbManager.Command.Parameters.AddWithValue("@2", phone);

                dbManager.Command.ExecuteNonQuery();


            }


        }
        catch (Exception exp)
        {
            throw;
        }



    }

    public void updatePincode(string pincode, string enumber)
    {
        int mewID = 0;

        try
        {
            using (DM dbManager = new DM())
            {



                dbManager.Command.CommandText = @"update Ewallet set pin =@pin   where enumber=@ID";

                dbManager.Command.Parameters.AddWithValue("@ID", enumber);
                dbManager.Command.Parameters.AddWithValue("@pin", pincode);

                dbManager.Command.ExecuteNonQuery();


            }


        }
        catch (Exception exp)
        {
            throw;
        }



    }

    public void updateCBTSCheduler(int ScheduleID, int usedCapacity)
    {
        int mewID = 0;

        try
        {
            using (DM dbManager = new DM())
            {



                dbManager.Command.CommandText = @"update CBT_Schedules set Used =@used   where ID=@ID";

                dbManager.Command.Parameters.AddWithValue("@ID", ScheduleID);
                dbManager.Command.Parameters.AddWithValue("@used", usedCapacity);

                dbManager.Command.ExecuteNonQuery();


            }


        }
        catch (Exception exp)
        {
            throw;
        }



    }

    public void updateApplicationStatus_Submit(int applicationID)
    {
        int mewID = 0;

        try
        {
            using (DM dbManager = new DM())
            {



                dbManager.Command.CommandText = @"update StudentApplications set FormFilled =1  where ID=@ID";

                dbManager.Command.Parameters.AddWithValue("@ID", applicationID);


                dbManager.Command.ExecuteNonQuery();


            }


        }
        catch (Exception exp)
        {
            throw;
        }



    }


    public void updateApplication_AcceptReject(int applicationID, int status, string reason)
    {
        int mewID = 0;

        try
        {
            using (DM dbManager = new DM())
            {



                dbManager.Command.CommandText = @"update StudentApplications set AdmissionGranted =@status ,ReasonText=@reason
                where ID=@ID";

                dbManager.Command.Parameters.AddWithValue("@ID", applicationID);
                dbManager.Command.Parameters.AddWithValue("@status", status);
                dbManager.Command.Parameters.AddWithValue("@reason", reason);

                dbManager.Command.ExecuteNonQuery();


            }


        }
        catch (Exception exp)
        {
            throw;
        }



    }

    public void updateApplicationPaymentStatus(int applicationID, string txnref, string query, int flag)
    {
        int mewID = 0;

        try
        {
            using (DM dbManager = new DM())
            {



                dbManager.Command.CommandText = query;
                if (flag == 0)
                {
                    dbManager.Command.Parameters.AddWithValue("@ID", applicationID);
                }
                else if (flag == 1)
                {
                    dbManager.Command.Parameters.AddWithValue("@tnumber", txnref);
                }


                dbManager.Command.ExecuteNonQuery();


            }


        }
        catch (Exception exp)
        {
            throw;
        }



    }



    public DataSet loadJamDataByUserID(string userID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from JAMB_Data where userID=@uID";

                dbManager.Command.Parameters.AddWithValue("@uID", userID);
                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet loadBiodataUserID(string userID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from Students_BioData where userID=@uID";

                dbManager.Command.Parameters.AddWithValue("@uID", userID);
                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet loadOlevelDataUserID_fs1(string userID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from Student_OlevelInfo_FirstSitting where userID=@uID";

                dbManager.Command.Parameters.AddWithValue("@uID", userID);
                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }

    public DataSet loadOlevelDataUserID_fs2(string userID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from Student_OlevelInfo_SecondSitting where userID=@uID";

                dbManager.Command.Parameters.AddWithValue("@uID", userID);
                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }


    public DataSet loadPreviousAcademicRecordByUserID(string userID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT * from Students_PreviousRecord where userID=@uID";

                dbManager.Command.Parameters.AddWithValue("@uID", userID);
                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }


    public DataSet loadCbtScheduleUserID(string userID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"SELECT *,(Select top 1 ID from CBT_Schedules cs 
where cs.ScheduleDate=si.ScheduleDate and cs.scheduleTime=si.ScheduleTime) as timeID from Students_CbtScheduleInfo si where userID=@uID";

                dbManager.Command.Parameters.AddWithValue("@uID", userID);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;
    }


    public DataSet getAlluserRelatedInfo(string userID)
    {
        DataSet ds = new DataSet();
        try
        {

            using (DM dbManager = new DM())
            {
                dbManager.Command.CommandText = @"select *,(Select State from Application_States at Where at.ID=sb.state ) as stateNew,
            (Select area from Application_Areas ar Where ar.ID=sb.LocalGovtArea ) as govtNew,
               (Select InstitutionName from Application_JambInstitutions aji 
                Where aji.ID=spr.InstitutionAttented  ) as  InstitutionNew
from Students_BioData sb
join dbo.Students_PreviousRecord spr on sb.UserID=spr.userID
join dbo.Students_CbtScheduleInfo cbt  on sb.UserID=cbt.userID

where sb.UserID=@uID
";
                dbManager.Command.Parameters.AddWithValue("@uID", userID);

                dbManager.LoadDataSet(ds);
            }
        }
        catch (Exception exp)
        {
            throw;
        }
        return ds;



    }
}
