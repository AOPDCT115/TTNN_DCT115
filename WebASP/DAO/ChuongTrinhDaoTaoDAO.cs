using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.DAO
{
    public class ChuongTrinhDaoTaoDAO
    {
        private DataVTT db = new DataVTT();
        public long Insert(Course entity)
        {
            db.Course.Add(entity);
            db.SaveChanges();
            return entity.CourseID;
        }
        public Course ViewDetail(int id)
        {
            return db.Course.Find(id);
        }
        public IEnumerable<Course> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Course> model = db.Course;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.DateStart).ToPagedList(page, pageSize);
        }
        public bool Update(Course entity)
        {
            try
            {
                var ne = db.Course.Find(entity.CourseID);
                ne.Name = entity.Name;
                ne.TypeCourseID = entity.TypeCourseID;
                ne.Introduce = entity.Introduce;
                ne.Price = entity.Price;
                ne.UrlImg = entity.UrlImg;
                ne.SaleID = entity.SaleID;
                ne.NumofLesson = entity.NumofLesson;
                ne.DateStart = entity.DateStart;
                ne.DateFinish = entity.DateFinish;

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
            var ne = db.Course.Find(id);
            ne.Available = !ne.Available;
            db.SaveChanges();
            return ne.Available;
        }
    }
}