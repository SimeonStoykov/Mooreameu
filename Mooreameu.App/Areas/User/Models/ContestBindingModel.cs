using Mooreameu.Model;
namespace Mooreameu.App.Areas.User.Models
{
    public class ContestBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public RewardType RewardStrategy { get; set; }

        public DeadlineStrategy Deadline{ get; set; }

        public VotingStrategy Voting { get; set; }

        public ParticipationStrategy Participation { get; set; }
    }
}