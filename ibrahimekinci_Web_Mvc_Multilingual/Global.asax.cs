using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ibrahimekinci_Web_Mvc_Multilingual
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //////////////
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            /////////////////
        }
    }
}
