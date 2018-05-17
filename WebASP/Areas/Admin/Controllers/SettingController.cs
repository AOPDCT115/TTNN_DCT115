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
    public class SettingController : Controller
    {
        // GET: Admin/SpamEmail
        // GET: Admin/Class
        private DataVTT db = new DataVTT();
        [HasCredential(Roles = "VIEW_USER")]
        public ActionResult Index()
        {
            var dao = new SettingDAO();

            return View(db.Menu.ToList());
        }
        [HasCredential(RoleID = "ADD_USER")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Menu.Find(id));
        }

        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create(Menu ne)
        {
            if (ModelState.IsValid)
            {
                var dao = new SettingDAO();

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
            return View();
        }

        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(Menu ne)
        {
            if (ModelState.IsValid)
            {
                var dao = new SettingDAO();

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
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View(db.Menu.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu personalDetail = db.Menu.Find(id);
            db.Menu.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}