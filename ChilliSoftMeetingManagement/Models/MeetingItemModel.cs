using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChilliSoftMeetingManagement.Models
{
    public class MeetingItemModel
    {
        public Guid MeetingItemId { get; set; }
        public string MeetingItemName { get; set; }
        public Guid MeetingItemStatusId { get; set; }
        public string PersonAssigned { get; set; }
        public string Comment { get; set; }

        public virtual MeetingItemStatusModel MeetingItemStatusModel { get; set; }
        public virtual ICollection<MeetingTypeItemModel> MeetingTypeItems { get; set; }
    }
}