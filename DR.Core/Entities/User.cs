using DR.Core.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public bool IsActive { get; set; } = true;
        [DataMember]
        public UserRole UserRoleId { get; set; } = UserRole.User;

        public ICollection<LifeEvent> LifeEvents { get; set; } = new Collection<LifeEvent>();
        public ICollection<RelationshipGroup> RelationshipGroups { get; set; } = new Collection<RelationshipGroup>();

        public User()
        {
            
        }
        int IEntityId.EntityId
        {
            get { return UserId; }
            set { UserId = value; }
        }
    }
}
