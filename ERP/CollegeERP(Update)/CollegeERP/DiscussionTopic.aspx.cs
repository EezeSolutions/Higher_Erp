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
        DBFunctions db = new DBFunctions();
        var discussionstopics = db.getdiscussiontopics();
        foreach(var topic in discussionstopics){
        discussionstxt.Text += "<tr><td><a href='discussions.aspx?topicid="+topic.ID+"'>"+topic.Topic+"</a></td><td>"+topic.DateCreated+"</td></tr>";
    }
    }
    protected void TopicBtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        int topicid= db.adddiscussiontopic(new DiscussionTopics_tbl { Topic=Topictxt.Text,DateCreated=DateTime.Now});
        Response.Redirect("discussions.aspx?topicid=" + topicid);
    }
}