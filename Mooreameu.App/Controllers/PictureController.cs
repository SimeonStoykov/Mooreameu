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

        public ActionResult Upload()
        {
            var user = this.Data.Users.Find(this.User.Identity.GetUserId());
            using (var client = this.GetClient(user))
            {
                return null;
            }
        }

        public ActionResult View(int id)
        {
            var picture = this.Data.Pictures.Find(id);

            var pictureView = Mapper.Map<Picture, PictureViewModel>(picture);
            return View(pictureView);
        }

        
        private DropboxClient GetClient(User user)
        {
            var client = new DropboxClient("Evnnh0pkhFAAAAAAAAAABjAWpr4XhVxoajYngqEK2kwZ-KOGq2lFtZtt8oxXuj02",
                userAgent: "Mooreameu");

            return client;
        }


    }
}