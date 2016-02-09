using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Datatype
/// </summary>
public class Datatype
{
    public  List<DataTypelist> datatypelist = new List<DataTypelist>();
    public List<controls> controllist = new List<controls>();
	public Datatype()
	{
        DataTypelist list = new DataTypelist();
        list.type = "Varchar";
        datatypelist.Add(list);
        list = new DataTypelist();
        list.type = "int";
        datatypelist.Add(list);
       list = new DataTypelist();
        list.type = "Text";
        datatypelist.Add(list);
        list = new DataTypelist();
        list.type = "boolean";
        datatypelist.Add(list);
        list = new DataTypelist();
        list.type = "Date";
        datatypelist.Add(list);

        /////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////

        controls cont = new controls();
        cont.type = "Text";
        controllist.Add(cont);
        cont = new controls();
        cont.type = "Radio Button";
        controllist.Add(cont);
        cont = new controls();
        cont.type = "Check Box";
        controllist.Add(cont);
        cont = new controls();
        cont.type = "DropdownList";
        controllist.Add(cont);


        
	}

    public class DataTypelist
    {
        public String type { get; set; }

    }

    public class controls
    {
        public string type { get; set; }
    }
}