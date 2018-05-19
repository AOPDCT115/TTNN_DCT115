using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP.Common;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.Controllers
{
    public class LichHocUserController : Controller
    {
        private DataVTT db = new DataVTT();
        

        public ActionResult XemmThoiKhoaBieu()
        {
            var std = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (std != null)
            {
                var id = std.UserID;

                var schedule = from a in db.Register
                               join b in db.Class on a.ClassID equals b.ClassID
                               join c in db.Schedule on b.ClassID equals c.ClassID
                               where a.StudentID == id
                               select c;


                var model = schedule.ToList();
                ViewBag.schedule = schedule.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Index","LichHoc"); 
            }
        }
    }
}
            

           

    
