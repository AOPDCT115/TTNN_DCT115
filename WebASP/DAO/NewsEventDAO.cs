using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.DAO
{
    public class NewsEventDAO
    {
        private DataVTT db = new DataVTT();
        public long Insert(NewsEvents entity)
        {
            db.NewsEvents.Add(entity);
            db.SaveChanges();
            return entity.NewsEventsID;
        }
        public NewsEvents ViewDetail(int id)
        {
            return db.NewsEvents.Find(id);
        }
        public IEnumerable<NewsEvents> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<NewsEvents> model = db.NewsEvents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString) || x.Content.Contains(searchString));
            }

            return model.OrderByDescending(x => x.NewsEventsID).ToPagedList(page, pageSize);
        }
        public bool Update(NewsEvents entity)
        {
            try
            {
                var ne = db.NewsEvents.Find(entity.NewsEventsID);
                ne.Type = entity.Type;
                ne.Title = entity.Title;
                ne.Content = entity.Content;
                ne.TypeCourseID = entity.TypeCourseID;
                ne.UrlImg = entity.UrlImg;
                ne.CreatedDate = entity.CreatedDate;
                ne.MetaKeywords = entity.MetaKeywords;

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
            var ne = db.NewsEvents.Find(id);
            ne.Status = !ne.Status;
            db.SaveChanges();
            return ne.Status;
        }
    }
}