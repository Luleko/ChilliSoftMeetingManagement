using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChilliSoftMeetingManagement.Models
{
    public class MeetingTypeModel
    {
        public Guid MeetingTypeId { get; set; }
        public string MeetingTypeName { get; set; }
        public string MeetingTypeCode { get; set; }
        public virtual ICollection<MeetingModel> Meetings { get; set; }
        public virtual ICollection<MeetingTypeItemModel> MeetingTypeItems { get; set; }
    }
}