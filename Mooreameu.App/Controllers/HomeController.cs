using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooreameu.Data.UnitOfWork;

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
            return View(contests);
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