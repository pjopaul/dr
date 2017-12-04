using DR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Data.Configurations
{
    public class LifeEventsConfiguration : EntityTypeConfiguration<LifeEvent>
    {
        public LifeEventsConfiguration()
        {
            ToTable("LifeEvents");
            HasKey<int>(pk => pk.LifeEventId);
            Property(g => g.LifeEventTypeId).IsRequired();
            Property(g => g.EventDesc).HasMaxLength(255);

            Property(g => g.EventDateDay).IsRequired();
            Property(g => g.EventDateMonth).IsRequired();
            Property(g => g.EventDateYear).IsOptional();
            Property<DateTime>(g => g.CreatedDate).IsRequired();
            Property<DateTime>(g => g.LastUpdated).IsConcurrencyToken();


            HasRequired(p => p.CreatedByUser).WithMany(u => u.LifeEvents)
                              .HasForeignKey(fk => fk.CreatedByUserId);


            HasOptional<RelationshipGroup>(g => g.RelationshipGroup).WithMany(r => r.LifeEvents)
                 .HasForeignKey(fk => fk.RelationshipGroupId);

        }
    }
}
