namespace Mooreameu.App.Controllers
{
    using Mooreameu.Data.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class UserController : BaseController
    {
        public UserController(IMooreameuData data)
            : base(data)
        {
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}