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

public partial class _Default : System.Web.UI.Page
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
        dummy.Columns.Add("Portal");
        dummy.Columns.Add("eNumber");
        dummy.Columns.Add("FeeType");
        dummy.Columns.Add("Amount");
        dummy.Columns.Add("txref");
        dummy.Columns.Add("TriedDate");
        dummy.Rows.Add();
        //gvewallet.DataSource = dummy;
        //gvewallet.DataBind();
        GridView1.DataSource = dummy;
        GridView1.DataBind();
    }
    public void Search()
    {
        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SearchInvalidRecords";
        cmd.Parameters.Add("@Enumber", SqlDbType.NVarChar).Value = SearchButton.Text.Trim();
        cmd.Connection = con;
        try
        {
            con.Open();
            GridView1.EmptyDataText = "No Records Found";
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //Bind search results to GridView control
        Search();

    }
    [WebMethod]
    public static string GeteWallet_invalid_payment_attempts(int pageIndex)
    {
        string query = "[GeteWalletInvalidPaymentAttempts]";
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
                    sda.Fill(ds, "eWallet_invalid_payment_attempts");
                    DataTable dt = new DataTable("Pager");
                    dt.Columns.Add("PageIndex");
                    dt.Columns.Add("PageSize");
                    dt.Columns.Add("RecordCount");
                    dt.Rows.Add();
                    dt.Rows[0]["PageIndex"] = pageIndex;
                    dt.Rows[0]["PageSize"] = PageSize;
                    dt.Rows[0]["RecordCount"] = cmd.Parameters["@RecordCount"].Value;
                    ds.Tables.Add(dt);
                    return ds;
                }
            }
        }
    }
}