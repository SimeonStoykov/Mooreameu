namespace Mooreameu.App.Models.ViewModels.Contests
{
    using Mooreameu.App.Models.ViewModels.Picture;
    using Mooreameu.App.Models.ViewModels.Reward;
    using Mooreameu.App.Models.ViewModels.User;
    using Mooreameu.Model;
    using System;
    using System.Collections.Generic;

    public class ContestFullVIewModel
    {
        public ContestFullVIewModel()
        {
            this.Pictures = new HashSet<PictureViewModel>();
        }

        public int ContestId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public UserShortViewModel Owner { get; set; }

        public ICollection<PictureViewModel> Pictures { get; set; }

        public ContestStatus Status { get; set; }

        public RewardViewModel Reward { get; set; }

        public DeadlineStrategy DeadLine { get; set; }

        public VotingStrategy Voting { get; set; }

        //TODO: Add participants and stuff
    }
}