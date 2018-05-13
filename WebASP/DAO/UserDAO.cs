using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebASP.Common;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.DAO
{
    public class UserDAO
    {
        private DataVTT db = new DataVTT();
        public long Insert(Student entity)
        {
            db.Student.Add(entity);
            db.SaveChanges();
            return entity.StudentID;
        }
        public Student ViewDetail(int id)
        {
            return db.Student.Find(id);
        }
        public IEnumerable<Student> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Student> model = db.Student;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.Student.Single(x => x.UserName == userName);
            var data = (from a in db.Credential
                        join b in db.UserGroup on a.UserGroupID equals b.ID
                        join c in db.Role on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.Student.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstantsG.ADMIN_GROUP || result.GroupID == CommonConstantsG.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.PassWord == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.PassWord == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }
        public Student GetById(string userName)
        {
            return db.Student.SingleOrDefault(x => x.UserName == userName);
        }
        public bool CheckUserName(string userName)
        {
            return db.Student.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Student.Count(x => x.Mail == email) > 0;
        }
        public bool CheckPhone(string phone)
        {
            return db.Student.Count(x => x.Phone == phone) > 0;
        }
        public long InsertStudent(Student entity)
        {
            db.Student.Add(entity);
            db.SaveChanges();
            return entity.StudentID;
        }
        public bool Update(Student entity)
        {
            try
            {
                var user = db.Student.Find(entity.StudentID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.PassWord))
                {
                    user.PassWord = entity.PassWord;
                }
                user.Address = entity.Address;
                user.Mail = entity.Mail;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
        public bool ChangeStatus(long id)
        {
            var user = db.Student.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
    }
}