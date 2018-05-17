using System;
using System.Collections.Generic;
using System.Configuration;
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

        [HttpGet]
        public ActionResult Edit(int id)
        {

            return View(db.Feedback.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Feedback ne)
        {
            try
            {
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/Client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", ne.Name);
                content = content.Replace("{{Phone}}", ne.Phone);
                content = content.Replace("{{Email}}", ne.Email);
                content = content.Replace("{{Text}}", ne.Text);
                content = content.Replace("{{Rely}}", ne.Reply);
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(ne.Email, "Trả lời phản hồi", content);

                var dao = new FeedbackDAO();
                var feedback = db.Feedback.Find(ne.FeedbackID);
                ne.Status = !ne.Status;
                db.SaveChanges();
                
            }
            catch(Exception)
            {
                return Redirect("/a");
            }
            return RedirectToAction("Index", "FeedBack");
        }

        [HttpPost]
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