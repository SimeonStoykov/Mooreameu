using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooreameu.Data.UnitOfWork;
using AutoMapper;
using Mooreameu.Model;
using Mooreameu.App.Models.ViewModels.Contests;

namespace Mooreameu.App.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IMooreameuData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var contests = this.Data.Contests.All()
                .OrderByDescending(c => c.CreatedOn)
                .Take(5);

            var contestModels = Mapper.Map<IEnumerable<Contest>, IEnumerable<ContestShortViewModel>>(contests);
            return View(contestModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Team Mooremeu.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacts";

            return View();
        }
    }
}