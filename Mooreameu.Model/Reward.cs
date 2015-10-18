using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooreameu.Model
{
    public class Reward
    {
        public Reward()
        {
            this.Winners = new HashSet<User>();
        }

        [Key]
        public int RewardId { get; set; }

        public decimal TotalPrize { get; set; }

        public RewardType Type { get; set; }

        public int ContestId { get; set; }

        [ForeignKey("ContestId")]
        public virtual Contest Contest { get; set; }

        public virtual ICollection<User> Winners { get; set; }
    }
}
