namespace МоитеГуми.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using МоитеГуми.Services.Statistics;

    [ApiController]
    [Route("api/statistic")]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticsService statistics;

        public StatisticApiController(IStatisticsService statistics)
         => this.statistics = statistics;

        [HttpGet]
        public StatisticsServiceModel GetStatistics()
            => this.statistics.Total();
    }
}
