namespace DR.Data.Migrations
{
    using DR.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LifeEventsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DR.Data.LifeEventsDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(
               new User() {UserId=1, LoginName = "Admin", Password = "admin", UserRoleId = UserRole.Admin,IsActive = true ,
                            RelationshipGroups=new List<RelationshipGroup>() {
                       new RelationshipGroup(){RelationshipGroupId=1, GroupDesc="Friends",CreatedByUserId =1 },
                       new RelationshipGroup(){RelationshipGroupId=2, GroupDesc="Family",CreatedByUserId =1 },
                       new RelationshipGroup(){RelationshipGroupId=3, GroupDesc="Cousins",CreatedByUserId =1 },
                       new RelationshipGroup(){RelationshipGroupId=4, GroupDesc="Work",CreatedByUserId =1 },
                       new RelationshipGroup(){RelationshipGroupId=5, GroupDesc="School",CreatedByUserId =1 },
                       new RelationshipGroup(){RelationshipGroupId=6, GroupDesc="College",CreatedByUserId =1 }
                   }
               },
               new User() { UserId = 2, LoginName = "User", Password = "user", UserRoleId = UserRole.User, IsActive = true }

               );

        }
    }
}
