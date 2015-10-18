using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooreameu.Model
{
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }

        public int ContestId { get; set; }

        [ForeignKey("ContestId")]
        public Contest Contest { get; set; }

        public DateTime SubmittedOn { get; set; }

        public PictureStatus Status { get; set; }

        public int Votes { get; set; }

        public int Likes { get; set; }
    }
}
