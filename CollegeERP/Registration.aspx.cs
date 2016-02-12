using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        MembershipCreateStatus createStatus;
        string message = string.Empty;
        Candidate_tbl candidate = new Candidate_tbl { Name = Nametxt.Text, Username = Usernametxt.Text, Email = Emailtxt.Text, Password = Passwordtxt.Text, Phone = Phonetxt.Text,  Status = 0, AdmissionYear = DateTime.Now.Year.ToString() };
        MembershipUser newUser = System.Web.Security.Membership.CreateUser(Usernametxt.Text, Passwordtxt.Text, Emailtxt.Text, null, null, true, out createStatus);
        switch (createStatus)
        {
            case MembershipCreateStatus.Success: message = "The user account was successfully created!";
                FormsAuthentication.SetAuthCookie(Usernametxt.Text, true);
                DatabaseFunctions db = new DatabaseFunctions();
                DBFunctions d = new DBFunctions();
                int i=db.insertUserOtherInfo(Usernametxt.Text, Phonetxt.Text, newUser.ProviderUserKey.ToString(),0);
                d.AddCandidate(candidate);
                if(i!=-1)
                {
                    Response.Redirect("ProfilePage.aspx");
                }
                break;

            case MembershipCreateStatus.DuplicateUserName: message = "There already exists a user with this username.";

                break;
            case MembershipCreateStatus.DuplicateEmail: message = "There already exists a user with this email address.";

                break;
            case MembershipCreateStatus.InvalidEmail: message = "There email address you provided in invalid.";

                break;
            case MembershipCreateStatus.InvalidAnswer: message = "There security answer was invalid.";

                break;
            case MembershipCreateStatus.InvalidPassword: message = "The password you provided is invalid. It must be atleast 4 characters long.";

                break;
            default: message = "There was an unknown error; the user account was NOT created.";

                break;
        }
        RegistrationLabel.Visible = true;
        RegistrationLabel.Text = message;
    }
}