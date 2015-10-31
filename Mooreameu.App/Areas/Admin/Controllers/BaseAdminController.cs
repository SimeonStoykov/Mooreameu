using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooreameu.App.Controllers;
using Mooreameu.Data.UnitOfWork;

namespace Mooreameu.App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BaseAdminController : BaseController
    {
        public BaseAdminController(IMooreameuData data)
            : base(data)
        {
        }
    }
}