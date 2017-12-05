using DR.Core.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DR.Core.Entities
{
    [DataContract]
    public enum UserRole
    {
        Admin = 1,
        User
    }

    [DataContract]
    public class User : EntityBase, IEntityId
    {

        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string LoginName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public UserRole UserRoleId { get; set; }

        public ICollection<LifeEvent> LifeEvents { get; set; }
        public ICollection<RelationshipGroup> RelationshipGroups { get; set; }

        int IEntityId.EntityId
        {
            get { return UserId; }
            set { UserId = value; }
        }
    }
}
