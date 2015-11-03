using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mooreameu.App.Areas.Admin.Models;
using Mooreameu.App.Extensions;
using Mooreameu.Data.UnitOfWork;
using Mooreameu.Model;

namespace Mooreameu.App.Areas.Admin.Controllers
{
    public class RewardsController : BaseAdminController
    {
        public RewardsController(IMooreameuData data)
            : base(data)
        {
        }
        // GET: Admin/Rewards
        [HttpGet]
        public ActionResult Edit(int rewardId)
        {
            var reward = this.Data.Rewards.Find(rewardId);
            var rewardView = Mapper.Map<Reward, RewardViewModel>(reward);
            return View(rewardView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int rewardId, RewardViewModel model)
        {
            var reward = this.Data.Rewards.Find(rewardId);
            if (reward == null)
            {
                this.AddNotification("Cannot find reward", NotificationType.WARNING);
                return RedirectToAction("Index", "Admin");
            }
            
            if (this.ModelState.IsValid)
            {
                reward.TotalPrize = model.TotalPrize;
                reward.Type = model.Type;
                this.Data.SaveChanges();
                this.AddNotification("Edited reward", NotificationType.SUCCESS);
            }
            else
            {
                this.AddNotification("Cannot apply changes", NotificationType.WARNING);
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}