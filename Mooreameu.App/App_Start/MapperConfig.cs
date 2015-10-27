namespace Mooreameu.App.App_Start
{
    using AutoMapper;
    using Mooreameu.App.Models.ViewModels.Contests;
    using Mooreameu.App.Models.ViewModels.Picture;
    using Mooreameu.App.Models.ViewModels.User;
    using Mooreameu.Model;

    public class MapperConfig
    {
        public static void ConfigMappings()
        {
            Mapper.CreateMap<Picture, PictureViewModel>();
            Mapper.CreateMap<Contest, ContestFullVIewModel>();
            Mapper.CreateMap<Contest, ContestShortViewModel>();
            Mapper.CreateMap<User, UserShortViewModel>();
        }
    }
}