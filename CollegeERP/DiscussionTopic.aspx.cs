using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string UserID = string.Empty;
    string pagename = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        pagename = Path.GetFileName(Request.PhysicalPath);
        if(System.Web.HttpContext.Current.User != null)
        {
            bool LoggedStatus = false;
            UserID = Membership.GetUser().ProviderUserKey.ToString();
            LoggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (LoggedStatus)
            {
                DBFunctions db = new DBFunctions();
                var discussionstopics = db.getdiscussiontopics();
                foreach (var topic in discussionstopics)
                {
                    discussionstxt.Text += "<tr><td><a href='discussions.aspx?topicid=" + topic.ID + "'>" + topic.Topic + "</a></td><td>" + topic.DateCreated + "</td></tr>";
                }
            }

            else
            {
                Response.Redirect("Login.aspx?Redirecturl=" + pagename);
            }
        }
       
    }
    
    protected void TopicBtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        int topicid= db.adddiscussiontopic(new DiscussionTopics_tbl { Topic=Topictxt.Text,DateCreated=DateTime.Now});
        Response.Redirect("discussions.aspx?topicid=" + topicid);
    }
}