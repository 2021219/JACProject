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

        public ActionResult CreatePost(int? threadID, int? boardID)
        {            
            {
                if (threadID != null)
                {
                    ViewBag.ThreadID = threadID.ToString();
                    ViewBag.BoardID = 0;
                }
                else
                {
                    ViewBag.ThreadID = 0;
                    ViewBag.BoardID = boardID;
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult PostPost(Post post, int? thrdID, int? boardID)
        {
            Thread chosenThread;
            string id = User.Identity.GetUserId();
            ApplicationUser currentUser = UserManager.FindById(id);
            Account poster = new Account();

            if (context.accounts.Where(x => x.name == currentUser.UserName).FirstOrDefault() == null)
            {
                poster.name = currentUser.UserName;
                context.accounts.Add(poster);
            }
            else
            {
                poster = context.accounts.Where(x => x.name == currentUser.UserName).FirstOrDefault();
            }


            thrdID = post.id;
            boardID = post.security;

            post.creator = poster;

            if (context.threads.Where(x => x.id == thrdID).FirstOrDefault() != null)
            {
                chosenThread = context.threads.Include("content").Where(x => x.id == thrdID).FirstOrDefault();
            }
            else
            {
                chosenThread = new Thread();
                chosenThread.title = post.title;
                chosenThread.content = new List<Post>();
                context.threads.Add(chosenThread);
                context.boards.Include("threads").Where(x => x.id == boardID).FirstOrDefault().threads.Add(chosenThread);
                context.SaveChanges();
                chosenThread.id = context.threads.OrderByDescending(x => x.id).FirstOrDefault().id;

            }
            post.creator = poster;
            post.timeCreated = DateTime.Now;
            chosenThread.content.Add(post);
            context.SaveChanges();


            return RedirectToAction("Threads", new { threadID = chosenThread.id });
        }

        public ActionResult Threads(int? threadID)
        {

            if (threadID == null)
            {
                threadID = context.threads.Include("content").FirstOrDefault().id;
            }
                Thread thread = context.threads.Include("content").Include("content.creator").Where(x => x.id == threadID).FirstOrDefault();
                return View(thread);
        }
        
        public ActionResult Board(int? boardID)
        {
            Board board;

            if (context.boards.FirstOrDefault() != null)
            {
                if (boardID != null)
                {
                    board = context.boards.Include("subBoards").Include("threads").Where(x => x.id == boardID).FirstOrDefault();
                    return View(board);
                }
                else
                {
                    board = context.boards.Include("subBoards").Include("threads").Where(x => x.initial == true).FirstOrDefault();
                    return View(board);
                }
            }
            else
            {
                board = new Board();
                board.initial = true;
                board.name = "Initial";
                board.security = 0;
                board.deleted = false;
                context.boards.Add(board);
                context.SaveChanges();

                return View(board);
            }
        }
        
        public ActionResult NewBoard(int preboardID)
        {
            if (preboardID != null)
            {
                ViewBag.ThreadID = preboardID.ToString();
            }

            return View();
        }

        [HttpPost]
        public ActionResult PostNewBoard(Board board)
        {
            Board newBoard = new Board();

            newBoard.deleted = false;
            newBoard.initial = false;
            newBoard.name = board.name;

            context.boards.Add(newBoard);

            Board container = context.boards.Include("subBoards").Where(x => x.id == board.id).FirstOrDefault();
            container.subBoards.Add(newBoard);

            context.SaveChanges();

            return RedirectToAction("Board", new { boardID = container.id });
        }
    }
}