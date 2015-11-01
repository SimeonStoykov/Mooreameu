using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class PicturesController : BaseAdminController
    {
        public PicturesController(IMooreameuData data)
            : base(data)
        {
        }

        public ActionResult Confirm(int id)
        {
            var picture = this.LoadPicture(id);
            if (picture == null)
            {
                this.AddNotification("Cannot find picture", NotificationType.WARNING);
                return RedirectToAction("GetContests", "Admin");
            }
            return this.PartialView("DisplayTemplates/PictureDeleteView", picture);
        }

        public ActionResult Delete(int id)
        {
            var picture = this.Data.Pictures.All().FirstOrDefault(p => p.PictureId==id);
            if (picture != null)
            {
                picture.Status = PictureStatus.Deleted;
                this.Data.SaveChanges();
                this.AddNotification("Successfully deleted picture", NotificationType.SUCCESS);
                return RedirectToAction("Details", "Contests", new {area = "Admin", id = picture.ContestId});
            }
            this.AddNotification("Cannot find picture", NotificationType.WARNING);
            return RedirectToAction("GetContests", "Admin");
        }

        public ActionResult Activate(int id)
        {
            var picture = this.Data.Pictures.All().FirstOrDefault(p => p.PictureId == id);
            if (picture != null)
            {
                picture.Status = PictureStatus.Ok;
                this.Data.SaveChanges();
                this.AddNotification("Successfully activated picture", NotificationType.SUCCESS);
                return RedirectToAction("Details", "Contests", new { area = "Admin", id = picture.ContestId });
            }
            this.AddNotification("Cannot find picture", NotificationType.WARNING);
            return RedirectToAction("GetContests", "Admin");
        }

        private PictureViewModel LoadPicture(int id)
        {
            var picture = this.Data.Pictures.Find(id);
            var pictureToShow = Mapper.Map<Picture, PictureViewModel>(picture);
            return pictureToShow;
        }
    }
}