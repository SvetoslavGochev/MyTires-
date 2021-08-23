namespace МоитеГуми.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ОбяваController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
