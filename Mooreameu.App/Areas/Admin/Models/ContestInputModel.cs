using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Mooreameu.Model;
using WebGrease;

namespace Mooreameu.App.Areas.Admin.Models
{
    public class ContestInputModel
    {
        [Required]
        [MinLength(1), MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(1), MaxLength(200)]
        public string Description { get; set; }

        public ContestStatus Status { get; set; }

        public DeadlineStrategy DeadLine { get; set; }

        public VotingStrategy Voting { get; set; }

        public ParticipationStrategy Participation { get; set; }
    }
}