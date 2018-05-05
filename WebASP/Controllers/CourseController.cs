using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.Controllers
{
    public class CourseController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult XemThem(int MaKH)
        {
            Course course = db.Course.SingleOrDefault(n => n.CourseID == MaKH);
            if (course == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(course);
        }

    }
}