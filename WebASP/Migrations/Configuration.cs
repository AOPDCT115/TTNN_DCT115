namespace WebASP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebASP.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebASP.DAL.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "WebASP.DAL.DataContext";
        }

        protected override void Seed(WebASP.DAL.DataContext context)
        {
            
        }
    }
}
