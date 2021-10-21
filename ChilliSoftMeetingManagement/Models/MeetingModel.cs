using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChilliSoftMeetingManagement.Models
{
    public class MeetingModel
    {
        public System.Guid MeetingId { get; set; }
        public System.Guid MeetingTypeId { get; set; }
        public System.DateTime MeetingDate { get; set; }
        public string MeetingName { get; set; }
        public virtual MeetingTypeModel MeetingType { get; set; }
        public virtual ICollection<MeetingItemModel> MeetingItems { get; set; }
    }
}