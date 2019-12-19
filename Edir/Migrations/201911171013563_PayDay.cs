namespace Edir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PayDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "PayDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "PayDate");
        }
    }
}
