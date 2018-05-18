using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP.DAL;

namespace WebASP.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        private DataVTT db = new DataVTT();
        public ActionResult Index()
        {
            ViewBag.soluonghocvien = db.Student.ToList().Count();

            ViewBag.soluonglopdangmo = db.Schedule.ToList().Count();

            ViewBag.soluongphanhoi = db.Feedback.Where(x => x.Status).ToList().Count();
            return View();
        }

        public ActionResult TrangTongQuat()
        {
            return View();
        }
    }
}