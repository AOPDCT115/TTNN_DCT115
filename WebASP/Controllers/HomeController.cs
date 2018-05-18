using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP.DAL;
using WebASP.DAO;
using WebASP.Models;

namespace WebASP.Controllers
{
    public class HomeController : Controller
    {
        private DataVTT db = new DataVTT();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GioiThieu()
        {
            return View();
        }

        public ActionResult Chuongtrinhdaotao()
        {
            var list = db.TypeCourse.ToList();
            ViewBag.chuongtrinhdaotao = db.TypeCourse.ToList();
            return PartialView(list);
        }

        public ActionResult TinTucSuKien()
        {
            return View();
        }
        public ActionResult LienHe()
        {
                return View();
        }
        public ActionResult Menu()
        {
            var list = db.Menu.ToList();
            ViewBag.chuongtrinhdaotao1 = db.TypeCourse.ToList();
            return PartialView(list);
        }
        public ActionResult NewsEvent()
        {
            var newsevent = db.NewsEvents.Take(3).ToList();
                return PartialView(newsevent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Feedback(Feedback ne)
        {
            if (ModelState.IsValid)
            {
                ne.Status = true;
                var dao = new FeedbackDAO();

                long id = dao.Insert(ne);

                if (id > 0)
                {
                    ModelState.AddModelError("Thêm thành công", "success");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View(ne);
        }

    }
}