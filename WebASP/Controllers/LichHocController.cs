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
            System.Threading.Thread.Sleep(3000);
            string codekh = Request.Form["khoahoc"];
            var codekh2 = Convert.ToInt64(codekh);
            if (codekh==null||codekh=="")
            {
                KhoaHoc(null);

                var schedule = from a in db.Class
                               join b in db.Schedule on a.ClassID equals b.ClassID
                               where a.CourseID == codekh2
                               select b;

                var model = schedule.ToList();

                ViewBag.count = codekh2;
                ViewBag.schedule = schedule.Where(x => x.Status == true).ToList();
            }
            
            if (codekh2 != 0)
            {
                
                var schedule = from a in db.Class
                               join b in db.Schedule on a.ClassID equals b.ClassID
                               where a.CourseID == codekh2
                               select b;

                var model = schedule.ToList();

                ViewBag.count = codekh2;
                ViewBag.schedule = schedule.Where(x => x.Status == true).ToList();
                KhoaHoc(codekh2);
            }
           
            return View();
        }

        public void SetViewBag(long? selectedId = null)
        {

            ViewBag.courseAll = new SelectList(db.Course.ToList(), "CourseID", "Name", selectedId);
        }

        public void KhoaHoc(long? selectedId)
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