namespace МоитеГуми.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using МоитеГуми.Models.Home;
    using МоитеГуми.Services.Obqwi;
    using МоитеГуми.Services.Statistics;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;
        public readonly IObqwiServices obqwi;

        public HomeController(
            IStatisticsService statistics,
            IObqwiServices obqwi)
        {
            this.statistics = statistics;
            this.obqwi = obqwi;
        }
        public IActionResult Index()
        {
            var latestObqwi = this.obqwi
                .Latest()
                .ToList();

            var TotalStatistics = this.statistics.Total();

            return this.View(new ObqwaViewModel
            {
                CountUsers = TotalStatistics.CountUsers,
                CountAnnouncement = TotalStatistics.CountAnnouncement,
                obqwi = latestObqwi
            }
            );

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View();
        }
    }
}
