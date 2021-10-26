namespace NHN1721050561.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Lecture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Faculty", c => c.String(maxLength: 50));
            AddColumn("dbo.Person", "Department", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Department");
            DropColumn("dbo.Person", "Faculty");
        }
    }
}
