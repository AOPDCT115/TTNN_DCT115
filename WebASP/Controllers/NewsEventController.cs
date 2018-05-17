using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.Controllers
{
    public class NewsEventController : Controller
    {
        // GET: NewsEvent
        private DataVTT db = new DataVTT();
        public ActionResult Index()
        {
            List<NewsEvents> newsevent = db.NewsEvents.ToList();
            return View(newsevent);
        }

        public ActionResult XemThem (int id)
        {

            return View(db.NewsEvents.Find(id));
        }


    }
}