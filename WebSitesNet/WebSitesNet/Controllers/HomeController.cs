using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSitesNet.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            ViewData["aboutData"] = "I Love you \nNokuthemba Pertunia Khumalo \nAKA 'Fikie'";
            ViewData["aboutHeader2"] = "Enjoy Studying and GoodNight";
            return View();
        }
    }
}
