using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooreameu.Model;

namespace Mooreameu.App.Areas.Admin.Models
{
    public class ContestShortViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public ContestStatus Status { get; set; }
    }
}