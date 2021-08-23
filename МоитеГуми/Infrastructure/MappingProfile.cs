namespace МоитеГуми.Infrastructure
{
    using AutoMapper;
    using МоитеГуми.Data.Models;
    using МоитеГуми.Models.Обява;
    using МоитеГуми.Services.Obqwi;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Обява, ObqwaServicesModel>()
            .ForMember(c => c.CategoryName, cfg => cfg.MapFrom(c => c.Category.Name));

            this.CreateMap<Category, ObqwaCategoryServiceModel>();

            this.CreateMap<ObqwaDetailsServiceModel, ObqwaModel>();
            this.CreateMap<Обява, LatestObqwaServiseModel>();


            this.CreateMap<Обява, ObqwaDetailsServiceModel>()
                .ForMember(c => c.UserId, cfg => cfg.MapFrom(c => c.Dealer.UserId))
                .ForMember(c => c.CategoryName, cfg => cfg.MapFrom(c => c.Category.Name));
        }
    }
    
}
