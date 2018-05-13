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
    public class ClassController : Controller
    {
        // GET: Admin/Class
        // GET: Admin/ChuongTrinhDaoTao
        private DataVTT db = new DataVTT();
        [HasCredential(Roles = "VIEW_USER")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ClassDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }
        [HasCredential(RoleID = "ADD_USER")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetViewBag(db.Class.Find(id).CourseID);
            return View(db.Class.Find(id));
        }

        public void SetViewBag(long? selectedId = null)
        {

            ViewBag.CourseAll = new SelectList(db.Course.ToList(), "CourseID", "Name", selectedId);
        }

        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create(Class ne)
        {
            if (ModelState.IsValid)
            {
                var dao = new ClassDAO();

                long id = dao.Insert(ne);

                if (id > 0)
                {
                    ModelState.AddModelError("Thêm thành công", "success");
                    return RedirectToAction("Index", "Class");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            SetViewBag();
            return View();
        }

        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(Class ne)
        {
            if (ModelState.IsValid)
            {
                var dao = new ClassDAO();

                var result = dao.Update(ne);
                if (result)
                {
                    ModelState.AddModelError("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "Class");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            SetViewBag(ne.CourseID);
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ClassDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }



        [HasCredential(Roles = "VIEW_USER")]
        public ActionResult LichHoc(int classid)
        {
            Class classi = db.Class.SingleOrDefault(n => n.ClassID == classid);
            if (classi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Schedule> schedule = db.Schedule.Where(n => n.ClassID == classid).ToList();
            ViewBag.sch = View(db.Schedule.Where(x=>x.ClassID == classid).ToList());
            return View(schedule);
        }

        public ActionResult LichHocAll(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ClassDAO();
            var model = dao.ListAllPagingSch(searchString, page, pageSize);

            ViewBag.SearchStringSch = searchString;

            return View(model);
        }

        [HasCredential(RoleID = "ADD_USER")]
        [HttpGet]
        public ActionResult EditSch(int id)
        {
            SetViewBagSch(db.Schedule.Find(id).ClassID);
            return View(db.Schedule.Find(id));
        }

        public void SetViewBagSch(long? selectedId = null)
        {

            ViewBag.ScheduleAll = new SelectList(db.Class.ToList(), "ClassID", "ClassID", selectedId);
        }

        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult CreateSch()
        {
            SetViewBagSch();
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult CreateSch(Schedule ne)
        {
            if (ModelState.IsValid)
            {
                var dao = new ClassDAO();

                long id = dao.InsertSch(ne);

                if (id > 0)
                {
                    ModelState.AddModelError("Thêm thành công", "success");
                    return RedirectToAction("LichHoc", "Class");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            SetViewBagSch();
            return View();
        }

        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult EditSch(Schedule ne)
        {
            if (ModelState.IsValid)
            {
                var dao = new ClassDAO();

                var result = dao.UpdateSch(ne);
                if (result)
                {
                    ModelState.AddModelError("Cập nhật thành công", "success");
                    return RedirectToAction("LichHoc", "Class");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            SetViewBagSch(ne.ClassID);
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatusSch(long id)
        {
            var result = new ClassDAO().ChangeStatusSch(id);
            return Json(new
            {
                status = result
            });
        }
    }
}