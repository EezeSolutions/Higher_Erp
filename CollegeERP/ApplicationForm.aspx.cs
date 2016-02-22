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

public partial class ApplicationForm : System.Web.UI.Page
{
    protected string UploadFolderPath = "/profilepics/";
    protected string FllUploadFolderPath = "http://apply.polyibadan.edu.ng/Students/profilepics/";
    bool loggedStatus = false;
    int StudentID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
        
        if (System.Web.HttpContext.Current.User != null)
        {
            loggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (loggedStatus)
            {
                DatabaseFunctions d = new DatabaseFunctions();
                string UserID = Membership.GetUser().ProviderUserKey.ToString();
                StudentID = d.GetCandidateID(UserID);
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                if (!IsPostBack)
                {
                    DatabaseFunctions db = new DatabaseFunctions();

                    DataSet appStatus = db.getApplication_ID(Request.QueryString["ApplicationID"].ToString());
                    if (appStatus.Tables[0].Rows.Count > 0)
                    {
                        if (appStatus.Tables[0].Rows[0]["formfilled"].ToString() != "Yes")
                        {

                            int programID = 0;

                            DataSet ds = db.getProgramIDbyApplicationID(Convert.ToInt32(Request.QueryString["ApplicationID"].ToString()));
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                programID = Convert.ToInt16(ds.Tables[0].Rows[0]["programID"].ToString());
                                ViewState["programID"] = programID;

                                ViewState["formnum"] = (ds.Tables[0].Rows[0]["FormNumber"].ToString());
                                loadbirthDay_Dropdowns();

                                int JambForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasJambData"].ToString());  //1
                                int BioForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasBioDataSection"].ToString());//2
                                int OlevelForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasOlevelResult"].ToString());//3
                                int PreviousRecordForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasPreviousRecord"].ToString());//4
                                int CbtScheduleForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasCBTSchedule"].ToString());//5


                                int progressBarAlgo = 0;
                                if (JambForm == 1)
                                {
                                    progressBarAlgo = progressBarAlgo + 1;
                                }
                                if (BioForm == 1)
                                {
                                    progressBarAlgo = progressBarAlgo + 1;
                                }
                                if (OlevelForm == 1)
                                {
                                    progressBarAlgo = progressBarAlgo + 1;
                                }
                                if (PreviousRecordForm == 1)
                                {
                                    progressBarAlgo = progressBarAlgo + 1;
                                }
                                if (CbtScheduleForm == 1)
                                {
                                    progressBarAlgo = progressBarAlgo + 1;
                                }

                                int startingPercentage = 0;
                                if (progressBarAlgo > 0)
                                {
                                    startingPercentage = 100 / progressBarAlgo;
                                }
                                else { startingPercentage = 100; }

                                progressBar.InnerHtml = "<div aria-valuemax=\"100\" aria-valuemin=\"0\"  role=\"progressbar\" class=\"progress-bar progress-bar-striped active\" style=\"width: " + startingPercentage + "%;height:30px;font-size:30px;padding-top:5px\">" + startingPercentage + "%</div>";
                                ViewState["stepsIncrement"] = startingPercentage;
                                ViewState["progressValue"] = startingPercentage;


                                var dt = ds.Tables[0];



                                ViewState["panelInfo"] = dt;
                                ViewState["NextPanel"] = "";
                                ViewState["PreviousPanel"] = "";
                                ViewState["CurrentPanel"] = "";
                                ViewState["previousPanelName"] = "";
                                ViewState["FirstPanel"] = "";
                                ViewState["CurrentPanelName"] = "";

                                string validationGroup = string.Empty;
                                for (int c = 2; c < ds.Tables[0].Columns.Count; c++)
                                {
                                    if (ds.Tables[0].Rows[0][c].ToString() == "1")
                                    {
                                        string colName = ds.Tables[0].Columns[c].ColumnName.ToString();
                                        Panel paneltx = this.Master.FindControl("ContentPlaceHolder1").FindControl(colName) as Panel;
                                        if (paneltx != null)
                                        {
                                            if (ViewState["CurrentPanel"] == "")
                                            {
                                                if (colName == "HasJambData")
                                                {
                                                    validationGroup = "appForm";
                                                }
                                                else if (colName == "HasBioDataSection")
                                                {
                                                    validationGroup = "appForm_biodata";
                                                }
                                                else if (colName == "HasOlevelResult")
                                                {
                                                    validationGroup = "appForm_Olevel";
                                                }
                                                else if (colName == "HasPreviousRecord")
                                                {
                                                    validationGroup = "appPreviousRecord";
                                                }
                                                else if (colName == "HasCBTSchedule")
                                                {
                                                    validationGroup = "appCBT";
                                                }



                                                ViewState["previousPanelName"] = colName;
                                                ViewState["FirstPanel"] = colName;
                                                ViewState["CurrentPanelName"] = colName;
                                                paneltx.Visible = true;
                                                ViewState["CurrentPanel"] = c;

                                                loadTabsInfo(colName);

                                                btnSave.ValidationGroup = validationGroup;
                                                btnSave.Visible = true;
                                            }
                                            else
                                            {
                                                ViewState["NextPanel"] = c;
                                                btnNext.ValidationGroup = validationGroup;
                                                btnNext.Visible = true;
                                                break;
                                            }
                                        }


                                    }
                                }


                                lblCbtUsername.Text = ViewState["formnum"].ToString();





                                if (ViewState["NextPanel"] != "")
                                {
                                    btnNext.Visible = true;
                                    btnNext.ValidationGroup = validationGroup;
                                    btnPreview.Visible = false;
                                }
                                else
                                {
                                    btnSave.Visible = false;
                                    btnNext.Visible = false;
                                    btnPreview.ValidationGroup = validationGroup;
                                    btnPreview.Visible = true;
                                }
                            }



                            string imgD = hidden_dpImage.Value;
                            if (imgD != "")
                            {
                                imgDisplay.Src = "profilepics/" + imgD.ToString();
                                imgDisplay.Style.Add("display", "inline");
                            }
                        }
                        else
                        {
                            Response.Redirect("Profilepage.aspx");
                        }
                    }

                }

            }
            else
            {
                Response.Redirect("Login.aspx?ReturnUrl=" + pageName + ".aspx");
            }
        }
    }

    public void getstates()
    {
        DatabaseFunctions db = new DatabaseFunctions();
        DataSet dt = db.getStates();
        if (dt.Tables[0].Rows.Count > 0)
        {
            dropdownSto.DataSource = dt.Tables[0];
            dropdownSto.DataBind();
        }

    }

    public void loadSubjectandGrades()
    {
        DatabaseFunctions db = new DatabaseFunctions();
        DataSet ds = new DataSet();
        ds = db.getSubjects();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dropdownOlevelSub1.DataSource = ds.Tables[0];
            dropdownOlevelSub1.DataBind();

            dropdownOlevelSub2.DataSource = ds.Tables[0];
            dropdownOlevelSub2.DataBind();

            dropdownolevelSub3.DataSource = ds.Tables[0];
            dropdownolevelSub3.DataBind();

            dropdownOlvlSub4.DataSource = ds.Tables[0];
            dropdownOlvlSub4.DataBind();

            dropdownOlevelsub5.DataSource = ds.Tables[0];
            dropdownOlevelsub5.DataBind();

            dropdownOlevelSub6.DataSource = ds.Tables[0];
            dropdownOlevelSub6.DataBind();

            dropdownOlevelSub7.DataSource = ds.Tables[0];
            dropdownOlevelSub7.DataBind();

            dropdownolevelSub8.DataSource = ds.Tables[0];
            dropdownolevelSub8.DataBind();

            dropdowOlevelSub9.DataSource = ds.Tables[0];
            dropdowOlevelSub9.DataBind();

            dropdownOlevelsubject1b.DataSource = ds.Tables[0];
            dropdownOlevelsubject1b.DataBind();


            dropdownOlevelSub2b.DataSource = ds.Tables[0];
            dropdownOlevelSub2b.DataBind();

            dropdownolevelSub3b.DataSource = ds.Tables[0];
            dropdownolevelSub3b.DataBind();

            dropdownOlvlSub4b.DataSource = ds.Tables[0];
            dropdownOlvlSub4b.DataBind();

            dropdownOlevelsub5b.DataSource = ds.Tables[0];
            dropdownOlevelsub5b.DataBind();

            dropdownOlevelSub6b.DataSource = ds.Tables[0];
            dropdownOlevelSub6b.DataBind();

            dropdownOlevelSub7b.DataSource = ds.Tables[0];
            dropdownOlevelSub7b.DataBind();

            dropdownolevelSub8b.DataSource = ds.Tables[0];
            dropdownolevelSub8b.DataBind();

            dropdowOlevelSub9b.DataSource = ds.Tables[0];
            dropdowOlevelSub9b.DataBind();
        }

    }

    public void loadInstitutions()
    {
        DatabaseFunctions db = new DatabaseFunctions();
        DataSet dt = db.getInstitutions();
        if (dt.Tables[0].Rows.Count > 0)
        {
            dropdwnJamIns_Previous.DataSource = dt.Tables[0];
            dropdwnJamIns_Previous.DataBind();
        }

    }

    public void loadTabsInfo(string colName)
    {
        DataSet ds = new DataSet();
        DatabaseFunctions db = new DatabaseFunctions();
        string userID = Membership.GetUser().ProviderUserKey.ToString();

        if (colName == "HasJambData")
        {
            ds = db.loadJamDataByUserID(userID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtJambRegNo.Text = ds.Tables[0].Rows[0]["JambRegNo"].ToString();
                dropdownSubject1.SelectedValue = ds.Tables[0].Rows[0]["Subject1"].ToString();
                txtScore1.Text = ds.Tables[0].Rows[0]["Score1"].ToString();
                dropdownSubject2.SelectedValue = ds.Tables[0].Rows[0]["Subject2"].ToString();
                txtscore2.Text = ds.Tables[0].Rows[0]["Score2"].ToString();
                dropdownSubject3.SelectedValue = ds.Tables[0].Rows[0]["Subject3"].ToString();
                txtscore3.Text = ds.Tables[0].Rows[0]["Score3"].ToString();
                dropdownSubject4.SelectedValue = ds.Tables[0].Rows[0]["Subject4"].ToString();
                txtscore4.Text = ds.Tables[0].Rows[0]["Score4"].ToString();
                dropdownJambchoice.SelectedValue = ds.Tables[0].Rows[0]["ChoiceOfPolytechnic"].ToString();

                if (txtScore1.Text != "" && txtscore2.Text != "" && txtscore3.Text != "" && txtscore4.Text != "")
                {
                    int sum = Convert.ToInt16(txtScore1.Text) + Convert.ToInt16(txtscore2.Text) + Convert.ToInt16(txtscore3.Text) + Convert.ToInt16(txtscore4.Text);

                    txtJambUtmeScore.Value = sum.ToString();
                }
            }
        }
        else if (colName == "HasBioDataSection")
        {
            ds = db.loadBiodataUserID(userID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string picture = ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                if (picture != "")
                {
                    hidden_dpImage.Value = picture;
                    imgDisplay.Src = "profilepics/" + picture;
                    imgDisplay.Style.Add("display", "inline");
                }
                txtSurname.Text = ds.Tables[0].Rows[0]["Surname"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["Firstname"].ToString();
                txtOtherName.Text = ds.Tables[0].Rows[0]["Othername"].ToString();
                dropdownGender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                string dob = ds.Tables[0].Rows[0]["DOB"].ToString();
                //SPLIE AND ASSIGN

                string[] splitter = dob.Split('-');
                if (splitter.Length > 0)
                {
                    dropdownDay.SelectedValue = splitter[2];
                    dropdownMonth.SelectedValue = splitter[1];
                    dropdownyears.SelectedValue = splitter[0];
                }

                txtPhonenumber.Value = ds.Tables[0].Rows[0]["Phonenumber"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtHomeaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();


                if (dropdownSto.Items.Count == 1)
                {
                    getstates();
                }
                try
                {
                    dropdownSto.SelectedValue = ds.Tables[0].Rows[0]["state"].ToString();
                }
                catch (Exception exx)
                { }
                DataSet dstate = new DataSet();
                dstate = db.getAreas_States(Convert.ToInt16(ds.Tables[0].Rows[0]["state"].ToString()));
                if (dstate.Tables[0].Rows.Count > 0)
                {
                    dropdownLocalGovtarea.DataSource = dstate.Tables[0];
                    dropdownLocalGovtarea.DataTextField = "Area";
                    dropdownLocalGovtarea.DataValueField = "ID";

                    dropdownLocalGovtarea.DataBind();
                }

                dropdownLocalGovtarea.SelectedValue = ds.Tables[0].Rows[0]["LocalGovtArea"].ToString();

            }
        }
        else if (colName == "HasOlevelResult")
        {
            loadSubjectandGrades();
            ds = db.loadOlevelDataUserID_fs1(userID);
            if (ds.Tables[0].Rows.Count > 0)
            {


                dropdownExam.SelectedValue = ds.Tables[0].Rows[0]["Examtype"].ToString();
                dropdownExamMonth.SelectedValue = ds.Tables[0].Rows[0]["Exammonth"].ToString();
                dropdownExamYear.SelectedValue = ds.Tables[0].Rows[0]["ExamYear"].ToString();
                txtExamNum.Text = ds.Tables[0].Rows[0]["Examnumber"].ToString();


                dropdownOlevelSub1.SelectedValue = ds.Tables[0].Rows[0]["Subject1"].ToString();
                dropdownolevelGrade1.SelectedValue = ds.Tables[0].Rows[0]["Grade1"].ToString();
                dropdownOlevelSub2.SelectedValue = ds.Tables[0].Rows[0]["Subject2"].ToString();
                dropdownGrade2.SelectedValue = ds.Tables[0].Rows[0]["Grade2"].ToString();
                dropdownolevelSub3.SelectedValue = ds.Tables[0].Rows[0]["Subject3"].ToString();
                dropdownGrade3.SelectedValue = ds.Tables[0].Rows[0]["Grade3"].ToString();
                dropdownOlvlSub4.SelectedValue = ds.Tables[0].Rows[0]["Subject4"].ToString();
                dropdownGrade4.SelectedValue = ds.Tables[0].Rows[0]["Grade4"].ToString();
                dropdownOlevelsub5.SelectedValue = ds.Tables[0].Rows[0]["Subject5"].ToString();
                dropdownGrade5.SelectedValue = ds.Tables[0].Rows[0]["Grade5"].ToString();
                dropdownOlevelSub6.SelectedValue = ds.Tables[0].Rows[0]["Subject6"].ToString();
                dropdownGrade6.SelectedValue = ds.Tables[0].Rows[0]["Grade6"].ToString();
                dropdownOlevelSub7.SelectedValue = ds.Tables[0].Rows[0]["Subject7"].ToString();
                dropdonGrade7.SelectedValue = ds.Tables[0].Rows[0]["Grade7"].ToString();
                dropdownolevelSub8.SelectedValue = ds.Tables[0].Rows[0]["Subject8"].ToString();
                dropdownGrade8.SelectedValue = ds.Tables[0].Rows[0]["Grade8"].ToString();
                dropdowOlevelSub9.SelectedValue = ds.Tables[0].Rows[0]["Subject9"].ToString();
                dropdownGrade9.SelectedValue = ds.Tables[0].Rows[0]["Grade9"].ToString();

            }
            ds = new DataSet();
            ds = db.loadOlevelDataUserID_fs2(userID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dropdownExamType2.SelectedValue = ds.Tables[0].Rows[0]["Examtype"].ToString();
                dropdownExamMonth2.SelectedValue = ds.Tables[0].Rows[0]["Exammonth"].ToString();
                dropdownListexamyear2.SelectedValue = ds.Tables[0].Rows[0]["ExamYear"].ToString();
                txtExamNum2.Text = ds.Tables[0].Rows[0]["Examnumber"].ToString();


                dropdownOlevelsubject1b.SelectedValue = ds.Tables[0].Rows[0]["Subject1"].ToString();
                dropdownListGrade2.SelectedValue = ds.Tables[0].Rows[0]["Grade1"].ToString();
                dropdownOlevelSub2b.SelectedValue = ds.Tables[0].Rows[0]["Subject2"].ToString();
                dropdownGrade2b.SelectedValue = ds.Tables[0].Rows[0]["Grade2"].ToString();
                dropdownolevelSub3b.SelectedValue = ds.Tables[0].Rows[0]["Subject3"].ToString();
                dropdownGrade3b.SelectedValue = ds.Tables[0].Rows[0]["Grade3"].ToString();
                dropdownOlvlSub4b.SelectedValue = ds.Tables[0].Rows[0]["Subject4"].ToString();
                dropdownGrade4b.SelectedValue = ds.Tables[0].Rows[0]["Grade4"].ToString();
                dropdownOlevelsub5b.SelectedValue = ds.Tables[0].Rows[0]["Subject5"].ToString();
                dropdownGrade5b.SelectedValue = ds.Tables[0].Rows[0]["Grade5"].ToString();
                dropdownOlevelSub6b.SelectedValue = ds.Tables[0].Rows[0]["Subject6"].ToString();
                dropdownGrade6b.SelectedValue = ds.Tables[0].Rows[0]["Grade6"].ToString();
                dropdownOlevelSub7b.SelectedValue = ds.Tables[0].Rows[0]["Subject7"].ToString();
                dropdonGrade7b.SelectedValue = ds.Tables[0].Rows[0]["Grade7"].ToString();
                dropdownolevelSub8b.SelectedValue = ds.Tables[0].Rows[0]["Subject8"].ToString();
                dropdownGrade8b.SelectedValue = ds.Tables[0].Rows[0]["Grade8"].ToString();
                dropdowOlevelSub9b.SelectedValue = ds.Tables[0].Rows[0]["Subject9"].ToString();
                dropdownGrade9b.SelectedValue = ds.Tables[0].Rows[0]["Grade9"].ToString();

            }
        }
        else if (colName == "HasPreviousRecord")
        {
            loadInstitutions();
            ds = db.loadPreviousAcademicRecordByUserID(userID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                txtNdMetricNum.Text = ds.Tables[0].Rows[0]["ND_Matric_Number"].ToString();
                txtjaRegno_previous.Text = ds.Tables[0].Rows[0]["JAMBRegno"].ToString();
                dropdownJambExamYear_Previous.SelectedValue = ds.Tables[0].Rows[0]["JambExamyear"].ToString();
                txtJambFullName_previous.Text = ds.Tables[0].Rows[0]["JambFullName"].ToString();
                dropdwnJamIns_Previous.SelectedValue = ds.Tables[0].Rows[0]["InstitutionAttented"].ToString();
                txtJambCourseName_previous.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                dropdownCourseType_Previous.Text = ds.Tables[0].Rows[0]["CourseType"].ToString();
                dropdownCourseGrade_Prvious.Text = ds.Tables[0].Rows[0]["CourseGrade"].ToString();
                dropdownyearCompleted_Previous.SelectedValue = ds.Tables[0].Rows[0]["YearCompleted"].ToString();
                string insStart = ds.Tables[0].Rows[0]["IndTrainingStart"].ToString();
                string[] splitter = insStart.Split('-');

                dropdownIndustrialtrainingStart.SelectedValue = splitter[0];
                dropdownIndustrialTrainingEndYear.SelectedValue = splitter[1];

                string[] splitter2 = ds.Tables[0].Rows[0]["IndTrainingEnd"].ToString().Split('-');

                dropdownIndustrialStarmonth2.SelectedValue = splitter2[0];
                dropdownIndustrialTrainingYearStart2.SelectedValue = splitter2[1];

            }
        }
        else if (colName == "HasCBTSchedule")
        {
            loadDates_CBT();

            ds = db.loadCbtScheduleUserID(userID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string dateTxt = ds.Tables[0].Rows[0]["ScheduleDate"].ToString();
                dropdownScheduleDate.SelectedItem.Text = dateTxt;
                dropdownTime.SelectedItem.Text = ds.Tables[0].Rows[0]["ScheduleTime"].ToString();
                //DataSet dm = db.getAllTimes_CBT(dateTxt, Convert.ToInt32(ViewState["programID"]));
                //if (dm.Tables[0].Rows.Count > 0)
                //{
                //    dropdownTime.DataSource = dm.Tables[0];
                //    dropdownTime.DataBind();
                //}
                string time = ds.Tables[0].Rows[0]["ScheduleTime"].ToString();
                //string timeID = ds.Tables[0].Rows[0]["timeID"].ToString();
                //dropdownTime.SelectedValue = timeID;
                labelScheduleTxt.Text = dateTxt + ", " + time;
                labelCbtUser.Text = ds.Tables[0].Rows[0]["CbtUserName"].ToString();
                lblCbtPassword.Text = ds.Tables[0].Rows[0]["CbtPassword"].ToString();

                dropdownTime.Enabled = false;
                RequiredFieldValidator87.Enabled = false;
                RequiredFieldValidator76.Enabled = false;
                dropdownScheduleDate.Enabled = false;
            }
        }

    }

    protected void dropdownSubject1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string val1 = dropdownSubject1.SelectedItem.Value.ToString();
        if (val1 != "")
        {
            string val2 = dropdownSubject2.SelectedItem.Value.ToString();
            string val3 = dropdownSubject3.SelectedItem.Value.ToString();
            string val4 = dropdownSubject4.SelectedItem.Value.ToString();

            if (val1 != val2 && val1 != val3 & val1 != val4)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alert('You cannot select a same subject twice!');", true);
                dropdownSubject1.SelectedValue = "";
            }
        }
    }

    protected void dropdownSubject2_SelectedIndexChanged(object sender, EventArgs e)
    {

        string val1 = dropdownSubject1.SelectedItem.Value.ToString();
        string val2 = dropdownSubject2.SelectedItem.Value.ToString();
        if (val2 != "")
        {
            string val3 = dropdownSubject3.SelectedItem.Value.ToString();
            string val4 = dropdownSubject4.SelectedItem.Value.ToString();

            if (val2 != val1 && val2 != val3 & val2 != val4)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alert('You cannot select a same subject twice!');", true);
                dropdownSubject2.SelectedValue = "";
            }
        }
    }

    protected void dropdownSubject3_SelectedIndexChanged(object sender, EventArgs e)
    {
        string val1 = dropdownSubject1.SelectedItem.Value.ToString();
        string val2 = dropdownSubject2.SelectedItem.Value.ToString();
        string val3 = dropdownSubject3.SelectedItem.Value.ToString();
        if (val3 != "")
        {
            string val4 = dropdownSubject4.SelectedItem.Value.ToString();

            if (val3 != val2 && val3 != val1 & val3 != val4)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alert('You cannot select a same subject twice!');", true);
                dropdownSubject3.SelectedValue = "";
            }
        }
    }

    protected void dropdownSubject4_SelectedIndexChanged(object sender, EventArgs e)
    {
        string val1 = dropdownSubject1.SelectedItem.Value.ToString();
        string val2 = dropdownSubject2.SelectedItem.Value.ToString();
        string val3 = dropdownSubject3.SelectedItem.Value.ToString();
        string val4 = dropdownSubject4.SelectedItem.Value.ToString();

        if (val4 != "")
        {
            if (val4 != val2 && val4 != val3 & val4 != val1)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alert('You cannot select a same subject twice!');", true);
                dropdownSubject4.SelectedValue = "";
            }
        }
    }

    protected void saveinfo_Click(object sender, EventArgs e)
    {
        saveFunction(1);
    }

    public void saveFunction(int tmp)
    {
        DatabaseFunctions db = new DatabaseFunctions();

        string tabName = ViewState["CurrentPanelName"].ToString();
        string userId = Membership.GetUser().ProviderUserKey.ToString();
        try
        {
            if (tabName == "HasJambData")
            {
                string fullName = db.getStudent_CompleteName(userId);

                db.InsertJambData(ViewState["formnum"].ToString(), txtJambRegNo.Text, dropdownSubject1.SelectedItem.Value, txtScore1.Text, dropdownSubject2.SelectedItem.Value, txtscore2.Text,
                    dropdownSubject3.SelectedItem.Value, txtscore3.Text, dropdownSubject4.SelectedItem.Value, txtscore4.Text, dropdownJambchoice.SelectedItem.Value, userId);

            }
            else if (tabName == "HasBioDataSection")
            {
                string dob = dropdownyears.SelectedItem.Value + "-" + dropdownMonth.SelectedItem.Value + "-" + dropdownDay.SelectedItem.Value;
                string img = string.Empty;


                if (hidden_dpImage.Value != "")
                {
                    img = ViewState["formnum"].ToString() + ".jpg";
                }


                db.InsertBioData(ViewState["formnum"].ToString(), txtSurname.Text, txtFirstName.Text, txtOtherName.Text, dropdownGender.SelectedItem.Value, txtHomeaddress.Text, txtPhonenumber.Value, txtEmail.Text, dropdownSto.SelectedItem.Value, dropdownLocalGovtarea.SelectedItem.Value, userId, img, dob);

            }
            else if (tabName == "HasOlevelResult")
            {
                db.InsertOlevelInfo_FirstSitting(ViewState["formnum"].ToString(), userId, dropdownExam.SelectedItem.Value, dropdownExamMonth.SelectedItem.Value, txtExamNum.Text, dropdownExamYear.SelectedItem.Value,
                    dropdownOlevelSub1.SelectedItem.Value, dropdownolevelGrade1.SelectedItem.Value, dropdownOlevelSub2.SelectedItem.Value, dropdownGrade2.SelectedItem.Value,
                    dropdownolevelSub3.SelectedItem.Value, dropdownGrade3.SelectedItem.Value, dropdownOlvlSub4.SelectedItem.Value, dropdownGrade4.SelectedItem.Value, dropdownOlevelsub5.SelectedItem.Value, dropdownGrade5.SelectedItem.Value,
                    dropdownOlevelSub6.SelectedItem.Value, dropdownGrade6.SelectedItem.Value, dropdownOlevelSub7.SelectedItem.Value, dropdonGrade7.SelectedItem.Value, dropdownolevelSub8.SelectedItem.Value, dropdownGrade8.SelectedItem.Value,
                    dropdowOlevelSub9.SelectedItem.Value, dropdownGrade9.SelectedItem.Value);

                db.InsertOlevelInfo_SecondSitting(ViewState["formnum"].ToString(), userId, dropdownExamType2.SelectedItem.Value, dropdownExamMonth2.SelectedItem.Value, txtExamNum2.Text, dropdownListexamyear2.SelectedItem.Value,
                   dropdownOlevelsubject1b.SelectedItem.Value, dropdownListGrade2.SelectedItem.Value, dropdownOlevelSub2b.SelectedItem.Value, dropdownGrade2b.SelectedItem.Value,
                   dropdownolevelSub3b.SelectedItem.Value, dropdownGrade3b.SelectedItem.Value, dropdownOlvlSub4b.SelectedItem.Value, dropdownGrade4b.SelectedItem.Value, dropdownOlevelsub5b.SelectedItem.Value, dropdownGrade5b.SelectedItem.Value,
                   dropdownOlevelSub6b.SelectedItem.Value, dropdownGrade6b.SelectedItem.Value, dropdownOlevelSub7b.SelectedItem.Value, dropdonGrade7b.SelectedItem.Value, dropdownolevelSub8b.SelectedItem.Value, dropdownGrade8b.SelectedItem.Value,
                   dropdowOlevelSub9b.SelectedItem.Value, dropdownGrade9b.SelectedItem.Value);

            }
            else if (tabName == "HasPreviousRecord")
            {
                string indstart = dropdownIndustrialtrainingStart.SelectedItem.Value + "-" + dropdownIndustrialTrainingEndYear.SelectedItem.Value;

                string indEnd = dropdownIndustrialStarmonth2.SelectedItem.Value + "-" + dropdownIndustrialTrainingYearStart2.SelectedItem.Value;


                db.InsertPreviousRecord(ViewState["formnum"].ToString(), userId, txtjaRegno_previous.Text, dropdownJambExamYear_Previous.SelectedItem.Value, txtJambFullName_previous.Text,
                    dropdwnJamIns_Previous.SelectedItem.Value, txtJambCourseName_previous.Text, dropdownCourseType_Previous.SelectedItem.Value, dropdownCourseGrade_Prvious.SelectedItem.Value,
                    dropdownyearCompleted_Previous.SelectedItem.Value, indstart, indEnd, txtNdMetricNum.Text);

            }
            else if (tabName == "HasCBTSchedule")
            {
                DataSet ds = db.getSingleTimes_CBT(dropdownScheduleDate.SelectedItem.Value, Convert.ToInt32(ViewState["programID"]), dropdownTime.SelectedItem.Text.ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //GET INGO ...
                    int ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                    int Usedcapacity = Convert.ToInt16(ds.Tables[0].Rows[0]["Used"].ToString());
                    Usedcapacity = Usedcapacity + 1;

                    int insertFlag = db.InsertCbtScheduleIngo(ViewState["formnum"].ToString(), userId, dropdownScheduleDate.SelectedItem.Value, dropdownTime.SelectedItem.Text, ViewState["formnum"].ToString(), lblCbtPassword.Text);
                    if (insertFlag > 0)
                    {
                        //UPDATE PROGRAM USED CAPACITY
                        db.updateCBTSCheduler(ID, Usedcapacity);
                    }

                }
            }
            if (tmp == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alert('Form section saved Successfully !');", true);
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void saveFunction_SaveAll()
    {
        DatabaseFunctions db = new DatabaseFunctions();


        string userId = Membership.GetUser().ProviderUserKey.ToString();
        try
        {
            //if (tabName == "HasJambData")
            {
                string fullName = db.getStudent_CompleteName(userId);

                db.InsertJambData(ViewState["formnum"].ToString(), txtJambRegNo.Text, dropdownSubject1.SelectedItem.Value, txtScore1.Text, dropdownSubject2.SelectedItem.Value, txtscore2.Text,
                    dropdownSubject3.SelectedItem.Value, txtscore3.Text, dropdownSubject4.SelectedItem.Value, txtscore4.Text, dropdownJambchoice.SelectedItem.Value, userId);

            }
            //  else if (tabName == "HasBioDataSection")
            {
                string dob = dropdownyears.SelectedItem.Value + "-" + dropdownMonth.SelectedItem.Value + "-" + dropdownDay.SelectedItem.Value;
                string img = string.Empty;


                if (hidden_dpImage.Value != "")
                {
                    img = ViewState["formnum"].ToString() + ".jpg";
                }
                db.InsertBioData(ViewState["formnum"].ToString(), txtSurname.Text, txtFirstName.Text, txtOtherName.Text, dropdownGender.SelectedItem.Value, txtHomeaddress.Text, txtPhonenumber.Value, txtEmail.Text, dropdownSto.SelectedItem.Value, dropdownLocalGovtarea.SelectedItem.Value, userId, img, dob);

            }
            // else if (tabName == "HasOlevelResult")
            {
                db.InsertOlevelInfo_FirstSitting(ViewState["formnum"].ToString(), userId, dropdownExam.SelectedItem.Value, dropdownExamMonth.SelectedItem.Value, txtExamNum.Text, dropdownExamYear.SelectedItem.Value,
                    dropdownOlevelSub1.SelectedItem.Value, dropdownolevelGrade1.SelectedItem.Value, dropdownOlevelSub2.SelectedItem.Value, dropdownGrade2.SelectedItem.Value,
                    dropdownolevelSub3.SelectedItem.Value, dropdownGrade3.SelectedItem.Value, dropdownOlvlSub4.SelectedItem.Value, dropdownGrade4.SelectedItem.Value, dropdownOlevelsub5.SelectedItem.Value, dropdownGrade5.SelectedItem.Value,
                    dropdownOlevelSub6.SelectedItem.Value, dropdownGrade6.SelectedItem.Value, dropdownOlevelSub7.SelectedItem.Value, dropdonGrade7.SelectedItem.Value, dropdownolevelSub8.SelectedItem.Value, dropdownGrade8.SelectedItem.Value,
                    dropdowOlevelSub9.SelectedItem.Value, dropdownGrade9.SelectedItem.Value);

                db.InsertOlevelInfo_SecondSitting(ViewState["formnum"].ToString(), userId, dropdownExamType2.SelectedItem.Value, dropdownExamMonth2.SelectedItem.Value, txtExamNum2.Text, dropdownListexamyear2.SelectedItem.Value,
                   dropdownOlevelsubject1b.SelectedItem.Value, dropdownListGrade2.SelectedItem.Value, dropdownOlevelSub2b.SelectedItem.Value, dropdownGrade2b.SelectedItem.Value,
                   dropdownolevelSub3b.SelectedItem.Value, dropdownGrade3b.SelectedItem.Value, dropdownOlvlSub4b.SelectedItem.Value, dropdownGrade4b.SelectedItem.Value, dropdownOlevelsub5b.SelectedItem.Value, dropdownGrade5b.SelectedItem.Value,
                   dropdownOlevelSub6b.SelectedItem.Value, dropdownGrade6b.SelectedItem.Value, dropdownOlevelSub7b.SelectedItem.Value, dropdonGrade7b.SelectedItem.Value, dropdownolevelSub8b.SelectedItem.Value, dropdownGrade8b.SelectedItem.Value,
                   dropdowOlevelSub9b.SelectedItem.Value, dropdownGrade9b.SelectedItem.Value);

            }
            //  else if (tabName == "HasPreviousRecord")
            {
                string indstart = dropdownIndustrialtrainingStart.SelectedItem.Value + "-" + dropdownIndustrialTrainingEndYear.SelectedItem.Value;

                string indEnd = dropdownIndustrialStarmonth2.SelectedItem.Value + "-" + dropdownIndustrialTrainingYearStart2.SelectedItem.Value;


                db.InsertPreviousRecord(ViewState["formnum"].ToString(), userId, txtjaRegno_previous.Text, dropdownJambExamYear_Previous.SelectedItem.Value, txtJambFullName_previous.Text,
                    dropdwnJamIns_Previous.SelectedItem.Value, txtJambCourseName_previous.Text, dropdownCourseType_Previous.SelectedItem.Value, dropdownCourseGrade_Prvious.SelectedItem.Value,
                    dropdownyearCompleted_Previous.SelectedItem.Value, indstart, indEnd, txtNdMetricNum.Text);

            }
            //else if (tabName == "HasCBTSchedule")
            {
                DataSet ds = db.getSingleTimes_CBT(dropdownScheduleDate.SelectedItem.Value, Convert.ToInt32(ViewState["programID"]), dropdownTime.SelectedItem.Text.ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //GET INGO ...
                    int ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                    int Usedcapacity = Convert.ToInt16(ds.Tables[0].Rows[0]["Used"].ToString());
                    Usedcapacity = Usedcapacity + 1;

                    int insertFlag = db.InsertCbtScheduleIngo(ViewState["formnum"].ToString(), userId, dropdownScheduleDate.SelectedItem.Value, dropdownTime.SelectedItem.Text, ViewState["formnum"].ToString(), lblCbtPassword.Text);
                    if (insertFlag > 0)
                    {
                        //UPDATE PROGRAM USED CAPACITY
                        db.updateCBTSCheduler(ID, Usedcapacity);
                    }

                }
            }
            //  if (tmp == 1)
            {
                //ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alert('Form section saved Successfully !');", true);
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void loadDates_CBT()
    {
        DatabaseFunctions db = new DatabaseFunctions();
        DataSet ds = new DataSet();
        ds = db.getdates_CBT(Convert.ToInt32(ViewState["programID"]));

        if (ds.Tables[0].Rows.Count > 0)
        {
            dropdownScheduleDate.DataSource = ds.Tables[0];
            dropdownScheduleDate.DataBind();
        }
        else
        {
            dropdownScheduleDate.Items.Clear();
            dropdownScheduleDate.Items.Insert(0, new ListItem("Select Date", ""));
            dropdownScheduleDate.DataBind();
        }

    }

    public void loadbirthDay_Dropdowns()
    {
        getstates();

        for (int i = 1; i < 32; i++)
        {

            dropdownDay.Items.Insert((i - 1), new ListItem(i.ToString(), i.ToString()));

        }
        int j = 0;

        for (int i = 1900; i < 2015; i++)
        {

            dropdownyears.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            j++;
        }

        int c = DateTime.Now.Year;
        int c2 = c - 45;
        j = 1;
        for (int i = c; i >= c2; i--)
        {
            dropdownExamYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            dropdownListexamyear2.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            j++;
        }

        c2 = c - 35;
        j = 1;
        for (int i = c; i >= c2; i--)
        {
            dropdownJambExamYear_Previous.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            dropdownyearCompleted_Previous.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            dropdownIndustrialTrainingEndYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            dropdownIndustrialTrainingYearStart2.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            j++;
        }

        //j=1;

        //for (int x = c; x < c + 20; x++)
        //{
        //    dropdownIndustrialTrainingEndYear.Items.Insert(j, new ListItem(x.ToString(), x.ToString()));
        //    dropdownIndustrialTrainingYearStart2.Items.Insert(j, new ListItem(x.ToString(), x.ToString()));
        //    j++;
        //}
        //dropdownJambExamYear_Previous


        DatabaseFunctions db = new DatabaseFunctions();
        DataSet ds = new DataSet();
        ds = db.getdates_CBT(Convert.ToInt32(ViewState["programID"]));

        if (ds.Tables[0].Rows.Count > 0)
        {
            dropdownScheduleDate.DataSource = ds.Tables[0];
            dropdownScheduleDate.DataBind();
        }
        else
        {
            dropdownScheduleDate.Items.Clear();
            dropdownScheduleDate.Items.Insert(0, new ListItem("Select Date", ""));
            dropdownScheduleDate.DataBind();
        }

    }

    protected void btnUploadPic_Click(object sender, EventArgs e)
    {

        if (AsyncFileUpload1.HasFile)
        {
            if (AsyncFileUpload1.FileContent.Length < 2000000)
            {
                AsyncFileUpload1.SaveAs(MapPath("profilepics/" + AsyncFileUpload1.FileName));
                //  imgViewFile.ImageUrl = "profilepics/" + AsyncFileUpload1.FileName;
                //   literealErrorImage.Text = "";
                //  imgDislay.Visible = true;

            }
            else
            {
                //  literealErrorImage.Text = " <span class=\"btn btn-danger\">Image file size should be less than 2 MB </span>";
                //  imgViewFile.ImageUrl = "";
                //  imgViewFile.Visible = false;
                //  imgDislay.Visible = false;
            }
        }
    }

    protected void FileUploadComplete_Old(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {

        if (AsyncFileUpload1.HasFile)
        {
            var fileName = AsyncFileUpload1.FileName;
            var fileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1);
            if (fileExtension.ToLower().Contains("jpg") || fileExtension.ToLower().Contains("png"))
            {
                if (AsyncFileUpload1.FileContent.Length < 2000000)
                {
                    String savePath = MapPath("profilepics/" + AsyncFileUpload1.FileName);
                    DatabaseFunctions db = new DatabaseFunctions();
                    string formnum = db.getFormumber();

                    AsyncFileUpload1.SaveAs(MapPath("profilepics/" + formnum + ".jpg"));
                    // File.AppendAllText("C:/lg.txt", "\r\n"+savePath);
                    AsyncFileUpload1.SaveAs(savePath);
                    // AsyncFileUpload1.SaveAs(MapPath("C:/AdmissionPortal/profilepics/" + AsyncFileUpload1.FileName));
                    //   literealErrorImage.Text = "";
                    UploadFolderPath = "profilepics/";
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
                    String savePath = MapPath("profilepics/" + AsyncFileUpload1.FileName);
                    DatabaseFunctions db = new DatabaseFunctions();
                    string formnum = db.getFormumber();

                    string origPath = MapPath("profilepics/" + formnum + ".jpg");
                    AsyncFileUpload1.SaveAs(origPath);
                    // File.AppendAllText("C:/lg.txt", "\r\n"+savePath);
                    AsyncFileUpload1.SaveAs(savePath);

                    var image = new Bitmap(MapPath("profilepics/" + formnum + ".jpg"));
                    if (image.Height > 200 || image.Width > 200)
                    {
                        Console.Write("IMAGE DIMENSION LARGE PROCESSING IMAGE");
                        var image2 = ResizeImage(image, 200, 200);
                        image.Dispose();
                        image = null;
                        File.Delete(origPath);
                        image2.Save(origPath);
                        image2.Dispose();
                        image2 = null;

                    }
                    else
                    {
                        //Console.Write("IMAGE DIMENSION SMALL SKIPPING IMAGE");
                        image.Dispose();
                        image = null;
                    }

                    // AsyncFileUpload1.SaveAs(MapPath("C:/AdmissionPortal/profilepics/" + AsyncFileUpload1.FileName));
                    //   literealErrorImage.Text = "";
                    UploadFolderPath = "profilepics/";
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

    public static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
    {
        //a holder for the result 
        Bitmap result = new Bitmap(width, height);

        //use a graphics object to draw the resized image into the bitmap 
        using (Graphics graphics = Graphics.FromImage(result))
        {
            //set the resize quality modes to high quality 
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //draw the image into the target bitmap 
            graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            graphics.Dispose();
        }

        //return the resulting bitmap 
        return result;
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

    protected void asd_Click(object sender, EventArgs e)
    {
       
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void newMatchingFunction(object sender, EventArgs e)
    {
        DropDownList dpp = (DropDownList)sender;

        string name = dpp.ID.ToString();
        string value = dpp.SelectedItem.Value.ToString();

        DataTable tmptablw = new DataTable();
        if (ViewState["Table"] == null)
        {
            tmptablw.Columns.Add("DropdownName");
            tmptablw.Columns.Add("Value");
        }
        else
        {
            tmptablw = (DataTable)ViewState["Table"];
        }

        bool dupflag = false;
        int dubindex = 0;
        if (tmptablw.Rows.Count == 0)
        {
            tmptablw.Rows.Add(name, value);
        }
        else
        {
            for (int i = 0; i < tmptablw.Rows.Count; i++)
            {
                string dropdownName = tmptablw.Rows[i]["DropdownName"].ToString();
                string dropdownValue = tmptablw.Rows[i]["value"].ToString();

                if (dropdownValue == value && dropdownName != name)
                {
                    dupflag = true;
                    break;
                }
                else if (dropdownName == name)
                {
                    dupflag = false;
                    tmptablw.Rows[i]["value"] = value;
                    break;
                }
            }


            if (dupflag)
            {
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alert('You cannot select a same Olevel subject twice!');", true);
                dpp.SelectedValue = "";
            }
            else
            {
                tmptablw.Rows.Add(name, value);
            }
        }
        var dt = tmptablw;

        ViewState["Table"] = dt;
    }

    protected void newMatchingFunction2(object sender, EventArgs e)
    {
        DropDownList dpp = (DropDownList)sender;

        string name = dpp.ID.ToString();
        string value = dpp.SelectedItem.Value.ToString();

        DataTable tmptablw = new DataTable();
        if (ViewState["Table2"] == null)
        {
            tmptablw.Columns.Add("DropdownName");
            tmptablw.Columns.Add("Value");
        }
        else
        {
            tmptablw = (DataTable)ViewState["Table2"];
        }

        bool dupflag = false;
        int dubindex = 0;
        if (tmptablw.Rows.Count == 0)
        {
            tmptablw.Rows.Add(name, value);
        }
        else
        {
            for (int i = 0; i < tmptablw.Rows.Count; i++)
            {
                string dropdownName = tmptablw.Rows[i]["DropdownName"].ToString();
                string dropdownValue = tmptablw.Rows[i]["value"].ToString();

                if (dropdownValue == value && dropdownName != name)
                {
                    dupflag = true;
                    break;
                }
                else if (dropdownName == name)
                {
                    dupflag = false;
                    tmptablw.Rows[i]["value"] = value;
                    break;
                }
            }


            if (dupflag)
            {
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alert('You cannot select a same Olevel subject twice!');", true);
                dpp.SelectedValue = "";
            }
            else
            {
                tmptablw.Rows.Add(name, value);
            }
        }
        var dt = tmptablw;

        ViewState["Table2"] = dt;
    }


    protected void dropdownSto_SelectedIndexChanged(object sender, EventArgs e)
    {

        int selecVal = Convert.ToInt16(dropdownSto.SelectedItem.Value);
        DatabaseFunctions db = new DatabaseFunctions();

        dropdownLocalGovtarea.Items.Clear();

        dropdownLocalGovtarea.Items.Insert(0, new ListItem("Select Local Government Area", ""));
        DataSet ds = db.getAreas_States(selecVal);
        if (ds.Tables[0].Rows.Count > 0)
        {

            dropdownLocalGovtarea.DataSource = ds.Tables[0];
            dropdownLocalGovtarea.DataTextField = "Area";
            dropdownLocalGovtarea.DataValueField = "ID";

            dropdownLocalGovtarea.DataBind();

        }
        else
        {

            // dropdownLocalGovtarea.Items.Clear();
            dropdownLocalGovtarea.DataBind();
        }
    }

    protected void dropdownScheduleDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string dateTxt = dropdownScheduleDate.SelectedItem.Text.ToString();

        DatabaseFunctions db = new DatabaseFunctions();
        DataSet ds = new DataSet();

        dropdownTime.Items.Clear();

        ds = db.getAllTimes_CBT(dateTxt, Convert.ToInt32(ViewState["programID"]));
        if (ds.Tables[0].Rows.Count > 0)
        {

            //GET INGO ...
            string time = ds.Tables[0].Rows[0]["ScheduleTime"].ToString();
            int capacity = Convert.ToInt16(ds.Tables[0].Rows[0]["Capacity"].ToString());
            int Usedcapacity = Convert.ToInt16(ds.Tables[0].Rows[0]["Used"].ToString());

            int available = 0;
            available = capacity - Usedcapacity;

            if (available > 0)
            {
                labelScheduleTxt.Text = dateTxt + ", " + time + " (" + available + " available)";
                lblError.Visible = false;
                Random generator = new Random();
                if (lblCbtPassword.Text == "")
                {
                    int r = generator.Next(1000, 9999);
                    lblCbtPassword.Text = r.ToString();
                }
            }
            else
            {
                lblCbtPassword.Text = "";
                lblError.Text = "No more space available , please choose another slot.";
                lblError.Visible = true;

            }

            dropdownTime.DataSource = ds.Tables[0];
            dropdownTime.DataBind();

        }
        else
        {
            labelScheduleTxt.Text = "";
            dropdownTime.Items.Insert(0, new ListItem("Select Time", ""));
            dropdownTime.DataBind();
        }
    }

    protected void dropdownTime_SelectedIndexChanged(object sender, EventArgs e)
    {
        string dateTxt = dropdownScheduleDate.SelectedItem.Text.ToString();
        DataSet ds = new DataSet();
        DatabaseFunctions db = new DatabaseFunctions();
        ds = db.getSingleTimes_CBT(dateTxt, Convert.ToInt32(ViewState["programID"]), dropdownTime.SelectedItem.Text.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            //GET INGO ...
            string time = ds.Tables[0].Rows[0]["ScheduleTime"].ToString();
            int capacity = Convert.ToInt16(ds.Tables[0].Rows[0]["Capacity"].ToString());
            int Usedcapacity = Convert.ToInt16(ds.Tables[0].Rows[0]["Used"].ToString());

            int available = 0;
            available = capacity - Usedcapacity;
            if (available > 0)
            {
                labelScheduleTxt.Text = dateTxt + ", " + time + " (" + available + " available)";
                lblError.Visible = false;
                Random generator = new Random();
                if (lblCbtPassword.Text == "")
                {
                    int r = generator.Next(1000, 9999);
                    lblCbtPassword.Text = r.ToString();
                }
            }
            else
            {
                lblCbtPassword.Text = "";
                labelScheduleTxt.Text = "";
                lblError.Text = "No more space available , please choose another slot.";
                lblError.Visible = true;
            }
        }

    }

    protected void nextBtn_Click(object sender, EventArgs e)
    {
        nxtButtonLogic();

    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {

        int newValu = Convert.ToInt16(ViewState["progressValue"].ToString()) - Convert.ToInt16(ViewState["stepsIncrement"].ToString());

        progressBar.InnerHtml = "<div aria-valuemax=\"100\" aria-valuemin=\"0\"  role=\"progressbar\" class=\"progress-bar progress-bar-striped active\" style=\"width: " + newValu + "%;height:30px;font-size:30px;padding-top:5px\">" + newValu + "%</div>";

        ViewState["progressValue"] = newValu;


        string txt = ViewState["previousPanelName"].ToString();

        ViewState["NextPanel"] = ViewState["CurrentPanel"];

        //ViewState["NextPanel"] = "";

        //ViewState["CurrentPanel"] = "";
        string previousColName = ViewState["CurrentPanelName"].ToString();
        Panel panelprev = this.Master.FindControl("ContentPlaceHolder1").FindControl(previousColName) as Panel;
        if (panelprev != null)
        {
            panelprev.Visible = false;
        }
        string validationGroup = string.Empty;
        DataTable ds = new DataTable();
        ds = (DataTable)ViewState["panelInfo"];

        int currentColmCount = Convert.ToInt16(ViewState["CurrentPanel"]);
        ViewState["CurrentPanel"] = "";
        for (int c = currentColmCount - 1; c > 1; c--)
        {
            if (ds.Rows[0][c].ToString() == "1")
            {
                string colName = ds.Columns[c].ColumnName.ToString();



                Panel paneltx = this.Master.FindControl("ContentPlaceHolder1").FindControl(colName) as Panel;
                if (paneltx != null)
                {
                    if (ViewState["CurrentPanel"] == "")
                    {
                        if (colName == "HasJambData")
                        {
                            validationGroup = "appForm";
                        }
                        else if (colName == "HasBioDataSection")
                        {
                            validationGroup = "appForm_biodata";
                        }
                        else if (colName == "HasOlevelResult")
                        {
                            validationGroup = "appForm_Olevel";
                        }
                        else if (colName == "HasPreviousRecord")
                        {
                            validationGroup = "appPreviousRecord";
                        }
                        else if (colName == "HasCBTSchedule")
                        {
                            validationGroup = "appCBT";
                        }

                        //CurrentPanelName
                        btnSave.ValidationGroup = validationGroup;
                        //ViewState["previousPanelName"] = colName;
                        ViewState["CurrentPanelName"] = colName;
                        loadTabsInfo(colName);
                        paneltx.Visible = true;
                        ViewState["CurrentPanel"] = c;
                    }
                    else
                    {
                        ViewState["PreviousPanel"] = c;
                        break;
                    }
                }


            }
        }

        string firstPanel = ViewState["FirstPanel"].ToString();
        string currentPanel = ViewState["CurrentPanelName"].ToString();

        if (firstPanel == currentPanel)  //SAME PAGE NO PREVIOUS BUTTON 
        {
            btnPrevious.Visible = false;

        }
        else
        {
            btnPrevious.Visible = true;

        }
        if (ViewState["NextPanel"] != "")
        {
            btnNext.Visible = true;
            btnPreview.Visible = false;
            btnNext.ValidationGroup = validationGroup;
        }
        else
        {

            btnNext.Visible = false;
            btnPreview.ValidationGroup = validationGroup;
            btnPreview.Visible = true;
        }

    }
    protected void txtscore4_TextChanged(object sender, EventArgs e)
    {
        if (txtScore1.Text != "" && txtscore2.Text != "" && txtscore3.Text != "" && txtscore4.Text != "")
        {
            int sum = Convert.ToInt16(txtScore1.Text) + Convert.ToInt16(txtscore2.Text) + Convert.ToInt16(txtscore3.Text) + Convert.ToInt16(txtscore4.Text);

            txtJambUtmeScore.Value = sum.ToString();
        }
    }

    public void nxtButtonLogic()
    {
        int newValu = Convert.ToInt16(ViewState["progressValue"].ToString()) + Convert.ToInt16(ViewState["stepsIncrement"].ToString());

        progressBar.InnerHtml = "<div aria-valuemax=\"100\" aria-valuemin=\"0\"  role=\"progressbar\" class=\"progress-bar progress-bar-striped active\" style=\"width: " + newValu + "%;height:30px;font-size:30px;padding-top:5px\">" + newValu + "%</div>";

        ViewState["progressValue"] = newValu;



        //ViewState["panelInfo"] = dt;
        string txt = ViewState["previousPanelName"].ToString();

        ViewState["PreviousPanel"] = ViewState["CurrentPanel"];

        ViewState["NextPanel"] = "";

        //ViewState["CurrentPanel"] = "";
        string previousColName = ViewState["CurrentPanelName"].ToString();
        Panel panelprev = this.Master.FindControl("ContentPlaceHolder1").FindControl(previousColName) as Panel;
        if (panelprev != null)
        {
            panelprev.Visible = false;
        }
        string validationGroup = string.Empty;
        DataTable ds = new DataTable();
        ds = (DataTable)ViewState["panelInfo"];

        int currentColmCount = Convert.ToInt16(ViewState["CurrentPanel"]);
        ViewState["CurrentPanel"] = "";
        for (int c = currentColmCount + 1; c < ds.Columns.Count; c++)
        {
            if (ds.Rows[0][c].ToString() == "1")
            {
                string colName = ds.Columns[c].ColumnName.ToString();



                Panel paneltx = this.Master.FindControl("ContentPlaceHolder1").FindControl(colName) as Panel;
                if (paneltx != null)
                {
                    if (ViewState["CurrentPanel"] == "")
                    {
                        if (colName == "HasJambData")
                        {
                            validationGroup = "appForm";
                        }
                        else if (colName == "HasBioDataSection")
                        {
                            validationGroup = "appForm_biodata";
                        }
                        else if (colName == "HasOlevelResult")
                        {
                            validationGroup = "appForm_Olevel";
                        }
                        else if (colName == "HasPreviousRecord")
                        {
                            validationGroup = "appPreviousRecord";
                        }
                        else if (colName == "HasCBTSchedule")
                        {
                            validationGroup = "appCBT";
                        }

                        loadTabsInfo(colName);
                        btnSave.ValidationGroup = validationGroup;
                        //ViewState["previousPanelName"] = colName;
                        ViewState["CurrentPanelName"] = colName;
                        paneltx.Visible = true;
                        ViewState["CurrentPanel"] = c;
                    }
                    else
                    {
                        ViewState["NextPanel"] = c;
                        break;
                    }
                }


            }
        }

        if (ViewState["FirstPanel"] == ViewState["CurrentPanel"])  //SAME PAGE NO PREVIOUS BUTTON 
        {
            btnPrevious.Visible = false;

        }
        else
        {
            btnPrevious.Visible = true;

        }
        if (ViewState["NextPanel"] != "")
        {
            btnNext.Visible = true;
            btnNext.ValidationGroup = validationGroup;
            btnPreview.Visible = false;
        }
        else
        {
            btnSave.Visible = false;
            btnNext.Visible = false;
            btnPreview.ValidationGroup = validationGroup;
            btnPreview.Visible = true;
        }

    }
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        //saveFunction(0);
        saveFunction_SaveAll();
        formPreview();

        //SHOW PREVIEW
    }
    public void formPreview()
    {
        btnSave.Visible = false;
        btnNext.Visible = false;
        btnPrevious.Visible = false;
        btnPreview.Visible = false;

        DataSet ds = new DataSet();
        DatabaseFunctions db = new DatabaseFunctions();

        ds = db.getProgramIDbyApplicationID(Convert.ToInt32(Request.QueryString["ApplicationID"].ToString()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            int JambForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasJambData"].ToString());  //1
            int BioForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasBioDataSection"].ToString());//2
            int OlevelForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasOlevelResult"].ToString());//3
            int PreviousRecordForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasPreviousRecord"].ToString());//4
            int CbtScheduleForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasCBTSchedule"].ToString());//5

            if (OlevelForm == 0)
            {
                HasOlevelResult.Visible = false;
            }
            if (PreviousRecordForm == 0)
            {
                panelpreview_PreviousRecord.Visible = false;
            }
            if (CbtScheduleForm == 0)
            {
                HasCBTSchedule.Visible = false;
            }

        }

        string previousColName = ViewState["CurrentPanelName"].ToString();
        Panel panelprev = this.Master.FindControl("ContentPlaceHolder1").FindControl(previousColName) as Panel;
        if (panelprev != null)
        {
            panelprev.Visible = false;
        }

        panelPreview.Visible = true;


        ds = new DataSet();


        ds = db.getAlluserRelatedInfo((Membership.GetUser().ProviderUserKey.ToString()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            string programName = string.Empty;
            string img = ds.Tables[0].Rows[0]["profilepic"].ToString();
            string course = string.Empty;

            if (img != "")
            {
                imgDp.Src = "profilepics/" + img.ToString(); ;
                imgDp.Visible = true;

            }
            else
            {
                imgDp.Visible = false;
            }


            DataSet pgName = db.getProgramByID(Convert.ToInt32(ViewState["programID"]));
            if (pgName.Tables[0].Rows.Count > 0)
            {
                programName = pgName.Tables[0].Rows[0]["ProgramName"].ToString();
            }



            lblSuname.Text = ds.Tables[0].Rows[0]["surname"].ToString();
            lblFname.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
            lblOtherName.Text = ds.Tables[0].Rows[0]["othername"].ToString();

            lblGender.Text = ds.Tables[0].Rows[0]["gender"].ToString();
            lblPhonenum.Text = ds.Tables[0].Rows[0]["phonenumber"].ToString();

            lblProgram.Text = programName;
            lblCourse.Text = db.getApplication_Courses(Convert.ToInt32(ViewState["programID"]), Convert.ToInt32(Request.QueryString["ApplicationID"]));
            lblstateoforigin.Text = ds.Tables[0].Rows[0]["statenew"].ToString();
            lblLocalGotArea.Text = ds.Tables[0].Rows[0]["govtnew"].ToString();

            lblJambRegno.Text = ds.Tables[0].Rows[0]["JAMBRegno"].ToString();
            lblJambExamyear.Text = ds.Tables[0].Rows[0]["JambExamyear"].ToString();
            lblJambFullName.Text = ds.Tables[0].Rows[0]["JambFullName"].ToString();
            lblInstitutionAttended.Text = ds.Tables[0].Rows[0]["institutionNew"].ToString();
            lblCourseName.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
            courseType.Text = ds.Tables[0].Rows[0]["CourseType"].ToString();
            lblCourseGrade.Text = ds.Tables[0].Rows[0]["CourseGrade"].ToString();
            yearCompleted.Text = ds.Tables[0].Rows[0]["YearCompleted"].ToString();

            lblIndustrialStart.Text = ds.Tables[0].Rows[0]["IndTrainingStart"].ToString();
            lblIndustrialEnd.Text = ds.Tables[0].Rows[0]["IndTrainingEnd"].ToString();

            lblCbtSchedule.Text = ds.Tables[0].Rows[0]["ScheduleDate"].ToString() + ", " + ds.Tables[0].Rows[0]["ScheduleTime"].ToString();
            labelCbtUser.Text = ds.Tables[0].Rows[0]["CbtUserName"].ToString();
            lblCbtPass.Text = ds.Tables[0].Rows[0]["CbtPassword"].ToString();

            lblRegistrationNum.Text = ViewState["formnum"].ToString(); ;

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        panelPreview.Visible = false;

        string previousColName = ViewState["CurrentPanelName"].ToString();
        Panel panelprev = this.Master.FindControl("ContentPlaceHolder1").FindControl(previousColName) as Panel;
        if (panelprev != null)
        {
            panelprev.Visible = true;
        }

        string firstPanel = ViewState["FirstPanel"].ToString();
        string currentPanel = ViewState["CurrentPanelName"].ToString();

        if (firstPanel == currentPanel)  //SAME PAGE NO PREVIOUS BUTTON 
        {
            btnPrevious.Visible = false;

        }
        else
        {
            btnPrevious.Visible = true;

        }
        if (ViewState["NextPanel"] != "")
        {
            btnNext.Visible = true;
            btnPreview.Visible = false;

        }
        else
        {

            btnNext.Visible = false;

            btnPreview.Visible = true;
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string applicationID = Request.QueryString["ApplicationID"].ToString();

            //      ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alertNew('Application Submitted Successfully !','0');", true);

            DatabaseFunctions db = new DatabaseFunctions();
            db.updateApplicationStatus_Submit(Convert.ToInt32(applicationID));

            DataSet appData = db.getApplication_ID((applicationID));
            if (appData != null)
            {
                int programID = Convert.ToInt32(appData.Tables[0].Rows[0]["ProgramID"].ToString());
                DataSet pDate = db.getProgramByID(programID);
                if (pDate.Tables[0].Rows.Count > 0)
                {
                    int instantadmission = Convert.ToInt16(pDate.Tables[0].Rows[0]["InstantAdmission"].ToString());
                    if (instantadmission == 1)
                    {
                        string programName = appData.Tables[0].Rows[0]["programName"].ToString();
                        string CourseName = appData.Tables[0].Rows[0]["Course1"].ToString();
                        string campus = appData.Tables[0].Rows[0]["Campus"].ToString();
                        string regno = appData.Tables[0].Rows[0]["formnumber"].ToString();

                        db.insertInstantAdmissiondata(regno, programName, CourseName, campus);
                        //db.AssignAcceptanceFee()
                        ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup2", "alertNew('You have been successfully awarded admission !','0');", true);
                        DatabaseFunctions d = new DatabaseFunctions();
                        d.AssignAcceptanceFee(StudentID, programID, 0);
                        ///// Generate acceptance fee and send a message. 
                        d.InsertIntoStudentInfoTableNew(programID, "ND1", StudentID, 0, 1, "0", DateTime.Now.Year.ToString());
                        int BatchID = d.GetBatchID(DateTime.Now.Year.ToString());
                        string matricno=DateTime.Now.Year+"-"+programName+"-"+StudentID;
                        d.InsertIntoAddmissionTableNew(programID, StudentID, 0, "Merit", matricno, BatchID);
                        double AcceptanceFee = d.GetAcceptanceFeeForProgram(programID);
                        ///// Update Admission Status to 1 . 
                        ///// Insert Values to StudentInfo_tbl and AddmissionList (New One) 

                        if(AcceptanceFee!=-1)
                        {
                            string Message = "Acceptence Fee Of " +AcceptanceFee+ " Has Been Assigned to You <br> Please Submit This Fees with in One Week";
                            d.SendMessage(StudentID, Message, "Acceptance Fee", 0);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alertNew('Application Submitted Successfully !','0');", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "alertNew('Error Submiting Application!','1');", true);
        }
    }
}