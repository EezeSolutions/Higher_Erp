using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected static int PageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (General.Session.UserName != "")
        {
            if (!IsPostBack)
            {
                BindDummyRow();
            }
        }
        else
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Unauthorized", "alert('You are not authorized to view this page !');location.href='admin_Login.aspx';", true);

        }
    }
    private void BindDummyRow()
    {
        DataTable dummy = new DataTable();
        dummy.Columns.Add("ImageName");
        dummy.Columns.Add("FormType");
        dummy.Columns.Add("PaymentDate");
        dummy.Columns.Add("AmountPaid");
        dummy.Columns.Add("TransactionNo");
        dummy.Columns.Add("Bankname");
        dummy.Columns.Add("OnlineBankAccountName");
        dummy.Columns.Add("BankTransactionNo");
        dummy.Columns.Add("Status");

        dummy.Rows.Add();
        //gvewallet.DataSource = dummy;
        //gvewallet.DataBind();
        GridView1.DataSource = dummy;
        GridView1.DataBind();

    }

    [WebMethod]
    public static string GeteWalletPayment(int pageIndex)
    {
        string query = "[GeteWalletPaymentdeposit_application]";
        SqlCommand cmd = new SqlCommand(query);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        return GetData(cmd, pageIndex).GetXml();
    }
    // idhar 

    [WebMethod]
    public static string depositFormUpdate(string trnum, string userID, int pageIndex)
    {

        DatabaseFunctions db = new DatabaseFunctions();

        int actualAmount = db.getDepositFormAmount(utilities.Encrypt(trnum));
        db.Update_eWallet_Status_Balance(trnum, userID, actualAmount);

        string query = "[GeteWalletPaymentdeposit_application]";
        SqlCommand cmd = new SqlCommand(query);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        return GetData(cmd, pageIndex).GetXml();

    }





    private static DataSet GetData(SqlCommand cmd, int pageIndex)
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        try
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (ds = new DataSet())
                    {
                        sda.Fill(ds, "eWalletPaymentDepositApplication");
                        DataTable dt = new DataTable("Pager");

                        DataTable dt1 = new DataTable("eWalletPaymentDepositApplication");
                        dt1.Columns.Add("Enumber");
                        dt1.Columns.Add("ImageName");
                        dt1.Columns.Add("FormType");
                        dt1.Columns.Add("PaymentDate");
                        dt1.Columns.Add("AmountPaid");
                        dt1.Columns.Add("TransactionNo");
                        dt1.Columns.Add("Bankname");
                        dt1.Columns.Add("OnlineBankAccountName");
                        dt1.Columns.Add("BankTransactionNo");
                        dt1.Columns.Add("Status");

                        dt.Columns.Add("PageIndex");
                        dt.Columns.Add("PageSize");
                        dt.Columns.Add("RecordCount");
                        dt.Rows.Add();
                        dt.Rows[0]["PageIndex"] = pageIndex;
                        dt.Rows[0]["PageSize"] = PageSize;
                        dt.Rows[0]["RecordCount"] = cmd.Parameters["@RecordCount"].Value;
                        DataRow[] rows = ds.Tables[0].Select();
                        foreach (DataRow r in rows)
                        {

                            dt1.Rows.Add(utilities.Decrypt(r["Enumber"].ToString()), utilities.Decrypt(r["ImageName"].ToString()), utilities.Decrypt(r["FormType"].ToString()), r["PaymentDate"].ToString(), utilities.Decrypt(r["AmountPaid"].ToString()), utilities.Decrypt(r["TransactionNo"].ToString()), utilities.Decrypt(r["Bankname"].ToString()), utilities.Decrypt(r["OnlineBankAccountName"].ToString()), utilities.Decrypt(r["BankTransactionNo"].ToString()), r["Status"].ToString());
                            // string d = r["Name"].ToString();
                        }
                        
                        ds1.Tables.Add(dt1);
                        ds1.Tables.Add(dt);



                    }
                }
            }
        }
        catch (Exception ex)
        { }

        return ds1;
    }

    [WebMethod]
    public static string searchTran(string searchterm)
    {
        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SearchPaymentDepositApplications";
        cmd.Parameters.Add("@TransactionNo", SqlDbType.NVarChar).Value = searchterm.Trim();
        cmd.Connection = con;
        return GetData(cmd, 1).GetXml();

    }


    /* protected void Login_click(object sender, EventArgs e)
     {

     }*/
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Bind search results to GridView control
        // Search();
        //////    DatabaseFunctions db = new DatabaseFunctions();

        // db.Update_eWallet_Status_Balance("PIB63569212098", "24feaf22-4a79-49be-a1b5-b803a7a6fad1", 1);



    }

}