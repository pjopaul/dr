using DR.Core.Abstract;
using DR.Core.Entities;
using DR.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DR.Data
{
    public class LifeEventsDBContext : DbContext
    {
        public LifeEventsDBContext() : base("name=LifeEventsDB")
        {
            //Uncomment the below line only if DB already created and EF don't want to create one
            //Database.SetInitializer<LifeEventsDBContext>(null);

           // Database.SetInitializer<LifeEventsDBContext>(new LifeEventsMasterData());
        }



        public DbSet<RelationshipGroup> RelationshipGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LifeEvent> LifeEvents { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove()

            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IEntityId>();


            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RelationshipGroupsConfiguration());
            modelBuilder.Configurations.Add(new LifeEventsConfiguration());
        }
    }
}
