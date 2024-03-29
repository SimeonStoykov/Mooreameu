﻿using Mooreameu.App.Controllers;
using Mooreameu.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooreameu.App.Areas.User.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMooreameuData data)
            :base(data)
        {
        }
        // GET: User/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile(string id)
        {
            this.Data.Users.Find(id);

            return View();
        }
    }
}