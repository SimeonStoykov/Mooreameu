using AutoMapper;
using Mooreameu.App.Areas.User.Models;
using Mooreameu.App.Controllers;
using Mooreameu.Data.UnitOfWork;
using Mooreameu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Mooreameu.App.Areas.User.Controllers
{
    [Authorize]
    public class ContestsController : BaseController
    {
        public ContestsController(IMooreameuData data)
            :base(data)
        {
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateContest(ContestBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            //var user = this.Data.Users.Find(userId);

            var contest = Mapper.Map<ContestBindingModel, Contest>(model);

            contest.OwnerId = userId;
            contest.CreatedOn = DateTime.Now;

            var reward = new Reward()
            {
                TotalPrize = model.Price,
                Type = model.RewardStrategy
            };

            
            this.Data.Contests.Add(contest);
            reward.ContestId = contest.ContestId;
            contest.Reward = reward;
            this.Data.Rewards.Add(reward);
            this.Data.SaveChanges();

            return RedirectToAction("my", new {id = contest.ContestId });
        }

        public ActionResult My(int id)
        {
            var contest = this.Data.Contests.Find(id);

            var contestView = Mapper.Map<Contest, Mooreameu.App.Models.ViewModels.Contests.ContestFullVIewModel>(contest);
            return View("ShowContest", contestView);
        }
    }
}