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
        string enumber = utilities.Encrypt(InputEnumber.Text);
        string pin = utilities.Encrypt(InputPin.Text);
        string name = utilities.Encrypt(InputName.Text);
        string address = utilities.Encrypt(InputAddress.Text);
        string portal = utilities.Encrypt(InputPortal.Text);

        DatabaseFunctions db = new DatabaseFunctions();
        //db.createeWalletAccount(,enumber, pin, name, address, portal);
        //string encpPin = utilities.Base64Encode(pin);
      //  Response.Write("<script>alert('"+encpPin+"')</script>");
        
     //   Response.Write("<script>alert('" + utilities.Base64Decode(encpPin) + "')</script>");

       
    }
}
