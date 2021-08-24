using Microsoft.AspNetCore.Mvc;

namespace МоитеГуми.Controllers
{

    public class ConnectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
