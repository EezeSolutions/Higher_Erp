using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
          string pagename = Path.GetFileName(Request.PhysicalPath);
          if (Session["userid"] == null)
          {
              Response.Redirect("Login.aspx?Redirecturl=" + pagename);
          }
    }
}
