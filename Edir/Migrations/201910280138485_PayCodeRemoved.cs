namespace Edir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PayCodeRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pays", "PaymentCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pays", "PaymentCode", c => c.Long(nullable: false));
        }
    }
}
