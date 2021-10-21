using ChilliSoftMeetingManagement.Models;
using ChilliSoftMeetingManagement.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF = ChilliSoftMeetingManagement.Repository.EF;

namespace ChilliSoftMeetingManagement.Service
{
    public class MeetingService : IMeeting
    {
        Repository.EF.Entities db = new Repository.EF.Entities();
        public bool AddMeeting(MeetingModel addMeeting)
        {
            Meeting dbmodel = new Meeting();

            dbmodel.MeetingId = Guid.NewGuid();
            dbmodel.MeetingTypeId = addMeeting.MeetingTypeId;
            dbmodel.MeetingDate = addMeeting.MeetingDate;
            dbmodel.MeetingName = addMeeting.MeetingName;

            db.Meetings.Add(dbmodel);
            db.SaveChanges();

            foreach (var item in addMeeting.MeetingItems)
            {
                MeetingItem meetingItem = new MeetingItem();
                meetingItem.MeetingItemId = Guid.NewGuid();
                meetingItem.MeetingItemName = item.MeetingItemName;
                meetingItem.MeetingItemStatusId = item.MeetingItemStatusId;
                meetingItem.PersonAssigned = item.PersonAssigned;
                meetingItem.Comment = item.Comment;

                db.MeetingItems.Add(meetingItem);
                db.SaveChanges();
            }

            return true;
        }
        public List<MeetingItemModel> GetMeetingItems(Guid meetingTypeId, Guid meetingId)
        {
            List<MeetingItemModel> meetingItems = new List<MeetingItemModel>();

            Guid meetingItemId = db.MeetingTypeItems.AsNoTracking().Where(c => c.MeetingTypeId == meetingTypeId && c.MeetingId == meetingId).FirstOrDefault().MeetingItemId;

            var query = (from c in db.MeetingItems.Where(it => it.MeetingItemId == meetingItemId)
                         select new MeetingItemModel
                         {
                             MeetingItemId = c.MeetingItemId,
                             MeetingItemName = c.MeetingItemName,
                             MeetingItemStatusModel = db.MeetingItemStatus.Where(j => j.MeetingItemStatusId == c.MeetingItemStatusId).Select(s => new MeetingItemStatusModel()
                             {
                                 MeetingItemStatusId = s.MeetingItemStatusId,
                                 MeetingItemStatusName = s.MeetingItemStatusName
                             }
                          ).FirstOrDefault(),
                             PersonAssigned = c.PersonAssigned,
                             Comment = c.Comment
                         }).ToList();

            return meetingItems;
        }
        public List<MeetingItemStatusModel> GetMeetingItemStatuses()
        {
            List<Models.MeetingItemStatusModel> statuses = new List<Models.MeetingItemStatusModel>();

            var query = (from c in db.MeetingItemStatus
                         select new Models.MeetingItemStatusModel
                         {
                             MeetingItemStatusId = c.MeetingItemStatusId,
                             MeetingItemStatusName = c.MeetingItemStatusName
                         }
                         ).ToList();

            return statuses = query;
        }
        public List<MeetingModel> GetMeetings()
        {
            List<Models.MeetingModel> meeetings = new List<Models.MeetingModel>();

            var query = (from c in db.Meetings
                         select new Models.MeetingModel
                         {
                             MeetingId = c.MeetingId,
                             MeetingTypeId = c.MeetingTypeId,
                             MeetingDate = c.MeetingDate,
                             MeetingName = c.MeetingName,
                         }
                         ).ToList();

            return meeetings = query;
        }

        public List<MeetingTypeModel> GetMeetingTypes()
        {
            List<Models.MeetingTypeModel> meetingTypes = new List<Models.MeetingTypeModel>();

            var query = (from c in db.MeetingTypes
                         select new Models.MeetingTypeModel
                         {
                             MeetingTypeId = c.MeetingTypeId,
                             MeetingTypeName = c.MeetingTypeName,
                             MeetingTypeCode = c.MeetingTypeCode
                         }
                         ).ToList();

            return meetingTypes = query;
        }
        public List<MeetingTypeModel> GetMeetingTypesByMeetingId(Guid meetingId)
        {
            List<Models.MeetingTypeModel> meetingTypes = new List<Models.MeetingTypeModel>();
            Guid meetingTypeId = db.MeetingTypeItems.AsNoTracking().Where(c => c.MeetingId == meetingId).FirstOrDefault().MeetingTypeId;

            var query = (from c in db.MeetingTypes.Where(id => id.MeetingTypeId == meetingTypeId)
                         select new Models.MeetingTypeModel
                         {
                             MeetingTypeId = c.MeetingTypeId,
                             MeetingTypeName = c.MeetingTypeName,
                             MeetingTypeCode = c.MeetingTypeCode
                         }
                          ).ToList();

            return meetingTypes = query;
        }

        public bool UpdateMeetingItemStatus(MeetingItemModel updateMeetingItemStatus)
        {
            var meetingItem = db.MeetingItems.SingleOrDefault(x => x.MeetingItemId == updateMeetingItemStatus.MeetingItemId);

            meetingItem.MeetingItemStatusId = updateMeetingItemStatus.MeetingItemStatusId;
            db.SaveChanges();
            return true;
        }
    }
}