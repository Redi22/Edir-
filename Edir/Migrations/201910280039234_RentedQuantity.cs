namespace Edir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentedQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Quantity", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "Quantity");
        }
    }
}
