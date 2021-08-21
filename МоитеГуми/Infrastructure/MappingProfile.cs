namespace МоитеГуми.Infrastructure
{
    using AutoMapper;
    using МоитеГуми.Data.Models;
    using МоитеГуми.Models.Home;
    using МоитеГуми.Models.Обява;
    using МоитеГуми.Services.Obqwi;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ObqwaDetailsServiceModel, ObqwaModel>();
            this.CreateMap<Обява, ObqwaIndexViewModel>();


            this.CreateMap<Обява, ObqwaDetailsServiceModel>()
                .ForMember(c => c.UserId, cfg => cfg.MapFrom(c => c.Dealer.UserId));

          
        }
    }
    
}
