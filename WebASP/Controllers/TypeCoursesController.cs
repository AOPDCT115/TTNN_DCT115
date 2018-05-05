using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.Controllers
{
    public class TypeCoursesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: TypeCourses
        public ActionResult Index()
        {
            return View(db.TypeCourse.ToList());
        }
        public ActionResult XemThem(int MaKH)
        {
            TypeCourse typecourse = db.TypeCourse.SingleOrDefault(n => n.TypeCourseID == MaKH);
            if (typecourse == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Course> course = db.Course.Where(n => n.TypeCourseID == MaKH).ToList();
            if (course.Count == 0)
            {
                ViewBag.Course = "Lỗi";
            }

            ViewBag.special_typecourse = db.Special_TypeCourse.Where(n => n.TypeCourseID == MaKH).ToList();
            return View(course);
        }
    }
}
