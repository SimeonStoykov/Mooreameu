using Mooreameu.App.Models.ViewModels.User;
using Mooreameu.Model;
namespace Mooreameu.App.Models.ViewModels.Picture
{
    public class PictureViewModel
    {
        public int PictureId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public UserShortViewModel Owner { get; set; }

        public PictureStatus Status { get; set; }

        public int Votes { get; set; }

        public int Likes { get; set; }

        public bool IsLast { get; set; }
    }
}