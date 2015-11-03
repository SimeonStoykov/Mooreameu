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
            Mapper.CreateMap<Contest, Areas.Admin.Models.ContestShortViewModel>()
                .ForMember(c => c.Id, config => config.MapFrom(contest => contest.ContestId));
            Mapper.CreateMap<User, Areas.Admin.Models.UserShortViewModel>();
            Mapper.CreateMap<Contest, Areas.Admin.Models.ContestDetailsView>()
                .ForMember(c => c.Id, config => config.MapFrom(contest => contest.ContestId))
                .ForMember(c => c.Owner, config => config.MapFrom(contest => contest.Owner.UserName));
            Mapper.CreateMap<Picture, Areas.Admin.Models.PictureViewModel>()
                .ForMember(p => p.Id, config => config.MapFrom(picture => picture.PictureId))
                .ForMember(p => p.Owner, config => config.MapFrom(picture => picture.Owner.UserName));
            Mapper.CreateMap<Reward, Mooreameu.App.Areas.Admin.Models.RewardViewModel>()
                .ForMember(r => r.RewardId, config => config.MapFrom(reward => reward.RewardId))
                .ForMember(r => r.TotalPrize, config => config.MapFrom(reward => reward.TotalPrize))
                .ForMember(r => r.Type, config => config.MapFrom(reward => reward.Type));
        }
    }
}