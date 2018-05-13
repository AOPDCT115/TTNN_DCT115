using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP.DAL;

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
    }
}