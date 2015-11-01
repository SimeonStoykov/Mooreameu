using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mooreameu.App.Areas.Admin.Models;
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
            return View(contest);
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