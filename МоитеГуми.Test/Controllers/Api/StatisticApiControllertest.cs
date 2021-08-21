namespace МоитеГуми.Test.Controllers.Api
{
    using Xunit;
    using МоитеГуми.Controllers.Api;
    using МоитеГуми.Test.Mocks;

    public class StatisticApiControllertest
    {
        [Fact]
        public void GetStatisticsShouldReturnTotalStatistics()
        {
            var statisticController = new StatisticApiController(StatisticsServiceMock.Instance);

            var result = statisticController.GetStatistics();

            Assert.NotNull(result);
            Assert.Equal(5, result.CountAnnouncement);
            Assert.Equal(15, result.CountUsers);
        }
    }
}
