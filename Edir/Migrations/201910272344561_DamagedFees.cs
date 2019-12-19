namespace Edir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DamagedFees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "SmallDamageFee", c => c.Double(nullable: false));
            AddColumn("dbo.Items", "ReplacementFee", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ReplacementFee");
            DropColumn("dbo.Items", "SmallDamageFee");
        }
    }
}
