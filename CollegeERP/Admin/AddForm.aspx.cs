using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         string pagename = Path.GetFileName(Request.PhysicalPath);
         if (Session["admin"] != null)
         {
             if (!IsPostBack)
             {
                 binddata();
             }
         }
         else
         {
             Response.Redirect("Login.aspx?Redirecturl=" + pagename);
         }
    }
    protected void btnAddField_Click(object sender, EventArgs e)
    {
        //DBFunctions db = new DBFunctions();
        //Forms_tbl form = new Forms_tbl { Field = FormFieldtxt.Text, DataType = Datatypetxt.SelectedValue, ProgrameID = int.Parse(Programtxt.SelectedValue), SectionID = int.Parse(Sectiontxt.SelectedValue) };
        //db.addFormField(form);

    }




    private void binddata()
    {
        DBFunctions db = new DBFunctions();
        Programtxt.DataSource = db.getprogramslist();
        Programtxt.DataValueField = "ID";
        Programtxt.DataTextField = "ProgramName";
        Programtxt.DataBind();

        Sectiontxt.DataSource = db.getformSectionlist();
        Sectiontxt.DataTextField = "Section";
        Sectiontxt.DataValueField = "ID";
        Sectiontxt.DataBind();

        Datatype dt=new Datatype();
        Datatypetxt.DataSource = dt.datatypelist;
        Datatypetxt.DataTextField = "type";
        Datatypetxt.DataValueField = "type";
        Datatypetxt.DataBind();


        Controltxt.DataSource = dt.controllist;
        //Controltxt.DataSource = dt.datatypelist;
        Controltxt.DataTextField = "type";
        Controltxt.DataValueField = "type";
        Controltxt.DataBind();
    }

    [WebMethod]
    public static string AddField(string Field, string Data, string Program, string Section, string cont, string[] options)
    {

        DBFunctions db = new DBFunctions();
        Forms_tbl form = new Forms_tbl { Field = Field, DataType = Data, ProgramID = int.Parse(Program), SectionID = int.Parse(Section), FormControl = cont };
        db.addFormField(form,options);

        return "done";
    }
}