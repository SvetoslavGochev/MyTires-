namespace МоитеГуми.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using МоитеГуми.Services.Obqwi;

    public class ОбяваController : AdminController
    {
        private readonly IObqwiServices obqwa;

        public ОбяваController(IObqwiServices obqwa)
        {
            this.obqwa = obqwa;
        }

        public IActionResult All()
        {
            var obqvi = this.obqwa.All(publicOnly: false).Obqwa;

            return View(obqvi);
        }

        public IActionResult ChangeVisibility(int Id)
        {
            this.obqwa.ChangeVisibility(Id);

            return RedirectToAction(nameof(All));
        }
    }
}
