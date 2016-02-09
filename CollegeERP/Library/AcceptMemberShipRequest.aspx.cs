using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["id"]!=null)
        {
            int reqid = int.Parse(Request.QueryString["id"]);
            DBFunctions db = new DBFunctions();
            db.acceptRequest(reqid);

            Response.Redirect("MemberRequest.aspx");
        }
        }
}