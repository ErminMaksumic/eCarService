using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : BaseCRUDController<Model.Part, PartSearchObject, PartUpsertRequest,
        PartUpsertRequest>
    {
        public PartController(IPartService service) : base(service)
        {}
    }
}
