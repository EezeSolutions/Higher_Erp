using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

/// <summary>
/// Summary description for utilities
/// </summary>
public class utilities
{
	public utilities()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string gethtml(string url)
    {
        string responseData = "";
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 160000;
            request.Method = "GET";
            request.KeepAlive = true;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(responseStream);
                responseData = myStreamReader.ReadToEnd();

                //foreach (Cookie cook in response.Cookies)
                //{
                //    yummycookies.Add(cook);
                //}

            }
            response.Close();

        }
        catch (WebException e)
        {
            if (e.Response != null)
                using (var sr = new StreamReader(e.Response.GetResponseStream()))
                    responseData = sr.ReadToEnd();
        }

        return responseData;

    }

     public static Byte[] generatePdfFromHtml(string html, int landscape, string enumber)
    {
        Byte[] bytes = null;
        try
        {
            string content = html;
            using (var ms = new MemoryStream())
            {
                var doc = new Document();
                if (landscape == 1)
                {
                    doc = new Document(PageSize.A4_LANDSCAPE, 10, 10, 20, 10);
                }
                else
                {
                    doc = new Document(PageSize.A4, 30, 30, 30, 30);
                }


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
          
        }
        catch (Exception ex)
        {

        }

        return bytes;
    }

     public static string ExportToCSVFile(DataTable dtTable)
     {
         StringBuilder sbldr = new StringBuilder();
         if (dtTable.Columns.Count != 0)
         {
             foreach (DataColumn col in dtTable.Columns)
             {
                 sbldr.Append(col.ColumnName + '\t');
             }
             sbldr.Append("\r\n");
             foreach (DataRow row in dtTable.Rows)
             {
                 foreach (DataColumn column in dtTable.Columns)
                 {
                     sbldr.Append(row[column].ToString() + '\t');
                 }
                 sbldr.Append("\r\n");
             }
         }
         return sbldr.ToString();
     }
     public static string ExportToCSVFile2(DataTable dtTable)
     {
         StringBuilder sbldr = new StringBuilder();
         if (dtTable.Columns.Count != 0)
         {
             foreach (DataColumn col in dtTable.Columns)
             {
                 sbldr.Append(col.ColumnName + ',');
             }
             sbldr.Append("\r\n");
             foreach (DataRow row in dtTable.Rows)
             {
                 foreach (DataColumn column in dtTable.Columns)
                 {
                     sbldr.Append(row[column].ToString() + ',');
                 }
                 sbldr.Append("\r\n");
             }
         }
         return sbldr.ToString();
     }

     public static string EncodePassword(string pass, string salt)
     {
         byte[] bytes = Encoding.Unicode.GetBytes(pass);
         byte[] src = Encoding.Unicode.GetBytes(salt);
         byte[] dst = new byte[src.Length + bytes.Length];
         Buffer.BlockCopy(src, 0, dst, 0, src.Length);
         Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
         HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
         byte[] inArray = algorithm.ComputeHash(dst);
         return Convert.ToBase64String(inArray);
     }

     public static string GetSHA512(string text)
     {
         ASCIIEncoding UE = new ASCIIEncoding();
         byte[] hashValue;
         byte[] message = UE.GetBytes(text);

         SHA512Managed hashString = new SHA512Managed();
         string hex = "";

         hashValue = hashString.ComputeHash(message);
         foreach (byte x in hashValue)
         {
             hex += String.Format("{0:x2}", x);
         }
         return hex;
     }

     public static void sendEmail(string from, string to, string subject, string body)
     {
         SmtpClient smtpClient = new SmtpClient();
         System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
         MailAddress fromAddress = new MailAddress("noreply@polyibadan.edu.ng", "The Polytechnic Ibadan - Admission Portal");
         MailAddress toAddress = new MailAddress(to);


         smtpClient.Host = "localhost";
         //smtpClient.Port = 25;

         message.From = fromAddress;
         message.Subject = subject;
         message.IsBodyHtml = true;
         message.Body = body;
         message.To.Add(toAddress);
         //s message.To.Add("e_kayani@hotmail.com");

         try
         {
             smtpClient.Send(message);

         }
         catch (Exception ex)
         {
             throw;
         }
     }

     public static void sendEmail_1(string from, string to, string subject, string body)
     {
         SmtpClient smtpClient = new SmtpClient();
         NetworkCredential basicCredential =
          new NetworkCredential("ehsan.kayani@gmail.com", "");

         smtpClient.Host = "smtp.gmail.com";
         smtpClient.Port = 587;
         smtpClient.UseDefaultCredentials = false;
         smtpClient.Credentials = basicCredential;
         smtpClient.EnableSsl = true;
         MailAddress mailfrom = new MailAddress("ehsan.kayani@gmail.com");
         MailAddress mailto = new MailAddress("e_kayani@hotmail.com");
         System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();



         message.From = mailfrom;
         message.Subject = subject;
         message.IsBodyHtml = true;
         message.Body = body;
         message.To.Add(to);
         try
         {
             smtpClient.Send(message);

         }
         catch (Exception ex)
         {
             throw;
         }
     }

     public static void sendEmail_sa(string from, string to, string subject, string body)
     {
         try
         {
             var client = new SmtpClient("localhost")
             {
             };

             System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

             MailAddress mailfrom = new MailAddress("noreply@polyibadan.edu.ng", "The Polytechnic Ibadan - Admission Portal");

             message.From = mailfrom;
             message.Subject = subject;
             message.IsBodyHtml = true;
             message.Body = body;
             message.To.Add(to);

             client.Send(message);

         }
         catch (Exception ex)
         { }
     }

     public static void sendEmail_MultiReceipient(string from, DataTable toList, string subject, string body)
     {
         SmtpClient smtpClient = new SmtpClient();
         System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
         MailAddress fromAddress = new MailAddress(from, "The Polytechnic Ibadan - Admission Portal");
         //  MailAddress toAddress = new MailAddress(to);


         smtpClient.Host = "localhost";
         //smtpClient.Port = 25;

         message.From = fromAddress;
         message.Subject = subject;
         message.IsBodyHtml = true;
         message.Body = body;

         for (int i = 0; i < toList.Rows.Count; i++)
         {
             message.To.Add(toList.Rows[i]["Email"].ToString());
         }

         try
         {
             smtpClient.Send(message);

         }
         catch (Exception ex)
         {
             throw;
         }
     }

     public static void sendEmail_Gmail(string from, string toList, string subject, string body)
     {
         NetworkCredential basicCredential =
                     new NetworkCredential(from, "site@123");
         SmtpClient smtpClient = new SmtpClient();
         smtpClient.Host = "mail.supplierlink.com.au";
         smtpClient.Port = 25;

         smtpClient.UseDefaultCredentials = false;
         smtpClient.Credentials = basicCredential;


         MailAddress mailfrom = new MailAddress(from);
         MailAddress mailto = new MailAddress(toList);
         System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

         message.From = mailfrom;
         message.Subject = subject;
         message.IsBodyHtml = true;


         message.Body = body;
         message.To.Add(toList);

         try
         {
             smtpClient.Send(message);

         }
         catch (Exception ex)
         {
             throw;
         }
     }

}