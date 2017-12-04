using DR.Data.Entities;
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
            //HasMany<LifeEvent>( le => le.)

        }
    }
}
