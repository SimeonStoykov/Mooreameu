﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooreameu.Model;

namespace Mooreameu.App.Areas.Admin.Models
{
    public class RewardViewModel
    {
        public int RewardId { get; set; }

        public decimal TotalPrize { get; set; }

        public RewardType Type { get; set; }
    }
}