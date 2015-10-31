using Dropbox.Api;
using DropNet;
using Mooreameu.Data.UnitOfWork;
using Mooreameu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutoMapper;
using Mooreameu.App.Models.ViewModels.Picture;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Mooreameu.App.Controllers
{
    public class PictureController : BaseController
    {
        private const string APP_KEY = "tahzi47ogafubvr";
        private const string APP_SECRET = "olxe096x2qd7q5m";    

        public PictureController(IMooreameuData data)
            :base(data)
        {
        }

        public ActionResult View(int id)
        {
            var picture = this.Data.Pictures.Find(id);

            var pictureView = Mapper.Map<Picture, PictureViewModel>(picture);
            return View(pictureView);
        }

        [Authorize]
        public ActionResult Vote(int id)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);
            var picture = this.Data.Pictures.Find(id);
            user.ParticipatingInContests.Add(picture.Contest); 
            picture.Votes++;

            this.Data.SaveChanges();
            
            var pictureView = Mapper.Map<Picture, PictureViewModel>(picture);
            return View("View", pictureView);
        }
    }
}