namespace DR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeSchemaChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LifeEvents", "Version", c => c.Binary());
            AddColumn("dbo.LifeEvents", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.LifeEvents", "DeletedDate", c => c.DateTime());
            AddColumn("dbo.LifeEvents", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.LifeEvents", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Version", c => c.Binary());
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Users", "DeletedDate", c => c.DateTime());
            AddColumn("dbo.Users", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "CreatedByUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CreatedByUser_UserId", c => c.Int());
            AddColumn("dbo.RelationshipGroups", "Version", c => c.Binary());
            AddColumn("dbo.RelationshipGroups", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RelationshipGroups", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.RelationshipGroups", "DeletedDate", c => c.DateTime());
            AddColumn("dbo.RelationshipGroups", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.RelationshipGroups", "IsDeleted", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Users", "CreatedByUser_UserId");
            AddForeignKey("dbo.Users", "CreatedByUser_UserId", "dbo.Users", "UserId");
            DropColumn("dbo.LifeEvents", "LastUpdated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LifeEvents", "LastUpdated", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Users", "CreatedByUser_UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "CreatedByUser_UserId" });
            DropColumn("dbo.RelationshipGroups", "IsDeleted");
            DropColumn("dbo.RelationshipGroups", "IsActive");
            DropColumn("dbo.RelationshipGroups", "DeletedDate");
            DropColumn("dbo.RelationshipGroups", "ModifiedDate");
            DropColumn("dbo.RelationshipGroups", "CreatedDate");
            DropColumn("dbo.RelationshipGroups", "Version");
            DropColumn("dbo.Users", "CreatedByUser_UserId");
            DropColumn("dbo.Users", "CreatedByUserId");
            DropColumn("dbo.Users", "IsDeleted");
            DropColumn("dbo.Users", "DeletedDate");
            DropColumn("dbo.Users", "ModifiedDate");
            DropColumn("dbo.Users", "CreatedDate");
            DropColumn("dbo.Users", "Version");
            DropColumn("dbo.LifeEvents", "IsDeleted");
            DropColumn("dbo.LifeEvents", "IsActive");
            DropColumn("dbo.LifeEvents", "DeletedDate");
            DropColumn("dbo.LifeEvents", "ModifiedDate");
            DropColumn("dbo.LifeEvents", "Version");
        }
    }
}
