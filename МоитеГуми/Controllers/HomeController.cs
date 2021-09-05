namespace МоитеГуми.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using МоитеГуми.Models.Home;
    using МоитеГуми.Services.Obqwi;
    using МоитеГуми.Services.Statistics;
    using System.Linq;
    using Microsoft.Extensions.Caching.Memory;
    using System.Collections.Generic;
    using System;

    using static WebConstatnts.Cache;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;
        public readonly IObqwiServices obqwi;
        public readonly IMemoryCache cache;

        public IActionResult Ajax()
        {
            return View();
        }

        public IActionResult AjaxData()
        {
           return this.Json(new[] {
               new { Name = "ss", Date = DateTime.UtcNow.ToString("O")},
               new { Name = "ss3434", Date = DateTime.UtcNow.AddDays(1).ToString("O") },
            });
        }

        public HomeController(
            IStatisticsService statistics,
            IObqwiServices obqwi,
            IMemoryCache cache)
        {
            this.statistics = statistics;
            this.obqwi = obqwi;
            this.cache = cache;
        }
        public IActionResult Index()
        {
            var latestObqwi = this.cache.Get<List<LatestObqwaServiseModel>>(LatestObqwiCacheKey);

            this.TempData["SomeValue"] = 5;

            if (latestObqwi == null)
            {
                 latestObqwi = this.obqwi
                    .Latest()
                    .ToList();

                var casheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));


                this.cache.Set(LatestObqwiCacheKey, latestObqwi , casheOptions);
            }

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
