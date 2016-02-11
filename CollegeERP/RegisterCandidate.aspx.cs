using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected string UploadFolderPath = "/images/";
    protected string FllUploadFolderPath = "http://apply.polyibadan.edu.ng/Students/profilePics/";
    string pagename = "RegisterCandidate.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            setdepartments();
            setdateofbirth();
            setstates();
        }
       

    }

    private void setdepartments()
    {
        DBFunctions db = new DBFunctions();
        Department_tbl dept = new Department_tbl { Department = "Select Department" };
        var department=db.getalldepartments();
        department.Add(dept);
        department = department.OrderBy(x => x.ID).ToList();
        DropDownDept.DataSource =department ;
        ListItem item = new ListItem();
        
        DropDownDept.DataTextField = "Department";
        DropDownDept.DataValueField = "ID";
        DropDownDept.DataBind();
    }
    private void setprogrammes()
    {
        DBFunctions db = new DBFunctions();
        
        if(DropDownDept.SelectedValue=="")
        {
            DropDownprogramme.DataSource = null;
            DropDownprogramme.DataTextField = "";
            DropDownprogramme.DataValueField = "";
            return;
        }
        int deptid =int.Parse(DropDownDept.SelectedValue);
        DropDownprogramme.DataSource= db.getprogramslist().Where(x=>x.DeptID==deptid);
        DropDownprogramme.DataTextField = "ProgramName";
        DropDownprogramme.DataValueField = "ID";
        DropDownprogramme.DataBind();

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (FileUpload.FileName!="")
        {
            FileUpload.SaveAs(Server.MapPath(UploadFolderPath + FileUpload.FileName));
        }
        double SecondaryPercentage = 0;
        double IntermediatePercentage = 0;
        string message = "";
        if ((Convert.ToInt16(SecondaryObtained.Text) <= Convert.ToInt16(TotalSecondary.Text))&&(Convert.ToInt16(ObtainedIntermediate.Text) <= Convert.ToInt16(TotalIntermediate.Text)))
        {
          
              IntermediatePercentage = (Convert.ToDouble(ObtainedIntermediate.Text) / Convert.ToDouble(TotalIntermediate.Text)) * 100;
              SecondaryPercentage = (Convert.ToDouble(SecondaryObtained.Text) / Convert.ToDouble(TotalSecondary.Text)) * 100;
              double SecondaryWeightage = 0.45;
              double IntermediateWeightage = 0.55;

              double TotalCutOff = (SecondaryWeightage * SecondaryPercentage) + (IntermediateWeightage * IntermediatePercentage);
            DBFunctions db = new DBFunctions();
            Candidate_tbl temp = db.CheckExistingUsers(Usernametxt.Text);
            if (temp == null)
            {
                Candidate_tbl candidate = new Candidate_tbl { Name = Nametxt.Text, Username = Usernametxt.Text, HomeAdress = txtHomeaddress.Text, Stateoforigin = int.Parse(dropdownSto.SelectedValue), LocalGovtArea = int.Parse(dropdownLocalGovtarea.SelectedValue), Email = Emailtxt.Text, DateofBirth = dropdownDay.SelectedItem.Text + "-" + dropdownMonth.SelectedItem.Text + "-" + dropdownyears.SelectedItem.Text, Password = Passwordtxt.Text, Phone = Phonetxt.Text, Image = FileUpload.FileName, Gender = dropdownGender.SelectedValue, ProgrammeID = int.Parse(DropDownprogramme.SelectedValue), CuttoffPoints = TotalCutOff, Status = 0, AdmissionYear = DateTime.Now.Year.ToString() };
                //// candidate is being stored in db here. 
                 MembershipCreateStatus createStatus = new MembershipCreateStatus();
                 MembershipUser newUser = System.Web.Security.Membership.CreateUser(Usernametxt.Text, Passwordtxt.Text, Emailtxt.Text, null, null, true, out createStatus);
                switch (createStatus)
                {
                    case MembershipCreateStatus.Success: message = "The user account was successfully created!";
                        FormsAuthentication.SetAuthCookie(Usernametxt.Text,true);

                        break;

                    case MembershipCreateStatus.DuplicateUserName: message = "There already exists a user with this username.";
                      
                        break;
                    case MembershipCreateStatus.DuplicateEmail: message = "There already exists a user with this email address.";
                       
                        break;
                    case MembershipCreateStatus.InvalidEmail: message = "There email address you provided in invalid.";
                      
                        break;
                    case MembershipCreateStatus.InvalidAnswer: message = "There security answer was invalid.";
                      
                        break;
                    case MembershipCreateStatus.InvalidPassword: message = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";
                      
                        break;
                    default: message = "There was an unknown error; the user account was NOT created.";
                       
                        break;
                }

                db.AddCandidate(candidate);
                Response.Redirect("Login.aspx");
            }
            else
            {
                LabelEmail.Text = "This email already exists, Please Login.";
                LabelEmail.Visible = true;
            }
        }
        else
        {
            CheckMarksSecondary.Text = "Please enter a valid value";
            CheckMarksSecondary.Visible = true;
        }

    }


    protected void setstates(){

        DBFunctions db = new DBFunctions();
       dropdownSto.DataSource=  db.getstates();
       dropdownSto.DataTextField = "State";
       dropdownSto.DataValueField = "ID";
       dropdownSto.DataBind();

}

    protected void setdateofbirth()
    {
        int j = 0;

        for (int i = 1985; i < 2015; i++)
        {

            dropdownyears.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            j++;
        }

        for (int i = 1; i < 32; i++)
        {

            dropdownDay.Items.Insert((i - 1), new ListItem(i.ToString(), i.ToString()));

        }
    }
    //protected void FileUploadComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    //{

    //    if (AsyncFileUpload1.HasFile)
    //    {
    //        var fileName = AsyncFileUpload1.FileName;
    //        var fileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1);
    //        if (fileExtension.ToLower().Contains("jpg") || fileExtension.ToLower().Contains("png"))
    //        {
    //            if (AsyncFileUpload1.FileContent.Length < 2000000)
    //            {
    //                String savePath = MapPath("~/Students/profilePics/" + AsyncFileUpload1.FileName);

    //                string formnum = "";

    //                string origPath = MapPath("~/Students/profilePics/" + formnum + ".jpg");
    //                AsyncFileUpload1.SaveAs(origPath);
    //                // File.AppendAllText("C:/lg.txt", "\r\n"+savePath);
    //                AsyncFileUpload1.SaveAs(savePath);

    //                var image = new Bitmap(MapPath("~/Students/profilePics/" + formnum + ".jpg"));
    //                if (image.Height > 200 || image.Width > 200)
    //                {
    //                    Console.Write("IMAGE DIMENSION LARGE PROCESSING IMAGE");
    //                    //var image2 = ResizeImage(image, 200, 200);
    //                    //image.Dispose();
    //                    //image = null;
    //                    //File.Delete(origPath);
    //                    //image2.Save(origPath);
    //                    //image2.Dispose();
    //                    //image2 = null;

    //                }
    //                else
    //                {
    //                    //Console.Write("IMAGE DIMENSION SMALL SKIPPING IMAGE");
    //                    image.Dispose();
    //                    image = null;
    //                }

    //                // AsyncFileUpload1.SaveAs(MapPath("C:/AdmissionPortal/Students/profilePics/" + AsyncFileUpload1.FileName));
    //                //   literealErrorImage.Text = "";
    //                UploadFolderPath = "~/Students/profilePics/";
    //                ViewState["imageDisplay_str"] = formnum + "." + fileExtension;
    //            }
    //            else
    //            {
    //                ClearContents(sender as Control);
    //                //   literealErrorImage.Text = " <span class=\"btn btn-danger\">Image file size should be less than 2 MB </span>";

    //            }
    //        }

    //    }


    //}
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

    protected void dropdownSto_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        if (dropdownSto.SelectedItem.Value=="")
        {
            return;
        }
        dropdownLocalGovtarea.DataSource = db.Getareas(int.Parse(dropdownSto.SelectedItem.Value));
        dropdownLocalGovtarea.DataTextField = "Area";
        dropdownLocalGovtarea.DataValueField = "ID";
        dropdownLocalGovtarea.DataBind();
    }
    protected void DropDownDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        setprogrammes();
    }
}