namespace МоитеГуми.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using МоитеГуми.Models.Обява;
    using Microsoft.AspNetCore.Authorization;
    using МоитеГуми.Infrastructure;
    using МоитеГуми.Services.Obqwi;
    using МоитеГуми.Services.Dealers;
    using AutoMapper;

    using static WebConstatnts;

    public class ОбяваController : Controller
    {
        private readonly IDealerService dealers;
        private readonly IObqwiServices obqwi;
        private readonly IMapper mapper;

        public ОбяваController(
            IObqwiServices obqwi,
            IDealerService dealers,
            IMapper mapper
            )
        {
            this.obqwi = obqwi;
            this.dealers = dealers;
            this.mapper = mapper;
        }

        public IActionResult All([FromQuery] ObqwiSearchingModel query)
        {
            var queryResult = this.obqwi.All(
                query.Marka,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                ObqwiSearchingModel.ObqwiPerPage);


            var obqwiMarki = this.obqwi.AllMarki();

            query.CountObqwi = queryResult.CountObqwi;
            query.Marki = obqwiMarki;
            query.Obqwi = queryResult.Obqwa;

            return this.View(query);
        }

        [Authorize]
        public IActionResult Mine()
        {
            var myObqwi = this.obqwi.ByUser(this.User.Id());

            return View(myObqwi);
        }

        public IActionResult Details(int Id, string information)
        {
            var obqwa = this.obqwi.Details(Id);
            if (information != obqwa.GetInformation())
            {
                return BadRequest();
            }


            return View(obqwa);
        }

        [Authorize]
        public IActionResult Delete(int Id)
        {
            this.obqwi.DeleteAnoncment(Id);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Create()
        {
            if (!this.dealers.IsDealer(this.User.Id()))
            {
                return RedirectToAction(nameof(DealersController.Create), "Dealers");
            }
            //ot infrastrukture
            return View(new ObqwaModel
            {
                Categories = this.obqwi.AllCategories()//vieto shte ima info za kategoriite
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ObqwaModel obqva)
        {
            var dealerId = this.dealers.IdByUser(this.User.Id());

            if (dealerId == 0)
            {
                return RedirectToAction(nameof(DealersController.Create), "Dealers");
            }

            if (!this.obqwi.CategoryExist(obqva.CategoryId))
            {
                this.ModelState.AddModelError(nameof(obqva.CategoryId), "Category is dont exist");
            }

            if (!ModelState.IsValid)
            {
                //IF NOT VALID PAK ПОКАЗЖА ЖИУТО ДА СЕ ПОПАЛНИ
                obqva.Categories = this.obqwi.AllCategories();

                return View(obqva);
            }

            this.obqwi.Create(
                obqva.Marka,
                obqva.Description,
                obqva.Year,
                obqva.CategoryId,
                obqva.ImageUrl,
                obqva.Size,
                dealerId);

            TempData[GlobalMessageKey] = "Вашата обява е запазена";

            return RedirectToAction(nameof(All));// Always REDIREKT
        }

        [Authorize]
        public IActionResult Edit(int Id)
        {
            var userId = this.User.Id();

            if (!this.dealers.IsDealer(userId) && !User.IsAdmin())
            {
                return RedirectToAction(nameof(DealersController.Create), "Dealers");
            }

            var currentObqwa = this.obqwi.Details(Id);

            if (currentObqwa.UserId != userId && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var obqwaForm = this.mapper.Map<ObqwaModel>(currentObqwa);

            obqwaForm.Categories = this.obqwi.AllCategories();

            TempData[GlobalMessageKey] = "Вашата обява редактирана";

            return View(obqwaForm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int Id, ObqwaModel obqva)
        {
            var dealerId = this.dealers.IdByUser(this.User.Id());

            if (dealerId == 0 && !User.IsAdmin())
            {
                return RedirectToAction(nameof(DealersController.Create), "Dealers");
            }

            if (!this.obqwi.CategoryExist(obqva.CategoryId) && !User.IsAdmin())
            {
                this.ModelState.AddModelError(nameof(obqva.CategoryId), "Category is dont exist");
            }

            if (!ModelState.IsValid)
            {
                //IF NOT VALID PAK ПОКАЗЖА ЖИУТО ДА СЕ ПОПАЛНИ
                obqva.Categories = this.obqwi.AllCategories();

                return View(obqva);
            }
            if (!this.obqwi.IsByDealer(Id, dealerId) && !User.IsAdmin())
            {
                return BadRequest();
            }

            this.obqwi.Edit(
                    Id,
                    obqva.Marka,
                    obqva.Description,
                    obqva.Year,
                    obqva.CategoryId,
                    obqva.ImageUrl,
                    obqva.Size);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        //[HttpPost]
        public IActionResult Info(int Id)
        {
            var currentObqwa = this.obqwi.Info(Id);

            return View(currentObqwa);
        }



    }

}
