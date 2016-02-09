using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    int programid = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        DBFunctions db=new DBFunctions();
        List<Forms_tbl> form = db.getform(programid);

        if(form.Count!=0)
        {
            foreach(Forms_tbl f in form)
            {
             Formtxt.Text += "<form method=get action='' name=admission /> <div class='form-group'>";
             Formtxt.Text +="<label class='col-sm-2 control-label'>"+f.Field+"</label>";
             Formtxt.Text +="<div class='col-sm-9'>";
             if (f.FormControl == "Text")
             {
                 Formtxt.Text += "<input type='text' class='form-control' name="+f.Field+"/>";
             }
             else if (f.FormControl == "Radio Button")
             {

                 List<ControlOptions_tbl> options=db.getoptions(f.ID);
                 foreach(ControlOptions_tbl op in options){
                 Formtxt.Text += "<input type='Radio'  name='" + f.Field + "' value="+op.optionvalue+"/>"+op.optionvalue+" ";
                 }
             }
             else if (f.FormControl == "Check Box")
             {
                 List<ControlOptions_tbl> options = db.getoptions(f.ID);
                 foreach (ControlOptions_tbl op in options)
                 {
                     Formtxt.Text += "<input type='checkbox'  name='" + f.Field + "' value=" + op.optionvalue + "/>" + op.optionvalue + " ";
                 }
             }

             else if (f.FormControl == "DropdownList")
             {
                 List<ControlOptions_tbl> options = db.getoptions(f.ID);
                 Formtxt.Text += "<select name="+f.Field+">";
                 foreach (ControlOptions_tbl op in options)
                 {
                     Formtxt.Text += "<option value='" + op.optionvalue + "'> "+op.optionvalue+"</option>";
                 }
                 Formtxt.Text += "</select>";
             }

             //else if (f.FormControl == "Check Box")
             //{

             //}

             Formtxt.Text +="</div>";
             Formtxt.Text += "</div><br /><br />";
            }
            Formtxt.Text += "</form>";
        }
    }
}