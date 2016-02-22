using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginBtn_Click(object sender, EventArgs e)
    {
         string username = InputEmail.Text;
        string password = InputPassword.Text;
        string captchaText = txtCaptcha.Value;
        string encpPass = string.Empty;
        string encryptedPassword = utilities.EncodePassword(password, "&@#&secretKey");

        string usernameEwallet = ConfigurationManager.AppSettings["username"].ToString();
        //TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider();

        //byte[] Data = EncryptTextToMemory(password, tDESalg.Key, tDESalg.IV);

        //encpPass = Data.ToString();

        //encpPass = HttpUtility.UrlEncode(Convert.ToBase64String(Data));
        //password = encpPass;
        if (this.Session["CaptchaImageText"] == null)
        {
            if (username != "" && password != "")
            {
                int flag = 0;

                DatabaseFunctions db = new DatabaseFunctions();
              //  flag = db.CheckValidUser(username, encryptedPassword);   // yahan pa flag check kar k captcha pa condition lagaani ha 
                string user = username;
                string pass = password;
                string adminu = ConfigurationManager.AppSettings["UserName"].ToString();
                string pass_comp = ConfigurationManager.AppSettings["Password"].ToString();
                if ((user == adminu) && (pass == pass_comp))
                {
                    flag = 1;
                }


                if (flag > 0)
                {
                    General.Session.UserName = "adminLogged";
                    Response.Redirect("eWalletTransactionList.aspx");
                    this.Session["CaptchaImageText"] = null;
                }
                else
                {
                    literalError.Text = "Invalid User/Password";
                    Image1.ImageUrl = "~/CImage.aspx";
                    txtCaptcha.Visible = true;
                    Image1.Visible = true;
                    labelCaptcha.Visible = true;
                }
            }
            else
            {
                literalError.Text = "Please enter username / password !";
                Image1.ImageUrl = "~/CImage.aspx";
                txtCaptcha.Visible = true;
                Image1.Visible = true;
                labelCaptcha.Visible = true;
            }
        }
        else
        {
            if (captchaText.ToLower() == this.Session["CaptchaImageText"].ToString().ToLower())
            {
                if (username != "" && password != "")
                {
                    int flag = 0;
                    DatabaseFunctions db = new DatabaseFunctions();

                    //flag = db.CheckValidUser(username, encryptedPassword);
                    string user = username;
                    string pass = password;
                    string adminu = ConfigurationManager.AppSettings["UserName"].ToString();
                    string pass_comp = ConfigurationManager.AppSettings["Password"].ToString();
                    if ((user == adminu) && (pass == pass_comp))
                    {
                        flag = 1;
                    }

                    if (flag > 0)
                    {
                        General.Session.UserName = "adminLogged";
                        Response.Redirect("eWalletTransactionList.aspx");
                        this.Session["CaptchaImageText"] = null;
                    }
                    else
                    {
                        literalError.Text = "Invalid User/Password";
                        Image1.ImageUrl = "~/CImage.aspx";
                        txtCaptcha.Visible = true;
                        Image1.Visible = true;
                        labelCaptcha.Visible = true;
                    }
                }
                else
                {
                    literalError.Text = "Please enter username / password !";
                    Image1.ImageUrl = "~/CImage.aspx";
                    txtCaptcha.Visible = true;
                    Image1.Visible = true;
                    labelCaptcha.Visible = true;
                }
            }
            else
            {
                literalError.Text = "Please enter correct words!";
            }

        }
    }
}
