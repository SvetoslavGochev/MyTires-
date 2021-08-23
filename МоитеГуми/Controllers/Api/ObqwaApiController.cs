namespace МоитеГуми.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using МоитеГуми.Models.Api;
    using МоитеГуми.Services.Obqwi;

    [ApiController]
    [Route("api/obqwa")]
    public class ObqwaApiController : ControllerBase
    {
        private readonly IObqwiServices obqwa;

        public ObqwaApiController(IObqwiServices obqwa)
        {
            this.obqwa = obqwa;
        }

        [HttpGet]
        public ObqwaQueryServicesModel All([FromQuery] AllObqwiApiRequestModel query)
        {
            return this.obqwa.All(
                query.Marka,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.ObqwiPerPage);
        }
    }
}
