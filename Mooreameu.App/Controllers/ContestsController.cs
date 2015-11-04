using AutoMapper;
using Mooreameu.App.Models.ViewModels.Contests;
using Mooreameu.Data.UnitOfWork;
using Mooreameu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Mooreameu.App.Controllers
{
    public class ContestsController : BaseController
    {
       public ContestsController(IMooreameuData data)
            : base(data)
        {
        }

        public ActionResult All()
        {
            var contests = this.Data.Contests
                .All()
                .OrderByDescending(c => c.CreatedOn);

            var contestViews = Mapper.Map<IEnumerable<Contest>, IEnumerable<ContestShortViewModel>>(contests);
            return View(contestViews);
        }

        public ActionResult ShowContest(int id)
        {
            var contest = this.Data.Contests.Find(id);

            if (contest == null)
            {
                return this.HttpNotFound();
            }

            var user = this.Data.Users.Find(this.User.Identity.GetUserId());

            this.ViewBag.IsParticipating = user.ParticipatingInContests.Any(c => c == contest);

            var contestModel = Mapper.Map<Contest, ContestFullVIewModel>(contest);
            return View(contestModel);
        }

        public ActionResult Participate(int id)
        {
            var contest = this.Data.Contests.Find(id);

            if (contest == null)
            {
                return this.HttpNotFound();
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            user.ParticipatingInContests.Add(contest);

            this.Data.SaveChanges();

            return RedirectToAction("ShowContest", new {id = id });
        }
    }
}