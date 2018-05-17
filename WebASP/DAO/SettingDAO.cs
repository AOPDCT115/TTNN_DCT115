using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebASP.DAL;
using WebASP.Models;

namespace WebASP.DAO
{
    public class SettingDAO
    {
        private DataVTT db = new DataVTT();
        public long Insert(Menu entity)
        {
            db.Menu.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Menu ViewDetail(int id)
        {
            return db.Menu.Find(id);
        }
        public bool Update(Menu entity)
        {
            try
            {
                var ne = db.Menu.Find(entity.ID);
                ne.Target = entity.Target;
                ne.Link = entity.Link;
                ne.Child = entity.Child;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }

    }
}