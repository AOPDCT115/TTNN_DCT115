using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.DAO
{
    public class FeedbackDAO
    {
        private DataVTT db = new DataVTT();
        
        public Feedback ViewDetail(int id)
        {
            return db.Feedback.Find(id);
        }
        public IEnumerable<Feedback> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Feedback> model = db.Feedback;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Email.Contains(searchString) || x.Phone.Contains(searchString));
            }

            return model.OrderByDescending(x => x.FeedbackID).ToPagedList(page, pageSize);
        }
        public bool Update(Feedback entity)
        {
            try
            {
                var ne = db.Feedback.Find(entity.FeedbackID);
                ne.Status = !entity.Status;

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
            var ne = db.Feedback.Find(id);
            ne.Status = !ne.Status;
            db.SaveChanges();
            return ne.Status;
        }
    }
}