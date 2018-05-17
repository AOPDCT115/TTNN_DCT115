using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP.Common;
using WebASP.DAL;
using WebASP.DAO;
using WebASP.Models;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PagedList;

namespace WebASP.Areas.Admin.Controllers
{
    public class ClassController : Controller
    {
        // GET: Admin/Class

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

        public ActionResult LichHoc(int classid)
        {
            Class classi = db.Class.SingleOrDefault(n => n.ClassID == classid);
            if (classi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.ClassIDStudent = classid;
            List<Schedule> schedule = db.Schedule.Where(n => n.ClassID == classid).ToList();
            ViewBag.sch = View(db.Schedule.Where(x=>x.ClassID == classid).ToList());
            return View(schedule);
        }

        

        [HasCredential(Roles = "VIEW_USER")]
        public ActionResult ShowStudent(string classstudentid, string searchString)
        {
            
                var classstudentidd = Convert.ToInt64(classstudentid);
                ViewBag.ClassStudentid = classstudentid;
                if (string.IsNullOrEmpty(searchString) || searchString == "")
                {
                
                    var studentshow = (from a in db.Register
                                       join b in db.Student
                                       on a.StudentID equals b.StudentID
                                       where a.ClassID == classstudentidd
                                       select new
                                       {
                                           ClassID = a.ClassID,
                                           StudentID = b.StudentID,
                                           Name = b.Name,
                                           CreatedDate = b.CreatedDate,
                                           Address = b.Address,
                                           Gender = b.Gender,
                                           Mail = b.Mail,
                                           Phone = b.Phone,
                                           Status = b.Status

                                       }).AsEnumerable().Select(x => new StudentNew()
                                       {
                                           ClassID = x.ClassID,
                                           StudentID = x.StudentID,
                                           Name = x.Name,
                                           CreatedDate = x.CreatedDate,
                                           Address = x.Address,
                                           Gender = x.Gender,
                                           Mail = x.Mail,
                                           Phone = x.Phone,
                                           Status = x.Status
                                       });

                ViewBag.SearchStringSch = searchString;
                return View(studentshow);
                }
                else
                {
                    var studentshow = (from a in db.Register
                                       join b in db.Student
                                       on a.StudentID equals b.StudentID
                                       where a.ClassID == classstudentidd && b.Name.Contains(searchString)
                                       select new
                                       {
                                           ClassID = a.ClassID,
                                           StudentID = b.StudentID,
                                           Name = b.Name,
                                           CreatedDate = b.CreatedDate,
                                           Address = b.Address,
                                           Gender = b.Gender,
                                           Mail = b.Mail,
                                           Phone = b.Phone,
                                           Status = b.Status

                                       }).AsEnumerable().Select(x => new StudentNew()
                                       {
                                           ClassID = x.ClassID,
                                           StudentID = x.StudentID,
                                           Name = x.Name,
                                           CreatedDate = x.CreatedDate,
                                           Address = x.Address,
                                           Gender = x.Gender,
                                           Mail = x.Mail,
                                           Phone = x.Phone,
                                           Status = x.Status
                                       });

                    ViewBag.SearchStringSch = searchString;
                    return View(studentshow);
                }
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
                    return RedirectToAction("LichHoc", "Class", new { @classid = ne.ClassID });
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
                    return RedirectToAction("LichHoc", "Class", new { @classid = ne.ClassID });
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            //SetViewBagSch(ne.ClassID);
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
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatusShowStudent(long id)
        {
            var result = new ClassDAO().ChangeStatusStudent(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(db.Student.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student personalDetail = db.Student.Find(id);
            db.Student.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("IndexSpecial");
        }
    }
}