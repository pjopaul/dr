using DR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DR.Data.Configurations
{
    public class RelationshipGroupsConfiguration: EntityTypeConfiguration<RelationshipGroup>
    {
        public RelationshipGroupsConfiguration()
        {
            ToTable("RelationshipGroups");
            HasKey(pk => pk.RelationshipGroupId);
            Property(g => g.Version).IsConcurrencyToken();
            HasRequired(p => p.CreatedByUser).WithMany(u => u.RelationshipGroups)
                              .HasForeignKey(fk => fk.CreatedByUserId);

        }
    }
}
