namespace МоитеГуми.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(AdminConstants.AreaName)]
    [Authorize(Roles = AdminConstants.AdministratorRoleName)]
    public abstract class AdminController : Controller
    {
    }
}
