namespace МоитеГуми.Test.Mocks
{
    using AutoMapper;
    using МоитеГуми.Infrastructure;

    public static class MapperMock
    {
        public static IMapper Instance
        {
            get
            {
                var mapperConfiguration = new MapperConfiguration(config =>
                {
                    config.AddProfile<MappingProfile>();
                });



                return new Mapper(mapperConfiguration);
            }
        }
    }
}
