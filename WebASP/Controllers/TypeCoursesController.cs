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



    }
}
