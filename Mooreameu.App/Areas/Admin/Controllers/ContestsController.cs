using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AutoMapper;
using Mooreameu.App.Areas.Admin.Models;
using Mooreameu.App.Extensions;
using Mooreameu.Data.UnitOfWork;
using Mooreameu.Model;

namespace Mooreameu.App.Areas.Admin.Controllers
{
    public class ContestsController : BaseAdminController
    {
        public ContestsController(IMooreameuData data) : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var contest = LoadContest(id);
            if (contest == null)
            {
                this.AddNotification("Cannot find contest", NotificationType.WARNING);
                return RedirectToAction("Index", "Admin");
            }
            return View(contest);
        }

        public ActionResult GetPictures(int id)
        {
            var contest = LoadContest(id);
            return this.PartialView("DisplayPictures",contest.Pictures);
        }

        public ActionResult ComitteeDetails(int id)
        {
            var contest = LoadContest(id);
            if (contest == null)
            {
                this.AddNotification("Wrong data", NotificationType.WARNING);
                return RedirectToAction("Index", "Admin");
            }
            this.ViewBag.contestId = id;
            return this.View(contest.Comittee);
        }

        public ActionResult RemoveFromComittee(int contestId, string userId)
        {
            var user = this.Data.Users.Find(userId);
            var contest = this.Data.Contests.Find(contestId);
            if (user != null && contest!=null)
            {
                contest.Comittee.Remove(user);
                this.Data.SaveChanges();
                this.AddNotification("Successfully removed comittee member "+ user.UserName,NotificationType.INFO);
            }
            this.AddNotification("Wrong data", NotificationType.WARNING);
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Edit()
        {
            return null;
        }

        public ActionResult Dismiss()
        {
            return null;
        }

        private ContestDetailsView LoadContest(int id)
        {
            var contest = this.Data.Contests.Find(id);
            var contestToShow = Mapper.Map<Contest, ContestDetailsView>(contest);
            return contestToShow;
        }
    }
}