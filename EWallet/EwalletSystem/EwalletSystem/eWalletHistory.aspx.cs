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

        }

    }
    private void BindDummyRow()
    {
        DataTable dummy = new DataTable();
        dummy.Columns.Add("ewalletNumber");
        dummy.Columns.Add("Description");
        dummy.Columns.Add("Amount");
        dummy.Columns.Add("FeeType");
        dummy.Columns.Add("TransasctionRef");
        dummy.Columns.Add("portal");
        dummy.Columns.Add("DateTime");

        dummy.Rows.Add();

        //table1.DataSource = dummy;
        //table1.DataBind();

        GridView1.DataSource = dummy;
        GridView1.DataBind();
    }
    [WebMethod]
    public static string GeteWalletHistory(int pageIndex)
    {
        string query = "[GeteWalletHistory_Pager]";
        SqlCommand cmd = new SqlCommand(query);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@TotalAmount", SqlDbType.Float, 4).Direction = ParameterDirection.Output;
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
                    sda.Fill(ds, "eWalletHistory");
                    DataTable dt = new DataTable("Pager");
                    DataTable dt1 = new DataTable("eWalletHistory");
                    DataSet ds1 = new DataSet();
                    dt1.Columns.Add("ewalletNumber");
                    dt1.Columns.Add("Description");
                    dt1.Columns.Add("Amount");
                    dt1.Columns.Add("FeeType");
                    dt1.Columns.Add("TransasctionRef");
                    dt1.Columns.Add("portal");
                    dt1.Columns.Add("DateTime");
                    dt1.Columns.Add("totalAmount");
                    dt.Columns.Add("PageIndex");
                    dt.Columns.Add("PageSize");
                    dt.Columns.Add("RecordCount");
                    dt.Columns.Add("TotalAmount");
                    dt.Rows.Add();
                    dt.Rows[0]["PageIndex"] = pageIndex;
                    dt.Rows[0]["PageSize"] = PageSize;
                    dt.Rows[0]["RecordCount"] = cmd.Parameters["@RecordCount"].Value;
                    dt.Rows[0]["TotalAmount"] = cmd.Parameters["@TotalAmount"].Value;

                    DataRow[] rows = ds.Tables[0].Select();
                    foreach (DataRow r in rows)
                    {

                        dt1.Rows.Add(utilities.Decrypt(r["ewalletNumber"].ToString()), r["Description"].ToString(), r["Amount"].ToString(), r["FeeType"].ToString(), r["TransasctionRef"].ToString(), r["portal"].ToString(), r["DateTime"].ToString());
                       // string d = r["Name"].ToString();
                    }
                    ds1.Tables.Add(dt1);
                    ds1.Tables.Add(dt);
                    return ds1;
                }
            }
        }
    }
    public void Search()
    {
        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SearchRecord";
        cmd.Parameters.Add("@TransasctionRef", SqlDbType.NVarChar).Value = SearchButton.Text.Trim();
        cmd.Connection = con;
        try
        {
            con.Open();
            GridView1.EmptyDataText = "No Records Found";
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            int row = 0;
            foreach (GridViewRow r in GridView1.Rows)
            {
                GridView1.Rows[row].Cells[0].Text = utilities.Decrypt(GridView1.Rows[row].Cells[0].Text);
                row++;
            }
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
}