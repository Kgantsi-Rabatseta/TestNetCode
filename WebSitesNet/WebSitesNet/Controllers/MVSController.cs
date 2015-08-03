using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataUtilities;
using DataUtilities.User;
using WebSitesNet.Models;

namespace WebSitesNet.Controllers
{
    public class MvsController : Controller
    {

        public ActionResult Mvs()
        {
            var model = new MvsModel
                {
                    Goals = "What \nThe\nFuck",
                    Mission = "To Understand this damn thing",
                    Vision = "Im going to crack it"
                };
            var ihasiDs = UserBuilder.BuildUsers(10);
            return
                View(ihasiDs);
        }

    }
}
