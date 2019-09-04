using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JACProject.Database;
using JACProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace JACProject.Controllers
{
    public class ForumController : Controller
    {

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }



        // GET: Forum
        public ActionResult Index()
        {
            return View();
        }


        Context context = new Context();

        public ActionResult CreatePost(int? threadID)
        {
            if (threadID == null)
            {
                threadID = 1;
            }

            ViewBag.ThreadID = threadID.ToString();

            return View();
        }

        [HttpPost]
        public ActionResult PostPost(Post post, int? thrdID)
        {
            Thread chosenThread;
            string id = User.Identity.GetUserId();
            ApplicationUser currentUser = UserManager.FindById(id);
            Account poster = new Account();


            if (context.accounts.Where(x => x.name == currentUser.UserName) == null)
            {
                poster.name = currentUser.UserName;
                context.accounts.Add(poster);
            }
            else
            {
                poster = context.accounts.Where(x => x.name == currentUser.UserName).FirstOrDefault();
            }


            thrdID = post.id;
            post.creator = poster;

            if (context.threads.Where(x => x.id == thrdID).FirstOrDefault() != null)
            {
                chosenThread = context.threads.Include("content").Where(x => x.id == thrdID).FirstOrDefault();
            }
            else
            {
                chosenThread = new Thread();
            }
            post.creator = context.accounts.FirstOrDefault();
            post.timeCreated = DateTime.Now;
            chosenThread.content.Add(post);
            context.SaveChanges();

            return RedirectToAction("Threads", new { threadID = thrdID });
        }

        public ActionResult Threads(int threadID)
        {
            Thread thread = context.threads.Include("content").Where(x => x.id == threadID).FirstOrDefault();
            return View(thread);
        }
    }
}