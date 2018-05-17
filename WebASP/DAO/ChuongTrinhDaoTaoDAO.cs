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

        public long InsertSpecial(Special_TypeCourse entity)
        {
            db.Special_TypeCourse.Add(entity);
            db.SaveChanges();
            return entity.SpecialID;
        }

        public Course ViewDetail(int id)
        {
            return db.Course.Find(id);
        }

        public Special_TypeCourse ViewDetailSpecial(int id)
        {
            return db.Special_TypeCourse.Find(id);
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

        public IEnumerable<Special_TypeCourse> ListAllPagingSpecial(string searchString, int page, int pageSize)
        {
            IQueryable<Special_TypeCourse> model = db.Special_TypeCourse;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.SpecialName.Contains(searchString));
            }

            return model.OrderByDescending(x => x.TypeCourseID).ToPagedList(page, pageSize);
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
        public bool UpdateSpeciall(Special_TypeCourse entity)
        {
            try
            {
                var ne = db.Special_TypeCourse.Find(entity.SpecialID);
                ne.TypeCourseID = entity.TypeCourseID;
                ne.SpecialName = entity.SpecialName;
                ne.Content = entity.Content;
                ne.UrlImg = entity.UrlImg;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
        public bool DeleteSpecial(Special_TypeCourse entity)
        {
            try
            {
                var ne = db.Special_TypeCourse.Find(entity.SpecialID);

                db.Special_TypeCourse.Remove(ne);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
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