using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Default2 : System.Web.UI.Page
{
    protected string UploadFolderPath = "/Students/profilePics/";
    protected string FllUploadFolderPath = "http://apply.polyibadan.edu.ng/Students/profilePics/";

    protected void Page_Load(object sender, EventArgs e)
    {
        int j = 0;

        for (int i = 1900; i < 2015; i++)
        {
            dropdownyears.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            j++;
        }
    }

    protected void FileUploadComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {

        if (AsyncFileUpload1.HasFile)
        {
            var fileName = AsyncFileUpload1.FileName;
            var fileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1);
            if (fileExtension.ToLower().Contains("jpg") || fileExtension.ToLower().Contains("png"))
            {
                if (AsyncFileUpload1.FileContent.Length < 2000000)
                {
                    String savePath = MapPath("~/Students/profilePics/" + AsyncFileUpload1.FileName);

                    string formnum = "";

                    string origPath = MapPath("~/Students/profilePics/" + formnum + ".jpg");
                    AsyncFileUpload1.SaveAs(origPath);
                    // File.AppendAllText("C:/lg.txt", "\r\n"+savePath);
                    AsyncFileUpload1.SaveAs(savePath);

                    var image = new Bitmap(MapPath("~/Students/profilePics/" + formnum + ".jpg"));
                    if (image.Height > 200 || image.Width > 200)
                    {
                        Console.Write("IMAGE DIMENSION LARGE PROCESSING IMAGE");
                        //var image2 = ResizeImage(image, 200, 200);
                        //image.Dispose();
                        //image = null;
                        //File.Delete(origPath);
                        //image2.Save(origPath);
                        //image2.Dispose();
                        //image2 = null;

                    }
                    else
                    {
                        //Console.Write("IMAGE DIMENSION SMALL SKIPPING IMAGE");
                        image.Dispose();
                        image = null;
                    }

                    // AsyncFileUpload1.SaveAs(MapPath("C:/AdmissionPortal/Students/profilePics/" + AsyncFileUpload1.FileName));
                    //   literealErrorImage.Text = "";
                    UploadFolderPath = "~/Students/profilePics/";
                    ViewState["imageDisplay_str"] = formnum + "." + fileExtension;
                }
                else
                {
                    ClearContents(sender as Control);
                    //   literealErrorImage.Text = " <span class=\"btn btn-danger\">Image file size should be less than 2 MB </span>";

                }
            }

        }


    }

    private void ClearContents(Control control)
    {
        for (var i = 0; i < Session.Keys.Count; i++)
        {
            if (Session.Keys[i].Contains(control.ClientID))
            {
                Session.Remove(Session.Keys[i]);
                break;
            }
        }
    }
}