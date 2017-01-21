using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
namespace ibrahimekinci_Web_Mvc_Multilingual
{
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