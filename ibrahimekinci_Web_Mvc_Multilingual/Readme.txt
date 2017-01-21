-----------Etkilenenler-------------
---web config---------------------------------------

  <system.web>
  --
    <globalization uiCulture="tr-TR" culture="tr-TR" />
--
  </system.web>
    <globalization uiCulture="tr-TR" culture="tr-TR" />

---app_start------------------------------------------
--------RouteConfig
 public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            ///////////////////////
            routes.MapRoute(
                name: "DefaultLocalized",
                url: "{lang}/{controller}/{action}/{id}",
                constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            /////////////////////////
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
---Filter Config------------------------------------------
 
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //////////////
            filters.Add(new LocalizationAttribute(), 0);
            /////////////////
        }
    }
	Eğer filter config yok ise ve yeni oluşturuluyorsa Global.asax dosyası

		 public class MvcApplication : System.Web.HttpApplication
		{
			protected void Application_Start()
			{
				///Eklenecek satır
				FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
				/////////////////
			}
		}
---------------------------------------------------------------
Localization
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private string _DefaultFileLanguage = "tr";
        private string _DefaultLanguage = "tr";
        // private string[] _LanguageList = new string[] { "tr", "en" };
        //public LocalizationAttribute()
        //{

        //}
        //public LocalizationAttribute(string DefaultLanguage)
        //{
        //    foreach (var item in _LanguageList)
        //    {
        //        if (item == DefaultLanguage)
        //        _DefaultLanguage = DefaultLanguage;
        //    }
        //}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = (string)filterContext.RouteData.Values["lang"] ?? _DefaultLanguage;
            if (lang != _DefaultFileLanguage)
            {
                try
                {
                    //   Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                }
                catch (Exception e)
                {
                    throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", lang));
                }
            }
        }
    }
}
-----------Lang klasörü---------------------------------------------------------------------------------------------------------------
---------------resx dosyaları   
			name.resx  varsayılan dil dosyası
			name.en.resx    kısaltması en olan dilin dosyası
---------------resx dosya- propertiesleri(Sağ tık)
	customtool    =   PublicResXFileCodeGenerator
	namespace    =   project.Name
-----------Lang klasörü---------------------------------------------------------------------------------------------------------------

