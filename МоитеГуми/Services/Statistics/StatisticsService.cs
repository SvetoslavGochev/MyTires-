namespace МоитеГуми.Services.Statistics
{
    using System.Linq;
    using МоитеГуми.Data;
    public class StatisticsService : IStatisticsService
    {
        public readonly ApplicationDbContext data;

        public StatisticsService(ApplicationDbContext data)
            => this.data = data;

        public StatisticsServiceModel Total()
        {
            var obqwiCount = this.data.Обяви.Count( o => o.IsPublic);
            var countUsers = this.data.Users.Count();

            return new StatisticsServiceModel
            {
                CountUsers = countUsers,
                CountAnnouncement = obqwiCount,

            };
        }
    }
}
