using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["mailid"] != null)
        {
            int mailid = int.Parse(Request.QueryString["mailid"]);
            DBFunctions db = new DBFunctions();
            var mail = db.getusermail(mailid);
            if(mail.SenderID!=null){

            fromlbl.Text = mail.Candidate_tbl.Name;
            }
            else
            {
                fromlbl.Text = "Admin";
            }
                subjectlbl.Text = mail.Subject;
            Messagelbl.Text = mail.Message;
        }
    }
}