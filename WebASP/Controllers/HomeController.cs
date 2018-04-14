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
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GioiThieu()
        {
            return View();
        }

        public ActionResult ChuongTrinhDaoTao()
        {
            var list = db.TypeCourse.ToList();
            return View(list);
        }

        public ActionResult TinTucSuKien()
        {
            return View();
        }
        public ActionResult LienHe()
        {
                return View();
        }

    }
}