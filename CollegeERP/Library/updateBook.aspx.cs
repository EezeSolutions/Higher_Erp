using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int bookid=-1;
        if (!IsPostBack) {
            if (Request.QueryString["Bookid"] != null)
            {
                bookid = int.Parse(Request.QueryString["Bookid"]);
                DBFunctions db = new DBFunctions();
                var book = db.loadBook(bookid);

                BookTitle.Text = book.Title;
                category.Text = book.Category;
                IsbnNo.Text = book.ISBN;
                Authorname.Text = book.Author;
                Quantitytxt.Text = book.Quantity.ToString();
                Editiontxt.Text = book.Edition;
                description.Text = book.Description;

            }
        }
    }
    protected void btnupdatebook_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        //Program_tbl prgram = new Program_tbl { ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormCh.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
        Book books = new Book {ID=int.Parse(Request.QueryString["bookid"]), Title = BookTitle.Text, ISBN = IsbnNo.Text, Author = Authorname.Text, Edition = Editiontxt.Text, Category = category.Text, Quantity = int.Parse(Quantitytxt.Text), Description = description.Text };
        db.updatebook(books);
        Response.Redirect("AddBooks.aspx");
    }
}