using Mooreameu.App.Models.ViewModels.User;
using Mooreameu.Model;
using System.Collections.Generic;
namespace Mooreameu.App.Models.ViewModels.Reward
{
    public class RewardViewModel
    {
        public RewardViewModel()
        {
            this.Winners = new HashSet<UserShortViewModel>();
        }

        public decimal totalPrice { get; set; }

        public RewardType Type { get; set; }

        //TODO: Add contest

        public ICollection<UserShortViewModel> Winners { get; set; }
    }
}