using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebASP.Models;

namespace WebASP.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            
        }
    }
}