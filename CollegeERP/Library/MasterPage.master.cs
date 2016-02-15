﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public bool isSTudent = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Userid = string.Empty;
        bool loggedStatus = false;
        if (Session["admin"] == null)
        {


            if (System.Web.HttpContext.Current.User != null)
            {
                DatabaseFunctions db = new DatabaseFunctions();
                loggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
                if (loggedStatus)
                {
                    Userid = Membership.GetUser().ProviderUserKey.ToString();
                    //  loadprogrammes();
                    if (!IsPostBack)
                    {
                        int uid = db.GetCandidateID(Userid);
                        int status = db.GetAdmissionStatus(uid);
                        if (status == 0)
                        {
                            isSTudent = false;
                        }
                        else if (status == 1)
                        {
                            isSTudent = true;
                        }
                    }

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}
