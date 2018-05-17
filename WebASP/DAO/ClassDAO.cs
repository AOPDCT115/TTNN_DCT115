using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.DAO
{
    public class ClassDAO
    {
        private DataVTT db = new DataVTT();
        public long Insert(Class entity)
        {
            db.Class.Add(entity);
            db.SaveChanges();
            return entity.ClassID;
        }
        public long InsertSch(Schedule entity)
        {
            db.Schedule.Add(entity);
            db.SaveChanges();
            return entity.ScheduleID;
        }
        public Class ViewDetail(int id)
        {
            return db.Class.Find(id);
        }
        public Schedule ViewDetailSch(int id)
        {
            return db.Schedule.Find(id);
        }
        public IEnumerable<Class> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Class> model = db.Class;
            try
            {
                var searchStrings = Convert.ToInt64(searchString);
                if (searchStrings != 0)
                {
                    model = model.Where(x => x.ClassID == searchStrings || x.CourseID == searchStrings);
                }
                return model.OrderByDescending(x => x.ClassID).ToPagedList(page, pageSize);
            }
            catch(Exception)
            {
                return model.OrderByDescending(x => x.ClassID).ToPagedList(page, pageSize);
            }
        }

        public IEnumerable<Schedule> ListAllPagingSch(string searchString, int page, int pageSize)
        {
            IQueryable<Schedule> model = db.Schedule;
            ;
            if (!string.IsNullOrEmpty(searchString))
            {
                var classstudentidd = Convert.ToInt64(searchString);
                model = model.Where(x =>x.Day.Contains(searchString)|| x.ClassID == classstudentidd);
            }
            
            return model.OrderByDescending(x => x.ClassID).ToPagedList(page, pageSize);
        }

        public bool Update(Class entity)
        {
            try
            {
                var ne = db.Class.Find(entity.ClassID);
                ne.CourseID = entity.CourseID;
                ne.Introduce = entity.Introduce;
                ne.NumOfMem = entity.NumOfMem;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
        public bool UpdateSch(Schedule entity)
        {
            try
            {
                var ne = db.Schedule.Find(entity.ScheduleID);
                ne.ClassID = entity.ClassID;
                ne.Week = entity.Week;
                ne.Day = entity.Day;
                ne.Dates = entity.Dates;
                ne.Times = entity.Times;

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
            var ne = db.Class.Find(id);
            ne.Status = !ne.Status;
            db.SaveChanges();
            return ne.Status;
        }
        public bool ChangeStatusSch(long id)
        {
            var ne = db.Schedule.Find(id);
            ne.Status = !ne.Status;
            db.SaveChanges();
            return ne.Status;
        }
        public bool ChangeStatusStudent(long id)
        {
            var ne = db.Student.Find(id);
            ne.Status = !ne.Status;
            db.SaveChanges();
            return ne.Status;
        }
    }
}