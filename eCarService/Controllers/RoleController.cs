using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCarService.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]

    public class RoleController : BaseController<Model.Role, BaseSearchObject>
    {
        public RoleController(IBaseService<Model.Role, BaseSearchObject> service) : base(service)
        { }
    }
}
