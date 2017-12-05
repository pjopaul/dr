using DR.Core.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DR.Core.Entities
{
    [DataContract]
    public class RelationshipGroup : EntityBase, IEntityId
    {
        [DataMember]
        public int RelationshipGroupId { get; set; }
        [DataMember]
        public string GroupDesc { get; set; }
        [DataMember]
        public int CreatedByUserId { get; set; }
        [DataMember]
        public virtual User CreatedByUser { get; set; }

        public ICollection<LifeEvent> LifeEvents { get; set; }

        int IEntityId.EntityId
        {
            get { return RelationshipGroupId; }
            set { RelationshipGroupId = value; }
        }
    }
}
