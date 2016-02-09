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
        
    }
    protected void AnswerBtn_Click(object sender, EventArgs e)
    {
        int userid =int.Parse(Request.QueryString["senderid"].ToString());
    }
}