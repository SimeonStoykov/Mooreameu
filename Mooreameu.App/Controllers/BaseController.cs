using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Mooreameu.Data.UnitOfWork;
using Mooreameu.Model;

namespace Mooreameu.App.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IMooreameuData data)
        {
            this.Data = data;
        }

        public BaseController(IMooreameuData data, User user)
            : this(data)
        {
            this.UserProfile = user;
        }

        public IMooreameuData Data { get; private set; }

        public User UserProfile { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}