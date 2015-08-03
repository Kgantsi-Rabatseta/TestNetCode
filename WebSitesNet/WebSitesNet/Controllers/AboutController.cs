using System.Web.Mvc;

namespace WebSitesNet.Controllers
{
    public class AboutController:Controller
    {
        
        public ActionResult About()
        {
            ViewData["aboutData"] = "I Love you \nNokuthemba Pertunia Khumalo \nAKA 'Fikie'";
            ViewData["aboutHeader2"] = "Enjoy Studying and GoodNight";
            return View();
        }
    }
}