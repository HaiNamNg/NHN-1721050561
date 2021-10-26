namespace NHN1721050561.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Person : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonID = c.String(nullable: false, maxLength: 20),
                        PersonName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PersonID);
            
            DropTable("dbo.Student");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            DropTable("dbo.Person");
        }
    }
}
