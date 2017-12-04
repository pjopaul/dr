using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DR.Data.Entities
{
    [DataContract]
    public abstract class EntityBase : IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
