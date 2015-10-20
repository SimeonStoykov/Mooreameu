using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooreameu.Model
{
    public class Contest
    {
        public Contest()
        {
            this.Pictures = new HashSet<Picture>();
            this.Participants = new HashSet<User>();
            this.Comittee = new HashSet<User>();
            this.Voters = new HashSet<User>();
        }

        [Key]
        public int ContestId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }

        public ContestStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public int RewardId { get; set; }

        [ForeignKey("RewardId")]
        public virtual Reward Reward { get; set; }

        public DeadlineStrategy DeadLine { get; set; }

        public VotingStrategy Voting { get; set; }

        public ParticipationStrategy Participation { get; set; }

        public virtual ICollection<User> Voters { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<User> Participants { get; set; }

        public virtual ICollection<User> Comittee { get; set; } 
    }
}
