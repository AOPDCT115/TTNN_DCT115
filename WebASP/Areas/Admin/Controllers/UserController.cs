using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebASP.Models;
using System.Data;
using System.Web.Security;
using WebASP.DAO;
using WebASP.Common;

namespace WebASP.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
         [HasCredential(Roles = "VIEW_USER")]

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            return View();
        }

        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create(Student user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();

                var encryptedMd5Pas = Encryptor.MD5Hash(user.PassWord);
                user.PassWord = encryptedMd5Pas;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Index");
        }

        private void SetAlert(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(Student user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!string.IsNullOrEmpty(user.PassWord))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.PassWord);
                    user.PassWord = encryptedMd5Pas;
                }


                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View("Index");
        }

        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}