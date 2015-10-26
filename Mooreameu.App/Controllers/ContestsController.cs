using AutoMapper;
using Mooreameu.App.Models.ViewModels.Contests;
using Mooreameu.Data.UnitOfWork;
using Mooreameu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return View(contests);
        }

        public ActionResult ShowContest(int id)
        {
            var contest = this.Data.Contests.Find(id);

            if (contest == null)
            {
                return this.HttpNotFound();
            }

            var contestModel = Mapper.Map<Contest, ContestFullVIewModel>(contest);
            return View();
        }
    }
}