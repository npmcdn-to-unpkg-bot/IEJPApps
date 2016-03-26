namespace IEJPApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
