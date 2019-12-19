namespace Edir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Defaults : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "DefaultFirstFin", c => c.Double(nullable: false));
            AddColumn("dbo.Abouts", "DefaultSecondFin", c => c.Double(nullable: false));
            AddColumn("dbo.Abouts", "DefaultFinalFin", c => c.Double(nullable: false));
            AddColumn("dbo.Abouts", "DefaultEventFin", c => c.Double(nullable: false));
            AddColumn("dbo.Abouts", "CustomSubcity", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "CustomSubcity");
            DropColumn("dbo.Abouts", "DefaultEventFin");
            DropColumn("dbo.Abouts", "DefaultFinalFin");
            DropColumn("dbo.Abouts", "DefaultSecondFin");
            DropColumn("dbo.Abouts", "DefaultFirstFin");
        }
    }
}
