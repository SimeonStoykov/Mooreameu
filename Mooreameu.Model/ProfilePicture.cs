using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooreameu.Model
{
    public class ProfilePicture
    {
        [Key]
        public int ProfilePictureId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Path { get; set; }

        public bool Active { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
    }
}
