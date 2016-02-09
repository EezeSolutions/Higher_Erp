using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuestionsAnswers
/// </summary>
public class QuestionsAnswers
{
	public QuestionsAnswers()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Question { get; set; }
    public int QID { get; set; }
    public int AnsID { get; set; }
    public string Answers { get; set; }

}