<%@ WebHandler Language="C#" Class="GetPDF" %>

using System;
using System.Web;
using iTextSharp.text;
using System.IO;
using System.Text;
using System.Data;
using iTextSharp.text.pdf;

public class GetPDF : IHttpHandler {
    public string imagerootPath_pdf = string.Empty;
    public void ProcessRequest(HttpContext context)
    {
        imagerootPath_pdf = System.Configuration.ConfigurationManager.AppSettings["imagerootPath_pdf"].ToString();
        
        StringBuilder sb = new StringBuilder();
        
        string inputData = context.Request.Form["data"];
        string inputData2 = context.Request.Form["data2"];
        string inputData3 = context.Request.Form["data3"];

        if (inputData2 == "applicationSlip")
        {
            applicationSlip(inputData, inputData3);
        }
        else if (inputData2 == "paymentSlip")
        {
            paymentSlip(inputData);
        }
        else if (inputData2 == "eWalletReceipt")
        {
            eWalletReceipt(inputData,1);
        }
        else if (inputData2 == "eWalletReceipt-Nibbs")
        {
            eWalletReceipt(inputData,2);
        }
        else if (inputData2 == "AdmissionSlip")
        {
            admissionSlip(inputData,inputData3);
        }
        else if (inputData2 == "AcceptanceSlip")
        {
            acceptanceSlip(inputData,inputData3);
        }
      
    }
  
    public bool IsReusable {
        get {
            return false;
        }
    }

    public static String generateBarcode2(String barcode)
    {
        Barcode_Generator.Code39 c39 = new Barcode_Generator.Code39();
        c39.FontFamilyName = "Free 3 of 9";
        //c39.FontFileName = Path.GetFullPath("Font/FREE3OF9.TTF");
        c39.FontFileName = HttpContext.Current.Server.MapPath("~/Font/FREE3OF9.TTF");
       
        c39.FontSize = 60;
        c39.ShowCodeString = true;
        //c39.Title = "test";
        System.Drawing.Bitmap objBitmap = c39.GenerateBarcode(barcode);
        long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;
        String savePath = milliseconds + "_2__" + barcode + ".png";
        string path2 = HttpContext.Current.Server.MapPath("~/barcodes/");
        objBitmap.Save(path2 + savePath, System.Drawing.Imaging.ImageFormat.Png);
        objBitmap.Dispose();
        return path2 + savePath;
    }
    
