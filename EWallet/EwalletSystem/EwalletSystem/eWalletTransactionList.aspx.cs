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
    private static int PageSize = 10;
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
            //     Response.Redirect("~/ACcount/Login.aspx");
        }
    }

    private void BindDummyRow()
    {
        DataTable dummy = new DataTable();
        dummy.Columns.Add("Enumber");
        dummy.Columns.Add("CurrentBalance");
        dummy.Columns.Add("Name");
        dummy.Columns.Add("Address");
        dummy.Columns.Add("DateCreated");
        dummy.Columns.Add("Portal");
        dummy.Columns.Add("Action");
        dummy.Rows.Add();
        //gvewallet.DataSource = dummy;
        //gvewallet.DataBind();
        GridView1.DataSource = dummy;
        GridView1.DataBind();
    }
    [WebMethod]
    public static string GeteWalletTransactions(int pageIndex)
    {
        string query = "[GeteWallet_Pager]";
        SqlCommand cmd = new SqlCommand(query);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        return GetData(cmd, pageIndex).GetXml();
    }

    private static DataSet GetData(SqlCommand cmd, int pageIndex)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    
                    sda.Fill(ds, "eWalletTransactionList");
                    DataSet ds1 = new DataSet();
                    DataTable dt = new DataTable("Pager");
                    DataTable dt1 = new DataTable("eWalletTransactionList");
                    dt1.Columns.Add("Enumber");
                    dt1.Columns.Add("CurrentBalance");
                    dt1.Columns.Add("Name");
                    dt1.Columns.Add("Address");
                    dt1.Columns.Add("DateCreated");
                    dt1.Columns.Add("Portal");
                    dt1.Columns.Add("Status");
                    dt.Columns.Add("PageIndex");
                    dt.Columns.Add("PageSize");
                    dt.Columns.Add("RecordCount");
                    dt.Rows.Add();
                    dt.Rows[0]["PageIndex"] = pageIndex;
                    dt.Rows[0]["PageSize"] = PageSize;
                    dt.Rows[0]["RecordCount"] = cmd.Parameters["@RecordCount"].Value;
                    //ds.Tables.Add(dt);
                    
                    DataRow[] rows = ds.Tables[0].Select();
                    foreach(DataRow r in rows){

                        dt1.Rows.Add(utilities.Decrypt(r["Enumber"].ToString()), r["CurrentBalance"].ToString(),utilities.Decrypt( r["Name"].ToString()), utilities.Decrypt(r["Address"].ToString()), r["DateCreated"].ToString(), utilities.Decrypt(r["portal"].ToString()),r["Status"]);
                       //string d= r["Name"].ToString();
                    }
                    ds1.Tables.Add(dt1);
                    ds1.Tables.Add(dt);
                    return ds1;
                }
            }
        }
    }
   
    private static DataSet GetData_search(SqlCommand cmd, int pageIndex)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds, "eWalletTransactionList");
                    DataTable dt1 = new DataTable("eWalletTransactionList");
                    DataSet ds1 = new DataSet();
                    dt1.Columns.Add("Enumber");
                    dt1.Columns.Add("CurrentBalance");
                    dt1.Columns.Add("Name");
                    dt1.Columns.Add("Address");
                    dt1.Columns.Add("DateCreated");
                    dt1.Columns.Add("Portal");
                    dt1.Columns.Add("Status");
                    DataRow[] rows = ds.Tables[0].Select();
                    foreach (DataRow r in rows)
                    {

                        dt1.Rows.Add(utilities.Decrypt(r["Enumber"].ToString()), r["CurrentBalance"].ToString(), utilities.Decrypt(r["Name"].ToString()), utilities.Decrypt(r["Address"].ToString()), r["DateCreated"].ToString(), utilities.Decrypt(r["portal"].ToString()), r["Status"]);
                      //  string d = r["Name"].ToString();
                    }
                    ds1.Tables.Add(dt1);
                    return ds1;
                }
            }
        }
    }

    [WebMethod]
    public static string searchterm(string searchNu)
    {
        searchNu = utilities.Encrypt(searchNu);
        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SearchTransaction";
        cmd.Parameters.Add("@Enumber", SqlDbType.NVarChar).Value = searchNu.Trim();

        return GetData_search(cmd, 1).GetXml();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Bind search results to GridView control

    }


    [WebMethod]
    public static string changeUserStatus(string enumber, int pageIndex, string status)
    {

        DatabaseFunctions db = new DatabaseFunctions();

        db.updateeWalletUser(status, enumber);

        string query = "[GeteWallet_Pager]";
        SqlCommand cmd = new SqlCommand(query);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        return GetData(cmd, pageIndex).GetXml();

    }


}