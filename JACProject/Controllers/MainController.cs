using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JACProject.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Views()
        {
            return View();
        }

        public ActionResult JudithSays()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}