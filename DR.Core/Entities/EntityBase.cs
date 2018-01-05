using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DR.Core.Entities
{
    [DataContract]
    public abstract class EntityBase : IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }

        
        public byte[] Version { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [DataMember]
        public int CreatedByUserId { get; set; }
        [DataMember]
        public virtual User CreatedByUser { get; set; }

        public EntityBase()
        {
            
            this.CreatedDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
            this.IsActive = true;
            this.IsDeleted = false;
        }

    }
}
