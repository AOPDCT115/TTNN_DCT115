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
        public DbSet<Course> Course { get; set; }
        public DbSet<Special_TypeCourse> Special_TypeCourse { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Credential> Credential { get; set; }
        public DbSet<Feedback> Feedback { get; set; }

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