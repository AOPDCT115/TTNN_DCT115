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
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ChuongTrinhDaoTaoDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        public ActionResult IndexSpecial(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ChuongTrinhDaoTaoDAO();
            var model = dao.ListAllPagingSpecial(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetViewBag(db.Course.Find(id).TypeCourseID);
            return View(db.Course.Find(id));
        }
        [HttpGet]
        public ActionResult EditSpecial(int id)
        {
            SetViewBagSpecial(db.Special_TypeCourse.Find(id).TypeCourseID);
            return View(db.Special_TypeCourse.Find(id));
        }

        public void SetViewBag(long? selectedId = null)
        {
            ViewBag.TypeCourse = new SelectList(db.TypeCourse.Where(x=>x.TypeCourseID == selectedId).ToList(), "TypeCourseID", "TypeName", selectedId);

            ViewBag.TypeCourseAll = new SelectList(db.TypeCourse.ToList(), "TypeCourseID", "TypeName", selectedId);
        }
        public void SetViewBagSpecial(long? selectedId = null)
        {
            ViewBag.specialTypeCourseAll = new SelectList(db.TypeCourse.ToList(), "TypeCourseID", "TypeName", selectedId);
        }

        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult CreateSpecial()
        {
            SetViewBagSpecial();
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
        public ActionResult CreateSpecial(Special_TypeCourse ne)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChuongTrinhDaoTaoDAO();

                long id = dao.InsertSpecial(ne);
                if (id > 0)
                {
                    ModelState.AddModelError("Thêm thành công", "success");
                    return RedirectToAction("IndexSpecial", "ChuongTrinhDaoTao");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            SetViewBagSpecial();
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
        public ActionResult EditSpecial(Special_TypeCourse ne)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChuongTrinhDaoTaoDAO();

                var result = dao.UpdateSpeciall(ne);
                if (result)
                {
                    ModelState.AddModelError("Cập nhật thành công", "success");
                    return RedirectToAction("IndexSpecial", "ChuongTrinhDaoTao");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            SetViewBagSpecial(ne.TypeCourseID);
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            SetViewBagSpecial(db.Special_TypeCourse.Find(id).TypeCourseID);
            return View(db.Special_TypeCourse.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Special_TypeCourse personalDetail = db.Special_TypeCourse.Find(id);
            db.Special_TypeCourse.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("IndexSpecial");
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