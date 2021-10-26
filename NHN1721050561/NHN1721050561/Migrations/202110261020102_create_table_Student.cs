namespace NHN1721050561.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Student : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "University", c => c.String(maxLength: 50));
            AddColumn("dbo.Person", "Address", c => c.String(maxLength: 50));
            AddColumn("dbo.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Discriminator");
            DropColumn("dbo.Person", "Address");
            DropColumn("dbo.Person", "University");
        }
    }
}
