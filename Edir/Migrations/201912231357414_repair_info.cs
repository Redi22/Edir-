namespace Edir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repair_info : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DamagedGoods", "IsRepaired", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DamagedGoods", "IsRepaired");
        }
    }
}
