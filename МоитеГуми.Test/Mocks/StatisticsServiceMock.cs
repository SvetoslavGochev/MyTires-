namespace МоитеГуми.Test.Mocks
{
    using Moq;
    using МоитеГуми.Services.Statistics;


    public static class StatisticsServiceMock
    {
        public static IStatisticsService Instance
        {
            get
            {
                var statistisserviseMock = new Mock<IStatisticsService>();

                statistisserviseMock
                    .Setup(s => s.Total())
                    .Returns(new StatisticsServiceModel
                    {
                        CountAnnouncement = 5,
                        CountUsers = 15
                    });

                return statistisserviseMock.Object;
            }
        }
    }
}
