using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mooreameu.App.Areas.Admin.Models;
using Mooreameu.App.Extensions;
using Mooreameu.Data.UnitOfWork;
using Mooreameu.Model;

namespace Mooreameu.App.Areas.Admin.Controllers
{
    public class UsersController : BaseAdminController
    {
        public UsersController(IMooreameuData data) : base(data)
        {
        }

        public ActionResult UnBan(string id)
        {
            var user = this.Data.Users.Find(id);
            if (user != null)
            {
                user.Status = UserStatus.Ok;
                this.Data.SaveChanges();
                this.AddNotification("User is unbanned", NotificationType.INFO);
            }
            else
            {
                this.AddNotification("Action failed", NotificationType.WARNING);
            }
            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }

        public ActionResult Ban(string id)
        {
            var user = this.Data.Users.Find(id);
            if (user != null)
            {
                user.Status = UserStatus.Banned;
                this.Data.SaveChanges();
                this.AddNotification("User is banned", NotificationType.INFO);
            }
            else
            {
                this.AddNotification("Action failed", NotificationType.WARNING);
            }
            return RedirectToAction("Index", "Admin", new {area = "Admin"});
        }

        public ActionResult Delete(string id)
        {
            var user = this.Data.Users.Find(id);
            if (user != null)
            {
                user.Status = UserStatus.Deleted;
                this.Data.SaveChanges();
                this.AddNotification("User is deleted", NotificationType.INFO);
            }
            else
            {
                this.AddNotification("Action failed", NotificationType.WARNING);
            }
            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }
    }
}