    public static string generatbarcode(string formnum)
    {
        string barCode = formnum;
        long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;
        String savePath = System.Web.HttpContext.Current.Server.MapPath("barcodes/" + milliseconds + formnum + ".png");
        //String savePath = milliseconds + "_1__" + formnum + ".png";

        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        using (System.Drawing.Bitmap bitMap = new System.Drawing.Bitmap(barCode.Length * 40, 80))
        {
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitMap))
            {
                System.Drawing.Font oFont = new System.Drawing.Font("Free 3 of 9", 16);
                System.Drawing.PointF point = new System.Drawing.PointF(2f, 2f);
                System.Drawing.SolidBrush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.SolidBrush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
                // bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                // byte[] byteImage = ms.ToArray();

                // Convert.ToBase64String(byteImage);
                // imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }

        }
        return savePath;
    }
    public void acceptanceSlip(string rowID,string appID)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        string path = string.Empty;
        string userID = System.Web.Security.Membership.GetUser().ProviderUserKey.ToString();
        string getprogtrypebyID = db.getProgramTypeByID(userID);

        if (getprogtrypebyID.Trim() == "Part-Time")
        {
            path = HttpContext.Current.Server.MapPath("Slips/DPPAcceptanceSlip.html");
        }
        else
        {
            path = HttpContext.Current.Server.MapPath("Slips/AcceptanceSlip.html");
        }
        
       
        string ownerName = string.Empty;
        string phone = string.Empty;


        DataSet admissionInfo = db.getAdmissionRow(Convert.ToInt32(rowID));
        DataSet paymentinfo = db.getAdmission_TransInfo(Convert.ToInt32(rowID));
        DataSet applicationInfo = db.getApplication_ID(appID);

        string fullName = db.getStudent_CompleteName(userID);
        
        string content = System.IO.File.ReadAllText(path);

        string formnumber = admissionInfo.Tables[0].Rows[0]["Regno"].ToString();
        content = content.Replace("{formnumber}", formnumber).Replace("{fullname}",fullName);

        
        string barcode = generateBarcode2(formnumber);
        barcode = barcode.Replace("C:\\AdmissionPortal\\Students\\barcodes\\", "http://apply.polyibadan.edu.ng/Students/barcodes/");
        
        content = content.Replace("{admissionsession}", System.Configuration.ConfigurationManager.AppSettings["admissionSession"].ToString());
        
        content = content.Replace("{progname}", admissionInfo.Tables[0].Rows[0]["Program_Admitted"].ToString());
        
        content = content.Replace("{refno}", paymentinfo.Tables[0].Rows[0]["TransactionRef"].ToString());
        content = content.Replace("{paymentdate}", paymentinfo.Tables[0].Rows[0]["PaymentDate"].ToString());
        content = content.Replace("{amountpaid}", paymentinfo.Tables[0].Rows[0]["AmountPaid"].ToString());
        content = content.Replace("{username}", System.Web.Security.Membership.GetUser().UserName.ToString());
     //   content = content.Replace("{COS}", applicationInfo.Tables[0].Rows[0]["Course1"].ToString());
        content = content.Replace("{COS}", admissionInfo.Tables[0].Rows[0]["Department_Admitted"].ToString());

        //content = content.Replace("{COS}", admissionInfo.Tables[0].Rows[0]["Program_Admitted"].ToString());
        //Program_Admitted
        string tmp2 = "<img  src=\"" + barcode + "\"  />";
        content = content.Replace("{barcodeimage}", tmp2);
            
        Byte[] bytes;

        content = content.Replace("http://localhost:3463", "http://apply.polyibadan.edu.ng");
        using (var ms = new MemoryStream())
        {
            var doc = new Document();
            doc = new Document(PageSize.A4, 30, 30, 30, 30);

            var writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();
            doc.NewPage();

            var example_html = content;
            using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
            {
                using (var sr = new StringReader(example_html))
                {
                    htmlWorker.Parse(sr);
                }
            }
            doc.Close();
            bytes = ms.ToArray();
        }
        long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + formnumber + "_AcceptanceSlip.pdf");
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.BinaryWrite(bytes);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Close();
    }
    
    public void admissionSlip(string rowID,string appID)
    {
        
        
        DatabaseFunctions db = new DatabaseFunctions();
        string path = string.Empty;
        string userID = System.Web.Security.Membership.GetUser().ProviderUserKey.ToString();
        string ownerName = string.Empty;
        string phone = string.Empty;
        
        
        DataSet admissionInfo = db.getAdmissionRow(Convert.ToInt32(rowID));
        DataSet applicationInfo = db.getApplication_ID(appID);

     //   int programID = Convert.ToInt16(applicationInfo.Tables[0].Rows[0]["programID"].ToString());
        string getprogtrypebyID = db.getProgramTypeByID(userID);

        if (getprogtrypebyID.Trim() == "Part-Time")
        {
            path = HttpContext.Current.Server.MapPath("~/Slips/DPPAdmissionSlip.html");
        }
        else 
        {
            path = HttpContext.Current.Server.MapPath("~/Slips/HNDAdmissionSlip.html");
        }
            
        string fullname = applicationInfo.Tables[0].Rows[0]["fullname"].ToString();
        string progname=applicationInfo.Tables[0].Rows[0]["programName"].ToString();
        string content = System.IO.File.ReadAllText(path);
        string picture = applicationInfo.Tables[0].Rows[0]["profilepic"].ToString();

        string formnumber = applicationInfo.Tables[0].Rows[0]["formnumber"].ToString();

        string barcode = generateBarcode2(formnumber);
        barcode = barcode.Replace("C:\\AdmissionPortal\\Students\\barcodes\\", "http://apply.polyibadan.edu.ng/Students/barcodes/");
        
        
        content = content.Replace("{FNAME}", fullname).Replace("{formnumber}", formnumber);
        content = content.Replace("{progname}", admissionInfo.Tables[0].Rows[0]["Program_Admitted"].ToString());
        content = content.Replace("{admissionsession}", System.Configuration.ConfigurationManager.AppSettings["admissionSession"].ToString());
       
        if (picture != "")
        {
            
            string src = imagerootPath_pdf + picture;
         //   if (File.Exists(src))
            {
                string tmp = "<img width=\"150px\" height=\"150px\" src=\"" + src + "\"  />";


                content = content.Replace("{imagename}", tmp);
            }
          
        }
        else
        {
            content = content.Replace("{imagename}", "");
        }
        
        //content = content.Replace("{COS}", applicationInfo.Tables[0].Rows[0]["Course1"].ToString());
        content = content.Replace("{COS}", admissionInfo.Tables[0].Rows[0]["Department_Admitted"].ToString());
        content = content.Replace("{STO}", applicationInfo.Tables[0].Rows[0]["state"].ToString());
        content = content.Replace("{CAMPUS}", admissionInfo.Tables[0].Rows[0]["Campus_Admitted"].ToString());

        string tmp2 = "<img  src=\"" + barcode + "\"  />";
        content = content.Replace("{barcodeimage}", tmp2);
            

       // string acceptaneFee = System.Configuration.ConfigurationManager.AppSettings["acceptanceFee"].ToString();
        //string Bank_Account_No = System.Configuration.ConfigurationManager.AppSettings["Bank_Account_No"].ToString();
        //string Bank_Name = System.Configuration.ConfigurationManager.AppSettings["Bank_Name"].ToString();

        //content = content.Replace("{bankacctname}", Bank_Account_Name);
        //content = content.Replace("{accountnum}", Bank_Account_No);
        //content = content.Replace("{bankame}", Bank_Name);
        //content = content.Replace("{amount}", "₦ " + rowInfo.Tables[0].Rows[0]["amount"].ToString());
     //   content = content.Replace("{emailID}",acceptaneFee);

      
        Byte[] bytes;
        content = content.Replace("http://localhost:3463", "http://apply.polyibadan.edu.ng");

        using (var ms = new MemoryStream())
        {
            var doc = new Document();
            doc = new Document(PageSize.A4, 30, 30, 30, 30);

            var writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();
            doc.NewPage();

            var example_html = content;
            using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
            {
                using (var sr = new StringReader(example_html))
                {
                    htmlWorker.Parse(sr);
                }
            }
            doc.Close();
            bytes = ms.ToArray();
        }
        long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + formnumber +"_admissionSlip.pdf");
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.BinaryWrite(bytes);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Close();
    }

    
    
    public void eWalletReceipt(string rowID,int flag)
    {
        DatabaseFunctions db = new DatabaseFunctions();

        string path = string.Empty;
        if (flag == 1)
        {
            path = HttpContext.Current.Server.MapPath("Slips/depositSlip.html");
        }
        else 
        {
            path = HttpContext.Current.Server.MapPath("Slips/depositSlip_Nibbs.html");
        }
        string userID = System.Web.Security.Membership.GetUser().ProviderUserKey.ToString();
        string ownerName = string.Empty;
        string phone = string.Empty;
        DataSet ownerInfo = db.getUserOtherInfo(userID);
        if (ownerInfo.Tables[0].Rows.Count > 0)
        {
            ownerName = ownerInfo.Tables[0].Rows[0]["FullName"].ToString();
            phone = ownerInfo.Tables[0].Rows[0]["PhoneNum"].ToString();
        }

        string content = System.IO.File.ReadAllText(path);
        DataSet rowInfo=db.geteWalletrow(Convert.ToInt32(rowID));
        
        content = content.Replace("{owner}", ownerName);
        content = content.Replace("{invoiceDate}", rowInfo.Tables[0].Rows[0]["DateTime"].ToString());
        content = content.Replace("{phone}", phone);
        content = content.Replace("{refno}", rowInfo.Tables[0].Rows[0]["TransasctionRef"].ToString());

        string Bank_Account_Name = System.Configuration.ConfigurationManager.AppSettings["Bank_Account_Name"].ToString();
        string Bank_Account_No = System.Configuration.ConfigurationManager.AppSettings["Bank_Account_No"].ToString();
        string Bank_Name = System.Configuration.ConfigurationManager.AppSettings["Bank_Name"].ToString();

        content = content.Replace("{bankacctname}", Bank_Account_Name);
        content = content.Replace("{accountnum}", Bank_Account_No);
        content = content.Replace("{bankame}", Bank_Name);
        content = content.Replace("{amount}", "₦ " + rowInfo.Tables[0].Rows[0]["amount"].ToString());
        content = content.Replace("{emailID}", System.Web.Security.Membership.GetUser().Email.ToString());

        string eWalletno = db.getEwalletNumber(userID);

        content = content.Replace("{ewalletno}", eWalletno);

        Byte[] bytes;

        content = content.Replace("http://localhost:3463", "http://apply.polyibadan.edu.ng");
        using (var ms = new MemoryStream())
        {
            var doc = new Document();
            doc = new Document(PageSize.A4, 30, 30, 30, 30);

            var writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();
            doc.NewPage();

            var example_html = content;
            using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
            {
                using (var sr = new StringReader(example_html))
                {
                    htmlWorker.Parse(sr);
                }
            }
            doc.Close();
            bytes = ms.ToArray();
        }
        long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;
        
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + milliseconds + "_" + eWalletno + "_depositSlip.pdf");
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.BinaryWrite(bytes);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Close();
    }

    public void paymentSlip(string txnref)
    {
        DatabaseFunctions db = new DatabaseFunctions();
        string path = HttpContext.Current.Server.MapPath("Slips/paymentSlip.html");
        string userID = System.Web.Security.Membership.GetUser().ProviderUserKey.ToString();
        string ownerName = string.Empty;
        string phone = string.Empty;

        ownerName = db.getStudent_CompleteName(userID);
        DataSet ownerInfo = db.getUserOtherInfo(userID);
        if (ownerInfo.Tables[0].Rows.Count > 0)
        {
            //ownerName = ownerInfo.Tables[0].Rows[0]["FullName"].ToString();
            phone = ownerInfo.Tables[0].Rows[0]["PhoneNum"].ToString();
        }
        DataSet transactionDetails = db.getTransactionDetails_txtRef(txnref);
        string content = System.IO.File.ReadAllText(path);
        if (transactionDetails.Tables[0].Rows.Count > 0)
        {
            content = content.Replace("{owner}", ownerName);
            content = content.Replace("{invoiceDate}", transactionDetails.Tables[0].Rows[0]["TransactionDate"].ToString());
            content = content.Replace("{phone}", phone);
            content = content.Replace("{refno}", txnref);


            content = content.Replace("{amount}", "<b>₦ " + transactionDetails.Tables[0].Rows[0]["amount"].ToString()+"</b>");
            content = content.Replace("{feetype}","<b>"+ transactionDetails.Tables[0].Rows[0]["feetype"].ToString())+"</b>";
            content = content.Replace("{paymentmethod}", "<b>" + transactionDetails.Tables[0].Rows[0]["PaidUsing"].ToString()) + "</b>";

            content = content.Replace("{emailID}", System.Web.Security.Membership.GetUser().Email.ToString());

            long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;
            //generatePdfFromHtml(content, 0, milliseconds.ToString());

            Byte[] bytes;

            content = content.Replace("http://localhost:3463", "http://apply.polyibadan.edu.ng");
            using (var ms = new MemoryStream())
            {
                var doc = new Document();
                doc = new Document(PageSize.A4, 30, 30, 30, 30);

                var writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();
                doc.NewPage();

                var example_html = content;
                using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
                {
                    using (var sr = new StringReader(example_html))
                    {
                        htmlWorker.Parse(sr);
                    }
                }
                doc.Close();
                bytes = ms.ToArray();
            }

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + milliseconds + "paymentSlip.pdf");
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Close();
        }
    }
    
    public void applicationSlip(string inputData,string programID)
    {
        string path = HttpContext.Current.Server.MapPath("Slips/applicationSlip.html");

        string content = System.IO.File.ReadAllText(path);
        
        DatabaseFunctions db = new DatabaseFunctions();

        string olevelpath = HttpContext.Current.Server.MapPath("Slips/olevelRecordTable.txt");
        string prevpath = HttpContext.Current.Server.MapPath("Slips/previousRecordTable.txt");
        string jambpath = HttpContext.Current.Server.MapPath("Slips/Jambdata.txt");

        string olevelText = System.IO.File.ReadAllText(olevelpath);
        string prevText = System.IO.File.ReadAllText(prevpath);
        string jabtext = System.IO.File.ReadAllText(jambpath);
        
        DataSet ds = db.getProgramIDbyApplicationID(Convert.ToInt32(inputData));
        if (ds.Tables[0].Rows.Count > 0)
        {
            int JambForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasJambData"].ToString());  //1
            int BioForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasBioDataSection"].ToString());//2
            int OlevelForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasOlevelResult"].ToString());//3
            int PreviousRecordForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasPreviousRecord"].ToString());//4
            int CbtScheduleForm = Convert.ToInt16(ds.Tables[0].Rows[0]["HasCBTSchedule"].ToString());//5

            if (JambForm == 1)
            {
                content = content.Replace("{jambData}", jabtext);
                
            }
            else 
            {
                content = content.Replace("{jambData}", "");
            }

            if (OlevelForm == 1)
            {
                content = content.Replace("{olevelRecordTable}", olevelText);

            }
            else
            {
                content = content.Replace("{olevelRecordTable}", "");
            }

            if (PreviousRecordForm == 1)
            {
                content = content.Replace("{previousRecordTable}", prevText);
                content = content.Replace("{previousRecordTable}", "");
            }
            else
            {

                content = content.Replace("{previousRecordTable}", "");
            }
           

        }

        
        
        
        ds = new DataSet();
        ds = db.getApplication_ID_NEW(inputData);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string fullname = ds.Tables[0].Rows[0]["fullname"].ToString();
            string formnumber = ds.Tables[0].Rows[0]["formnumber"].ToString();
            string barcode = generateBarcode2(formnumber);
            barcode = barcode.Replace("C:\\AdmissionPortal\\Students\\barcodes\\", "http://apply.polyibadan.edu.ng/Students/barcodes/");
            
            string gender = ds.Tables[0].Rows[0]["gender"].ToString();
            string email = ds.Tables[0].Rows[0]["email"].ToString();
            string phone = ds.Tables[0].Rows[0]["phonenumber"].ToString();
            string course = ds.Tables[0].Rows[0]["course1"].ToString();
            string course2 = ds.Tables[0].Rows[0]["course2"].ToString();
            string picture = ds.Tables[0].Rows[0]["profilepic"].ToString();


            int score = 0;
            if (ds.Tables[0].Rows[0]["score1"].ToString() != "")
            {
                score = score + Convert.ToInt16(ds.Tables[0].Rows[0]["score1"].ToString());
            }
            if (ds.Tables[0].Rows[0]["score2"].ToString() != "")
            {
                score = score + Convert.ToInt16(ds.Tables[0].Rows[0]["score2"].ToString());
            }
            if (ds.Tables[0].Rows[0]["score3"].ToString() != "")
            {
                score = score + Convert.ToInt16(ds.Tables[0].Rows[0]["score3"].ToString());
            }
            if (ds.Tables[0].Rows[0]["score4"].ToString() != "")
            {
                score = score + Convert.ToInt16(ds.Tables[0].Rows[0]["score4"].ToString());
            }
            
            if (course2 != "")
            {
                course = course + ", " + course2;
            }
            string state = ds.Tables[0].Rows[0]["state"].ToString();
            string program = ds.Tables[0].Rows[0]["programName"].ToString();

         

            if (picture != "")
            {
                 string src = imagerootPath_pdf + picture;
             //    if (File.Exists(src))
                 {
                     string tmp = "<img width=\"150px\" height=\"150px\" src=\"" + src + "\"  />";


                     content = content.Replace("{imagename}", tmp);
                 }
            
            }
            else
            {
                content = content.Replace("{imagename}", "");
            }
          
            string tmp2 = "<img  src=\"" + barcode + "\"  />";
            content = content.Replace("{barcodeimage}", tmp2);
            
            
            
            content = content.Replace("{owner}", fullname);
            content = content.Replace("{gender}", gender);
            content = content.Replace("{phone}", phone);
            content = content.Replace("{course}", course);
            content = content.Replace("{formnumber}", formnumber);
            content = content.Replace("{state}", state);
            content = content.Replace("{program}", program);
            content = content.Replace("{emailID}", email);

            //CBT INFORMATION

            string cbtschedule = ds.Tables[0].Rows[0]["cbtschedule"].ToString();
            string cbtusername = ds.Tables[0].Rows[0]["cbtusername"].ToString();
            string cbtpassword = ds.Tables[0].Rows[0]["cbtpassword"].ToString();
            string venue = string.Empty;
            string subjectcombindation = ds.Tables[0].Rows[0]["jambsubjects"].ToString();


            content = content.Replace("{cbtschedule}", cbtschedule);
            content = content.Replace("{cbtusername}", cbtusername);
            content = content.Replace("{cbtpassword}", cbtpassword);
            content = content.Replace("{venue}", System.Configuration.ConfigurationManager.AppSettings["applicationVenue"].ToString());
            content = content.Replace("{subjectcombination}", subjectcombindation);
            string adScore = ds.Tables[0].Rows[0]["admissionscore"].ToString();
            if (adScore != "")
            {
                try
                {

                    adScore = Math.Round(Convert.ToDouble(adScore), 2).ToString();
                }
                catch (Exception ex1)
                { }
            }
            content = content.Replace("{avgscore}", adScore);
            //JAMBDATA

            string jambregno2 = ds.Tables[0].Rows[0]["JambRegNo"].ToString();
            string originaljampolu = ds.Tables[0].Rows[0]["OriginalJAMBChoiceofPolytechnic"].ToString();
            string originaljambsource = ds.Tables[0].Rows[0]["OriginalJambCourse"].ToString();
            string poly = ds.Tables[0].Rows[0]["jambins"].ToString();
            string subinnfo = ds.Tables[0].Rows[0]["jambscoreMain"].ToString();


            content = content.Replace("{JambRegNo}", jambregno2);
            content = content.Replace("{originalpolyu}", originaljampolu);
            content = content.Replace("{originaljambcourse}", originaljambsource);
            content = content.Replace("{polychoice}", poly);
            content = content.Replace("{JAMBCOURSEINFO}", subinnfo);
            content = content.Replace("{totalScore}", score.ToString());
            

            //PREVIOUS ACADEMIC RECORD

            string jambfullname = ds.Tables[0].Rows[0]["jambfullname"].ToString();
            string jambregno = ds.Tables[0].Rows[0]["jambregno"].ToString();
            string institution = ds.Tables[0].Rows[0]["InstitutionAttented"].ToString();
            string jambyear = ds.Tables[0].Rows[0]["JambExamyear"].ToString();
            string coursename = ds.Tables[0].Rows[0]["CourseName"].ToString();
            string coursetype = ds.Tables[0].Rows[0]["coursetype"].ToString();
            string coursegrade = ds.Tables[0].Rows[0]["coursegrade"].ToString();
            string yearcompleted = ds.Tables[0].Rows[0]["YearCompleted"].ToString();
            string trainingPersiod = ds.Tables[0].Rows[0]["IndTrainingStart"].ToString() + "-" + ds.Tables[0].Rows[0]["IndTrainingEnd"].ToString();
            string formermatricnumber = ds.Tables[0].Rows[0]["ND_Matric_Number"].ToString();

            content = content.Replace("{formerMatricNumber}", formermatricnumber);
            content = content.Replace("{jambfullname}", jambfullname);
            content = content.Replace("{jambregno}", jambregno);
            content = content.Replace("{institution}", institution);
            content = content.Replace("{jambyear}", jambyear);
            content = content.Replace("{coursename_jamb}", coursename);
            content = content.Replace("{coursetype_jamb}", coursetype);
            content = content.Replace("{coursegrade_jamb}", coursegrade);
            content = content.Replace("{yearcompleted}", yearcompleted);
            content = content.Replace("{trainingperiod_jamb}", trainingPersiod);



            //OLEVEL RESULTS


            string Examtype = ds.Tables[0].Rows[0]["Examtype"].ToString();
            string Examnumber = ds.Tables[0].Rows[0]["Examnumber"].ToString();
            string Exammonth = ds.Tables[0].Rows[0]["Exammonth"].ToString();
            string ExamYear = ds.Tables[0].Rows[0]["ExamYear"].ToString();
            
            string Examtype2 = ds.Tables[0].Rows[0]["Examtype2"].ToString();
            string Examnumber2 = ds.Tables[0].Rows[0]["Examnumber2"].ToString();
            string Exammonth2 = ds.Tables[0].Rows[0]["Exammonth2"].ToString();
            string ExamYear2 = ds.Tables[0].Rows[0]["ExamYear2"].ToString();

            content = content.Replace("{exam_olevel}", Examtype);
            content = content.Replace("{examnumber_olevel}", Examnumber);
            content = content.Replace("{exammonth_olevel}", Exammonth);
            content = content.Replace("{examyear_olevel}", ExamYear);
          
            content = content.Replace("{exam_olevel2}", Examtype2);
            content = content.Replace("{examnumber_olevel2}", Examnumber2);
            content = content.Replace("{exammonth_olevel2}", Exammonth2);
            content = content.Replace("{examyear_olevel2}", ExamYear2);


            content = content.Replace("{info_course1_sitting}", ds.Tables[0].Rows[0]["olevelsitting1"].ToString());
            content = content.Replace("{info_course1_2sitting}", ds.Tables[0].Rows[0]["olevelsitting2"].ToString());
            
            
            content = content.Replace("http://localhost:3463", "http://apply.polyibadan.edu.ng");

            Byte[] bytes;


            using (var ms = new MemoryStream())
            {
                var doc = new Document();
                doc = new Document(PageSize.A4, 30, 30, 30, 30);

                var writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();
                doc.NewPage();

                var example_html = content;
                using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
                {
                    using (var sr = new StringReader(example_html))
                    {
                        htmlWorker.Parse(sr);
                    }
                }
                doc.Close();
                bytes = ms.ToArray();
            }

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + formnumber + "_applicationSlip.pdf");
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Close();

        }
    }
}