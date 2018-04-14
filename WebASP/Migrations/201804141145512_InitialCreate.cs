namespace WebASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeCourses",
                c => new
                    {
                        TypeCourseID = c.String(nullable: false, maxLength: 128),
                        TypeName = c.String(),
                        Introduce = c.String(),
                        UrlImg = c.String(),
                    })
                .PrimaryKey(t => t.TypeCourseID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypeCourses");
        }
    }
}
