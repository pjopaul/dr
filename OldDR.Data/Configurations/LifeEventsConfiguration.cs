using DR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Data.Configurations
{
    public class LifeEventsConfiguration: EntityTypeConfiguration<LifeEvent>
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
            //Property(g => g.CreatedByUserId).IsRequired();
            //Property(g => g.RelationshipGroupId).IsOptional();
            Property<DateTime>(g => g.LastUpdated).IsConcurrencyToken();

            HasOptional(rg => rg.RelationshipGroup).WithOptionalDependent();
            HasRequired(u => u.CreatedByUser).WithRequiredDependent();

            //HasRequired(u => u.CreatedByUser);


        }
    }
}
