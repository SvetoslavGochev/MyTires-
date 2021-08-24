namespace МоитеГуми.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using static МоитеГуми.Data.Models.DataConstatnt.Connection;
    using МоитеГуми.Models.Confidentiality;

    public class ConfidentialityController : Controller
    {
        public IActionResult Index()
        {
            return View(new ConfidentialityViewModel
            {
                confidentiality = Privacy
            });
        }
    }
}
