using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooreameu.Data.UnitOfWork;

namespace Mooreameu.App.Areas.Admin.Controllers
{
    public class UsersController : BaseAdminController
    {
        public UsersController(IMooreameuData data) : base(data)
        {
        }

        public ActionResult Edit()
        {
            return null;
        }

        public ActionResult Ban()
        {
            return null;
        }

        public ActionResult Delete()
        {
            return null;
        }
    }
}