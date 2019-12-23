namespace Edir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class single_price_for_purchased_item : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "SinglePrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "SinglePrice");
        }
    }
}
