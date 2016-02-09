using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    int pagesize = 5;
    int page = 1;
    int pagecount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
            int topicid = -1;
            string pagename = Path.GetFileName(Request.PhysicalPath);
            if (Request.QueryString["topicid"] != null)
            {
                topicid = int.Parse(Request.QueryString["topicid"].ToString());
            }
            else
            {
                Response.Redirect("DiscussionTopic.aspx");
            }
            if (Session["userid"] != null)
            {
                pageing.Text = "";
                
               
                    
                        loaddiscussions(topicid);
                        DBFunctions db = new DBFunctions();
                        pagecount = (db.getdiscussionbytopiccount(topicid) + pagesize - 1) / pagesize;
                        if (Request.QueryString["page"]!=null)
                        {
                           page= int.Parse(Request.QueryString["page"].ToString());
                        }
                            if (pagecount > 1)
                            for (int i = 1; i <= pagecount; i++)
                            {
                                
                                if (i != page)
                                {
                                    pageing.Text += "<li class=''><a style='background: #f0f0f0;height:30px;width:30px' href='" + pagename + "?topicid=" + topicid + "&";
                                    pageing.Text += "page=" + i + "'>" + i + "</a><li>";
                                }
                                else
                                {
                                    pageing.Text += "<li><a href='#0'>"+i.ToString()+"</a></li>";
                                }
                            }
                    
                
            }
            else
            {
                if(topicid!=-1)
                    Response.Redirect("Login.aspx?Redirecturl=" + pagename + "?topicid=" + topicid);
                else
                {
                    Response.Redirect("Login.aspx?Redirecturl=" + pagename);
                }
            }
        
    }
    protected void submitcommentbtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        Discussions_tbl dis = new Discussions_tbl { userID = int.Parse(Session["userid"].ToString()), Discission = commenttxt.InnerText, TopicID = int.Parse(Request.QueryString["topicid"].ToString()), Date = DateTime.Now };
        dis= db.adddiscussion(dis);
        //discusion.Text += "<div class='comment-name'><img src='images//" + Session["Image"] + "' height='50px' width='50px'> <span class='h4 '>" + Session["Name"] + "</span></div><br>";
        //discusion.Text += "<p class='blockquote comment'> " + dis.Discission + "</p><br>";
        //discusion.Text += "<p class='caption'>" + dis.Date + "</p><br><hr>";
        loaddiscussions(dis.TopicID.Value);
    }

    protected void loaddiscussions(int topicid)
    {
        discusion.Text = "";
            DBFunctions db = new DBFunctions();
            if (Request.QueryString["page"] != null)
                page = int.Parse(Request.QueryString["page"].ToString());
            var dis = db.getdiscussionbytopic(topicid,page-1,pagesize);
        
            topicnamelbl.Text = db.gettopic(topicid).Topic;
        
            foreach (var d in dis)
            {
                discusion.Text += "<div class='comment-name'><img src='images//" + d.Candidate_tbl.Image + "' height='50px' width='50px'> <span class='h4 '>" + d.Candidate_tbl.Name + "</span></div><br>";
                discusion.Text += "<p class='blockquote comment fa fa-comment'> " + d.Discission + "</p><br><br>";
                discusion.Text += "<p class='caption'>" + d.Date + "</p><br><hr>";
            }
        
    }
}