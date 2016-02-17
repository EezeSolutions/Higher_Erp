using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string UserID = "";
    bool LoggedStatus = false;
    string text = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (System.Web.HttpContext.Current.User != null)
        {
            LoggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (LoggedStatus)
            {
                UserID = Membership.GetUser().ProviderUserKey.ToString();
                if (Request.QueryString["mailid"] != null)
                {
                    int mailid = int.Parse(Request.QueryString["mailid"]);
                    DBFunctions db = new DBFunctions();
                    var mail = db.getusermail(mailid);
                    if (mail.SenderID != null)
                    {

                        fromlbl.Text = mail.Candidate_tbl.Name;
                    }
                    else
                    {
                        fromlbl.Text = "Admin";
                    }
                    subjectlbl.Text = mail.Subject;
                    Messagelbl.Text = mail.Message;
                    if (mail.Subject == "Acceptance Fee")
                    {
                        DatabaseFunctions d = new DatabaseFunctions();
                        string form = "";
                        form = d.getFormumber();
                        if (form != "")
                        {
                            int admissionRowID = d.getAdmissionRow(form);
                            DataSet ds = d.loadAdmission(form);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {

                                    string ID = ds.Tables[0].Rows[i]["ID"].ToString();
                                    string programname = ds.Tables[0].Rows[i]["Program_Admitted"].ToString();
                                    string department = ds.Tables[0].Rows[i]["Department_Admitted"].ToString();
                                    string campus = ds.Tables[0].Rows[i]["Campus_Admitted"].ToString();
                                    int acceptancefee = Convert.ToInt16(ds.Tables[0].Rows[i]["AcceptanceFeePaid"].ToString());
                                    int biometricsCompleted = Convert.ToInt16(ds.Tables[0].Rows[i]["BiometricsCompleted"].ToString());
                                    string action = string.Empty;





                                    if (acceptancefee == 0)
                                    {
                                        text = "<a class=\"btn btn-danger\" href=\"PaymentPage.aspx?acceptanceFee=" + ID + "&admission=" + admissionRowID + "\">Pay Acceptance Fee</a>";
                                    }
                                }
                            }
                        }
                    }
                    FeeButton.Text = text;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}