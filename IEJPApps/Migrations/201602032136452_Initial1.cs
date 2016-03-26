namespace IEJPApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.Employees", "Rate", c => c.Double(nullable: false));
        }
    }
}
