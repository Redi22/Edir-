namespace Edir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PayAttendance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "MonthlyPayment", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "MonthlyPayment");
        }
    }
}
