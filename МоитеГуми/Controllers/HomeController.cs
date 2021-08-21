namespace МоитеГуми.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;
    using МоитеГуми.Data;
    using МоитеГуми.Models;
    using МоитеГуми.Models.Home;
    using МоитеГуми.Services.Statistics;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;
        private readonly IMapper mapper;
        public readonly ApplicationDbContext data;

        public HomeController(
            IStatisticsService statistics,
            ApplicationDbContext data,
            IMapper mapper)
        {
            this.statistics = statistics;
            this.data = data;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var obqwi = this.data
              .Обяви
              .OrderByDescending(c => c.Id)
              .ProjectTo<ObqwaIndexViewModel>(this.mapper.ConfigurationProvider)
              .Take(3)
              .ToList();

            var TotalStatistics = this.statistics.Total();

            return this.View(new ObqwaViewModel
            {
                CountUsers = TotalStatistics.CountUsers,
                CountAnnouncement = TotalStatistics.CountAnnouncement,
                obqwi = obqwi
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
