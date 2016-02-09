using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Request.QueryString["id"] != null && Request.QueryString["status"] != null)
            {
                string prevpage= Request.UrlReferrer.ToString();
                int id = int.Parse(Request.QueryString["id"]);
                int status = int.Parse(Request.QueryString["status"]);

                DBFunctions db = new DBFunctions();
                db.updateleaverequest(id,status);
                Response.Redirect(prevpage);
            }
        }
    }
}