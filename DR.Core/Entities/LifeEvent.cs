﻿using DR.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DR.Core.Entities
{

    [DataContract]
    public enum LifeEventType
    {
        BIRTHDAY = 1,
        MARRIAGE,
        DEATH
    }

    [DataContract]
    public class LifeEvent : EntityBase, IEntityId
    {
        [DataMember]
        public int LifeEventId { get; set; }

        [DataMember]
        public LifeEventType LifeEventTypeId { get; set; }

        [DataMember]
        public int? RelationshipGroupId { get; set; }
        [DataMember]
        public RelationshipGroup RelationshipGroup { get; set; }

        [DataMember]
        public string EventDesc { get; set; }
        [DataMember]
        public int EventDateDay { get; set; }
        [DataMember]
        public int EventDateMonth { get; set; }
        [DataMember]
        public int? EventDateYear { get; set; }

       
        int IEntityId.EntityId
        {
            get { return LifeEventId; }
            set { LifeEventId = value; }
        }


    }
}
