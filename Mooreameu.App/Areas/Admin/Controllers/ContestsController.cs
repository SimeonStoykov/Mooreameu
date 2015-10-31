using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooreameu.Data.UnitOfWork;

namespace Mooreameu.App.Areas.Admin.Controllers
{
    public class ContestsController : BaseAdminController
    {
        public ContestsController(IMooreameuData data) : base(data)
        {
        }

        public ActionResult Edit()
        {
            return null;
        }

        public ActionResult Dismiss()
        {
            return null;
        }
    }
}