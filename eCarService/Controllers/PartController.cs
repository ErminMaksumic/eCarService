using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator, ServiceRegistered")]

    public class PartController : BaseCRUDController<Model.Part, PartSearchObject, PartUpsertRequest,
        PartUpsertRequest>
    {
        public PartController(IPartService service) : base(service)
        {}
    }
}
