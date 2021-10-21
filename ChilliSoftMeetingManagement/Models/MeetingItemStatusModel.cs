using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChilliSoftMeetingManagement.Models
{
    public class MeetingItemStatusModel
    {
        public Guid MeetingItemStatusId { get; set; }
        public string MeetingItemStatusName { get; set; }
        public virtual ICollection<MeetingItemModel> MeetingItems { get; set; }
    }
}