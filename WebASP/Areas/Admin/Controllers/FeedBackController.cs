using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP.Common;
using WebASP.DAL;
using WebASP.DAO;
using WebASP.Models;

namespace WebASP.Areas.Admin.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: Admin/FeedBack
        private DataVTT db = new DataVTT();
        [HasCredential(Roles = "VIEW_USER")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new FeedbackDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }
        [HasCredential(RoleID = "ADD_USER")]
        [HttpGet]
        public ActionResult Edit(int id)
        {

            return View(db.NewsEvents.Find(id));
        }

        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        //public ActionResult Edit(Feedback ne)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new FeedbackDAO();

        //        dao.SendMail(ne.Email, ne.Name, ne.Reply);
        //        if (result)
        //        {
        //            ModelState.AddModelError("Gửi thành công", "success");
        //            return RedirectToAction("Index", "Feedback");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Gửi không thành công");
        //        }
        //    }

        //    return View();
        //}
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new FeedbackDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}