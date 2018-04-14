using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebASP.Models;

namespace WebASP.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<TypeCourse> TypeCourse { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    modelBuilder.Entity<Course>()
        //        .HasMany(c => c.Instructors).WithMany(i => i.Courses)
        //        .Map(t => t.MapLeftKey("CourseID")
        //            .MapRightKey("InstructorID")
        //            .ToTable("CourseInstructor"));

        //    modelBuilder.Entity<Department>().MapToStoredProcedures();
        //}
    }
}