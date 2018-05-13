using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.Controllers
{
    public class LichHocController : Controller
    {
        private DataVTT db = new DataVTT();
        // GET: LichHoc
        public ActionResult Index()
        {
            KhoaHoc();

            System.Threading.Thread.Sleep(3000);
            string codekh = Request.Form["khoahoc"];
            if (codekh == "")
            {
                codekh = null;
            }
            var codekhh = Convert.ToInt64(codekh);
            var schedule = from a in db.Class
                           join b in db.Schedule on a.ClassID equals b.ClassID
                           where a.CourseID == codekhh
                           select b;

            var model = schedule.ToList();
            ViewBag.count = codekh;
            ViewBag.schedule = schedule.ToList();

            return View();
        }

        public void KhoaHoc(long? selectedId = null)
        {
            List<Course> course = db.Course.ToList();
            if (course.Count == 0)
            {
                ViewBag.Course = "Lỗi";
            }
            ViewBag.khoahoc = new SelectList(course, "CourseID", "Name", selectedId);
        }

        public void ChuongTrinhHoc(int khoahoc)
        {
            List<Course> course = db.Course.Where(x => x.TypeCourseID == khoahoc).ToList();
            if (course.Count == 0)
            {
                ViewBag.Course = "Lỗi";
            }
            ViewBag.chuongtrinhhoc = new SelectList(course, "TypeCourseID", "TypeName", khoahoc);
        }

    }
}