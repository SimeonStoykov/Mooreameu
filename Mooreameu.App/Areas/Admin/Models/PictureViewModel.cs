using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooreameu.Model;

namespace Mooreameu.App.Areas.Admin.Models
{
    public class PictureViewModel
    {
        public string Id { get; set; }

        public int ContestId { get; set; }

        public string Owner { get; set; }

        public string Path { get; set; }

        public PictureStatus Status { get; set; }
    }
}