using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChilliSoftMeetingManagement.Models
{
    public class MeetingTypeItemModel
    {
        public Guid MeetingTypeId { get; set; }
        public Guid MeetingItemId { get; set; }
        public Guid MeetingId { get; set; }

        public virtual MeetingModel MeetingModel { get; set; }
        public virtual MeetingItemModel MeetingItemModel { get; set; }
        public virtual MeetingTypeModel MeetingTypeModel { get; set; }
    }
}