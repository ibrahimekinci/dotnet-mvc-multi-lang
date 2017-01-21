using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ibrahimekinci_Web_Mvc_Multilingual.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.MyModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View();
        }
    }
}