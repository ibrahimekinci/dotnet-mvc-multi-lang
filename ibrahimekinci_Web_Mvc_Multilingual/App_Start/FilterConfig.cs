using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ibrahimekinci_Web_Mvc_Multilingual
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //////////////
            filters.Add(new LocalizationAttribute(), 0);
            /////////////////
        }
    }
}