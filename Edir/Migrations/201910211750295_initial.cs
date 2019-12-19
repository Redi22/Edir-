namespace Edir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EdirName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Capital = c.Double(nullable: false),
                        Description = c.String(),
                        PayMemberDeseced = c.Double(nullable: false),
                        PayChildDeseced = c.Double(nullable: false),
                        PaySiblingDeseced = c.Double(nullable: false),
                        PayParentDeseced = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attendaces",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EventId = c.Long(nullable: false),
                        MemberId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EdirEvents", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.EdirEvents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Place = c.String(),
                        date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Fin = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MotherName = c.String(),
                        Gender = c.String(),
                        MariageStatus = c.Boolean(nullable: false),
                        SubCity = c.String(),
                        Woreda = c.Long(nullable: false),
                        Kebele = c.Long(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        HouseNummber = c.String(),
                        Debit = c.Double(nullable: false),
                        RegisteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Long(nullable: false),
                        ParentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Siblings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Long(nullable: false),
                        ParentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.SpouseSiblings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Long(nullable: false),
                        ParentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.DamagedGoods",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ItemId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        RepairType = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        PurchasedDate = c.DateTime(nullable: false),
                        DailyPayment = c.Double(nullable: false),
                        DamageFee = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        RentedQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentedDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        Damaged = c.Boolean(nullable: false),
                        TotalPayment = c.Double(nullable: false),
                        ItemId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Losses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        PaidMoney = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ParentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Pays",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MemberId = c.Long(nullable: false),
                        PaymentCode = c.Long(nullable: false),
                        Amount = c.Double(nullable: false),
                        PaidDate = c.DateTime(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        EventPrivilage = c.Boolean(nullable: false),
                        MemberPrivilage = c.Boolean(nullable: false),
                        StorePrivilage = c.Boolean(nullable: false),
                        PaymentPrivilage = c.Boolean(nullable: false),
                        RulePrivilage = c.Boolean(nullable: false),
                        SuperAdminPrivilage = c.Boolean(nullable: false),
                        RoleCreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        FirstFin = c.Double(nullable: false),
                        SecondFin = c.Double(nullable: false),
                        LastFin = c.Double(nullable: false),
                        RuleRegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Violations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RuleId = c.Long(nullable: false),
                        MemberId = c.Long(nullable: false),
                        Description = c.String(),
                        ReportDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Rules", t => t.RuleId, cascadeDelete: true)
                .Index(t => t.RuleId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Spouses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        ParentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RoleId = c.Long(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        AdminUpgradeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Spouses", "ParentId", "dbo.Members");
            DropForeignKey("dbo.Violations", "RuleId", "dbo.Rules");
            DropForeignKey("dbo.Violations", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Pays", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Losses", "ParentId", "dbo.Members");
            DropForeignKey("dbo.Rentals", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Attendaces", "MemberId", "dbo.Members");
            DropForeignKey("dbo.SpouseSiblings", "ParentId", "dbo.Members");
            DropForeignKey("dbo.Siblings", "ParentId", "dbo.Members");
            DropForeignKey("dbo.Children", "ParentId", "dbo.Members");
            DropForeignKey("dbo.Attendaces", "EventId", "dbo.EdirEvents");
            DropIndex("dbo.UserAccounts", new[] { "RoleId" });
            DropIndex("dbo.Spouses", new[] { "ParentId" });
            DropIndex("dbo.Violations", new[] { "MemberId" });
            DropIndex("dbo.Violations", new[] { "RuleId" });
            DropIndex("dbo.Pays", new[] { "MemberId" });
            DropIndex("dbo.Losses", new[] { "ParentId" });
            DropIndex("dbo.Rentals", new[] { "ItemId" });
            DropIndex("dbo.SpouseSiblings", new[] { "ParentId" });
            DropIndex("dbo.Siblings", new[] { "ParentId" });
            DropIndex("dbo.Children", new[] { "ParentId" });
            DropIndex("dbo.Attendaces", new[] { "MemberId" });
            DropIndex("dbo.Attendaces", new[] { "EventId" });
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Spouses");
            DropTable("dbo.Violations");
            DropTable("dbo.Rules");
            DropTable("dbo.Roles");
            DropTable("dbo.Pays");
            DropTable("dbo.Losses");
            DropTable("dbo.Rentals");
            DropTable("dbo.Items");
            DropTable("dbo.DamagedGoods");
            DropTable("dbo.SpouseSiblings");
            DropTable("dbo.Siblings");
            DropTable("dbo.Children");
            DropTable("dbo.Members");
            DropTable("dbo.EdirEvents");
            DropTable("dbo.Attendaces");
            DropTable("dbo.Abouts");
        }
    }
}
