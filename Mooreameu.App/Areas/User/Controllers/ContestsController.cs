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
            return View(model);
        }
    }
}