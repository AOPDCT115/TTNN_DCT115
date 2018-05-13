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
    public class ChuongTrinhDaoTaoController : Controller
    {
        // GET: Admin/ChuongTrinhDaoTao
        private DataVTT db = new DataVTT();
        [HasCredential(Roles = "VIEW_USER")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ChuongTrinhDaoTaoDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }
        [HasCredential(RoleID = "ADD_USER")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetViewBag(db.Course.Find(id).TypeCourseID);
            return View(db.Course.Find(id));
        }

        public void SetViewBag(long? selectedId = null)
        {
            ViewBag.TypeCourse = new SelectList(db.TypeCourse.Where(x=>x.TypeCourseID == selectedId).ToList(), "TypeCourseID", "TypeName", selectedId);

            ViewBag.TypeCourseAll = new SelectList(db.TypeCourse.ToList(), "TypeCourseID", "TypeName", selectedId);
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
        public ActionResult Create(Course ne)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChuongTrinhDaoTaoDAO();

                long id = dao.Insert(ne);
                if (id > 0)
                {
                    ModelState.AddModelError("Thêm thành công", "success");
                    return RedirectToAction("Index", "ChuongTrinhDaoTao");
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
        public ActionResult Edit(Course ne)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChuongTrinhDaoTaoDAO();

                var result = dao.Update(ne);
                if (result)
                {
                    ModelState.AddModelError("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "ChuongTrinhDaoTao");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            SetViewBag(ne.TypeCourseID);
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ChuongTrinhDaoTaoDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}