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

        public ActionResult GetReward(int id)
        {
            var reward = this.LoadContest(id).Reward;
            if (reward != null)
            {
                var rewardView = Mapper.Map<Reward, RewardViewModel>(reward);
                return this.PartialView("DisplayReward", rewardView);
            }
            this.AddNotification("No reward found", NotificationType.WARNING);
            return RedirectToAction("GetPictures", "Contests", new { id = id });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contest = this.LoadContest(id);
            return View(contest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContestInputModel model)
        {
            var contest = this.LoadContest(id);
            if (contest == null)
            {
                this.AddNotification("Cannot find contest", NotificationType.WARNING);
                return RedirectToAction("Index", "Admin");
            }

            if (model != null && this.ModelState.IsValid)
            {
                contest.DeadLine = model.DeadLine;
                contest.Title = model.Title;
                contest.Description = model.Description;
                contest.Participation = model.Participation;
                contest.Status = model.Status;
                contest.Voting = model.Voting;
                this.Data.SaveChanges();
                this.AddNotification("Successfully updated contest", NotificationType.INFO);
            }
            else
            {
                this.AddNotification("Wrong data", NotificationType.WARNING);
            }

            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Dismiss(int id)
        {
            var contest = this.Data.Contests.Find(id);
            if (contest != null)
            {
                contest.Status = ContestStatus.Dismissed;
                this.Data.SaveChanges();
                this.AddNotification("Successfully dismissed contest", NotificationType.SUCCESS);
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            this.AddNotification("Cannot find contest", NotificationType.WARNING);
            return RedirectToAction("Index", "Admin", new { area = "Admin"});
        }

        private ContestDetailsView LoadContest(int id)
        {
            var contest = this.Data.Contests.Find(id);
            var contestToShow = Mapper.Map<Contest, ContestDetailsView>(contest);
            return contestToShow;
        }
    }
}