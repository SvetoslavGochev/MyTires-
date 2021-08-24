namespace МоитеГуми.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using МоитеГуми.Models.Connection;
    using static МоитеГуми.Data.Models.DataConstatnt.Connection;
    public class ConnectionController : Controller
    {
        public IActionResult Index()
        {
            return View(new ConnectionViewModel { connection = ConnectionString });
        }
    }
}
