namespace МоитеГуми.Areas.Admim.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using МоитеГуми.Areas.Admin.Controllers;
    using static Admin.AdminConstants;

    [Area(AreaName)]
    public class ОбяваController : AdminController
    {
        public IActionResult Index => View();
    }
}
