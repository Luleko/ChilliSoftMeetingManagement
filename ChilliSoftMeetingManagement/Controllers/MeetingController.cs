using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChilliSoftMeetingManagement.Service;
using ChilliSoftMeetingManagement.Models;

namespace ChilliSoftMeetingManagement.Controllers
{
    public class MeetingController : Controller
    {
        MeetingService svc = new MeetingService();

        // GET: Meeting
        public ActionResult Index()
        {
            try
            {
                Guid meetingType = Guid.Parse("cda9bd2c-dd50-4e9b-af2a-b0d44e11e2cf");
                Guid meetingId = Guid.Parse("9f17d769-ba61-4225-b1ab-e70e10cee52a");

                var result = svc.GetMeetingItems(meetingType, meetingId);

                ViewBag.Meetings = result;

                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Meeting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meeting/Create
        [HttpPost]
        public ActionResult Create(MeetingModel meetingModel)
        {
            try
            {
                // TODO: Add insert logic here
                var result = svc.AddMeeting(meetingModel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Meeting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Meeting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MeetingItemModel meetingItemModel)
        {
            try
            {
                // TODO: Add update logic here
                var result = svc.UpdateMeetingItemStatus(meetingItemModel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
