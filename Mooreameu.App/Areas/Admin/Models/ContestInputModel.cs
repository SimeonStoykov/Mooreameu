using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooreameu.Model;

namespace Mooreameu.App.Areas.Admin.Models
{
    public class ContestInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ContestStatus Status { get; set; }

        public DeadlineStrategy DeadLine { get; set; }

        public VotingStrategy Voting { get; set; }

        public ParticipationStrategy Participation { get; set; }
    }
}