using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

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
}