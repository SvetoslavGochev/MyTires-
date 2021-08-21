namespace МоитеГуми.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using МоитеГуми.Data;
    using МоитеГуми.Data.Models;
    using МоитеГуми.Infrastructure;
    using МоитеГуми.Models.Dealers;

    public class DealersController : Controller
    {
        private readonly ApplicationDbContext data;

        public DealersController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(BecomeDealerFormModel dealer)
        {
            var userId = this.User.Id();

            var useridIsDealer = this.data
                .Dealers
                .Any(d => d.UserId == userId);

            if (useridIsDealer)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(dealer);
            }

            var dealerData = new Dealer
            {
                Name = dealer.Name,
                PhoneNumber = dealer.PhoneNumber,
                UserId = userId
            };


            this.data.Dealers.Add(dealerData);
            this.data.SaveChanges();


            return RedirectToAction("All", "Обява");
        }


    }
}
