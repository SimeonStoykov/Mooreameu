using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Mooreameu.Model;

namespace Mooreameu.App.Areas.Admin.Models
{
    public class ContestDetailsView
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public ContestStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public Reward Reward { get; set; }

        public DeadlineStrategy DeadLine { get; set; }

        public VotingStrategy Voting { get; set; }

        public ParticipationStrategy Participation { get; set; }

        public virtual ICollection<PictureViewModel> Pictures { get; set; }

        public virtual ICollection<UserShortViewModel> Comittee { get; set; }
    }
}