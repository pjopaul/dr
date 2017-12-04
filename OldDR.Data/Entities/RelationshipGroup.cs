using DR.Core.Abstract;
using System.Runtime.Serialization;

namespace DR.Data.Entities
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


        int IEntityId.EntityId
        {
            get { return RelationshipGroupId; }
            set { RelationshipGroupId = value; }
        }
    }
}
