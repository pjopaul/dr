namespace DR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LifeEvents",
                c => new
                    {
                        LifeEventId = c.Int(nullable: false, identity: true),
                        LifeEventTypeId = c.Int(nullable: false),
                        RelationshipGroupId = c.Int(),
                        EventDesc = c.String(maxLength: 255),
                        EventDateDay = c.Int(nullable: false),
                        EventDateMonth = c.Int(nullable: false),
                        EventDateYear = c.Int(),
                        CreatedByUserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false,defaultValue:DateTime.UtcNow),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LifeEventId)
                .ForeignKey("dbo.Users", t => t.CreatedByUserId, cascadeDelete: true)
                .ForeignKey("dbo.RelationshipGroups", t => t.RelationshipGroupId)
                .Index(t => t.RelationshipGroupId)
                .Index(t => t.CreatedByUserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginName = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false,defaultValue:true),
                        UserRoleId = c.Int(nullable: false,defaultValue:1),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.RelationshipGroups",
                c => new
                    {
                        RelationshipGroupId = c.Int(nullable: false, identity: true),
                        GroupDesc = c.String(),
                        CreatedByUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelationshipGroupId)
                .ForeignKey("dbo.Users", t => t.CreatedByUserId, cascadeDelete: true)
                .Index(t => t.CreatedByUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LifeEvents", "RelationshipGroupId", "dbo.RelationshipGroups");
            DropForeignKey("dbo.LifeEvents", "CreatedByUserId", "dbo.Users");
            DropForeignKey("dbo.RelationshipGroups", "CreatedByUserId", "dbo.Users");
            DropIndex("dbo.RelationshipGroups", new[] { "CreatedByUserId" });
            DropIndex("dbo.LifeEvents", new[] { "CreatedByUserId" });
            DropIndex("dbo.LifeEvents", new[] { "RelationshipGroupId" });
            DropTable("dbo.RelationshipGroups");
            DropTable("dbo.Users");
            DropTable("dbo.LifeEvents");
        }
    }
}
