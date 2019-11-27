using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JACProject.Models
{
    public class MainSiteController : Controller
    {
        // GET: MainSite
        public ActionResult Index()
        {
            return View();
        }
    }
}