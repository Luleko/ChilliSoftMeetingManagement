using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChilliSoftMeetingManagement.Models;

namespace ChilliSoftMeetingManagement.Service
{
    interface IMeeting
    {
        List<MeetingModel> GetMeetings();
        List<MeetingItemModel> GetMeetingItems(Guid meetingTypeId, Guid meetingId);
        List<MeetingTypeModel> GetMeetingTypes();
        List<MeetingTypeModel> GetMeetingTypesByMeetingId(Guid meetingId);
        List<MeetingItemStatusModel> GetMeetingItemStatuses();
        bool AddMeeting(MeetingModel addMeeting);
        bool UpdateMeetingItemStatus(MeetingItemModel updateMeetingItemStatus);
    }
}
