using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Core.DTO
{
    public class LifeEvent
    {

        public int LifeEventId { get; set; }

        public int LifeEventTypeId { get; set; }
        public string LifeEventTypeDesc { get; set; }
        
        public int RelationshipGroupId { get; set; }
        public string RelationshipGroupDesc { get; set; }

        public string EventDesc { get; set; }

        public int EventDateDay { get; set; }
        public int EventDateMonth { get; set; }
        public int? EventDateYear { get; set; }


        public int CreatedByUserId { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }

        public LifeEvent()
        {

        }


    }
}
