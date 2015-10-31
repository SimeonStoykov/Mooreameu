using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooreameu.App.Controllers;
using Mooreameu.Data.UnitOfWork;
using Mooreameu.App.Areas.Admin.Models;
using Mooreameu.Model;

namespace Mooreameu.App.Areas.Admin.Controllers
{
    public class AdminController : BaseAdminController
    {
        public AdminController(IMooreameuData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var users = this.Data.Users.All()
                .Where(u =>u.Id != currentUserId)
                .OrderBy(u => u.UserName)
                .ThenBy(u => u.Status);
            var shortViewUsers = Mapper.Map<IEnumerable<Model.User>, IEnumerable<UserShortViewModel>>(users);
            return this.PartialView("GetUsers", shortViewUsers);
        }

        public ActionResult GetContests()
        {
            var contests = this.Data.Contests.All().OrderByDescending(c => c.CreatedOn);
            var shortConstestView = Mapper.Map<IEnumerable<Contest>, IEnumerable<ContestShortViewModel>>(contests);
            return this.PartialView("GetContests", shortConstestView);
        }
    }
}